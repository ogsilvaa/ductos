using System;
using System.Collections.Generic;
using CNPC.SISDUC.Model.Servicio;
using CNPC.SISDUC.Repository.Contracts;
using CNPC.SISDUC.DAL.Helper;
using System.Data;

namespace CNPC.SISDUC.Repository.SqlServer
{
    public class TipoSoporteRepositorio : ITipoSoporteRepositorio
    {
        public bool Actualizar(TipoSoporte item)
        {
            throw new NotImplementedException();
        }

        public TipoSoporte Agregar(TipoSoporte item)
        {
            throw new NotImplementedException();
        }

        public TipoSoporte BuscarPorId(int id)
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

        public IEnumerable<TipoSoporte> Listar()
        {
            throw new NotImplementedException();
        }

        public TipoSoporteResponse usp_GetListTipoSoporte()
        {
            TipoSoporteResponse Result = new TipoSoporteResponse();
            Result.List = new List<TipoSoporte>();
            using (SqlHelper helper = new SqlHelper(Util.Conexion()))
            {
                var reader = helper.ExecuteReader("uspGetListTipoSoporte");
                while (reader.Read())
                {
                    TipoSoporte registro = new TipoSoporte();
                    registro.Valor = reader.SafeGetString("Valor", "");
                    registro.Nombre = reader.SafeGetString("Nombre", "");
                    Result.List.Add(registro);
                }
                if (Result.List.Count > 0)
                    Result.Resultado = true;
                else
                    Result.Resultado = false;
                reader.Close();
            }
            return Result;
        }
    }
}
