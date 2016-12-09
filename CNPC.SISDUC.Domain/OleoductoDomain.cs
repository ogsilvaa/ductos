using System;
using System.Collections.Generic;
using System.Linq;
using log4net;
using CNPC.SISDUC.Model;
using System.Transactions;
using CNPC.SISDUC.Domain.Contracts;
using CNPC.SISDUC.Repository.Contracts;
using CNPC.SISDUC.Model.Servicio;
using CNPC.SISDUC.Domain.Exceptions;

namespace CNPC.SISDUC.Domain
{
    public class OleoductoDomain : IOleoductoDomain
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(OleoductoDomain));

        public List<Inventario> ObtenerInventario()
        {
            IEnumerable<Inventario> inventarios;
            using (var oleoductoRepositorio = Factory<IOleoductoRepositorio>.GetInstancia())
            {
                inventarios = oleoductoRepositorio.ObtenerInventario();
                if (inventarios == null)
                {
                    throw new OleoductosInexistenteException();
                }
            }
            return inventarios.ToList();
        }

        public Oleoducto Agregar(Oleoducto newDucto)
        {
            Oleoducto Result = null;
            using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
            {
                using (IOleoductoRepositorio oleoductoRepositorio = Factory<IOleoductoRepositorio>.GetInstancia())
                {
                    var codigoExistente = oleoductoRepositorio.BuscarByNombre(newDucto.Codigo);
                    if (codigoExistente != null)
                    {
                        throw new CodigoOleoductoExistenteException();
                    }
                    Result = oleoductoRepositorio.Agregar(newDucto);
                    if (Result == null)
                        throw new OleoductoNoSeGuardoException();
                }
                tx.Complete();
            }
            return Result;
        }
        public Oleoducto RetrieveByID(int ID)
        {
            Oleoducto Result = null;

            using (IOleoductoRepositorio oleoductoRepositorio = Factory<IOleoductoRepositorio>.GetInstancia())
            {
                Result = oleoductoRepositorio.BuscarPorId(ID);
                if (Result == null)
                {
                    throw new OleoductoInexistenteException();
                }
            }
            return Result;
        }
        public bool Actualizar(Oleoducto ductoToUpdate)
        {
            bool Result = false;
            using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
            {
                using (IOleoductoRepositorio oleoductoRepositorio = Factory<IOleoductoRepositorio>.GetInstancia())
                {
                    var codigoExistente = oleoductoRepositorio.BuscarPorId(ductoToUpdate.Id);
                    if (codigoExistente != null)
                    {
                        throw new OleoductoInexistenteException();
                    }
                    oleoductoRepositorio.Actualizar(ductoToUpdate);
                    Result = true;
                }
                tx.Complete();
            }
            return Result;
        }
        public bool Eliminar(int ID)
        {
            bool Result = false;
            using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
            {
                using (IOleoductoRepositorio oleoductoRepositorio = Factory<IOleoductoRepositorio>.GetInstancia())
                {
                    Oleoducto oleoductoExistente = oleoductoRepositorio.BuscarPorId(ID);
                    if (oleoductoExistente == null)
                    {
                        throw new OleoductoInexistenteException();
                    }
                    //Validar otras condiciones antes de dar de baja el registro
                    oleoductoRepositorio.Eliminar(ID);
                    Result = true;
                }
                tx.Complete();
            }
            return Result;
        }
        public List<Oleoducto> FilterByName(string Nombre)
        {
            IEnumerable<Oleoducto> oleoductos = null;
            using (IOleoductoRepositorio oleoductoRepositorio = Factory<IOleoductoRepositorio>.GetInstancia())
            {
                oleoductos = oleoductoRepositorio.BuscarByNombre(Nombre);
                if (oleoductos == null)
                {
                    throw new OleoductosInexistenteException();
                }
            }
            return oleoductos.ToList();
        }
        public OleoductoResponse FilterByName(string prefijo, string Nombre, int page, int records)
        {
            OleoductoResponse oleoductos = null;
            using (IOleoductoRepositorio oleoductoRepositorio = Factory<IOleoductoRepositorio>.GetInstancia())
            {
                oleoductos = oleoductoRepositorio.FilterByName(prefijo, Nombre, page, records);
                if (oleoductos == null)
                {
                    throw new OleoductoInexistenteException();
                }
            }
            return oleoductos;
        }
        public List<Oleoducto> GetListOleoductosByNombre(string prefijo, string Nombre)
        {
            List<Oleoducto> Result;
            using (IOleoductoRepositorio oleoductoRepositorio = Factory<IOleoductoRepositorio>.GetInstancia())
            {
                Result = oleoductoRepositorio.GetListOleoductosByNombre(prefijo, Nombre);
                if (Result == null)
                {
                    throw new OleoductosInexistenteException();
                }
            }
            return Result;
        }
        public Oleoducto FilterByID(int ID)
        {
            Oleoducto Result = null;
            using (IOleoductoRepositorio oleoductoRepositorio = Factory<IOleoductoRepositorio>.GetInstancia())
            {
                Result = oleoductoRepositorio.BuscarPorId(ID);
            }
            return Result;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public IEnumerable<Oleoducto> BuscarByNombre(string Nombre)
        {
            throw new NotImplementedException();
        }
        public decimal LongitudOleoducto(int Id)
        {
            throw new NotImplementedException();
        }
        public Oleoducto BuscarById(int id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Oleoducto> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
