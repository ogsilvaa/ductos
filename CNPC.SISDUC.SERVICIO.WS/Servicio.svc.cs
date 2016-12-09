using System;
using CNPC.SISDUC.Model.Servicio;
using CNPC.SISDUC.Model;
using System.Linq;
using log4net;
using CNPC.SISDUC.SERVICIO.WS.Recursos;
using CNPC.SISDUC.Domain;
using CNPC.SISDUC.Domain.Exceptions;

namespace CNPC.SISDUC.SERVICIO.WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Servicio : IServicio
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Servicio));
        //Servicio para Oleoductos
        public OleoductoResponse OleoductoEjecutarOperacion(OleoductoRequest request)
        {
            var response = new OleoductoResponse { Item = request.Item };
            try
            {
                Log.Info("Call OleoductoEjecutarOperacion: Operacion: " + request.Operacion + ", request: " + request.Item.Codigo);
                using (var dominio = new OleoductoDomain())
                {
                    response.Resultado = false;
                    switch (request.Operacion)
                    {
                        case Operacion.Agregar:
                            {
                                response.Item = dominio.Agregar(request.Item);
                                response.Resultado = true;
                            }
                            break;
                        case Operacion.Actualizar:
                            {
                                response.Resultado = dominio.Actualizar(request.Item);
                                response.Resultado = true;
                            }
                            break;
                        case Operacion.Eliminar:
                            {
                                response.Resultado = dominio.Eliminar(request.Item.Id);
                                response.Resultado = true;
                            }

                            break;
                        case Operacion.BuscarPorId:
                            {
                                response.Item = dominio.FilterByID(request.Item.Id);
                                if (response.Item != null)
                                    response.Resultado = true;
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                response.Resultado = false;
                Log.ErrorFormat(LogMensajes.ErrorGenericoFormat, ex.Message, ex.StackTrace);
            }

            return response;
        }
        public OleoductoResponse OleoductoEnviarActualizaciones(OleoductoListaRequest request)
        {
            throw new NotImplementedException();
        }
        public OleoductoResponse OleoductoListarAllEntidad(string prefijo, string nombre)
        {
            OleoductoResponse response = new OleoductoResponse();
            try
            {
                using (var dominio = new OleoductoDomain())
                {
                    response.List = dominio.GetListOleoductosByNombre(prefijo, nombre);
                    response.Resultado = true;
                }
            }
            catch (Exception ex)
            {
                response.Resultado = false;
                Log.ErrorFormat(LogMensajes.ErrorGenericoFormat, ex.Message, ex.StackTrace);
            }
            return response;
        }
        public OleoductoResponse OleoductoListarEntidad(string prefijo, string search = null, int page = 1, int rowsPerPage = 10)
        {
            OleoductoResponse response = null;
            try
            {
                using (var dominio = new OleoductoDomain())
                {
                    response = dominio.FilterByName(prefijo, search, page, rowsPerPage);
                    response.Resultado = true;
                }
            }
            catch (Exception ex)
            {
                response.Resultado = false;

                Log.ErrorFormat(LogMensajes.ErrorGenericoFormat, ex.Message, ex.StackTrace);
            }
            return response;
        }

        public InventarioResponse ObtenerInventario()
        {
            var response = new InventarioResponse();
            try
            {
                using (var dominio = new OleoductoDomain())
                {
                    response.List = dominio.ObtenerInventario();
                    response.Resultado = true;
                }
            }
            catch (Exception ex)
            {
                response.Resultado = false;
                Log.ErrorFormat(LogMensajes.ErrorGenericoFormat, ex.Message, ex.StackTrace);
            }
            return response;
        }

        //Servicio para CambiosTuberia
        public CambiosTuberiaResponse CambiosTuberiaEjecutarOperacion(CambiosTuberiaRequest request)
        {
            CambiosTuberiaResponse response = new CambiosTuberiaResponse();
            try
            {
                using (var dominio = new CambiosTuberiaDomain())
                {
                    CambiosTuberia item = request.Item;
                    switch (request.Operacion)
                    {
                        case Operacion.Agregar:
                            {

                                response.Item = dominio.Agregar(item);
                            }
                            break;
                        case Operacion.Actualizar:
                            {
                                response.Resultado = dominio.Actualizar(item);
                            }
                            break;
                        case Operacion.Eliminar:
                            {
                                response.Resultado = dominio.Eliminar(item.Id);
                            }
                            break;
                    }
                    response.Resultado = true;
                }
            }
            catch (Exception ex)
            {
                response.Resultado = false;
                response.MensajeError = ex.Message;// + " "+ ex.InnerException + " " + ex.StackTrace;;
            }

            return response;
        }
        public CambiosTuberiaResponse CambiosTuberiaListarAllEntidad()
        {
            CambiosTuberiaResponse response = new CambiosTuberiaResponse();
            try
            {
                using (var dominio = new CambiosTuberiaDomain())
                {
                    response = dominio.GetListCambiosTuberia("", 0, 1, 10);
                    response.Resultado = true;
                }
            }
            catch (Exception ex)
            {
                response.Resultado = false;
                response.MensajeError = ex.Message;//+ " "+ ex.InnerException + " " + ex.StackTrace; 
            }
            return response;
        }
        public CambiosTuberiaResponse CambiosTuberiaListarEntidad(string oleoducto, int TuberiaId = 0, int page = 1, int rowsPerPage = 10)
        {
            CambiosTuberiaResponse response = new CambiosTuberiaResponse();
            try
            {
                using (var dominio = new CambiosTuberiaDomain())
                {
                    response = dominio.GetListCambiosTuberia(oleoducto, TuberiaId, page, rowsPerPage);
                    response.Resultado = true;
                }

            }
            catch (Exception ex)
            {
                response.Resultado = false;
                response.MensajeError = ex.Message + " " + ex.InnerException + " " + ex.StackTrace;
            }
            return response;
        }

        //Servicio para Accesorios
        public AccesorioResponse AccesoriosEjecutarOperacion(AccesoriosRequest request)
        {
            AccesorioResponse response = new AccesorioResponse();
            try
            {
                using (var dominio = new AccesorioDomain())
                {
                    switch (request.Operacion)
                    {
                        case Operacion.Agregar:
                            {
                                response.Item = dominio.Agregar(request.Item);
                            }
                            break;
                        case Operacion.Actualizar:
                            {
                                response.Resultado = dominio.Actualizar(request.Item);
                            }
                            break;
                        case Operacion.Eliminar:
                            {
                                response.Resultado = dominio.Eliminar(request.Item.Id);
                            }
                            break;
                    }
                    response.Resultado = true;
                }
            }
            catch (Exception ex)
            {
                response.Resultado = false;
                response.MensajeError = ex.Message;// + " "+ ex.InnerException + " " + ex.StackTrace;;
            }

            return response;
        }
        public AccesorioResponse AccesoriosListarPorTuberia(int anio, int TuberiaId)
        {
            AccesorioResponse response = new AccesorioResponse();
            try
            {
                using (var dominio = new AccesorioDomain())
                {
                    response.List = dominio.BuscarPorOleoducto(anio, TuberiaId, "", 1, 10).ToList();
                    response.Resultado = true;
                }
            }
            catch (Exception ex)
            {
                response.Resultado = false;
                response.MensajeError = ex.Message;//+ " "+ ex.InnerException + " " + ex.StackTrace; 
            }
            return response;
        }
        public AccesorioResponse AccesoriosListarEntidad(int oleoductoId, string search = null, int page = 1, int rowsPerPage = 10)
        {
            AccesorioResponse response = new AccesorioResponse();
            try
            {
                using (var dominio = new AccesorioDomain())
                {
                    response.List = dominio.BuscarPorOleoducto(DateTime.Now.Year, oleoductoId, search, page, rowsPerPage).ToList();
                    response.Resultado = true;
                }
            }
            catch (Exception ex)
            {
                response.Resultado = false;
                response.MensajeError = ex.Message;//+ " "+ ex.InnerException + " " + ex.StackTrace; 
            }
            return response;
        }
        public AccesorioResponse AccesoriosListarPorNombreYTuberia(string IdTuberia, string search = null)
        {
            AccesorioResponse response = new AccesorioResponse();
            try
            {
                using (var dominio = new AccesorioDomain())
                {
                    response = dominio.FilterByTuberiaAccesorios(IdTuberia, search);
                    response.Resultado = true;
                }
            }
            catch (Exception ex)
            {
                response.Resultado = false;
                response.MensajeError = ex.Message;//+ " "+ ex.InnerException + " " + ex.StackTrace; 
            }
            return response;
        }
        //Servicio para las Constantes
        public TipoSoporteResponse TipoSoporteListarAllEntidad()
        {
            TipoSoporteResponse response = new TipoSoporteResponse();
            try
            {
                using (var dominio = new TipoSoporteDomain())
                {
                    response = dominio.GetListTipoSoporte();
                    response.Resultado = true;
                }
            }
            catch (Exception ex)
            {
                response.Resultado = false;
                response.MensajeError = ex.Message + "\n " + ex.InnerException + " " + ex.StackTrace;
            }
            return response;
        }


        //Servicio para las RegistroInspeccionVisual
        public RegistroInspeccionVisualResponse RegistroInspeccionVisualEjecutarOperacion(RegistroInspeccionVisualRequest request)
        {
            RegistroInspeccionVisualResponse response = new RegistroInspeccionVisualResponse();
            try
            {
                using (var dominio = new RegistroInspeccionVisualDomain())
                {
                    switch (request.Operacion)
                    {
                        case Operacion.Agregar:
                            {
                                response.Item = dominio.Agregar(request.Item);
                            }
                            break;
                        case Operacion.Actualizar:
                            {
                                response.Resultado = dominio.Actualizar(request.Item);
                            }
                            break;
                        case Operacion.Eliminar:
                            {
                                response.Resultado = dominio.Eliminar(request.Item.Id);
                            }
                            break;
                        case Operacion.BuscarPorId:
                            {
                                response.Item = dominio.BuscarById(request.Item.Id);
                                if (response.Item != null)
                                {
                                    response.Resultado = true;
                                }
                                else
                                {
                                    response.Resultado = false;
                                }
                            }
                            break;
                    }
                    response.Resultado = true;
                }
            }
            catch (Exception ex)
            {
                response.Resultado = false;
                Log.ErrorFormat(LogMensajes.ErrorGenericoFormat, ex.Message, ex.StackTrace);
            }

            return response;
        }
        public RegistroInspeccionVisualResponse RegistroInspeccionVisualListarEliminados(int anio, int ductoId)
        {
            RegistroInspeccionVisualResponse response = new RegistroInspeccionVisualResponse();
            try
            {
                using (var dominio = new RegistroInspeccionVisualDomain())
                {
                    response.List = dominio.RegistroInspeccionVisualListarEliminados(DateTime.Now.Year, ductoId).ToList();
                    using (var dominioOleoducto = new OleoductoDomain())
                    {
                        response.oleoducto = dominioOleoducto.FilterByID(ductoId);
                        response.Resultado = true;
                    }
                }

            }
            catch (Exception ex)
            {
                response.Resultado = false;
                Log.ErrorFormat(LogMensajes.ErrorGenericoFormat, ex.Message, ex.StackTrace);
            }
            return response;
        }

        public RegistroInspeccionVisualResponse RegistroInspeccionVisualListarByDucto(int ductoId, string search = "", string Estado = null, int anio = 0)
        {

            RegistroInspeccionVisualResponse response = new RegistroInspeccionVisualResponse();
            try
            {
                using (var dominio = new RegistroInspeccionVisualDomain())
                {
                    response.List = dominio.GetListRegistroInspeccionVisualByNombre(anio, ductoId, search).ToList();
                    using (var dominioOleoducto = new OleoductoDomain())
                    {
                        response.oleoducto = dominioOleoducto.FilterByID(ductoId);
                        response.Resultado = true;
                    }
                }

            }
            catch (Exception ex)
            {
                response.Resultado = false;
                Log.ErrorFormat(LogMensajes.ErrorGenericoFormat, ex.Message, ex.StackTrace);
            }
            return response;
        }




        //Servicio para Usuario
        //public int ListCountUsuario()
        //{
        //    var result = 0;
        //    try
        //    {
        //        using (var proxy = new UsuarioBLL())
        //        {
        //            result = proxy.ListCount();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (new Exception("Error: " + ex.Message));
        //    }
        //    return result;
        //}
        //public UsuarioResponse UsuarioEjecutarOperacion(UsuarioRequest request)
        //{
        //    var response = new UsuarioResponse { Item = request.Item };
        //    try
        //    {
        //        using (var dominio = new UsuarioBLL())
        //        {
        //            request.Item.Contrasenia = SHA1.Encode(request.Item.Contrasenia);
        //            switch (request.Operacion)
        //            {
        //                case Operacion.Agregar:
        //                    {
        //                        response.Item = dominio.Create(request.Item);
        //                    }
        //                    break;
        //                case Operacion.Actualizar:
        //                    {
        //                        response.Resultado = dominio.Update(request.Item);
        //                    }
        //                    break;
        //                case Operacion.Eliminar:
        //                    {
        //                        response.Resultado = dominio.Delete(request.Item.Id);
        //                    }
        //                    break;
        //            }
        //            response.Resultado = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Resultado = false;
        //        response.MensajeError = ex.Message;//+ " "+ ex.InnerException + " " + ex.StackTrace;
        //    }

        //    return response;
        //}
        //public UsuarioResponse UsuarioBuscarEntidad(UsuarioRequest request)
        //{
        //    var response = new UsuarioResponse();
        //    try
        //    {
        //        using (var dominio = new UsuarioBLL())
        //        {
        //            response.Item = dominio.RetrieveByID(request.Item.Id);
        //            response.Resultado = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Resultado = false;
        //        response.MensajeError = ex.Message;//+ " "+ ex.InnerException + " " + ex.StackTrace;
        //    }

        //    return response;
        //}
        //public UsuarioResponse UsuarioListarAllEntidad(string rowState)
        //{
        //    var response = new UsuarioResponse();
        //    try
        //    {
        //        using (var dominio = new UsuarioBLL())
        //        {
        //            response.List = dominio.List(rowState).ToList();
        //            response.Resultado = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Resultado = false;
        //        response.MensajeError = ex.Message;//+ " "+ ex.InnerException + " " + ex.StackTrace;
        //    }
        //    return response;
        //}

        //public UsuarioResponse ValidaLogin(UsuarioRequest request)
        //{
        //    UsuarioResponse response = new UsuarioResponse();
        //    try
        //    {
        //        response.Item = null;
        //        response.Resultado = false;
        //        using (var dominio = new UsuarioBLL())
        //        {
        //            response.Item = dominio.ValidaLogin(request.Item);
        //            response.Resultado = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Resultado = false;
        //        response.MensajeError = ex.Message;//+ " "+ ex.InnerException + " " + ex.StackTrace;
        //    }
        //    return response;
        //}
        //public bool ValidaRolconAccion(int rolid, string controller)
        //{
        //    var response = false;
        //    try
        //    {
        //        using (var dominio = new UsuarioBLL())
        //        {
        //            response = dominio.ValidaRolconAccion(rolid, controller);

        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return response;
        //}
        //public int ListCountUsuario(ref string error)
        //{
        //    throw new NotImplementedException();
        //}

    }
}
