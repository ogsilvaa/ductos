using CNPC.SISDUC.Model.Servicio;
using System;
using System.Web.Mvc;
using PagedList;
using CNPC.SISDUC.Model;
using System.Collections.Generic;
using CNPC.SISDUC.WEB.Models;
using CNPC.SISDUC.Web.Proxy;

namespace CNPC.SISDUC.WEB.Controllers
{
    public class AccesoriosController : Controller
    {
        // GET: Accesorios
        public ActionResult Index(string TuberiaId, int? page, string search = "", int pageSize = 10)
        {
            AccesorioResponse Resultado = null;
            // RegistroInspeccionVisualModel modelo = null;

            ServicioClient proxy = new ServicioClient();
            string error = String.Empty;
            Resultado = proxy.AccesoriosListarPorNombreYTuberia(TuberiaId, search);
            ViewBag.CodigoTuberia = TuberiaId;
            List<AccesoriosModels> modelo = Resultado.ConvertToViewModel();
            return View(modelo);
            //int pageNumber = (page ?? 1);
            //return View(modelo.ToPagedList(pageNumber, pageSize));
        }

        // GET: Accesorios/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Accesorios/Create
        public ActionResult Create(string codigoTuberia)
        {
            return View(new AccesorioResponse() { Item = new Accesorio { CodigoTuberia = codigoTuberia }, MensajeError = "" });
        }

        // POST: Accesorios/Create
        [HttpPost]
        public ActionResult Create(AccesorioResponse nuevo)
        {
            try
            {
                // TODO: Add insert logic here
                AccesoriosRequest registro = new AccesoriosRequest();
                AccesorioResponse resultado = new AccesorioResponse();
                var proxy = new ServicioClient();
                if (ModelState.IsValid)
                {
                    try
                    {
                        nuevo.Item.RowState = "A";
                        nuevo.Item.LastUpdate = DateTime.Now;
                        registro.Item = nuevo.Item;
                        registro.Operacion = Model.Operacion.Agregar;
                        resultado = proxy.AccesoriosEjecutarOperacion(registro);
                        if (resultado.Resultado) return RedirectToAction("Index", new { id = registro.Item.CodigoTuberia });
                        else return View(resultado);
                    }
                    catch (Exception ex)
                    {
                        resultado.MensajeError = ex.Message;
                    }
                }
                else
                {
                    resultado.MensajeError = "Error en el ingreso de Datos";
                }
                return View(resultado);
                //////////////

            }
            catch
            {
                return View();
            }
        }

        // GET: Accesorios/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Accesorios/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Accesorios/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Accesorios/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
