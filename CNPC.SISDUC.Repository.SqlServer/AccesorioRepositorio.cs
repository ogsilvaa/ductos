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
    public class AccesorioRepositorio : IAccesorioRepositorio
    {
        public Accesorio Agregar(Accesorio item)
        {
            Accesorio result = new Accesorio();

            List<ParametroSP> parametros = new List<ParametroSP>();
            parametros.Add(new ParametroSP("@Id", SqlDbType.Int, 0, item.Id, ParameterDirection.Output));
            parametros.Add(new ParametroSP("@NombreAccesorio", SqlDbType.VarChar, 50, item.NombreAccesorio));
            parametros.Add(new ParametroSP("@CodigoTuberia", SqlDbType.VarChar, 50, item.CodigoTuberia));
            parametros.Add(new ParametroSP("@Correlativo", SqlDbType.VarChar, 50, item.Correlativo));
            parametros.Add(new ParametroSP("@NPS", SqlDbType.Decimal, 0, item.NPS));
            parametros.Add(new ParametroSP("@Schedule", SqlDbType.Int, 0, item.Schedule));
            parametros.Add(new ParametroSP("@TipoMaterial", SqlDbType.VarChar, 10, item.TipoMaterial));
            parametros.Add(new ParametroSP("@Longitud", SqlDbType.Decimal, 50, item.Longitud));
            parametros.Add(new ParametroSP("@CoordenadasUTMX", SqlDbType.Int, 0, item.CoordenadasUTMX));
            parametros.Add(new ParametroSP("@CoordenadasUTMY", SqlDbType.Int, 0, item.CoordenadasUTMY));
            parametros.Add(new ParametroSP("@Observaciones", SqlDbType.VarChar, 500, item.Observaciones));
            parametros.Add(new ParametroSP("@CondicionAccesorio", SqlDbType.VarChar, 10, item.CondicionAccesorio));
            parametros.Add(new ParametroSP("@RowState", SqlDbType.VarChar, 10, item.RowState));
            parametros.Add(new ParametroSP("@LastUpdate", SqlDbType.DateTime, 0, item.LastUpdate));
            parametros.Add(new ParametroSP("@RegistroInspeccionVisualId", SqlDbType.Int, 0, item.RegistroInspeccionVisualId));

            int id = 0;
            using (SqlHelper helper = new SqlHelper(Util.Conexion()))
            {
                id = Convert.ToInt32(helper.ExecuteNonQuery("uspRegistrarAccesorio", parametros, "@Id"));
                if (id > 0)
                {
                    result = item;
                    result.Id = id;
                }
                else
                    result = null;
            }
            return result;

        }

        public bool Actualizar(Accesorio item)
        {
            bool Result = false;
            List<ParametroSP> parametros = new List<ParametroSP>();
            parametros.Add(new ParametroSP("@Id", SqlDbType.Int, 0, item.Id));
            parametros.Add(new ParametroSP("@NombreAccesorio", SqlDbType.VarChar, 50, item.NombreAccesorio));
            parametros.Add(new ParametroSP("@CodigoTuberia", SqlDbType.VarChar, 50, item.CodigoTuberia));
            parametros.Add(new ParametroSP("@Correlativo", SqlDbType.VarChar, 50, item.Correlativo));
            parametros.Add(new ParametroSP("@NPS", SqlDbType.Decimal, 0, item.NPS));
            parametros.Add(new ParametroSP("@Schedule", SqlDbType.Int, 0, item.Schedule));
            parametros.Add(new ParametroSP("@TipoMaterial", SqlDbType.VarChar, 10, item.TipoMaterial));
            parametros.Add(new ParametroSP("@Longitud", SqlDbType.Decimal, 50, item.Longitud));
            parametros.Add(new ParametroSP("@CoordenadasUTMX", SqlDbType.Int, 0, item.CoordenadasUTMX));
            parametros.Add(new ParametroSP("@CoordenadasUTMY", SqlDbType.Int, 0, item.CoordenadasUTMY));
            parametros.Add(new ParametroSP("@Observaciones", SqlDbType.VarChar, 500, item.Observaciones));
            parametros.Add(new ParametroSP("@CondicionAccesorio", SqlDbType.VarChar, 10, item.CondicionAccesorio));
            parametros.Add(new ParametroSP("@RowState", SqlDbType.VarChar, 10, item.RowState));
            parametros.Add(new ParametroSP("@LastUpdate", SqlDbType.DateTime, 0, item.LastUpdate));
            parametros.Add(new ParametroSP("@RegistroInspeccionVisualId", SqlDbType.Int, 0, item.RegistroInspeccionVisualId));

            using (SqlHelper helper = new SqlHelper(Util.Conexion()))
            {
                Result = helper.ExecuteNonQuery("uspActualizarAccesorio", parametros) > 0;
            }
            return Result;
        }

        public bool Eliminar(int id)
        {
            bool Result = false;
            List<ParametroSP> parametros = new List<ParametroSP>();
            parametros.Add(new ParametroSP("@Id", SqlDbType.Int, 0, id));
            parametros.Add(new ParametroSP("@RowState", SqlDbType.VarChar, 10, "D"));
            parametros.Add(new ParametroSP("@LastUpdate", SqlDbType.DateTime, 0, DateTime.Now));
            using (SqlHelper helper = new SqlHelper(Util.Conexion()))
            {
                Result = helper.ExecuteNonQuery("uspEliminarAccesorio", parametros) > 0;
            }
            return Result;
        }

        public Accesorio BuscarPorId(int id)
        {
            Accesorio Result = new Accesorio();
            using (SqlHelper helper = new SqlHelper(Util.Conexion()))
            {
                ParametroSP parametro = new ParametroSP("@Id", SqlDbType.Int, 0, id);

                var reader = helper.ExecuteReader("uspGetAccesorioById", parametro);
                while (reader.Read())
                {
                    Result.Id = reader.SafeGetInt32("ID", 0);
                    Result.NombreAccesorio = reader.SafeGetString("NombreAccesorio", "");
                    Result.CodigoTuberia = reader.SafeGetString("CodigoTuberia", "");
                    Result.Correlativo = reader.SafeGetString("Correlativo", "");
                    Result.CodigoAccesorio = reader.SafeGetString("CodigoAccesorio", "");
                    Result.NPS = reader.SafeGetDecimal("NPS", 0);
                    Result.Schedule = reader.SafeGetInt32("Schedule", 0);
                    Result.TipoMaterial = reader.SafeGetString("TipoMaterial", "");
                    Result.Longitud = reader.SafeGetDecimal("Longitud", 0);
                    Result.CoordenadasUTMX = reader.SafeGetInt32("CoordenadasUTMX", 0);
                    Result.CoordenadasUTMY = reader.SafeGetInt32("CoordenadasUTMY", 0);
                    Result.Observaciones = reader.SafeGetString("Observaciones", "");
                    Result.CondicionAccesorio = reader.SafeGetString("CondicionAccesorio", "");
                    Result.RowState = reader.SafeGetString("RowState", "");
                    Result.LastUpdate = reader.SafeGetDateTime("LastUpdate", new DateTime(1950, 01, 01));
                    Result.RegistroInspeccionVisualId = reader.SafeGetInt32("RegistroInspeccionVisualId", 0);
                }
                reader.Close();
            }
            return Result;
        }

        public IEnumerable<Accesorio> Listar()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Accesorio> BuscarPorOleoducto(int anio, int OleoductoId, string Nombre, int Page, int Records)
        {
            IList<Accesorio> Result = new List<Accesorio>();
            using (SqlHelper helper = new SqlHelper(Util.Conexion()))
            {
                List<ParametroSP> parametros = new List<ParametroSP>();
                parametros.Add(new ParametroSP("@OleoductoId", SqlDbType.Int, 0, OleoductoId));
                parametros.Add(new ParametroSP("@Nombre", SqlDbType.VarChar, 50, Nombre));
                parametros.Add(new ParametroSP("@Page", SqlDbType.Int, 0, Page));
                parametros.Add(new ParametroSP("@Records", SqlDbType.Int, 0, Records));

                var reader = helper.ExecuteReader("uspGetListAccesoriosPorOleoducto", parametros);
                while (reader.Read())
                {
                    Accesorio registro = new Accesorio();
                    registro.Id = reader.SafeGetInt32("ID", 0);
                    registro.NombreAccesorio = reader.SafeGetString("NombreAccesorio", "");
                    registro.CodigoTuberia = reader.SafeGetString("CodigoTuberia", "");
                    registro.Correlativo = reader.SafeGetString("Correlativo", "");
                    registro.CodigoAccesorio = reader.SafeGetString("CodigoAccesorio", "");
                    registro.NPS = reader.SafeGetDecimal("NPS", 0);
                    registro.Schedule = reader.SafeGetInt32("Schedule", 0);
                    registro.TipoMaterial = reader.SafeGetString("TipoMaterial", "");
                    registro.Longitud = reader.SafeGetDecimal("Longitud", 0);
                    registro.CoordenadasUTMX = reader.SafeGetInt32("CoordenadasUTMX", 0);
                    registro.CoordenadasUTMY = reader.SafeGetInt32("CoordenadasUTMY", 0);
                    registro.Observaciones = reader.SafeGetString("Observaciones", "");
                    registro.CondicionAccesorio = reader.SafeGetString("CondicionAccesorio", "");
                    registro.RowState = reader.SafeGetString("RowState", "");
                    registro.LastUpdate = reader.SafeGetDateTime("LastUpdate", new DateTime(1950, 01, 01));
                    Result.Add(registro);
                }
                reader.Close();
            }
            return Result;
        }

        public Accesorio BuscarPorCodigo(string codigo)
        {
            Accesorio Result = new Accesorio();
            using (SqlHelper helper = new SqlHelper(Util.Conexion()))
            {
                ParametroSP parametro = new ParametroSP("@CodigoAccesorio", SqlDbType.VarChar, 100, codigo);

                var reader = helper.ExecuteReader("uspGetAccesorioByCodigo", parametro);
                while (reader.Read())
                {
                    Result.Id = reader.SafeGetInt32("ID", 0);
                    Result.NombreAccesorio = reader.SafeGetString("NombreAccesorio", "");
                    Result.CodigoTuberia = reader.SafeGetString("CodigoTuberia", "");
                    Result.Correlativo = reader.SafeGetString("Correlativo", "");
                    Result.CodigoAccesorio = reader.SafeGetString("CodigoAccesorio", "");
                    Result.NPS = reader.SafeGetDecimal("NPS", 0);
                    Result.Schedule = reader.SafeGetInt32("Schedule", 0);
                    Result.TipoMaterial = reader.SafeGetString("TipoMaterial", "");
                    Result.Longitud = reader.SafeGetDecimal("Longitud", 0);
                    Result.CoordenadasUTMX = reader.SafeGetInt32("CoordenadasUTMX", 0);
                    Result.CoordenadasUTMY = reader.SafeGetInt32("CoordenadasUTMY", 0);
                    Result.Observaciones = reader.SafeGetString("Observaciones", "");
                    Result.CondicionAccesorio = reader.SafeGetString("CondicionAccesorio", "");
                    Result.RowState = reader.SafeGetString("RowState", "");
                    Result.LastUpdate = reader.SafeGetDateTime("LastUpdate", new DateTime(1950, 01, 01));
                    Result.RegistroInspeccionVisualId = reader.SafeGetInt32("RegistroInspeccionVisualId", 0);
                }
                reader.Close();
            }
            return Result;
        }

        public IEnumerable<Accesorio> BuscarPorNombre(string Nombre)
        {
            throw new NotImplementedException();
        }

        public int TotalBuscarPorNombre(int TuberiaId, string Nombre)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Accesorio> BuscarPorTuberia(string TuberiaCodigo, string Nombre)
        {
            IList<Accesorio> Result = new List<Accesorio>();
            using (SqlHelper helper = new SqlHelper(Util.Conexion()))
            {
                List<ParametroSP> parametros = new List<ParametroSP>();
                parametros.Add(new ParametroSP("@TuberiaId", SqlDbType.Int, 0, TuberiaCodigo));
                parametros.Add(new ParametroSP("@Nombre", SqlDbType.VarChar, 50, Nombre));

                var reader = helper.ExecuteReader("uspGetListAccesoriosPorTuberia", parametros);
                while (reader.Read())
                {
                    Accesorio registro = new Accesorio();
                    registro.Id = reader.SafeGetInt32("ID", 0);
                    registro.NombreAccesorio = reader.SafeGetString("NombreAccesorio", "");
                    registro.CodigoTuberia = reader.SafeGetString("CodigoTuberia", "");
                    registro.Correlativo = reader.SafeGetString("Correlativo", "");
                    registro.CodigoAccesorio = reader.SafeGetString("CodigoAccesorio", "");
                    registro.NPS = reader.SafeGetDecimal("NPS", 0);
                    registro.Schedule = reader.SafeGetInt32("Schedule", 0);
                    registro.TipoMaterial = reader.SafeGetString("TipoMaterial", "");
                    registro.Longitud = reader.SafeGetDecimal("Longitud", 0);
                    registro.CoordenadasUTMX = reader.SafeGetInt32("CoordenadasUTMX", 0);
                    registro.CoordenadasUTMY = reader.SafeGetInt32("CoordenadasUTMY", 0);
                    registro.Observaciones = reader.SafeGetString("Observaciones", "");
                    registro.CondicionAccesorio = reader.SafeGetString("CondicionAccesorio", "");
                    registro.RowState = reader.SafeGetString("RowState", "");
                    registro.LastUpdate = reader.SafeGetDateTime("LastUpdate", new DateTime(1950, 01, 01));
                    Result.Add(registro);
                }
                reader.Close();
            }
            return Result;
        }
    }

}

