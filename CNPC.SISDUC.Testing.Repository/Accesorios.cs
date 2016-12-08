using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CNPC.SISDUC.Repository.Contracts;
using CNPC.SISDUC.Repository.SqlServer;
using CNPC.SISDUC.Model;
using System.Collections.Generic;
using System.Linq;

namespace CNPC.SISDUC.Testing.Repository
{
    [TestClass]
    public class Accesorios
    {
        [TestMethod]
        public void AgregarAccesorio()
        {
            int Result = 0;
            int valorEsperado = 7;

            Accesorio obj = new Accesorio()
            {
                Id = 0,
                CodigoAccesorio = "",
                CodigoTuberia = "OLB-0001-158-008-A-0-0216",
                CondicionAccesorio = "Regular",
                CoordenadasUTMX = 11,
                CoordenadasUTMY = 22,
                Correlativo = "2155",
                LastUpdate = DateTime.Now,
                Longitud = 12343.5m,
                NombreAccesorio = "Accesorio 101",
                NPS = 12.2m,
                Observaciones = "Accesorio de Prueba 02",
                RowState = "A",
                Schedule = 3,
                TipoMaterial = "Aluminio"
            };

            using (IAccesorioRepositorio repositorio = new AccesorioRepositorio())
            {
                Result = repositorio.Agregar(obj).Id;
            }
            Assert.AreEqual<int>(valorEsperado, Result);
        }
        [TestMethod]
        public void BuscarPorNombre()
        {
            int Result = 0;
            int valorEsperado = 5;

            IEnumerable<Accesorio> lista = new List<Accesorio>();

            using (IAccesorioRepositorio repositorio = new AccesorioRepositorio())
            {
                lista = repositorio.BuscarPorNombre("");
                Result = lista.Count();
            }
            Assert.AreEqual<int>(valorEsperado, Result);

        }
        [TestMethod]
        public void BuscarPorId()
        {
            Accesorio Result = new Accesorio();

            Accesorio valorEsperado = new Accesorio()
            {
                Id = 2,
                CodigoAccesorio = "OLB-0001-158-006-A-0-0216 - CD-02",
                CodigoTuberia = "OLB-0001-158-006-A-0-0216",
                CondicionAccesorio = "Bueno",
                CoordenadasUTMX = 1266,
                CoordenadasUTMY = 76543,
                Correlativo = "CD-02",
                LastUpdate = new DateTime(2016, 11, 01, 17, 01, 40, 527),
                Longitud = 1.4m,
                NombreAccesorio = "Accesorio 001",
                NPS = 0,
                Observaciones = "Ninguno",
                RowState = "A",
                Schedule = 2,
                TipoMaterial = "Cemento",
                RegistroInspeccionVisualId = 1
            };

            using (IAccesorioRepositorio repositorio = new AccesorioRepositorio())
            {
                Result = repositorio.BuscarPorId(2);
            }
            Assert.AreEqual<Accesorio>(valorEsperado, Result);
        }
        [TestMethod]
        public void BuscarPorCodigo()
        {
            Accesorio Result = new Accesorio();

            Accesorio valorEsperado = new Accesorio()
            {
                Id = 2,
                CodigoAccesorio = "OLB-0001-158-006-A-0-0216 - CD-02",
                CodigoTuberia = "OLB-0001-158-006-A-0-0216",
                CondicionAccesorio = "Bueno",
                CoordenadasUTMX = 1266,
                CoordenadasUTMY = 76543,
                Correlativo = "CD-02",
                LastUpdate = new DateTime(2016, 11, 22, 13, 48, 22, 790),
                Longitud = 1.4m,
                NombreAccesorio = "Accesorio 001",
                NPS = 0,
                Observaciones = "Ninguno",
                RowState = "A",
                Schedule = 2,
                TipoMaterial = "Cemento",
                RegistroInspeccionVisualId = 1
            };

            using (IAccesorioRepositorio repositorio = new AccesorioRepositorio())
            {
                Result = repositorio.BuscarPorCodigo("OLB-0001-158-006-A-0-0216 - CD-02");
            }
            Assert.AreEqual<Accesorio>(valorEsperado, Result);
        }
        [TestMethod]
        public void Actualizar()
        {
            Accesorio Result = new Accesorio();

            Accesorio valorPrueba = new Accesorio()
            {
                Id = 2,
                CodigoAccesorio = "OLB-0001-158-006-A-0-0216 - CD-02",
                CodigoTuberia = "OLB-0001-158-006-A-0-0216",
                CondicionAccesorio = "Bueno",
                CoordenadasUTMX = 1266,
                CoordenadasUTMY = 76543,
                Correlativo = "CD-05",
                LastUpdate = new DateTime(2016, 11, 01, 17, 01, 40, 527),
                Longitud = 1.4m,
                NombreAccesorio = "Accesorio 001",
                NPS = 0,
                Observaciones = "Ninguno",
                RowState = "A",
                Schedule = 2,
                TipoMaterial = "Cemento",
                RegistroInspeccionVisualId = 1
            };

            using (IAccesorioRepositorio repositorio = new AccesorioRepositorio())
            {
                repositorio.Actualizar(valorPrueba);
                Result = repositorio.BuscarPorId(2);

            }
            Assert.AreEqual<Accesorio>(valorPrueba, Result);
        }
        [TestMethod]
        public void Eliminar()
        {
            string Result = string.Empty;
            string valorEsperado = "D";
            Accesorio valorPrueba = new Accesorio()
            {
                Id = 2,
                LastUpdate = DateTime.Now,
                RowState = "D",
            };

            using (IAccesorioRepositorio repositorio = new AccesorioRepositorio())
            {
                repositorio.Eliminar(2);
                Result = repositorio.BuscarPorId(2).RowState;

            }
            Assert.AreEqual<string>(valorEsperado, Result);
        }
    }
}
