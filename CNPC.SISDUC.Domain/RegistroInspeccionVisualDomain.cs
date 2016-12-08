using System;
using System.Collections.Generic;
using CNPC.SISDUC.Domain.Contracts;
using CNPC.SISDUC.Model;
using System.Transactions;
using CNPC.SISDUC.Repository.Contracts;
using CNPC.SISDUC.Domain.Exceptions;
using CNPC.SISDUC.Model.Servicio;
using System.Linq;

namespace CNPC.SISDUC.Domain
{
    public class RegistroInspeccionVisualDomain : IRegistroDeInspeccionVisualDomain
    {
        public bool Actualizar(RegistroInspeccionVisual item)
        {
            bool Result = false;
            using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
            {
                using (IRegistroInspeccionVisualRepositorio Repositorio = Factory<IRegistroInspeccionVisualRepositorio>.GetInstancia())
                {
                    var codigoExistente = Repositorio.BuscarPorCodigo(DateTime.Now.Year, item.CodigoDelTubo);
                    if (codigoExistente == null)
                    {
                        throw new RegistroInspeccionVisualInexistenteException();
                    }
                    Result = Repositorio.Actualizar(item);
                    tx.Complete();
                }
            }
            return Result;
        }

        public RegistroInspeccionVisual Agregar(RegistroInspeccionVisual item)
        {
            RegistroInspeccionVisual Result = null;
            using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
            {
                using (IRegistroInspeccionVisualRepositorio Repositorio = Factory<IRegistroInspeccionVisualRepositorio>.GetInstancia())
                {
                    var codigoExistente = Repositorio.BuscarPorCodigo(DateTime.Now.Year, item.CodigoDelTubo);
                    if (codigoExistente != null)
                    {
                        throw new CodigoRegistroInspeccionVisualExistenteException();
                    }
                    Result = Repositorio.Agregar(item);
                    tx.Complete();
                }
            }
            return Result;
        }

        public RegistroInspeccionVisual Agregar(RegistroInspeccionVisual item, int anio = 2016)
        {
            RegistroInspeccionVisual Result = null;
            using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
            {
                using (IRegistroInspeccionVisualRepositorio Repositorio = Factory<IRegistroInspeccionVisualRepositorio>.GetInstancia())
                {
                    var codigoExistente = Repositorio.BuscarPorCodigo(anio, item.CodigoDelTubo);
                    if (codigoExistente != null)
                    {
                        throw new CodigoRegistroInspeccionVisualExistenteException();
                    }
                    Result = Repositorio.Agregar(item);
                    if (Result == null)
                        throw new RegistroInspeccionVisualNoSeGuardoException();
                    tx.Complete();
                }
            }
            return Result;
        }

        public RegistroInspeccionVisual BuscarById(int id)
        {
            RegistroInspeccionVisual Result = new RegistroInspeccionVisual();
            using (IRegistroInspeccionVisualRepositorio Repositorio = Factory<IRegistroInspeccionVisualRepositorio>.GetInstancia())
            {
                Result = Repositorio.BuscarPorId(id);
                if (Result == null)
                    throw new CodigoRegistroInspeccionVisualExistenteException();
            }
            return Result;
        }

        public RegistroInspeccionVisual BuscarPorCodigo(int AnioInspeccion, string codigo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RegistroInspeccionVisual> BuscarPorNombre(int AnioInspeccion, int DuctoId, string Nombre)
        {
            throw new NotImplementedException();
        }
        public List<RegistroInspeccionVisual> GetListRegistroInspeccionVisualByNombre(int anio, int DuctoId, string Nombre)
        {
            List<RegistroInspeccionVisual> Result = new List<RegistroInspeccionVisual>();
            using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
            {
                using (IRegistroInspeccionVisualRepositorio Repositorio = Factory<IRegistroInspeccionVisualRepositorio>.GetInstancia())
                {
                    Result = Repositorio.GetListRegistroInspeccionVisualByNombre(anio, DuctoId, Nombre).ToList();
                    if (Result == null)
                        throw new CodigoRegistroInspeccionVisualExistenteException();
                    tx.Complete();
                }
            }
            return Result;
        }
        public List<RegistroInspeccionVisual> RegistroInspeccionVisualListarEliminados(int anio, int ductoId)
        {
            List<RegistroInspeccionVisual> Result = new List<RegistroInspeccionVisual>();
            using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
            {
                using (IRegistroInspeccionVisualRepositorio Repositorio = Factory<IRegistroInspeccionVisualRepositorio>.GetInstancia())
                {
                    Result = Repositorio.RegistroInspeccionVisualListarEliminados(anio, ductoId).ToList();
                    if (Result == null)
                        throw new CodigoRegistroInspeccionVisualExistenteException();
                    tx.Complete();
                }
            }
            return Result;
        }

        public IEnumerable<RegistroInspeccionVisual> BuscarPorNombre(int AnioInspeccion, int DuctoId, string Nombre, int Page, int Records)
        {
            throw new NotImplementedException();
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
                using (IRegistroInspeccionVisualRepositorio Repositorio = Factory<IRegistroInspeccionVisualRepositorio>.GetInstancia())
                {
                    var codigoExistente = Repositorio.BuscarPorId(id);
                    if (codigoExistente == null)
                    {
                        throw new RegistroInspeccionVisualInexistenteException();
                    }
                    Result = Repositorio.Eliminar(id);
                    tx.Complete();
                }
            }
            return Result;
        }

        public IEnumerable<RegistroInspeccionVisual> Listar()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RegistroInspeccionVisual> Listar(int AnioInspeccion, int DuctoId)
        {
            throw new NotImplementedException();
        }

        public RegistroInspeccionVisual RetrieveByID(int ID)
        {
            throw new NotImplementedException();
        }

        public int TotalBuscarPorNombre(int AnioInspeccion, int DuctoId, string Nombre)
        {
            throw new NotImplementedException();
        }
    }
}
