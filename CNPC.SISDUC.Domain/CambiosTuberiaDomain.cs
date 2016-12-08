using CNPC.SISDUC.Domain.Contracts;
using System;
using System.Collections.Generic;
using CNPC.SISDUC.Model;
using CNPC.SISDUC.Model.Servicio;
using CNPC.SISDUC.Repository.Contracts;
using CNPC.SISDUC.Domain.Exceptions;
using System.Transactions;
using log4net;

namespace CNPC.SISDUC.Domain
{
    public class CambiosTuberiaDomain : ICambiosTuberiaDomain
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(CambiosTuberiaDomain));
        public bool Actualizar(CambiosTuberia item)
        {
            bool Result = false;
            using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
            {
                using (ICambiosTuberiaRepositorio Repositorio = Factory<ICambiosTuberiaRepositorio>.GetInstancia())
                {
                    Result = Repositorio.Actualizar(item);
                }
                tx.Complete();
            }
            return Result;
        }
        public CambiosTuberia Agregar(CambiosTuberia item)
        {
            CambiosTuberia Result = new CambiosTuberia();
            using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
            {
                using (ICambiosTuberiaRepositorio Repositorio = Factory<ICambiosTuberiaRepositorio>.GetInstancia())
                {
                    Result = Repositorio.Agregar(item);
                    if (Result == null)
                        throw new CambiosTuberiaNoSeGuardoException();
                    tx.Complete();
                }
            }
            return Result;
        }
        public CambiosTuberia BuscarById(int id)
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
                using (ICambiosTuberiaRepositorio Repositorio = Factory<ICambiosTuberiaRepositorio>.GetInstancia())
                {
                    Result = Repositorio.Eliminar(id);
                }
                tx.Complete();
            }
            return Result;
        }
        public CambiosTuberiaResponse GetListCambiosTuberia(string NumeroOleoducto, int TuberiaID, int page, int records)
        {
            CambiosTuberiaResponse Result = new CambiosTuberiaResponse();
            using (ICambiosTuberiaRepositorio Repositorio = Factory<ICambiosTuberiaRepositorio>.GetInstancia())
            {
                Result = Repositorio.usp_GetListCambiosTuberia(NumeroOleoducto, TuberiaID, records, page);
                if (Result.List == null)
                {
                    throw new CambiosTuberiaInexistenteException();
                }
            }
            return Result;
        }
        public IEnumerable<CambiosTuberia> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
