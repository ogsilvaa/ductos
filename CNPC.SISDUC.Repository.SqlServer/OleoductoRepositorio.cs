using System;
using System.Collections.Generic;
using CNPC.SISDUC.Model;
using CNPC.SISDUC.Model.Servicio;
using CNPC.SISDUC.Repository.Contracts;
using log4net;
using CNPC.SISDUC.DAL.Helper;
using System.Data;

namespace CNPC.SISDUC.Repository.SqlServer
{
    public class OleoductoRepositorio : IOleoductoRepositorio
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(OleoductoRepositorio));

        public List<Inventario> ObtenerInventario()
        {
            var result = new List<Inventario>();
            using (var helper = new SqlHelper(Util.Conexion()))
            {
                var reader = helper.ExecuteReader("uspGetInventarios");
                while (reader.Read())
                {
                    var item = new Inventario
                    {
                        Prefijo = reader.SafeGetString("prefijo", ""),
                        Anio = reader.SafeGetInt32("AnioInspeccion", 0)
                    };
                    result.Add(item);
                }
            }
            return result;
        }
        public bool Actualizar(Oleoducto item)
        {
            bool result = false;

            List<ParametroSP> parametros = new List<ParametroSP>();
            parametros.Add(new ParametroSP("@Id", SqlDbType.Int, 0, item.Id));
            parametros.Add(new ParametroSP("@VersionId", SqlDbType.Int, 0, item.VersionId));
            parametros.Add(new ParametroSP("@Cliente", SqlDbType.VarChar, 50, item.Cliente));
            parametros.Add(new ParametroSP("@Codigo", SqlDbType.VarChar, 50, item.Codigo));
            parametros.Add(new ParametroSP("@Descripcion", SqlDbType.VarChar, 150, item.Descripcion));
            parametros.Add(new ParametroSP("@NoLamina", SqlDbType.VarChar, 50, item.NoLamina));
            parametros.Add(new ParametroSP("@Ubicacion", SqlDbType.VarChar, 50, item.Ubicacion));
            parametros.Add(new ParametroSP("@Material1", SqlDbType.VarChar, 50, item.Material1));
            parametros.Add(new ParametroSP("@Material2", SqlDbType.VarChar, 50, item.Material1));
            parametros.Add(new ParametroSP("@Material3", SqlDbType.VarChar, 50, item.Material1));
            parametros.Add(new ParametroSP("@Schedule1", SqlDbType.Int, 0, item.Schedule1));
            parametros.Add(new ParametroSP("@Schedule2", SqlDbType.Int, 0, item.Schedule2));
            parametros.Add(new ParametroSP("@Schedule3", SqlDbType.Int, 0, item.Schedule3));
            parametros.Add(new ParametroSP("@BLPD", SqlDbType.Int, 0, item.BLPD));
            parametros.Add(new ParametroSP("@Presion", SqlDbType.Decimal, 0, item.Presion));
            parametros.Add(new ParametroSP("@Temperatura", SqlDbType.Decimal, 0, item.Temperatura));
            parametros.Add(new ParametroSP("@BSW", SqlDbType.VarChar, 50, item.BSW));
            parametros.Add(new ParametroSP("@FechaInspeccion", SqlDbType.DateTime, 0, item.FechaInspeccion));
            parametros.Add(new ParametroSP("@Observaciones", SqlDbType.VarChar, 500, item.Observaciones));
            parametros.Add(new ParametroSP("@RowState", SqlDbType.VarChar, 1, item.RowState));
            parametros.Add(new ParametroSP("@LastUpdate", SqlDbType.DateTime, 0, item.LastUpdate));

            using (SqlHelper helper = new SqlHelper(Util.Conexion()))
            {
                result = Convert.ToInt32(helper.ExecuteNonQuery("uspRegistrarOleoducto", parametros, "@Id")) > 0;
            }
            return result;
        }

        public Oleoducto Agregar(Oleoducto item)
        {
            Oleoducto Result = null;
            List<ParametroSP> parametros = new List<ParametroSP>();
            parametros.Add(new ParametroSP("@Id", SqlDbType.Int, 0, item.Id, ParameterDirection.Output));
            parametros.Add(new ParametroSP("@VersionId", SqlDbType.Int, 0, item.VersionId));
            parametros.Add(new ParametroSP("@Cliente", SqlDbType.VarChar, 50, item.Cliente));
            parametros.Add(new ParametroSP("@Codigo", SqlDbType.VarChar, 50, item.Codigo));
            parametros.Add(new ParametroSP("@Descripcion", SqlDbType.VarChar, 150, item.Descripcion));
            parametros.Add(new ParametroSP("@NoLamina", SqlDbType.VarChar, 50, item.NoLamina));
            parametros.Add(new ParametroSP("@Ubicacion", SqlDbType.VarChar, 50, item.Ubicacion));
            parametros.Add(new ParametroSP("@Material1", SqlDbType.VarChar, 50, item.Material1));
            parametros.Add(new ParametroSP("@Material2", SqlDbType.VarChar, 50, item.Material1));
            parametros.Add(new ParametroSP("@Material3", SqlDbType.VarChar, 50, item.Material1));
            parametros.Add(new ParametroSP("@Schedule1", SqlDbType.Int, 0, item.Schedule1));
            parametros.Add(new ParametroSP("@Schedule2", SqlDbType.Int, 0, item.Schedule2));
            parametros.Add(new ParametroSP("@Schedule3", SqlDbType.Int, 0, item.Schedule3));
            parametros.Add(new ParametroSP("@BLPD", SqlDbType.Int, 0, item.BLPD));
            parametros.Add(new ParametroSP("@Presion", SqlDbType.Decimal, 0, item.Presion));
            parametros.Add(new ParametroSP("@Temperatura", SqlDbType.Decimal, 0, item.Temperatura));
            parametros.Add(new ParametroSP("@BSW", SqlDbType.VarChar, 50, item.BSW));
            parametros.Add(new ParametroSP("@FechaInspeccion", SqlDbType.DateTime, 0, item.FechaInspeccion));
            parametros.Add(new ParametroSP("@Observaciones", SqlDbType.VarChar, 500, item.Observaciones));
            parametros.Add(new ParametroSP("@RowState", SqlDbType.VarChar, 1, item.RowState));
            parametros.Add(new ParametroSP("@LastUpdate", SqlDbType.DateTime, 0, item.LastUpdate));

            int id = 0;
            using (SqlHelper helper = new SqlHelper(Util.Conexion()))
            {
                id = Convert.ToInt32(helper.ExecuteNonQuery("uspRegistrarOleoducto", parametros, "@Id"));
                if (id > 0)
                {
                    Result.Id = id;
                }
            }
            return Result;
        }

        public IEnumerable<Oleoducto> BuscarByNombre(string Nombre)
        {
            List<Oleoducto> Result = new List<Oleoducto>();
            using (SqlHelper helper = new SqlHelper(Util.Conexion()))
            {
                List<ParametroSP> parametros = new List<ParametroSP> {
                new ParametroSP("@TipoDucto", SqlDbType.VarChar, 50, "OLB"),
                new ParametroSP("@Nombre", SqlDbType.VarChar, 50, Nombre)
            };
                var reader = helper.ExecuteReader("uspGetListOleoductosByNombre", parametros);
                while (reader.Read())
                {
                    Oleoducto registro = new Oleoducto();
                    registro.Id = reader.SafeGetInt32("ID", 0);
                    registro.VersionId = reader.SafeGetInt32("VersionId", 0);
                    registro.Cliente = reader.SafeGetString("Cliente", "");
                    registro.Codigo = reader.SafeGetString("Codigo", "");
                    registro.Descripcion = reader.SafeGetString("Descripcion", "");
                    registro.NoLamina = reader.SafeGetString("NoLamina", "");
                    registro.Ubicacion = reader.SafeGetString("Ubicacion", "");
                    registro.Material1 = reader.SafeGetString("Material1", "");
                    registro.Material2 = reader.SafeGetString("Material2", "");
                    registro.Material3 = reader.SafeGetString("Material3", "");
                    registro.Schedule1 = reader.SafeGetInt32("Schedule1", 0);
                    registro.Schedule2 = reader.SafeGetInt32("Schedule2", 0);
                    registro.Schedule3 = reader.SafeGetInt32("Schedule3", 0);
                    registro.BLPD = reader.SafeGetInt32("BLPD", 0);
                    registro.Presion = reader.SafeGetDecimal("Presion", 0);
                    registro.Temperatura = reader.SafeGetDecimal("Temperatura", 0);
                    registro.BSW = reader.SafeGetString("BSW", "");
                    registro.FechaInspeccion = reader.SafeGetDateTime("FechaInspeccion", new DateTime(1950, 01, 01, 0, 0, 0));
                    registro.Observaciones = reader.SafeGetString("Observaciones", "");
                    registro.RowState = reader.SafeGetString("RowState", "");
                    registro.LastUpdate = reader.SafeGetDateTime("LastUpdate", new DateTime(1950, 01, 01));
                    Result.Add(registro);
                }
                reader.Close();
            }
            return Result;
        }

        public Oleoducto BuscarPorId(int id)
        {
            Oleoducto Result = new Oleoducto();
            using (SqlHelper helper = new SqlHelper(Util.Conexion()))
            {
                ParametroSP parametro = new ParametroSP("@Id", SqlDbType.Int, 0, id);

                var reader = helper.ExecuteReader("uspGetOleoductoById", parametro);
                while (reader.Read())
                {
                    Result.Id = reader.SafeGetInt32("ID", 0);
                    Result.VersionId = reader.SafeGetInt32("VersionId", 0);
                    Result.Cliente = reader.SafeGetString("Cliente", "");
                    Result.Codigo = reader.SafeGetString("Codigo", "");
                    Result.Descripcion = reader.SafeGetString("Descripcion", "");
                    Result.NoLamina = reader.SafeGetString("NoLamina", "");
                    Result.Ubicacion = reader.SafeGetString("Ubicacion", "");
                    Result.Material1 = reader.SafeGetString("Material1", "");
                    Result.Material2 = reader.SafeGetString("Material2", "");
                    Result.Material3 = reader.SafeGetString("Material3", "");
                    Result.Schedule1 = reader.SafeGetInt32("Schedule1", 0);
                    Result.Schedule2 = reader.SafeGetInt32("Schedule2", 0);
                    Result.Schedule3 = reader.SafeGetInt32("Schedule3", 0);
                    Result.BLPD = reader.SafeGetInt32("BLPD", 0);
                    Result.Presion = reader.SafeGetDecimal("Presion", 0);
                    Result.Temperatura = reader.SafeGetDecimal("Temperatura", 0);
                    Result.BSW = reader.SafeGetString("BSW", "");
                    Result.FechaInspeccion = reader.SafeGetDateTime("FechaInspeccion", new DateTime(1950, 01, 01, 0, 0, 0));
                    Result.Observaciones = reader.SafeGetString("Observaciones", "");
                    Result.RowState = reader.SafeGetString("RowState", "");
                    Result.LastUpdate = reader.SafeGetDateTime("LastUpdate", new DateTime(1950, 01, 01));
                }
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
            throw new NotImplementedException();
        }

        public Oleoducto FilterByID(int ID)
        {
            return BuscarPorId(ID);
        }

        public OleoductoResponse FilterByName(string prefijo, string Nombre, int page, int records)
        {
            OleoductoResponse Result = new OleoductoResponse();
            using (SqlHelper helper = new SqlHelper(Util.Conexion()))
            {
                List<ParametroSP> parametros = new List<ParametroSP>();
                parametros.Add(new ParametroSP("@TipoDucto", SqlDbType.Int, 0, prefijo));
                parametros.Add(new ParametroSP("@Nombre", SqlDbType.VarChar, 50, Nombre));
                parametros.Add(new ParametroSP("@Page", SqlDbType.Int, 0, page));
                parametros.Add(new ParametroSP("@Records", SqlDbType.Int, 0, records));

                var reader = helper.ExecuteReader("uspGetListOleoductosByNombrePageRecords", parametros);
                while (reader.Read())
                {
                    Oleoducto registro = new Oleoducto();
                    registro.Id = reader.SafeGetInt32("ID", 0);
                    registro.VersionId = reader.SafeGetInt32("VersionId", 0);
                    registro.Cliente = reader.SafeGetString("Cliente", "");
                    registro.Codigo = reader.SafeGetString("Codigo", "");
                    registro.Descripcion = reader.SafeGetString("Descripcion", "");
                    registro.NoLamina = reader.SafeGetString("NoLamina", "");
                    registro.Ubicacion = reader.SafeGetString("Ubicacion", "");
                    registro.Material1 = reader.SafeGetString("Material1", "");
                    registro.Material2 = reader.SafeGetString("Material2", "");
                    registro.Material3 = reader.SafeGetString("Material3", "");
                    registro.Schedule1 = reader.SafeGetInt32("Schedule1", 0);
                    registro.Schedule2 = reader.SafeGetInt32("Schedule2", 0);
                    registro.Schedule3 = reader.SafeGetInt32("Schedule3", 0);
                    registro.BLPD = reader.SafeGetInt32("BLPD", 0);
                    registro.Presion = reader.SafeGetDecimal("Presion", 0);
                    registro.Temperatura = reader.SafeGetDecimal("Temperatura", 0);
                    registro.BSW = reader.SafeGetString("BSW", "");
                    registro.FechaInspeccion = reader.SafeGetDateTime("FechaInspeccion", new DateTime(1950, 01, 01, 0, 0, 0));
                    registro.Observaciones = reader.SafeGetString("Observaciones", "");
                    registro.RowState = reader.SafeGetString("RowState", "");
                    registro.LastUpdate = reader.SafeGetDateTime("LastUpdate", new DateTime(1950, 01, 01));
                    Result.List.Add(registro);
                }
                reader.Close();
            }
            return Result;
        }

        public List<Oleoducto> GetListOleoductosByNombre(string prefijo, string Nombre)
        {
            List<Oleoducto> Result = new List<Oleoducto>();
            using (SqlHelper helper = new SqlHelper(Util.Conexion()))
            {
                List<ParametroSP> parametros = new List<ParametroSP>();
                parametros.Add(new ParametroSP("@TipoDucto", SqlDbType.VarChar, 50, prefijo));
                parametros.Add(new ParametroSP("@Nombre", SqlDbType.VarChar, 50, Nombre));

                var reader = helper.ExecuteReader("uspGetListOleoductosByNombre", parametros);
                while (reader.Read())
                {
                    Oleoducto registro = new Oleoducto();
                    registro.Id = reader.SafeGetInt32("ID", 0);
                    registro.VersionId = reader.SafeGetInt32("VersionId", 0);
                    registro.Cliente = reader.SafeGetString("Cliente", "");
                    registro.Codigo = reader.SafeGetString("Codigo", "");
                    registro.Descripcion = reader.SafeGetString("Descripcion", "");
                    registro.NoLamina = reader.SafeGetString("NoLamina", "");
                    registro.Ubicacion = reader.SafeGetString("Ubicacion", "");
                    registro.Material1 = reader.SafeGetString("Material1", "");
                    registro.Material2 = reader.SafeGetString("Material2", "");
                    registro.Material3 = reader.SafeGetString("Material3", "");
                    registro.Schedule1 = reader.SafeGetInt32("Schedule1", 0);
                    registro.Schedule2 = reader.SafeGetInt32("Schedule2", 0);
                    registro.Schedule3 = reader.SafeGetInt32("Schedule3", 0);
                    registro.BLPD = reader.SafeGetInt32("BLPD", 0);
                    registro.Presion = reader.SafeGetDecimal("Presion", 0);
                    registro.Temperatura = reader.SafeGetDecimal("Temperatura", 0);
                    registro.BSW = reader.SafeGetString("BSW", "");
                    registro.FechaInspeccion = reader.SafeGetDateTime("FechaInspeccion", new DateTime(1950, 01, 01, 0, 0, 0));
                    registro.Observaciones = reader.SafeGetString("Observaciones", "");
                    registro.RowState = reader.SafeGetString("RowState", "");
                    registro.LastUpdate = reader.SafeGetDateTime("LastUpdate", new DateTime(1950, 01, 01));
                    Result.Add(registro);
                }
                reader.Close();
            }
            return Result;
        }

        public IEnumerable<Oleoducto> Listar()
        {
            throw new NotImplementedException();
        }

        public decimal LongitudOleoducto(int Id)
        {
            throw new NotImplementedException();
        }


    }
}
