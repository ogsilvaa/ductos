using CNPC.SISDUC.DAL.Helper;
using CNPC.SISDUC.Model;
using CNPC.SISDUC.Model.Servicio;
using CNPC.SISDUC.Repository.Contracts;
using CNPC.SISDUC.Repository.SqlServer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CNPC.SISDUC.Repository.SqlServer
{
    public class CambiosTuberiaRepositorio : ICambiosTuberiaRepositorio
    {
        public bool Actualizar(CambiosTuberia item)
        {
            bool result = false;
            List<ParametroSP> parametros = new List<ParametroSP>();
            parametros.Add(new ParametroSP("@Id", SqlDbType.Int, 0, item.Id));
            parametros.Add(new ParametroSP("@NumeroOleoducto", SqlDbType.VarChar, 50, item.NumeroOleoducto));
            parametros.Add(new ParametroSP("@CodigoDelTubo01", SqlDbType.VarChar, 100, item.CodigoDelTubo01));
            parametros.Add(new ParametroSP("@CodigoDelTuboReemplazado", SqlDbType.VarChar, 100, item.CodigoDelTuboReemplazado));
            parametros.Add(new ParametroSP("@Motivo", SqlDbType.NVarChar, 500, item.Motivo));
            parametros.Add(new ParametroSP("@OrdenServicio", SqlDbType.NVarChar, 100, item.OrdenServicio));
            parametros.Add(new ParametroSP("@FechaOrdenServicio", SqlDbType.DateTime, 0, item.FechaOrdenServicio));
            parametros.Add(new ParametroSP("@RowState", SqlDbType.VarChar, 1, item.RowState));
            parametros.Add(new ParametroSP("@LastUpdate", SqlDbType.DateTime, 0, item.LastUpdate));
            using (SqlHelper helper = new SqlHelper(Util.Conexion()))
            {
                result = Convert.ToInt32(helper.ExecuteNonQuery("uspActualizarCambiosTuberia", parametros, "@Id")) > 0;
            }
            return result;
        }

        public CambiosTuberia Agregar(CambiosTuberia item)
        {
            CambiosTuberia result = new CambiosTuberia();
            List<ParametroSP> parametros = new List<ParametroSP>();
            parametros.Add(new ParametroSP("@Id", SqlDbType.Int, 0, item.Id, ParameterDirection.Output));
            parametros.Add(new ParametroSP("@NumeroOleoducto", SqlDbType.VarChar, 50, item.NumeroOleoducto ?? ""));
            parametros.Add(new ParametroSP("@CodigoDelTubo01", SqlDbType.VarChar, 100, item.CodigoDelTubo01 ?? ""));
            parametros.Add(new ParametroSP("@CodigoDelTuboReemplazado", SqlDbType.VarChar, 100, item.CodigoDelTuboReemplazado ?? ""));
            parametros.Add(new ParametroSP("@Motivo", SqlDbType.NVarChar, 500, item.Motivo ?? ""));
            parametros.Add(new ParametroSP("@OrdenServicio", SqlDbType.NVarChar, 100, item.OrdenServicio ?? ""));
            parametros.Add(new ParametroSP("@FechaOrdenServicio", SqlDbType.DateTime, 0, item.FechaOrdenServicio ?? DateTime.Now));
            parametros.Add(new ParametroSP("@RowState", SqlDbType.VarChar, 1, item.RowState));
            int id = 0;
            using (SqlHelper helper = new SqlHelper(Util.Conexion()))
            {
                id = Convert.ToInt32(helper.ExecuteNonQuery("uspRegistrarCambiosTuberia", parametros, "@Id"));
                if (id > 0)
                {
                    result = item;
                    result.Id = id;
                }
            }
            return result;
        }

        public CambiosTuberia BuscarPorId(int id)
        {
            CambiosTuberia Result = new CambiosTuberia();
            using (SqlHelper helper = new SqlHelper(Util.Conexion()))
            {
                ParametroSP parametro = new ParametroSP("@Id", SqlDbType.Int, 0, id);

                var reader = helper.ExecuteReader("uspGetCambiosTuberiaById", parametro);
                while (reader.Read())
                {
                    Result.Id = reader.SafeGetInt32("ID", 0);
                    Result.NumeroOleoducto = reader.SafeGetString("NumeroOleoducto", "");
                    Result.CodigoDelTubo01 = reader.SafeGetString("CodigoDelTubo01", "");
                    Result.CodigoDelTuboReemplazado = reader.SafeGetString("CodigoDelTuboReemplazado", "");
                    Result.Motivo = reader.SafeGetString("Motivo", "");
                    Result.OrdenServicio = reader.SafeGetString("OrdenServicio", "");
                    Result.FechaOrdenServicio = reader.SafeGetDateTime("FechaOrdenServicio", new DateTime(1950, 1, 1, 0, 0, 0));
                    Result.RowState = reader.SafeGetString("RowState", "");
                    Result.LastUpdate = reader.SafeGetDateTime("LastUpdate", new DateTime(1950, 1, 1, 0, 0, 0));
                }
                reader.Close();
            }
            return Result;
        }

        public IEnumerable<CambiosTuberia> BuscarPorNombre(string NumeroOleoducto, int TuberiaId, int Page, int Records, out int TotalPage)
        {
            IList<CambiosTuberia> Result = new List<CambiosTuberia>();
            TotalPage = 0;
            using (SqlHelper helper = new SqlHelper(Util.Conexion()))
            {
                List<ParametroSP> parametros = new List<ParametroSP>();
                parametros.Add(new ParametroSP("@NumeroOleoducto", SqlDbType.VarChar, 50, NumeroOleoducto));
                parametros.Add(new ParametroSP("@TuberiaId", SqlDbType.Int, 0, TuberiaId));
                parametros.Add(new ParametroSP("@Page", SqlDbType.Int, 0, Page));
                parametros.Add(new ParametroSP("@Records", SqlDbType.Int, 0, Records));
                parametros.Add(new ParametroSP("@TotalPage", SqlDbType.Int, 0, TotalPage, ParameterDirection.Output));

                var reader = helper.ExecuteReader("uspGetListCambiosTuberia", parametros);
                while (reader.Read())
                {
                    CambiosTuberia registro = new CambiosTuberia();
                    registro.Id = reader.SafeGetInt32("ID", 0);
                    registro.NumeroOleoducto = reader.SafeGetString("NumeroOleoducto", "");
                    registro.CodigoDelTubo01 = reader.SafeGetString("CodigoDelTubo01", "");
                    registro.CodigoDelTuboReemplazado = reader.SafeGetString("CodigoDelTuboReemplazado", "");
                    registro.Motivo = reader.SafeGetString("Motivo", "");
                    registro.OrdenServicio = reader.SafeGetString("OrdenServicio", "");
                    registro.FechaOrdenServicio = reader.SafeGetDateTime("FechaOrdenServicio", new DateTime(1950, 1, 1, 0, 0, 0));
                    registro.RowState = reader.SafeGetString("RowState", "");
                    registro.LastUpdate = reader.SafeGetDateTime("LastUpdate", new DateTime(1950, 1, 1, 0, 0, 0));
                    Result.Add(registro);
                }
                TotalPage = Convert.ToInt32(helper.ExecuteNonQuery("uspGetListCambiosTuberia", parametros, "@TotalPage"));
                reader.Close();
            }
            return Result;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public bool Eliminar(int id)
        {
            bool Result = false;
            List<ParametroSP> parametros = new List<ParametroSP>();
            parametros.Add(new ParametroSP("@Id", SqlDbType.Int, 0, id));
            parametros.Add(new ParametroSP("@RowState", SqlDbType.VarChar, 1, "D"));
            parametros.Add(new ParametroSP("@LastUpdate", SqlDbType.DateTime, 0, DateTime.Now));
            using (SqlHelper helper = new SqlHelper(Util.Conexion()))
            {
                Result = Convert.ToInt32(helper.ExecuteNonQuery("uspEliminarCambiosTuberia", parametros)) > 0;
                helper.ExecuteNonQuery("uspEliminarCambiosTuberia", parametros);
            }
            return Result;
        }

        public IEnumerable<CambiosTuberia> Listar()
        {
            throw new NotImplementedException();
        }

        public CambiosTuberiaResponse usp_GetListCambiosTuberia(string NumeroOleoducto, int TuberiaID, int records, int page)
        {
            CambiosTuberiaResponse Result = new CambiosTuberiaResponse();
            int totalPage = 0;
            Result.List = BuscarPorNombre(NumeroOleoducto, TuberiaID, page, records, out totalPage).ToList();
            Result.Records = records;
            Result.Page = page;
            Result.TotalPages = totalPage;
            return Result;
        }
    }

}

