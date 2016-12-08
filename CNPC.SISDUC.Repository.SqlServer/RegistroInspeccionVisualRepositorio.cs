using CNPC.SISDUC.DAL.Helper;
using CNPC.SISDUC.Model;
using CNPC.SISDUC.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CNPC.SISDUC.Repository.SqlServer
{
    public class RegistroInspeccionVisualRepositorio : IRegistroInspeccionVisualRepositorio
    {
        public RegistroInspeccionVisual Agregar(RegistroInspeccionVisual item)
        {
            RegistroInspeccionVisual result = new RegistroInspeccionVisual();

            List<ParametroSP> parametros = new List<ParametroSP>();
            parametros.Add(new ParametroSP("@Id", SqlDbType.Int, 0, item.Id, ParameterDirection.Output));
            parametros.Add(new ParametroSP("@OleoductoID", SqlDbType.Int, 0, item.OleoductoID));
            parametros.Add(new ParametroSP("@NumeroOleoducto", SqlDbType.VarChar, 50, item.NumeroOleoducto));
            parametros.Add(new ParametroSP("@CodigoDelTubo01", SqlDbType.VarChar, 5, item.CodigoDelTubo01));
            parametros.Add(new ParametroSP("@CodigoDelTubo02", SqlDbType.VarChar, 1, item.CodigoDelTubo02));
            parametros.Add(new ParametroSP("@CodigoDelTubo03", SqlDbType.VarChar, 4, item.CodigoDelTubo03));
            parametros.Add(new ParametroSP("@NumeroAnterior", SqlDbType.Int, 0, item.NumeroAnterior));
            parametros.Add(new ParametroSP("@NPS", SqlDbType.Decimal, 0, item.NPS));
            parametros.Add(new ParametroSP("@Schedule", SqlDbType.Int, 0, item.Schedule));
            parametros.Add(new ParametroSP("@SHC", SqlDbType.Int, 0, item.SHC));
            parametros.Add(new ParametroSP("@TipoMaterial", SqlDbType.VarChar, 50, item.TipoMaterial));
            parametros.Add(new ParametroSP("@Longitud", SqlDbType.Decimal, 0, item.Longitud));
            parametros.Add(new ParametroSP("@CoordenadasUTM_X", SqlDbType.VarChar, 0, item.CoordenadasUTM_X));
            parametros.Add(new ParametroSP("@CoordenadasUTM_Y", SqlDbType.VarChar, 0, item.CoordenadasUTM_Y));
            parametros.Add(new ParametroSP("@ExtremoInicial1", SqlDbType.Decimal, 0, item.ExtremoInicial1));
            parametros.Add(new ParametroSP("@ExtremoInicial2", SqlDbType.Decimal, 0, item.ExtremoInicial2));
            parametros.Add(new ParametroSP("@ExtremoInicial3", SqlDbType.Decimal, 0, item.ExtremoInicial3));
            parametros.Add(new ParametroSP("@ExtremoInicial4", SqlDbType.Decimal, 0, item.ExtremoInicial4));
            parametros.Add(new ParametroSP("@BSCAN", SqlDbType.Decimal, 0, item.BSCAN));
            parametros.Add(new ParametroSP("@EspesorPared", SqlDbType.Decimal, 0, item.EspesorPared));
            parametros.Add(new ParametroSP("@ExtremoMedio1", SqlDbType.Decimal, 0, item.ExtremoMedio1));
            parametros.Add(new ParametroSP("@ExtremoMedio2", SqlDbType.Decimal, 0, item.ExtremoMedio2));
            parametros.Add(new ParametroSP("@ExtremoMedio3", SqlDbType.Decimal, 0, item.ExtremoMedio3));
            parametros.Add(new ParametroSP("@ExtremoMedio4", SqlDbType.Decimal, 0, item.ExtremoMedio4));
            parametros.Add(new ParametroSP("@MapeoCorrison", SqlDbType.Decimal, 0, item.MapeoCorrison));
            parametros.Add(new ParametroSP("@PitCorrosion", SqlDbType.Decimal, 0, item.PitCorrosion));
            parametros.Add(new ParametroSP("@ExtremoFinal1", SqlDbType.Decimal, 0, item.ExtremoFinal1));
            parametros.Add(new ParametroSP("@ExtremoFinal2", SqlDbType.Decimal, 0, item.ExtremoFinal2));
            parametros.Add(new ParametroSP("@ExtremoFinal3", SqlDbType.Decimal, 0, item.ExtremoFinal3));
            parametros.Add(new ParametroSP("@ExtremoFinal4", SqlDbType.Decimal, 0, item.ExtremoFinal4));
            parametros.Add(new ParametroSP("@LEFT_MINIMO", SqlDbType.Decimal, 0, item.LEFT_MINIMO));
            parametros.Add(new ParametroSP("@EspesorRemanente", SqlDbType.Decimal, 0, item.EspesorRemanente));
            parametros.Add(new ParametroSP("@Defecto", SqlDbType.VarChar, 1000, item.Defecto));
            parametros.Add(new ParametroSP("@Defecto2", SqlDbType.Bit, 0, item.Defecto2));
            parametros.Add(new ParametroSP("@NumeroGrapas", SqlDbType.Int, 0, item.NumeroGrapas));
            parametros.Add(new ParametroSP("@TipoSoporte", SqlDbType.VarChar, 100, item.TipoSoporte));
            parametros.Add(new ParametroSP("@Elastomero", SqlDbType.Bit, 0, item.Elastomero));
            parametros.Add(new ParametroSP("@Maleza", SqlDbType.Bit, 0, item.Maleza));
            parametros.Add(new ParametroSP("@TuberiaAlrededor", SqlDbType.Bit, 0, item.TuberiaAlrededor));
            parametros.Add(new ParametroSP("@Pintura", SqlDbType.Bit, 0, item.Pintura));
            parametros.Add(new ParametroSP("@CruceCarretera", SqlDbType.Bit, 0, item.CruceCarretera));
            parametros.Add(new ParametroSP("@TipoProteccion", SqlDbType.VarChar, 50, item.TipoProteccion));
            parametros.Add(new ParametroSP("@EstadoProteccion", SqlDbType.VarChar, 50, item.EstadoProteccion));
            parametros.Add(new ParametroSP("@EstadoTuberia", SqlDbType.VarChar, 3, item.EstadoTuberia));
            parametros.Add(new ParametroSP("@UltimaFechaDeInspeccion", SqlDbType.DateTime, 0, item.UltimaFechaDeInspeccion));
            parametros.Add(new ParametroSP("@SeleccionarTuberia", SqlDbType.Bit, 0, item.SeleccionarTuberia));
            parametros.Add(new ParametroSP("@RowState", SqlDbType.VarChar, 10, item.RowState));
            parametros.Add(new ParametroSP("@LastUpdate", SqlDbType.DateTime, 0, item.LastUpdate));

            int id = 0;
            using (SqlHelper helper = new SqlHelper(Util.Conexion()))
            {
                id = Convert.ToInt32(helper.ExecuteNonQuery("uspRegistrarRegistroInspeccionVisual", parametros, "@Id"));
                if (id > 0)
                {
                    result = item;
                    result.Id = id;
                }
            }
            return result;

        }

        public bool Actualizar(RegistroInspeccionVisual item)
        {
            bool Result = false;
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@Id", item.Id));
            parametros.Add(new SqlParameter("@OleoductoID", item.OleoductoID));
            parametros.Add(new SqlParameter("@NumeroOleoducto", item.NumeroOleoducto));
            parametros.Add(new SqlParameter("@CodigoDelTubo01", item.CodigoDelTubo01 ?? ""));
            parametros.Add(new SqlParameter("@CodigoDelTubo02", item.CodigoDelTubo02 ?? ""));
            parametros.Add(new SqlParameter("@CodigoDelTubo03", item.CodigoDelTubo03 ?? ""));
            parametros.Add(new SqlParameter("@NumeroAnterior", item.NumeroAnterior ?? 0));
            parametros.Add(new SqlParameter("@NPS", item.NPS ?? 0m));
            parametros.Add(new SqlParameter("@Schedule", item.Schedule ?? 0));
            parametros.Add(new SqlParameter("@SHC", item.SHC ?? 0));
            parametros.Add(new SqlParameter("@TipoMaterial", item.TipoMaterial ?? ""));
            parametros.Add(new SqlParameter("@Longitud", item.Longitud ?? 0m));
            parametros.Add(new SqlParameter("@CoordenadasUTM_X", item.CoordenadasUTM_X ?? ""));
            parametros.Add(new SqlParameter("@CoordenadasUTM_Y", item.CoordenadasUTM_Y ?? ""));
            parametros.Add(new SqlParameter("@ExtremoInicial1", item.ExtremoInicial1 ?? 0m));
            parametros.Add(new SqlParameter("@ExtremoInicial2", item.ExtremoInicial2 ?? 0m));
            parametros.Add(new SqlParameter("@ExtremoInicial3", item.ExtremoInicial3 ?? 0m));
            parametros.Add(new SqlParameter("@ExtremoInicial4", item.ExtremoInicial4 ?? 0m));
            parametros.Add(new SqlParameter("@BSCAN", item.BSCAN ?? 0m));
            parametros.Add(new SqlParameter("@EspesorPared", item.EspesorPared ?? 0m));
            parametros.Add(new SqlParameter("@ExtremoMedio1", item.ExtremoMedio1 ?? 0m));
            parametros.Add(new SqlParameter("@ExtremoMedio2", item.ExtremoMedio2 ?? 0m));
            parametros.Add(new SqlParameter("@ExtremoMedio3", item.ExtremoMedio3 ?? 0m));
            parametros.Add(new SqlParameter("@ExtremoMedio4", item.ExtremoMedio4 ?? 0m));
            parametros.Add(new SqlParameter("@MapeoCorrison", item.MapeoCorrison ?? 0m));
            parametros.Add(new SqlParameter("@PitCorrosion", item.PitCorrosion ?? 0m));
            parametros.Add(new SqlParameter("@ExtremoFinal1", item.ExtremoFinal1 ?? 0m));
            parametros.Add(new SqlParameter("@ExtremoFinal2", item.ExtremoFinal2 ?? 0m));
            parametros.Add(new SqlParameter("@ExtremoFinal3", item.ExtremoFinal3 ?? 0m));
            parametros.Add(new SqlParameter("@ExtremoFinal4", item.ExtremoFinal4 ?? 0m));
            parametros.Add(new SqlParameter("@LEFT_MINIMO", item.LEFT_MINIMO ?? 0m));
            parametros.Add(new SqlParameter("@Defecto", item.Defecto ?? ""));
            parametros.Add(new SqlParameter("@Defecto2", item.Defecto2));
            parametros.Add(new SqlParameter("@NumeroGrapas", item.NumeroGrapas ?? 0));
            parametros.Add(new SqlParameter("@TipoSoporte", item.TipoSoporte ?? ""));
            parametros.Add(new SqlParameter("@Elastomero", item.Elastomero ?? false));
            parametros.Add(new SqlParameter("@Maleza", item.Maleza));
            parametros.Add(new SqlParameter("@TuberiaAlrededor", item.TuberiaAlrededor));
            parametros.Add(new SqlParameter("@Pintura", item.Pintura));
            parametros.Add(new SqlParameter("@CruceCarretera", item.CruceCarretera));
            parametros.Add(new SqlParameter("@TipoProteccion", item.TipoProteccion ?? ""));
            parametros.Add(new SqlParameter("@EstadoProteccion", item.EstadoProteccion ?? ""));
            parametros.Add(new SqlParameter("@EstadoTuberia", item.EstadoTuberia ?? ""));
            parametros.Add(new SqlParameter("@UltimaFechaDeInspeccion", item.UltimaFechaDeInspeccion ?? new DateTime(1950, 1, 1, 0, 0, 0)));
            parametros.Add(new SqlParameter("@SeleccionarTuberia", item.SeleccionarTuberia));
            parametros.Add(new SqlParameter("@RowState", "M"));

            SqlConnection cnn = new SqlConnection(Util.Conexion());
            using (SqlCommand cmd = new SqlCommand("uspActualizarRegistroInspeccionVisual", cnn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter p in parametros)
                {
                    cmd.Parameters.Add(p);
                }
                cnn.Open();
                Result = cmd.ExecuteNonQuery() > 0;
                cnn.Close();
            }
            return Result;
        }


        public bool Eliminar(int id)
        {
            bool Result = false;
            List<ParametroSP> parametros = new List<ParametroSP>();
            parametros.Add(new ParametroSP("@Id", SqlDbType.Int, 0, id));
            using (SqlHelper helper = new SqlHelper(Util.Conexion()))
            {
                Result = helper.ExecuteNonQuery("uspEliminarRegistroInspeccionVisual", parametros) > 0;
            }
            return Result;
        }

        public RegistroInspeccionVisual BuscarPorId(int id)
        {
            RegistroInspeccionVisual Result = new RegistroInspeccionVisual();
            using (SqlHelper helper = new SqlHelper(Util.Conexion()))
            {
                ParametroSP parametro = new ParametroSP("@Id", SqlDbType.Int, 0, id);

                var reader = helper.ExecuteReader("uspGetRegistroInspeccionVisualById", parametro);
                while (reader.Read())
                {
                    Result.Id = reader.SafeGetInt32("ID", 0);
                    Result.OleoductoID = reader.SafeGetInt32("OleoductoID", 0);
                    Result.TuberiaId = reader.SafeGetInt32("TuberiaId", 0);
                    Result.CodigoDelTubo = reader.SafeGetString("CodigoDelTubo", "");
                    Result.TuberiaId = reader.SafeGetInt32("TuberiaId", 0);
                    Result.NumeroOleoducto = reader.SafeGetString("NumeroOleoducto", "");
                    Result.CodigoDelTubo01 = reader.SafeGetString("CodigoDelTubo01", "");
                    Result.CodigoDelTubo02 = reader.SafeGetString("CodigoDelTubo02", "");
                    Result.CodigoDelTubo03 = reader.SafeGetString("CodigoDelTubo03", "");
                    Result.NumeroAnterior = reader.SafeGetInt32("NumeroAnterior", 0);
                    Result.NPS = reader.SafeGetDecimal("NPS", 0);
                    Result.Schedule = reader.SafeGetInt32("Schedule", 0);
                    Result.SHC = reader.SafeGetInt32("SHC", 0);
                    Result.TipoMaterial = reader.SafeGetString("TipoMaterial", "");
                    Result.Longitud = reader.SafeGetDecimal("Longitud", 0);
                    Result.CoordenadasUTM_X = reader.SafeGetString("CoordenadasUTM_X", "");
                    Result.CoordenadasUTM_Y = reader.SafeGetString("CoordenadasUTM_Y", "");
                    Result.ExtremoInicial1 = reader.SafeGetDecimal("ExtremoInicial1", 0);
                    Result.ExtremoInicial2 = reader.SafeGetDecimal("ExtremoInicial2", 0);
                    Result.ExtremoInicial3 = reader.SafeGetDecimal("ExtremoInicial3", 0);
                    Result.ExtremoInicial4 = reader.SafeGetDecimal("ExtremoInicial4", 0);
                    Result.BSCAN = reader.SafeGetDecimal("BSCAN", 0);
                    Result.EspesorPared = reader.SafeGetDecimal("EspesorPared", 0);
                    Result.ExtremoMedio1 = reader.SafeGetDecimal("ExtremoMedio1", 0);
                    Result.ExtremoMedio2 = reader.SafeGetDecimal("ExtremoMedio2", 0);
                    Result.ExtremoMedio3 = reader.SafeGetDecimal("ExtremoMedio3", 0);
                    Result.ExtremoMedio4 = reader.SafeGetDecimal("ExtremoMedio4", 0);
                    Result.MapeoCorrison = reader.SafeGetDecimal("MapeoCorrison", 0);
                    Result.PitCorrosion = reader.SafeGetDecimal("PitCorrosion", 0);
                    Result.ExtremoFinal1 = reader.SafeGetDecimal("ExtremoFinal1", 0);
                    Result.ExtremoFinal2 = reader.SafeGetDecimal("ExtremoFinal2", 0);
                    Result.ExtremoFinal3 = reader.SafeGetDecimal("ExtremoFinal3", 0);
                    Result.ExtremoFinal4 = reader.SafeGetDecimal("ExtremoFinal4", 0);
                    Result.LEFT_MINIMO = reader.SafeGetDecimal("LEFT_MINIMO", 0);
                    Result.EspesorRemanente = reader.SafeGetDecimal("EspesorRemanente", 0);
                    Result.Defecto = reader.SafeGetString("Defecto", "");
                    Result.Defecto2 = reader.SafeGetBoolean("Defecto2", false);
                    Result.NumeroGrapas = reader.SafeGetInt32("NumeroGrapas", 0);
                    Result.TipoSoporte = reader.SafeGetString("TipoSoporte", "");
                    Result.Elastomero = reader.SafeGetBoolean("Elastomero", false);
                    Result.Maleza = reader.SafeGetBoolean("Maleza", false);
                    Result.TuberiaAlrededor = reader.SafeGetBoolean("TuberiaAlrededor", false);
                    Result.Pintura = reader.SafeGetBoolean("Pintura", false);
                    Result.CruceCarretera = reader.SafeGetBoolean("CruceCarretera", false);
                    Result.TipoProteccion = reader.SafeGetString("TipoProteccion", "");
                    Result.EstadoProteccion = reader.SafeGetString("EstadoProteccion", "");
                    Result.EstadoTuberia = reader.SafeGetString("EstadoTuberia", "");
                    Result.UltimaFechaDeInspeccion = reader.SafeGetDateTime("UltimaFechaDeInspeccion", new DateTime(1950, 01, 01, 0, 0, 0));
                    Result.AnioInspeccion = reader.SafeGetInt32("AnioInspeccion", 1950);
                    Result.SeleccionarTuberia = reader.SafeGetBoolean("SeleccionarTuberia", false);
                    Result.RowState = reader.SafeGetString("RowState", "");
                    Result.LastUpdate = reader.SafeGetDateTime("LastUpdate", new DateTime(1950, 01, 01, 0, 0, 0));
                }
                reader.Close();
            }
            return Result;
        }

        public IEnumerable<RegistroInspeccionVisual> Listar(int AnioInspeccion, int DuctoId, string Nombre, int Page, int Records)
        {
            List<RegistroInspeccionVisual> Result = null;
            using (SqlHelper helper = new SqlHelper(Util.Conexion()))
            {
                List<ParametroSP> listaParametros = new List<ParametroSP>
                {
                    new ParametroSP("@Anio", SqlDbType.Int, 0, AnioInspeccion),
                    new ParametroSP("@DuctoId", SqlDbType.Int, 0, DuctoId),
                    new ParametroSP("@Nombre", SqlDbType.VarChar, 50, Nombre),
                    new ParametroSP("@Page", SqlDbType.Int, 0, Page),
                    new ParametroSP("@Records", SqlDbType.Int, 0, Records)
                };

                var reader = helper.ExecuteReader("uspGetListRegistroInspeccionVisualByNombrePageRecords", listaParametros);
                while (reader.Read())
                {
                    RegistroInspeccionVisual item = new RegistroInspeccionVisual();
                    item.Id = reader.SafeGetInt32("ID", 0);
                    item.OleoductoID = reader.SafeGetInt32("OleoductoID", 0);
                    item.TuberiaId = reader.SafeGetInt32("TuberiaId", 0);
                    item.CodigoDelTubo = reader.SafeGetString("CodigoDelTubo", "");
                    item.TuberiaId = reader.SafeGetInt32("TuberiaId", 0);
                    item.NumeroOleoducto = reader.SafeGetString("NumeroOleoducto", "");
                    item.CodigoDelTubo01 = reader.SafeGetString("CodigoDelTubo01", "");
                    item.CodigoDelTubo02 = reader.SafeGetString("CodigoDelTubo02", "");
                    item.CodigoDelTubo03 = reader.SafeGetString("CodigoDelTubo03", "");
                    item.NumeroAnterior = reader.SafeGetInt32("NumeroAnterior", 0);
                    item.NPS = reader.SafeGetDecimal("NPS", 0);
                    item.Schedule = reader.SafeGetInt32("Schedule", 0);
                    item.SHC = reader.SafeGetInt32("SHC", 0);
                    item.TipoMaterial = reader.SafeGetString("TipoMaterial", "");
                    item.Longitud = reader.SafeGetDecimal("Longitud", 0);
                    item.CoordenadasUTM_X = reader.SafeGetString("CoordenadasUTM_X", "");
                    item.CoordenadasUTM_Y = reader.SafeGetString("CoordenadasUTM_Y", "");
                    item.ExtremoInicial1 = reader.SafeGetDecimal("ExtremoInicial1", 0);
                    item.ExtremoInicial2 = reader.SafeGetDecimal("ExtremoInicial2", 0);
                    item.ExtremoInicial3 = reader.SafeGetDecimal("ExtremoInicial3", 0);
                    item.ExtremoInicial4 = reader.SafeGetDecimal("ExtremoInicial4", 0);
                    item.BSCAN = reader.SafeGetDecimal("BSCAN", 0);
                    item.EspesorPared = reader.SafeGetDecimal("EspesorPared", 0);
                    item.ExtremoMedio1 = reader.SafeGetDecimal("ExtremoMedio1", 0);
                    item.ExtremoMedio2 = reader.SafeGetDecimal("ExtremoMedio2", 0);
                    item.ExtremoMedio3 = reader.SafeGetDecimal("ExtremoMedio3", 0);
                    item.ExtremoMedio4 = reader.SafeGetDecimal("ExtremoMedio4", 0);
                    item.MapeoCorrison = reader.SafeGetDecimal("MapeoCorrison", 0);
                    item.PitCorrosion = reader.SafeGetDecimal("PitCorrosion", 0);
                    item.ExtremoFinal1 = reader.SafeGetDecimal("ExtremoFinal1", 0);
                    item.ExtremoFinal2 = reader.SafeGetDecimal("ExtremoFinal2", 0);
                    item.ExtremoFinal3 = reader.SafeGetDecimal("ExtremoFinal3", 0);
                    item.ExtremoFinal4 = reader.SafeGetDecimal("ExtremoFinal4", 0);
                    item.LEFT_MINIMO = reader.SafeGetDecimal("LEFT_MINIMO", 0);
                    item.EspesorRemanente = reader.SafeGetDecimal("EspesorRemanente", 0);
                    item.Defecto = reader.SafeGetString("Defecto", "");
                    item.Defecto2 = reader.SafeGetBoolean("Defecto2", false);
                    item.NumeroGrapas = reader.SafeGetInt32("NumeroGrapas", 0);
                    item.TipoSoporte = reader.SafeGetString("TipoSoporte", "");
                    item.Elastomero = reader.SafeGetBoolean("Elastomero", false);
                    item.Maleza = reader.SafeGetBoolean("Maleza", false);
                    item.TuberiaAlrededor = reader.SafeGetBoolean("TuberiaAlrededor", false);
                    item.Pintura = reader.SafeGetBoolean("Pintura", false);
                    item.CruceCarretera = reader.SafeGetBoolean("CruceCarretera", false);
                    item.TipoProteccion = reader.SafeGetString("TipoProteccion", "");
                    item.EstadoProteccion = reader.SafeGetString("EstadoProteccion", "");
                    item.EstadoTuberia = reader.SafeGetString("EstadoTuberia", "");
                    item.UltimaFechaDeInspeccion = reader.SafeGetDateTime("UltimaFechaDeInspeccion", new DateTime(1950, 01, 01, 0, 0, 0));
                    item.AnioInspeccion = reader.SafeGetInt32("AnioInspeccion", 1950);
                    item.SeleccionarTuberia = reader.SafeGetBoolean("SeleccionarTuberia", false);
                    item.RowState = reader.SafeGetString("RowState", "");
                    item.LastUpdate = reader.SafeGetDateTime("LastUpdate", new DateTime(1950, 01, 01, 0, 0, 0));
                    Result.Add(item);
                }
                reader.Close();
            }
            return Result;
        }

        public IEnumerable<RegistroInspeccionVisual> BuscarPorNombre(int AnioInspeccion, int DuctoId, string Nombre, int Page, int Records)
        {
            List<RegistroInspeccionVisual> Result = null;
            using (SqlHelper helper = new SqlHelper(Util.Conexion()))
            {
                List<ParametroSP> listaParametros = new List<ParametroSP>
                {
                new ParametroSP("@DuctoId", SqlDbType.Int, 0, DuctoId),
                new ParametroSP("@Nombre", SqlDbType.VarChar, 50, Nombre),
                new ParametroSP("@Page", SqlDbType.Int, 0, Page),
                new ParametroSP("@Records", SqlDbType.Int, 0, Records)

            };
                var reader = helper.ExecuteReader("uspGetListRegistroInspeccionVisualByNombrePageRecords", listaParametros);
                while (reader.Read())
                {
                    RegistroInspeccionVisual item = new RegistroInspeccionVisual();
                    item.Id = reader.SafeGetInt32("ID", 0);
                    item.OleoductoID = reader.SafeGetInt32("OleoductoID", 0);
                    item.TuberiaId = reader.SafeGetInt32("TuberiaId", 0);
                    item.CodigoDelTubo = reader.SafeGetString("CodigoDelTubo", "");
                    item.TuberiaId = reader.SafeGetInt32("TuberiaId", 0);
                    item.NumeroOleoducto = reader.SafeGetString("NumeroOleoducto", "");
                    item.CodigoDelTubo01 = reader.SafeGetString("CodigoDelTubo01", "");
                    item.CodigoDelTubo02 = reader.SafeGetString("CodigoDelTubo02", "");
                    item.CodigoDelTubo03 = reader.SafeGetString("CodigoDelTubo03", "");
                    item.NumeroAnterior = reader.SafeGetInt32("NumeroAnterior", 0);
                    item.NPS = reader.SafeGetDecimal("NPS", 0);
                    item.Schedule = reader.SafeGetInt32("Schedule", 0);
                    item.SHC = reader.SafeGetInt32("SHC", 0);
                    item.TipoMaterial = reader.SafeGetString("TipoMaterial", "");
                    item.Longitud = reader.SafeGetDecimal("Longitud", 0);
                    item.CoordenadasUTM_X = reader.SafeGetString("CoordenadasUTM_X", "");
                    item.CoordenadasUTM_Y = reader.SafeGetString("CoordenadasUTM_Y", "");
                    item.ExtremoInicial1 = reader.SafeGetDecimal("ExtremoInicial1", 0);
                    item.ExtremoInicial2 = reader.SafeGetDecimal("ExtremoInicial2", 0);
                    item.ExtremoInicial3 = reader.SafeGetDecimal("ExtremoInicial3", 0);
                    item.ExtremoInicial4 = reader.SafeGetDecimal("ExtremoInicial4", 0);
                    item.BSCAN = reader.SafeGetDecimal("BSCAN", 0);
                    item.EspesorPared = reader.SafeGetDecimal("EspesorPared", 0);
                    item.ExtremoMedio1 = reader.SafeGetDecimal("ExtremoMedio1", 0);
                    item.ExtremoMedio2 = reader.SafeGetDecimal("ExtremoMedio2", 0);
                    item.ExtremoMedio3 = reader.SafeGetDecimal("ExtremoMedio3", 0);
                    item.ExtremoMedio4 = reader.SafeGetDecimal("ExtremoMedio4", 0);
                    item.MapeoCorrison = reader.SafeGetDecimal("MapeoCorrison", 0);
                    item.PitCorrosion = reader.SafeGetDecimal("PitCorrosion", 0);
                    item.ExtremoFinal1 = reader.SafeGetDecimal("ExtremoFinal1", 0);
                    item.ExtremoFinal2 = reader.SafeGetDecimal("ExtremoFinal2", 0);
                    item.ExtremoFinal3 = reader.SafeGetDecimal("ExtremoFinal3", 0);
                    item.ExtremoFinal4 = reader.SafeGetDecimal("ExtremoFinal4", 0);
                    item.LEFT_MINIMO = reader.SafeGetDecimal("LEFT_MINIMO", 0);
                    item.EspesorRemanente = reader.SafeGetDecimal("EspesorRemanente", 0);
                    item.Defecto = reader.SafeGetString("Defecto", "");
                    item.Defecto2 = reader.SafeGetBoolean("Defecto2", false);
                    item.NumeroGrapas = reader.SafeGetInt32("NumeroGrapas", 0);
                    item.TipoSoporte = reader.SafeGetString("TipoSoporte", "");
                    item.Elastomero = reader.SafeGetBoolean("Elastomero", false);
                    item.Maleza = reader.SafeGetBoolean("Maleza", false);
                    item.TuberiaAlrededor = reader.SafeGetBoolean("TuberiaAlrededor", false);
                    item.Pintura = reader.SafeGetBoolean("Pintura", false);
                    item.CruceCarretera = reader.SafeGetBoolean("CruceCarretera", false);
                    item.TipoProteccion = reader.SafeGetString("TipoProteccion", "");
                    item.EstadoProteccion = reader.SafeGetString("EstadoProteccion", "");
                    item.EstadoTuberia = reader.SafeGetString("EstadoTuberia", "");
                    item.UltimaFechaDeInspeccion = reader.SafeGetDateTime("UltimaFechaDeInspeccion", new DateTime(1950, 01, 01, 0, 0, 0));
                    item.AnioInspeccion = reader.SafeGetInt32("AnioInspeccion", 1950);
                    item.SeleccionarTuberia = reader.SafeGetBoolean("SeleccionarTuberia", false);
                    item.RowState = reader.SafeGetString("RowState", "");
                    item.LastUpdate = reader.SafeGetDateTime("LastUpdate", new DateTime(1950, 01, 01, 0, 0, 0));
                    Result.Add(item);
                }
                reader.Close();
            }
            return Result;
        }

        public IEnumerable<RegistroInspeccionVisual> BuscarPorNombre(int AnioInspeccion, int DuctoId, string Nombre)
        {
            List<RegistroInspeccionVisual> Result = null;
            using (SqlHelper helper = new SqlHelper(Util.Conexion()))
            {
                List<ParametroSP> listaParametros = new List<ParametroSP>
                {
                new ParametroSP("@Anio", SqlDbType.Int, 0, AnioInspeccion),
                new ParametroSP("@DuctoId", SqlDbType.Int, 0, DuctoId),
                new ParametroSP("@Nombre", SqlDbType.VarChar, 50, Nombre)
            };
                var reader = helper.ExecuteReader("uspGetListRegistroInspeccionVisualByNombre", listaParametros);
                while (reader.Read())
                {
                    RegistroInspeccionVisual item = new RegistroInspeccionVisual();
                    item.Id = reader.SafeGetInt32("ID", 0);
                    item.OleoductoID = reader.SafeGetInt32("OleoductoID", 0);
                    item.TuberiaId = reader.SafeGetInt32("TuberiaId", 0);
                    item.CodigoDelTubo = reader.SafeGetString("CodigoDelTubo", "");
                    item.TuberiaId = reader.SafeGetInt32("TuberiaId", 0);
                    item.NumeroOleoducto = reader.SafeGetString("NumeroOleoducto", "");
                    item.CodigoDelTubo01 = reader.SafeGetString("CodigoDelTubo01", "");
                    item.CodigoDelTubo02 = reader.SafeGetString("CodigoDelTubo02", "");
                    item.CodigoDelTubo03 = reader.SafeGetString("CodigoDelTubo03", "");
                    item.NumeroAnterior = reader.SafeGetInt32("NumeroAnterior", 0);
                    item.NPS = reader.SafeGetDecimal("NPS", 0);
                    item.Schedule = reader.SafeGetInt32("Schedule", 0);
                    item.SHC = reader.SafeGetInt32("SHC", 0);
                    item.TipoMaterial = reader.SafeGetString("TipoMaterial", "");
                    item.Longitud = reader.SafeGetDecimal("Longitud", 0);
                    item.CoordenadasUTM_X = reader.SafeGetString("CoordenadasUTM_X", "");
                    item.CoordenadasUTM_Y = reader.SafeGetString("CoordenadasUTM_Y", "");
                    item.ExtremoInicial1 = reader.SafeGetDecimal("ExtremoInicial1", 0);
                    item.ExtremoInicial2 = reader.SafeGetDecimal("ExtremoInicial2", 0);
                    item.ExtremoInicial3 = reader.SafeGetDecimal("ExtremoInicial3", 0);
                    item.ExtremoInicial4 = reader.SafeGetDecimal("ExtremoInicial4", 0);
                    item.BSCAN = reader.SafeGetDecimal("BSCAN", 0);
                    item.EspesorPared = reader.SafeGetDecimal("EspesorPared", 0);
                    item.ExtremoMedio1 = reader.SafeGetDecimal("ExtremoMedio1", 0);
                    item.ExtremoMedio2 = reader.SafeGetDecimal("ExtremoMedio2", 0);
                    item.ExtremoMedio3 = reader.SafeGetDecimal("ExtremoMedio3", 0);
                    item.ExtremoMedio4 = reader.SafeGetDecimal("ExtremoMedio4", 0);
                    item.MapeoCorrison = reader.SafeGetDecimal("MapeoCorrison", 0);
                    item.PitCorrosion = reader.SafeGetDecimal("PitCorrosion", 0);
                    item.ExtremoFinal1 = reader.SafeGetDecimal("ExtremoFinal1", 0);
                    item.ExtremoFinal2 = reader.SafeGetDecimal("ExtremoFinal2", 0);
                    item.ExtremoFinal3 = reader.SafeGetDecimal("ExtremoFinal3", 0);
                    item.ExtremoFinal4 = reader.SafeGetDecimal("ExtremoFinal4", 0);
                    item.LEFT_MINIMO = reader.SafeGetDecimal("LEFT_MINIMO", 0);
                    item.EspesorRemanente = reader.SafeGetDecimal("EspesorRemanente", 0);
                    item.Defecto = reader.SafeGetString("Defecto", "");
                    item.Defecto2 = reader.SafeGetBoolean("Defecto2", false);
                    item.NumeroGrapas = reader.SafeGetInt32("NumeroGrapas", 0);
                    item.TipoSoporte = reader.SafeGetString("TipoSoporte", "");
                    item.Elastomero = reader.SafeGetBoolean("Elastomero", false);
                    item.Maleza = reader.SafeGetBoolean("Maleza", false);
                    item.TuberiaAlrededor = reader.SafeGetBoolean("TuberiaAlrededor", false);
                    item.Pintura = reader.SafeGetBoolean("Pintura", false);
                    item.CruceCarretera = reader.SafeGetBoolean("CruceCarretera", false);
                    item.TipoProteccion = reader.SafeGetString("TipoProteccion", "");
                    item.EstadoProteccion = reader.SafeGetString("EstadoProteccion", "");
                    item.EstadoTuberia = reader.SafeGetString("EstadoTuberia", "");
                    item.UltimaFechaDeInspeccion = reader.SafeGetDateTime("UltimaFechaDeInspeccion", new DateTime(1950, 01, 01, 0, 0, 0));
                    item.AnioInspeccion = reader.SafeGetInt32("AnioInspeccion", 1950);
                    item.SeleccionarTuberia = reader.SafeGetBoolean("SeleccionarTuberia", false);
                    item.RowState = reader.SafeGetString("RowState", "");
                    item.LastUpdate = reader.SafeGetDateTime("LastUpdate", new DateTime(1950, 01, 01, 0, 0, 0));
                    Result.Add(item);
                }
                reader.Close();
            }
            return Result;
        }

        public int TotalBuscarPorNombre(int AnioInspeccion, int DuctoId, string Nombre)
        {

            int Result = 0;
            using (SqlHelper helper = new SqlHelper(Util.Conexion()))
            {
                List<ParametroSP> listaParametros = new List<ParametroSP>
                {
                new ParametroSP("@Anio", SqlDbType.Int, 0, AnioInspeccion),
                new ParametroSP("@DuctoId", SqlDbType.Int, 0, DuctoId),
                new ParametroSP("@Nombre", SqlDbType.VarChar, 50, Nombre)
            };
                var reader = helper.ExecuteReader("uspGetTotalRegistroInspeccionVisualByNombre", listaParametros);
                while (reader.Read())
                {

                    Result = reader.SafeGetInt32("total", 0);
                }
                reader.Close();
            }
            return Result;
        }

        public RegistroInspeccionVisual BuscarPorCodigo(int AnioInspeccion, string codigo)
        {
            RegistroInspeccionVisual Result = new RegistroInspeccionVisual();
            using (SqlHelper helper = new SqlHelper(Util.Conexion()))
            {
                List<ParametroSP> listaParametros = new List<ParametroSP>
                {
                new ParametroSP("@Anio", SqlDbType.Int, 0, AnioInspeccion),
                new ParametroSP("@Codigo", SqlDbType.VarChar, 50, codigo)
                };
                var reader = helper.ExecuteReader("uspGetListRegistroInspeccionVisualByCodigo", listaParametros);
                while (reader.Read())
                {
                    Result.Id = reader.SafeGetInt32("ID", 0);
                    Result.OleoductoID = reader.SafeGetInt32("OleoductoID", 0);
                    Result.TuberiaId = reader.SafeGetInt32("TuberiaId", 0);
                    Result.CodigoDelTubo = reader.SafeGetString("CodigoDelTubo", "");
                    Result.TuberiaId = reader.SafeGetInt32("TuberiaId", 0);
                    Result.NumeroOleoducto = reader.SafeGetString("NumeroOleoducto", "");
                    Result.CodigoDelTubo01 = reader.SafeGetString("CodigoDelTubo01", "");
                    Result.CodigoDelTubo02 = reader.SafeGetString("CodigoDelTubo02", "");
                    Result.CodigoDelTubo03 = reader.SafeGetString("CodigoDelTubo03", "");
                    Result.NumeroAnterior = reader.SafeGetInt32("NumeroAnterior", 0);
                    Result.NPS = reader.SafeGetDecimal("NPS", 0);
                    Result.Schedule = reader.SafeGetInt32("Schedule", 0);
                    Result.SHC = reader.SafeGetInt32("SHC", 0);
                    Result.TipoMaterial = reader.SafeGetString("TipoMaterial", "");
                    Result.Longitud = reader.SafeGetDecimal("Longitud", 0);
                    Result.CoordenadasUTM_X = reader.SafeGetString("CoordenadasUTM_X", "");
                    Result.CoordenadasUTM_Y = reader.SafeGetString("CoordenadasUTM_Y", "");
                    Result.ExtremoInicial1 = reader.SafeGetDecimal("ExtremoInicial1", 0);
                    Result.ExtremoInicial2 = reader.SafeGetDecimal("ExtremoInicial2", 0);
                    Result.ExtremoInicial3 = reader.SafeGetDecimal("ExtremoInicial3", 0);
                    Result.ExtremoInicial4 = reader.SafeGetDecimal("ExtremoInicial4", 0);
                    Result.BSCAN = reader.SafeGetDecimal("BSCAN", 0);
                    Result.EspesorPared = reader.SafeGetDecimal("EspesorPared", 0);
                    Result.ExtremoMedio1 = reader.SafeGetDecimal("ExtremoMedio1", 0);
                    Result.ExtremoMedio2 = reader.SafeGetDecimal("ExtremoMedio2", 0);
                    Result.ExtremoMedio3 = reader.SafeGetDecimal("ExtremoMedio3", 0);
                    Result.ExtremoMedio4 = reader.SafeGetDecimal("ExtremoMedio4", 0);
                    Result.MapeoCorrison = reader.SafeGetDecimal("MapeoCorrison", 0);
                    Result.PitCorrosion = reader.SafeGetDecimal("PitCorrosion", 0);
                    Result.ExtremoFinal1 = reader.SafeGetDecimal("ExtremoFinal1", 0);
                    Result.ExtremoFinal2 = reader.SafeGetDecimal("ExtremoFinal2", 0);
                    Result.ExtremoFinal3 = reader.SafeGetDecimal("ExtremoFinal3", 0);
                    Result.ExtremoFinal4 = reader.SafeGetDecimal("ExtremoFinal4", 0);
                    Result.LEFT_MINIMO = reader.SafeGetDecimal("LEFT_MINIMO", 0);
                    Result.EspesorRemanente = reader.SafeGetDecimal("EspesorRemanente", 0);
                    Result.Defecto = reader.SafeGetString("Defecto", "");
                    Result.Defecto2 = reader.SafeGetBoolean("Defecto2", false);
                    Result.NumeroGrapas = reader.SafeGetInt32("NumeroGrapas", 0);
                    Result.TipoSoporte = reader.SafeGetString("TipoSoporte", "");
                    Result.Elastomero = reader.SafeGetBoolean("Elastomero", false);
                    Result.Maleza = reader.SafeGetBoolean("Maleza", false);
                    Result.TuberiaAlrededor = reader.SafeGetBoolean("TuberiaAlrededor", false);
                    Result.Pintura = reader.SafeGetBoolean("Pintura", false);
                    Result.CruceCarretera = reader.SafeGetBoolean("CruceCarretera", false);
                    Result.TipoProteccion = reader.SafeGetString("TipoProteccion", "");
                    Result.EstadoProteccion = reader.SafeGetString("EstadoProteccion", "");
                    Result.EstadoTuberia = reader.SafeGetString("EstadoTuberia", "");
                    Result.UltimaFechaDeInspeccion = reader.SafeGetDateTime("UltimaFechaDeInspeccion", new DateTime(1950, 01, 01, 0, 0, 0));
                    Result.AnioInspeccion = reader.SafeGetInt32("AnioInspeccion", 1950);
                    Result.SeleccionarTuberia = reader.SafeGetBoolean("SeleccionarTuberia", false);
                    Result.RowState = reader.SafeGetString("RowState", "");
                    Result.LastUpdate = reader.SafeGetDateTime("LastUpdate", new DateTime(1950, 01, 01, 0, 0, 0));
                }
                reader.Close();
            }
            return Result;
        }
        public IEnumerable<RegistroInspeccionVisual> RegistroInspeccionVisualListarEliminados(int AnioInspeccion, int ductoId)
        {
            List<RegistroInspeccionVisual> Result = new List<RegistroInspeccionVisual>();
            using (SqlHelper helper = new SqlHelper(Util.Conexion()))
            {
                List<ParametroSP> listaParametros = new List<ParametroSP>
                {
                new ParametroSP("@Anio", SqlDbType.Int, 0, AnioInspeccion),
                new ParametroSP("@DuctoId", SqlDbType.VarChar, 50, ductoId)
                };
                var reader = helper.ExecuteReader("uspGetListRegistroInspeccionVisualListarEliminados", listaParametros);
                while (reader.Read())
                {
                    RegistroInspeccionVisual item = new RegistroInspeccionVisual();
                    item.Id = reader.SafeGetInt32("ID", 0);
                    item.OleoductoID = reader.SafeGetInt32("OleoductoID", 0);
                    item.TuberiaId = reader.SafeGetInt32("TuberiaId", 0);
                    item.CodigoDelTubo = reader.SafeGetString("CodigoDelTubo", "");
                    item.TuberiaId = reader.SafeGetInt32("TuberiaId", 0);
                    item.NumeroOleoducto = reader.SafeGetString("NumeroOleoducto", "");
                    item.CodigoDelTubo01 = reader.SafeGetString("CodigoDelTubo01", "");
                    item.CodigoDelTubo02 = reader.SafeGetString("CodigoDelTubo02", "");
                    item.CodigoDelTubo03 = reader.SafeGetString("CodigoDelTubo03", "");
                    item.NumeroAnterior = reader.SafeGetInt32("NumeroAnterior", 0);
                    item.NPS = reader.SafeGetDecimal("NPS", 0);
                    item.Schedule = reader.SafeGetInt32("Schedule", 0);
                    item.SHC = reader.SafeGetInt32("SHC", 0);
                    item.TipoMaterial = reader.SafeGetString("TipoMaterial", "");
                    item.Longitud = reader.SafeGetDecimal("Longitud", 0);
                    item.CoordenadasUTM_X = reader.SafeGetString("CoordenadasUTM_X", "");
                    item.CoordenadasUTM_Y = reader.SafeGetString("CoordenadasUTM_Y", "");
                    item.ExtremoInicial1 = reader.SafeGetDecimal("ExtremoInicial1", 0);
                    item.ExtremoInicial2 = reader.SafeGetDecimal("ExtremoInicial2", 0);
                    item.ExtremoInicial3 = reader.SafeGetDecimal("ExtremoInicial3", 0);
                    item.ExtremoInicial4 = reader.SafeGetDecimal("ExtremoInicial4", 0);
                    item.BSCAN = reader.SafeGetDecimal("BSCAN", 0);
                    item.EspesorPared = reader.SafeGetDecimal("EspesorPared", 0);
                    item.ExtremoMedio1 = reader.SafeGetDecimal("ExtremoMedio1", 0);
                    item.ExtremoMedio2 = reader.SafeGetDecimal("ExtremoMedio2", 0);
                    item.ExtremoMedio3 = reader.SafeGetDecimal("ExtremoMedio3", 0);
                    item.ExtremoMedio4 = reader.SafeGetDecimal("ExtremoMedio4", 0);
                    item.MapeoCorrison = reader.SafeGetDecimal("MapeoCorrison", 0);
                    item.PitCorrosion = reader.SafeGetDecimal("PitCorrosion", 0);
                    item.ExtremoFinal1 = reader.SafeGetDecimal("ExtremoFinal1", 0);
                    item.ExtremoFinal2 = reader.SafeGetDecimal("ExtremoFinal2", 0);
                    item.ExtremoFinal3 = reader.SafeGetDecimal("ExtremoFinal3", 0);
                    item.ExtremoFinal4 = reader.SafeGetDecimal("ExtremoFinal4", 0);
                    item.LEFT_MINIMO = reader.SafeGetDecimal("LEFT_MINIMO", 0);
                    item.EspesorRemanente = reader.SafeGetDecimal("EspesorRemanente", 0);
                    item.Defecto = reader.SafeGetString("Defecto", "");
                    item.Defecto2 = reader.SafeGetBoolean("Defecto2", false);
                    item.NumeroGrapas = reader.SafeGetInt32("NumeroGrapas", 0);
                    item.TipoSoporte = reader.SafeGetString("TipoSoporte", "");
                    item.Elastomero = reader.SafeGetBoolean("Elastomero", false);
                    item.Maleza = reader.SafeGetBoolean("Maleza", false);
                    item.TuberiaAlrededor = reader.SafeGetBoolean("TuberiaAlrededor", false);
                    item.Pintura = reader.SafeGetBoolean("Pintura", false);
                    item.CruceCarretera = reader.SafeGetBoolean("CruceCarretera", false);
                    item.TipoProteccion = reader.SafeGetString("TipoProteccion", "");
                    item.EstadoProteccion = reader.SafeGetString("EstadoProteccion", "");
                    item.EstadoTuberia = reader.SafeGetString("EstadoTuberia", "");
                    item.UltimaFechaDeInspeccion = reader.SafeGetDateTime("UltimaFechaDeInspeccion", new DateTime(1950, 01, 01, 0, 0, 0));
                    item.AnioInspeccion = reader.SafeGetInt32("AnioInspeccion", 1950);
                    item.SeleccionarTuberia = reader.SafeGetBoolean("SeleccionarTuberia", false);
                    item.RowState = reader.SafeGetString("RowState", "");
                    item.LastUpdate = reader.SafeGetDateTime("LastUpdate", new DateTime(1950, 01, 01, 0, 0, 0));
                    Result.Add(item);
                }
                reader.Close();
            }
            return Result;
        }

        public IEnumerable<RegistroInspeccionVisual> Listar(int AnioInspeccion, int DuctoId)
        {
            List<RegistroInspeccionVisual> Result = null;
            using (SqlHelper helper = new SqlHelper(Util.Conexion()))
            {
                List<ParametroSP> listaParametros = new List<ParametroSP>
                {
                new ParametroSP("@Anio", SqlDbType.Int, 0, AnioInspeccion),
                new ParametroSP("@DuctoId", SqlDbType.Int, 0, DuctoId)
            };
                var reader = helper.ExecuteReader("uspGetListRegistroInspeccionVisual", listaParametros);
                while (reader.Read())
                {
                    RegistroInspeccionVisual item = new RegistroInspeccionVisual();
                    item.Id = reader.SafeGetInt32("ID", 0);
                    item.OleoductoID = reader.SafeGetInt32("OleoductoID", 0);
                    item.TuberiaId = reader.SafeGetInt32("TuberiaId", 0);
                    item.CodigoDelTubo = reader.SafeGetString("CodigoDelTubo", "");
                    item.TuberiaId = reader.SafeGetInt32("TuberiaId", 0);
                    item.NumeroOleoducto = reader.SafeGetString("NumeroOleoducto", "");
                    item.CodigoDelTubo01 = reader.SafeGetString("CodigoDelTubo01", "");
                    item.CodigoDelTubo02 = reader.SafeGetString("CodigoDelTubo02", "");
                    item.CodigoDelTubo03 = reader.SafeGetString("CodigoDelTubo03", "");
                    item.NumeroAnterior = reader.SafeGetInt32("NumeroAnterior", 0);
                    item.NPS = reader.SafeGetDecimal("NPS", 0);
                    item.Schedule = reader.SafeGetInt32("Schedule", 0);
                    item.SHC = reader.SafeGetInt32("SHC", 0);
                    item.TipoMaterial = reader.SafeGetString("TipoMaterial", "");
                    item.Longitud = reader.SafeGetDecimal("Longitud", 0);
                    item.CoordenadasUTM_X = reader.SafeGetString("CoordenadasUTM_X", "");
                    item.CoordenadasUTM_Y = reader.SafeGetString("CoordenadasUTM_Y", "");
                    item.ExtremoInicial1 = reader.SafeGetDecimal("ExtremoInicial1", 0);
                    item.ExtremoInicial2 = reader.SafeGetDecimal("ExtremoInicial2", 0);
                    item.ExtremoInicial3 = reader.SafeGetDecimal("ExtremoInicial3", 0);
                    item.ExtremoInicial4 = reader.SafeGetDecimal("ExtremoInicial4", 0);
                    item.BSCAN = reader.SafeGetDecimal("BSCAN", 0);
                    item.EspesorPared = reader.SafeGetDecimal("EspesorPared", 0);
                    item.ExtremoMedio1 = reader.SafeGetDecimal("ExtremoMedio1", 0);
                    item.ExtremoMedio2 = reader.SafeGetDecimal("ExtremoMedio2", 0);
                    item.ExtremoMedio3 = reader.SafeGetDecimal("ExtremoMedio3", 0);
                    item.ExtremoMedio4 = reader.SafeGetDecimal("ExtremoMedio4", 0);
                    item.MapeoCorrison = reader.SafeGetDecimal("MapeoCorrison", 0);
                    item.PitCorrosion = reader.SafeGetDecimal("PitCorrosion", 0);
                    item.ExtremoFinal1 = reader.SafeGetDecimal("ExtremoFinal1", 0);
                    item.ExtremoFinal2 = reader.SafeGetDecimal("ExtremoFinal2", 0);
                    item.ExtremoFinal3 = reader.SafeGetDecimal("ExtremoFinal3", 0);
                    item.ExtremoFinal4 = reader.SafeGetDecimal("ExtremoFinal4", 0);
                    item.LEFT_MINIMO = reader.SafeGetDecimal("LEFT_MINIMO", 0);
                    item.EspesorRemanente = reader.SafeGetDecimal("EspesorRemanente", 0);
                    item.Defecto = reader.SafeGetString("Defecto", "");
                    item.Defecto2 = reader.SafeGetBoolean("Defecto2", false);
                    item.NumeroGrapas = reader.SafeGetInt32("NumeroGrapas", 0);
                    item.TipoSoporte = reader.SafeGetString("TipoSoporte", "");
                    item.Elastomero = reader.SafeGetBoolean("Elastomero", false);
                    item.Maleza = reader.SafeGetBoolean("Maleza", false);
                    item.TuberiaAlrededor = reader.SafeGetBoolean("TuberiaAlrededor", false);
                    item.Pintura = reader.SafeGetBoolean("Pintura", false);
                    item.CruceCarretera = reader.SafeGetBoolean("CruceCarretera", false);
                    item.TipoProteccion = reader.SafeGetString("TipoProteccion", "");
                    item.EstadoProteccion = reader.SafeGetString("EstadoProteccion", "");
                    item.EstadoTuberia = reader.SafeGetString("EstadoTuberia", "");
                    item.UltimaFechaDeInspeccion = reader.SafeGetDateTime("UltimaFechaDeInspeccion", new DateTime(1950, 01, 01, 0, 0, 0));
                    item.AnioInspeccion = reader.SafeGetInt32("AnioInspeccion", 1950);
                    item.SeleccionarTuberia = reader.SafeGetBoolean("SeleccionarTuberia", false);
                    item.RowState = reader.SafeGetString("RowState", "");
                    item.LastUpdate = reader.SafeGetDateTime("LastUpdate", new DateTime(1950, 01, 01, 0, 0, 0));
                    Result.Add(item);
                }
                reader.Close();
            }
            return Result;
        }

        public IEnumerable<RegistroInspeccionVisual> Listar()
        {
            List<RegistroInspeccionVisual> Result = null;
            using (SqlHelper helper = new SqlHelper(Util.Conexion()))
            {
                List<ParametroSP> listaParametros = new List<ParametroSP>
                {
                new ParametroSP("@Anio", SqlDbType.Int, 0, 2016),
                new ParametroSP("@DuctoId", SqlDbType.Int, 0, 1)
            };
                var reader = helper.ExecuteReader("uspGetListRegistroInspeccionVisual", listaParametros);
                while (reader.Read())
                {
                    RegistroInspeccionVisual item = new RegistroInspeccionVisual();
                    item.Id = reader.SafeGetInt32("ID", 0);
                    item.OleoductoID = reader.SafeGetInt32("OleoductoID", 0);
                    item.TuberiaId = reader.SafeGetInt32("TuberiaId", 0);
                    item.CodigoDelTubo = reader.SafeGetString("CodigoDelTubo", "");
                    item.TuberiaId = reader.SafeGetInt32("TuberiaId", 0);
                    item.NumeroOleoducto = reader.SafeGetString("NumeroOleoducto", "");
                    item.CodigoDelTubo01 = reader.SafeGetString("CodigoDelTubo01", "");
                    item.CodigoDelTubo02 = reader.SafeGetString("CodigoDelTubo02", "");
                    item.CodigoDelTubo03 = reader.SafeGetString("CodigoDelTubo03", "");
                    item.NumeroAnterior = reader.SafeGetInt32("NumeroAnterior", 0);
                    item.NPS = reader.SafeGetDecimal("NPS", 0);
                    item.Schedule = reader.SafeGetInt32("Schedule", 0);
                    item.SHC = reader.SafeGetInt32("SHC", 0);
                    item.TipoMaterial = reader.SafeGetString("TipoMaterial", "");
                    item.Longitud = reader.SafeGetDecimal("Longitud", 0);
                    item.CoordenadasUTM_X = reader.SafeGetString("CoordenadasUTM_X", "");
                    item.CoordenadasUTM_Y = reader.SafeGetString("CoordenadasUTM_Y", "");
                    item.ExtremoInicial1 = reader.SafeGetDecimal("ExtremoInicial1", 0);
                    item.ExtremoInicial2 = reader.SafeGetDecimal("ExtremoInicial2", 0);
                    item.ExtremoInicial3 = reader.SafeGetDecimal("ExtremoInicial3", 0);
                    item.ExtremoInicial4 = reader.SafeGetDecimal("ExtremoInicial4", 0);
                    item.BSCAN = reader.SafeGetDecimal("BSCAN", 0);
                    item.EspesorPared = reader.SafeGetDecimal("EspesorPared", 0);
                    item.ExtremoMedio1 = reader.SafeGetDecimal("ExtremoMedio1", 0);
                    item.ExtremoMedio2 = reader.SafeGetDecimal("ExtremoMedio2", 0);
                    item.ExtremoMedio3 = reader.SafeGetDecimal("ExtremoMedio3", 0);
                    item.ExtremoMedio4 = reader.SafeGetDecimal("ExtremoMedio4", 0);
                    item.MapeoCorrison = reader.SafeGetDecimal("MapeoCorrison", 0);
                    item.PitCorrosion = reader.SafeGetDecimal("PitCorrosion", 0);
                    item.ExtremoFinal1 = reader.SafeGetDecimal("ExtremoFinal1", 0);
                    item.ExtremoFinal2 = reader.SafeGetDecimal("ExtremoFinal2", 0);
                    item.ExtremoFinal3 = reader.SafeGetDecimal("ExtremoFinal3", 0);
                    item.ExtremoFinal4 = reader.SafeGetDecimal("ExtremoFinal4", 0);
                    item.LEFT_MINIMO = reader.SafeGetDecimal("LEFT_MINIMO", 0);
                    item.EspesorRemanente = reader.SafeGetDecimal("EspesorRemanente", 0);
                    item.Defecto = reader.SafeGetString("Defecto", "");
                    item.Defecto2 = reader.SafeGetBoolean("Defecto2", false);
                    item.NumeroGrapas = reader.SafeGetInt32("NumeroGrapas", 0);
                    item.TipoSoporte = reader.SafeGetString("TipoSoporte", "");
                    item.Elastomero = reader.SafeGetBoolean("Elastomero", false);
                    item.Maleza = reader.SafeGetBoolean("Maleza", false);
                    item.TuberiaAlrededor = reader.SafeGetBoolean("TuberiaAlrededor", false);
                    item.Pintura = reader.SafeGetBoolean("Pintura", false);
                    item.CruceCarretera = reader.SafeGetBoolean("CruceCarretera", false);
                    item.TipoProteccion = reader.SafeGetString("TipoProteccion", "");
                    item.EstadoProteccion = reader.SafeGetString("EstadoProteccion", "");
                    item.EstadoTuberia = reader.SafeGetString("EstadoTuberia", "");
                    item.UltimaFechaDeInspeccion = reader.SafeGetDateTime("UltimaFechaDeInspeccion", new DateTime(1950, 01, 01, 0, 0, 0));
                    item.AnioInspeccion = reader.SafeGetInt32("AnioInspeccion", 1950);
                    item.SeleccionarTuberia = reader.SafeGetBoolean("SeleccionarTuberia", false);
                    item.RowState = reader.SafeGetString("RowState", "");
                    item.LastUpdate = reader.SafeGetDateTime("LastUpdate", new DateTime(1950, 01, 01, 0, 0, 0));
                    Result.Add(item);
                }
                reader.Close();
            }
            return Result;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<RegistroInspeccionVisual> GetListRegistroInspeccionVisualByNombre(int anio, int DuctoId, string Nombre)
        {
            List<RegistroInspeccionVisual> Result = new List<RegistroInspeccionVisual>();
            using (SqlHelper helper = new SqlHelper(Util.Conexion()))
            {
                List<ParametroSP> listaParametros = new List<ParametroSP>
                {new ParametroSP("@Anio", SqlDbType.Int, 0, anio),
                new ParametroSP("@DuctoId", SqlDbType.Int, 0, DuctoId),
                new ParametroSP("@Nombre",SqlDbType.VarChar,50,Nombre)};
                var reader = helper.ExecuteReader("uspGetListRegistroInspeccionVisualByNombre", listaParametros);
                while (reader.Read())
                {
                    RegistroInspeccionVisual item = new RegistroInspeccionVisual();
                    item.Id = reader.SafeGetInt32("ID", 0);
                    item.OleoductoID = reader.SafeGetInt32("OleoductoID", 0);
                    item.TuberiaId = reader.SafeGetInt32("TuberiaId", 0);
                    item.CodigoDelTubo = reader.SafeGetString("CodigoDelTubo", "");
                    item.TuberiaId = reader.SafeGetInt32("TuberiaId", 0);
                    item.NumeroOleoducto = reader.SafeGetString("NumeroOleoducto", "");
                    item.CodigoDelTubo01 = reader.SafeGetString("CodigoDelTubo01", "");
                    item.CodigoDelTubo02 = reader.SafeGetString("CodigoDelTubo02", "");
                    item.CodigoDelTubo03 = reader.SafeGetString("CodigoDelTubo03", "");
                    item.NumeroAnterior = reader.SafeGetInt32("NumeroAnterior", 0);
                    item.NPS = reader.SafeGetDecimal("NPS", 0);
                    item.Schedule = reader.SafeGetInt32("Schedule", 0);
                    item.SHC = reader.SafeGetInt32("SHC", 0);
                    item.TipoMaterial = reader.SafeGetString("TipoMaterial", "");
                    item.Longitud = reader.SafeGetDecimal("Longitud", 0);
                    item.CoordenadasUTM_X = reader.SafeGetString("CoordenadasUTM_X", "");
                    item.CoordenadasUTM_Y = reader.SafeGetString("CoordenadasUTM_Y", "");
                    item.ExtremoInicial1 = reader.SafeGetDecimal("ExtremoInicial1", 0);
                    item.ExtremoInicial2 = reader.SafeGetDecimal("ExtremoInicial2", 0);
                    item.ExtremoInicial3 = reader.SafeGetDecimal("ExtremoInicial3", 0);
                    item.ExtremoInicial4 = reader.SafeGetDecimal("ExtremoInicial4", 0);
                    item.BSCAN = reader.SafeGetDecimal("BSCAN", 0);
                    item.EspesorPared = reader.SafeGetDecimal("EspesorPared", 0);
                    item.ExtremoMedio1 = reader.SafeGetDecimal("ExtremoMedio1", 0);
                    item.ExtremoMedio2 = reader.SafeGetDecimal("ExtremoMedio2", 0);
                    item.ExtremoMedio3 = reader.SafeGetDecimal("ExtremoMedio3", 0);
                    item.ExtremoMedio4 = reader.SafeGetDecimal("ExtremoMedio4", 0);
                    item.MapeoCorrison = reader.SafeGetDecimal("MapeoCorrison", 0);
                    item.PitCorrosion = reader.SafeGetDecimal("PitCorrosion", 0);
                    item.ExtremoFinal1 = reader.SafeGetDecimal("ExtremoFinal1", 0);
                    item.ExtremoFinal2 = reader.SafeGetDecimal("ExtremoFinal2", 0);
                    item.ExtremoFinal3 = reader.SafeGetDecimal("ExtremoFinal3", 0);
                    item.ExtremoFinal4 = reader.SafeGetDecimal("ExtremoFinal4", 0);
                    item.LEFT_MINIMO = reader.SafeGetDecimal("LEFT_MINIMO", 0);
                    item.EspesorRemanente = reader.SafeGetDecimal("EspesorRemanente", 0);
                    item.Defecto = reader.SafeGetString("Defecto", "");
                    item.Defecto2 = reader.SafeGetBoolean("Defecto2", false);
                    item.NumeroGrapas = reader.SafeGetInt32("NumeroGrapas", 0);
                    item.TipoSoporte = reader.SafeGetString("TipoSoporte", "");
                    item.Elastomero = reader.SafeGetBoolean("Elastomero", false);
                    item.Maleza = reader.SafeGetBoolean("Maleza", false);
                    item.TuberiaAlrededor = reader.SafeGetBoolean("TuberiaAlrededor", false);
                    item.Pintura = reader.SafeGetBoolean("Pintura", false);
                    item.CruceCarretera = reader.SafeGetBoolean("CruceCarretera", false);
                    item.TipoProteccion = reader.SafeGetString("TipoProteccion", "");
                    item.EstadoProteccion = reader.SafeGetString("EstadoProteccion", "");
                    item.EstadoTuberia = reader.SafeGetString("EstadoTuberia", "");
                    item.UltimaFechaDeInspeccion = reader.SafeGetDateTime("UltimaFechaDeInspeccion", new DateTime(1950, 01, 01, 0, 0, 0));
                    item.AnioInspeccion = reader.SafeGetInt32("AnioInspeccion", 1950);
                    item.SeleccionarTuberia = reader.SafeGetBoolean("SeleccionarTuberia", false);
                    item.RowState = reader.SafeGetString("RowState", "");
                    item.LastUpdate = reader.SafeGetDateTime("LastUpdate", new DateTime(1950, 01, 01, 0, 0, 0));
                    Result.Add(item);
                }
                reader.Close();
            }
            return Result;
        }


    }

}

