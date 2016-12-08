using CNPC.SISDUC.Domain.Contracts;
using CNPC.SISDUC.Domain.Exceptions;
using CNPC.SISDUC.Model;
using CNPC.SISDUC.Model.Servicio;
using CNPC.SISDUC.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace CNPC.SISDUC.Domain
{
    public class AccesorioDomain : IAccesorioDomain
    {
        public bool Actualizar(Accesorio item)
        {
            bool Result = false;
            using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
            {
                using (IAccesorioRepositorio accesorioRepositorio = Factory<IAccesorioRepositorio>.GetInstancia())
                {
                    var codigoExistente = accesorioRepositorio.BuscarPorCodigo(item.CodigoAccesorio);
                    if (codigoExistente != null)
                    {
                        throw new AccesorioInexistenteException();
                    }
                    Result = accesorioRepositorio.Actualizar(item);
                }
                tx.Complete();
            }
            return Result;
        }

        public Accesorio Agregar(Accesorio item)
        {
            Accesorio Result = new Accesorio();
            using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
            {
                using (IAccesorioRepositorio accesorioRepositorio = Factory<IAccesorioRepositorio>.GetInstancia())
                {
                    var codigoExistente = accesorioRepositorio.BuscarPorCodigo(item.CondicionAccesorio);
                    if (codigoExistente != null)
                    {
                        throw new CodigoAccesorioExistenteException();
                    }
                    Result = accesorioRepositorio.Agregar(item);
                    if (Result == null)
                        throw new AccesorioNoSeGuardoException();
                }
                tx.Complete();
            }
            return Result;
        }

        public Accesorio BuscarById(int id)
        {
            Accesorio Result = null;
            using (IAccesorioRepositorio accesorioRepositorio = Factory<IAccesorioRepositorio>.GetInstancia())
            {
                Result = accesorioRepositorio.BuscarPorId(id);
                if (Result == null)
                {
                    throw new AccesorioInexistenteException();
                }
            }
            return Result;
        }

        public Accesorio BuscarPorCodigo(string codigo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Accesorio> BuscarPorNombre(string Nombre)
        {
            IEnumerable<Accesorio> accesorios = null;
            using (IAccesorioRepositorio accesorioRepositorio = Factory<IAccesorioRepositorio>.GetInstancia())
            {
                accesorios = accesorioRepositorio.BuscarPorNombre(Nombre);
                if (accesorios == null)
                {
                    throw new AccesorioInexistenteException();
                }
            }
            return accesorios;
        }

        public IEnumerable<Accesorio> BuscarPorOleoducto(int anio, int OleoductoId, string Nombre, int Page, int Records)
        {
            IEnumerable<Accesorio> accesorios = null;
            using (IAccesorioRepositorio accesorioRepositorio = Factory<IAccesorioRepositorio>.GetInstancia())
            {
                accesorios = accesorioRepositorio.BuscarPorOleoducto(anio, OleoductoId, Nombre, Page, Records);
                if (accesorios == null)
                {
                    throw new AccesorioInexistenteException();
                }
            }
            return accesorios;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public bool Eliminar(int id)
        {
            bool Result = false;
            using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
            {
                using (IAccesorioRepositorio accesorioRepositorio = Factory<IAccesorioRepositorio>.GetInstancia())
                {
                    Accesorio accesorioExistente = accesorioRepositorio.BuscarPorId(id);
                    if (accesorioExistente == null)
                    {
                        throw new AccesorioInexistenteException();
                    }
                    //Validar otras condiciones antes de dar de baja el registro
                    accesorioRepositorio.Eliminar(id);
                }
                tx.Complete();
            }
            return Result;
        }

        public AccesorioResponse FilterByTuberiaAccesorios(string TuberiaCodigo, string Nombre)
        {

            AccesorioResponse accesorios = new AccesorioResponse();
            using (IAccesorioRepositorio accesorioRepositorio = Factory<IAccesorioRepositorio>.GetInstancia())
            {
                accesorios.List = accesorioRepositorio.BuscarPorTuberia(TuberiaCodigo, Nombre).ToList();
                if (accesorios == null)
                {
                    throw new AccesorioInexistenteException();
                }

            }
            return accesorios;
        }

        public IEnumerable<Accesorio> Listar()
        {
            throw new NotImplementedException();
        }

    }
}
