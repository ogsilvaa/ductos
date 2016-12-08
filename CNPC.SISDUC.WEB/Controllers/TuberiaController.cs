using CNPC.SISDUC.Model.Servicio;
using System;
using System.Web.Mvc;
using PagedList;
using CNPC.SISDUC.Model;
using System.Collections.Generic;
using CNPC.SISDUC.WEB.Models;
using CNPC.SISDUC.Web.Proxy;
using log4net;
using CNPC.SISDUC.WEB.Recursos;
//using CNPC.SISDUC.WEB.Proxy;

namespace CNPC.SISDUC.WEB.Controllers
{
    [HandleError]
    public class TuberiaController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(TuberiaController));
        // GET: Tuberia
        public ActionResult Index()
        {
            Log.Info("call: TuberiaController.Index ()");
            return View();
        }

        public ActionResult Create(int id)
        {
            Log.Info("call: TuberiaController.Create (" + id + ")");
            RegistroInspeccionVisualModel Entidad = new RegistroInspeccionVisualModel();

            var proxy = new ServicioClient();

            OleoductoResponse oleoducto =
               proxy.OleoductoEjecutarOperacion(new OleoductoRequest
               {
                   Item = new Model.Oleoducto
                   {
                       Id = id
                   },
                   Operacion = Model.Operacion.BuscarPorId
               });

            //ViewBag.oleoducto = oleoducto.Item;
            var Modelo_Oleo = oleoducto.Item.ConvertToViewModel();

            List<SelectListItem> list = new List<SelectListItem>();
            var listado = proxy.TipoSoporteListarAllEntidad();
            foreach (var item in listado.List)
            {
                var newItem = new SelectListItem { Text = item.Nombre, Value = item.Valor };
                list.Add(newItem);
            }
            //resultado.ListTipoSoporte = proxy.TipoSoporteListarAllEntidad();

            //Entidad.ListaTipoSoporte = resultado.ListTipoSoporte;
            Entidad.oleoducto = oleoducto.Item;
            Entidad.ListaTipoSoporte = list;
            Entidad.OleoductoID = Modelo_Oleo.Id;
            Entidad.NumeroOleoducto = Modelo_Oleo.Codigo;


            RegistroInspeccionVisualResponse Resultado = null;
            Resultado = proxy.RegistroInspeccionVisualListarEliminados(DateTime.Now.Year, Entidad.OleoductoID);
            Entidad.ListaEliminados = Resultado.ConvertToViewModel();

            return View(Entidad);

        }

        public ActionResult Details(int id, int Codigo)
        {
            Log.Info("call: TuberiaController.Details (" + id + ", " + Codigo + ")");
            var proxy = new ServicioClient();
            RegistroInspeccionVisualRequest registro = new RegistroInspeccionVisualRequest();
            RegistroInspeccionVisualResponse resultado = null;

            registro.Item = new RegistroInspeccionVisual { Id = id };
            registro.Operacion = Model.Operacion.BuscarPorId;
            resultado = proxy.RegistroInspeccionVisualEjecutarOperacion(registro);

            OleoductoResponse oleoducto =
                proxy.OleoductoEjecutarOperacion(new OleoductoRequest
                {
                    Item = new Model.Oleoducto
                    {
                        Id = Codigo
                    },
                    Operacion = Model.Operacion.BuscarPorId
                });
            ViewBag.oleoducto = oleoducto.Item;

            return View(resultado.Item.ConvertToViewModel());

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(string hd_id_oleoducto, int id_oleoducto, int hd_id_tuberia, string Motivo, string OrdenServicio)
        {
            Log.Info("call: TuberiaController.Eliminar (hd_id_oleoducto: " + hd_id_oleoducto + ",id_oleoducto: " + id_oleoducto + ",hd_id_tuberia: " + hd_id_tuberia + ",Motivo: " + Motivo + ",OrdenServicio: " + OrdenServicio + ")");
            CambiosTuberiaRequest registro = new CambiosTuberiaRequest();
            CambiosTuberiaResponse resultado = null;
            CambiosTuberia Entidad = new CambiosTuberia();
            var proxy = new ServicioClient();

            RegistroInspeccionVisualResponse Tuberia =
                proxy.RegistroInspeccionVisualEjecutarOperacion(new RegistroInspeccionVisualRequest
                {
                    Item = new Model.RegistroInspeccionVisual
                    {
                        Id = hd_id_tuberia
                    },
                    Operacion = Model.Operacion.BuscarPorId
                });

            Entidad.Id = hd_id_tuberia;
            Entidad.NumeroOleoducto = hd_id_oleoducto;
            Entidad.CodigoDelTubo01 = Tuberia.Item.CodigoDelTubo;
            Entidad.LastUpdate = DateTime.Now;
            Entidad.OrdenServicio = OrdenServicio;
            Entidad.Motivo = Motivo;
            Entidad.RowState = "A";

            registro.Item = Entidad;
            registro.Operacion = Model.Operacion.Agregar;
            resultado = proxy.CambiosTuberiaEjecutarOperacion(registro);

            RegistroInspeccionVisualResponse ElimTuberia =
               proxy.RegistroInspeccionVisualEjecutarOperacion(new RegistroInspeccionVisualRequest
               {
                   Item = new Model.RegistroInspeccionVisual
                   {
                       Id = hd_id_tuberia
                   },
                   Operacion = Model.Operacion.Eliminar
               });

            return RedirectToAction("List/" + id_oleoducto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RegistroInspeccionVisual nuevaTuberia,
            string motivo, string OrdenServicio, string id_marcados)
        {
            RegistroInspeccionVisualRequest registro = new RegistroInspeccionVisualRequest();

            RegistroInspeccionVisualResponse resultado = null;
            var proxy = new ServicioClient();
            if (ModelState.IsValid)
            {
                try
                {

                    nuevaTuberia.RowState = "A";
                    nuevaTuberia.LastUpdate = DateTime.Now;
                    nuevaTuberia.CodigoDelTubo02 = "0";
                    nuevaTuberia.CodigoDelTubo03 = "0216";
                    nuevaTuberia.CodigoDelTubo = string.Format("{0}-{1}-{2}-{3}", nuevaTuberia.NumeroOleoducto
                        , nuevaTuberia.CodigoDelTubo01
                        , nuevaTuberia.CodigoDelTubo02
                        , nuevaTuberia.CodigoDelTubo03);

                    registro.Item = nuevaTuberia;
                    registro.Operacion = Model.Operacion.Agregar;
                    resultado = proxy.RegistroInspeccionVisualEjecutarOperacion(registro);

                    //REGISTRO DE CAMBIOS
                    CambiosTuberiaRequest CambioRequest = new CambiosTuberiaRequest();
                    CambiosTuberiaResponse CambioResponse = null;

                    if (motivo == "Agregado")
                    {
                        CambiosTuberia Cambio = new CambiosTuberia();
                        Cambio.NumeroOleoducto = nuevaTuberia.NumeroOleoducto;
                        Cambio.CodigoDelTubo01 = nuevaTuberia.CodigoDelTubo;
                        Cambio.CodigoDelTuboReemplazado = "";
                        Cambio.LastUpdate = DateTime.Now;
                        Cambio.OrdenServicio = OrdenServicio;
                        Cambio.Motivo = motivo;
                        Cambio.RowState = "A";

                        CambioRequest.Item = Cambio;
                        CambioRequest.Operacion = Model.Operacion.Agregar;
                        CambioResponse = proxy.CambiosTuberiaEjecutarOperacion(CambioRequest);
                    }
                    else
                    {
                        foreach (var item in id_marcados.Split(','))
                        {
                            CambiosTuberia Cambio = new CambiosTuberia();
                            Cambio.NumeroOleoducto = nuevaTuberia.NumeroOleoducto;
                            Cambio.CodigoDelTubo01 = nuevaTuberia.CodigoDelTubo;
                            Cambio.CodigoDelTuboReemplazado = item;
                            Cambio.LastUpdate = DateTime.Now;
                            Cambio.OrdenServicio = OrdenServicio;
                            Cambio.Motivo = motivo;
                            Cambio.RowState = "A";

                            CambioRequest.Item = Cambio;
                            CambioRequest.Operacion = Model.Operacion.Agregar;
                            CambioResponse = proxy.CambiosTuberiaEjecutarOperacion(CambioRequest);
                        }
                    }

                    //FIN REGISTRO DE CAMBIOS

                    if (resultado.Resultado) return RedirectToAction("List/" + nuevaTuberia.OleoductoID);
                    else return View(nuevaTuberia.ConvertToViewModel());
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
        }

        [HttpGet]
        //public ActionResult List(int id, int page, string search = "", int pageSize = 10)
        public ActionResult List(int id)
        {
            Log.Info("call: TuberiaController.List (" + id + ")");
            RegistroInspeccionVisualResponse Resultado = new RegistroInspeccionVisualResponse();
            List<RegistroInspeccionVisualModel> modelo = new List<RegistroInspeccionVisualModel>(); ;

            ServicioClient proxy = new ServicioClient();
            string error = String.Empty;
            
            try
            {
                Log.Info("call: RegistroInspeccionVisualListarByDucto (" + id + ")");
                Resultado = proxy.RegistroInspeccionVisualListarByDucto(id, "", "A");
                Log.Info("Registros encontrados " + Resultado.List.Length);

                OleoductoResponse oleoducto =
                                proxy.OleoductoEjecutarOperacion(new OleoductoRequest
                                {
                                    Item = new Model.Oleoducto
                                    {
                                        Id = id
                                    },
                                    Operacion = Model.Operacion.BuscarPorId
                                });
                modelo = Resultado.ConvertToViewModel();
                ViewBag.oleoducto = oleoducto.Item;
            }
            catch (Exception ex)
            {
                Log.ErrorFormat(LogMensajes.ErrorGenericoFormat, ex.Message, ex.StackTrace);
            }
            int pageNumber = 1;
            return View(modelo.ToPagedList(pageNumber, 10));
        }

        [HttpGet]
        public ActionResult GetTuberia(int id, string name)
        {
            Log.Info("call: TuberiaController.GetTuberia (" + id + ", " + name + ")");
            ServicioClient proxy = new ServicioClient();
            RegistroInspeccionVisualRequest registro = new RegistroInspeccionVisualRequest();
            RegistroInspeccionVisualResponse resultado = new RegistroInspeccionVisualResponse();
            RegistroInspeccionVisualModel modelo = new RegistroInspeccionVisualModel();
            if (ModelState.IsValid)
            {
                try
                {
                    registro.Item = new RegistroInspeccionVisual { Id = id };
                    registro.Operacion = Model.Operacion.BuscarPorId;
                    resultado = proxy.RegistroInspeccionVisualEjecutarOperacion(registro);
                    resultado.ListTipoSoporte = proxy.TipoSoporteListarAllEntidad();

                    
                    modelo = resultado.Item.ConvertToViewModel();

                    List<SelectListItem> list = new List<SelectListItem>();
                    foreach (var item in resultado.ListTipoSoporte.List)
                    {
                        var newItem = new SelectListItem { Text = item.Nombre, Value = item.Valor };
                        list.Add(newItem);
                    }
                    modelo.ListaTipoSoporte = list;

                    OleoductoResponse ducto = proxy.OleoductoEjecutarOperacion(
                        new OleoductoRequest
                        {
                            Item = new Oleoducto { Id = resultado.Item.OleoductoID },
                            Operacion = Operacion.BuscarPorId
                        });
                    modelo.oleoducto = ducto.Item;

                }
                catch (Exception ex)
                {
                    Log.ErrorFormat(LogMensajes.ErrorGenericoFormat, ex.Message, ex.StackTrace);
                }
            }
            else
            {
                resultado.MensajeError = "Error en el ingreso de Datos";
            }

            return View(modelo);
        }
        public IEnumerable<RegistroInspeccionVisual> GetIEnumerable(List<RegistroInspeccionVisual> lista)
        {
            List<RegistroInspeccionVisual> books = lista;
            return books;
        }
        [HttpPost]
        public ActionResult ActualizarTuberia(RegistroInspeccionVisualModel model, string returnUrl)
        {
            ServicioClient proxy = new ServicioClient();
            RegistroInspeccionVisualRequest registro = new RegistroInspeccionVisualRequest();
            RegistroInspeccionVisualResponse resultado = null;
            RegistroInspeccionVisual modelo = new RegistroInspeccionVisual();
            modelo = model.ConvertToModel();

            OleoductoResponse resultados =
             proxy.OleoductoEjecutarOperacion(new OleoductoRequest
             {
                 Item = new Model.Oleoducto
                 {
                     Id = modelo.OleoductoID
                 },
                 Operacion = Model.Operacion.BuscarPorId
             });

            if (ModelState.IsValid)
            {
                try
                {
                    modelo.RowState = "A";
                    modelo.LastUpdate = DateTime.Now;
                    modelo.NumeroOleoducto = resultados.Item.Codigo;
                    modelo.CodigoDelTubo02 = "0";
                    modelo.CodigoDelTubo03 = "0216";
                    modelo.CodigoDelTubo = string.Format("{0}-{1}-{2}-{3}", modelo.NumeroOleoducto
                                                                            , modelo.CodigoDelTubo01
                                                                            , modelo.CodigoDelTubo02
                                                                            , modelo.CodigoDelTubo03);
                    modelo.UltimaFechaDeInspeccion = DateTime.Now;
                    registro.Item = modelo;
                    registro.Operacion = Model.Operacion.Actualizar;
                    resultado = proxy.RegistroInspeccionVisualEjecutarOperacion(registro);
                    if (resultado.Resultado) return RedirectToAction("List/" + model.OleoductoID);
                    else return View(model);
                    //OleoductoResponse ducto = proxy.OleoductoEjecutarOperacion(
                    //    new OleoductoRequest
                    //    {
                    //        Item = new Oleoducto { Id = resultado.Item.OleoductoID },
                    //        Operacion = Operacion.BuscarPorId
                    //    });

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

            return View(modelo);
        }

    }
}