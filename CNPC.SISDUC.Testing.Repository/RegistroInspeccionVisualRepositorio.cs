using CNPC.SISDUC.Model;
using CNPC.SISDUC.Repository.Contracts;
using CNPC.SISDUC.Repository.SqlServer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CNPC.SISDUC.Testing.Repository
{
    [TestClass]
    public class RegistroInspeccionVisualRepositorioTest
    {
        [TestMethod]
        public void Actualizar()
        {
            RegistroInspeccionVisual Result = new RegistroInspeccionVisual();

            RegistroInspeccionVisual valorPrueba = new RegistroInspeccionVisual()
            {
                Id = 17,
                OleoductoID = 1,
                NumeroOleoducto = "OLB-0001-158",
                CodigoDelTubo01 = "010-A",
                CodigoDelTubo02 = "0",
                CodigoDelTubo03 = "0216",
                NumeroAnterior = 0,
                NPS = 1.2m,
                SHC = 4,
                Schedule = 2,
                TipoMaterial = "Cemento",
                Longitud = 1.4m,
                CoordenadasUTM_X = "1266",
                CoordenadasUTM_Y = "76543",
                ExtremoInicial1 = 1.2m,
                ExtremoInicial2 = 1.1m,
                ExtremoInicial3 = 1.3m,
                ExtremoInicial4 = 1.5m,
                BSCAN = 1.01m,
                EspesorPared = 1.02m,
                ExtremoMedio1 = 1.05m,
                ExtremoMedio2 = 1.06m,
                ExtremoMedio3 = 1.07m,
                ExtremoMedio4 = 1.08m,
                PitCorrosion = 0.9m,
                ExtremoFinal1 = 1.9m,
                ExtremoFinal2 = 1.8m,
                ExtremoFinal3 = 1.7m,
                ExtremoFinal4 = 1.6m,
                LEFT_MINIMO = 0.3m,
                Defecto = "Ninguno",
                Defecto2 = true,
                NumeroGrapas = 10,
                TipoSoporte = "Ninguno",
                Elastomero = true,
                Maleza = true,
                TuberiaAlrededor = true,
                Pintura = true,
                CruceCarretera = true,
                TipoProteccion = "",
                EstadoProteccion = "Ninguno",
                EstadoTuberia = "AAA",
                UltimaFechaDeInspeccion = new DateTime(2016, 1, 1),
                SeleccionarTuberia = true,
                LastUpdate = new DateTime(2016, 11, 01, 17, 01, 40, 527),
                RowState = "D",
            };

            using (IRegistroInspeccionVisualRepositorio repositorio = new RegistroInspeccionVisualRepositorio())
            {
                repositorio.Actualizar(valorPrueba);
                Result = repositorio.BuscarPorId(17);

            }
            Assert.AreEqual<string>(valorPrueba.EstadoTuberia, Result.EstadoTuberia);
        }
    }
}
