using System;
using System.Collections.Generic;
using CNPC.SISDUC.Domain.Contracts;
using CNPC.SISDUC.Model;
using CNPC.SISDUC.Model.Servicio;
using CNPC.SISDUC.Repository.Contracts;

namespace CNPC.SISDUC.Domain
{
    public class TipoSoporteDomain : ITipoSoporteDomain
    {
        public bool Actualizar(Oleoducto item)
        {
            throw new NotImplementedException();
        }

        public Oleoducto Agregar(Oleoducto item)
        {
            throw new NotImplementedException();
        }

        public Oleoducto BuscarById(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public TipoSoporteResponse GetListTipoSoporte()
        {
            TipoSoporteResponse Result = new TipoSoporteResponse();
            using (ITipoSoporteRepositorio Repositorio = Factory<ITipoSoporteRepositorio>.GetInstancia())
            {
                Result = Repositorio.usp_GetListTipoSoporte();
            }
            return Result;
        }

        public IEnumerable<Oleoducto> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
