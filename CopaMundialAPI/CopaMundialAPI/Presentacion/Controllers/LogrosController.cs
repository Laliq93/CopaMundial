using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Logica_de_Negocio.Fabrica;
using CopaMundialAPI.Logica_de_Negocio.Comando;
using CopaMundialAPI.Servicios.DTO.Logros;
using CopaMundialAPI.Servicios.Fabrica;
using CopaMundialAPI.Comun.Excepciones;
using CopaMundialAPI.Servicios.Traductores.Logros;
using CopaMundialAPI.Servicios.Traductores.Fabrica;
using NLog;

namespace CopaMundialAPI.Presentacion.Controllers
{
    [RoutePrefix ( "api/logros" )]
    public class LogrosController : ApiController
    {
        Logger logger = LogManager.GetLogger("fileLogger");

        [Route("agregarLogroCantidad")]
        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage AgregarLogroCantidad(DTOLogroCantidad dto)
        {
            try
            {
                TraductorLogroCantidad traductor = FabricaTraductor.CrearTraductorLogroCantidad();

                Entidad logroCantidad = traductor.CrearEntidad(dto);

                Comando comando;

                comando = FabricaComando.CrearComandoAgregarLogroCantidad(logroCantidad);

                comando.Ejecutar();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral personalizada = new ExcepcionGeneral(exc.InnerException, DateTime.Now);
                logger.Error(exc, exc.Message);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, personalizada.Mensaje);
            }
        }



        [Route("agregarLogroJugador")]
        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage AgregarLogroJugador(DTOLogroJugador dto)
        {
            try
            {
                TraductorLogroJugador traductor = FabricaTraductor.CrearTraductorLogroJugador();

                Entidad logroJugador = traductor.CrearEntidad(dto);

                Comando comando;

                comando = FabricaComando.CrearComandoAgregarLogroJugador(logroJugador);

                comando.Ejecutar();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral personalizada = new ExcepcionGeneral(exc.InnerException, DateTime.Now);
                logger.Error(exc, exc.Message);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, personalizada.Mensaje);
            }
        }


        [Route("agregarLogroEquipo")]
        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage AgregarLogroEquipo(DTOLogroEquipo dto)
        {
            try
            {
                TraductorLogroEquipo traductor = FabricaTraductor.CrearTraductorLogroEquipo();

                Entidad logroEquipo = traductor.CrearEntidad(dto);

                Comando comando;

                comando = FabricaComando.CrearComandoAgregarLogroEquipo(logroEquipo);

                comando.Ejecutar();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral personalizada = new ExcepcionGeneral(exc.InnerException, DateTime.Now);
                logger.Error(exc, exc.Message);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, personalizada.Mensaje);
            }
        }


        [Route("agregarLogroVF")]
        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage AgregarLogroVF(DTOLogroVF dto)
        {
            try
            {
                TraductorLogroVF traductor = FabricaTraductor.CrearTraductorLogroVF();

                Entidad logroEquipo = traductor.CrearEntidad(dto);

                Comando comando;

                comando = FabricaComando.CrearComandoAgregarLogroVF(logroEquipo);

                comando.Ejecutar();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral personalizada = new ExcepcionGeneral(exc.InnerException, DateTime.Now);
                logger.Error(exc, exc.Message);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, personalizada.Mensaje);
            }
        }

        [Route("obtenerLogrosCantidadPendiente")]
        [System.Web.Http.AcceptVerbs("GET", "PUT")]
        [System.Web.Http.HttpPut, System.Web.Http.HttpGet]
        public HttpResponseMessage ObtenerLogrosCantidadPendientes(DTOLogroPartidoId dto)
        {
            try
            {
                TraductorLogroPartidoId traductorPartido = FabricaTraductor.CrearTraductorLogroPartidoId();

                Entidad partido = traductorPartido.CrearEntidad(dto);

                Comando comando = FabricaComando.CrearComandoObtenerLogrosCantidadPendientes(partido);

                comando.Ejecutar();

                TraductorMostrarLogrosPartido traductorLogros = FabricaTraductor.CrearTraductorMostrarLogrosPartidos();

                List<DTOMostrarLogrosPartido> dtos = traductorLogros.CrearListaDto(comando.GetEntidades());
          
                return Request.CreateResponse(HttpStatusCode.OK, dtos);
            }
            catch(LogrosPendientesNoExisteException exc)
            {  
                logger.Error(exc, exc.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (ObjetoNullException exc)
            {
                logger.Error(exc, exc.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral personalizada = new ExcepcionGeneral(exc.InnerException, DateTime.Now);
                logger.Error(exc, exc.Message);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, personalizada.Mensaje);
            
            }

        }



        [Route("obtenerLogrosJugadorPendiente")]
        [System.Web.Http.AcceptVerbs("GET", "PUT")]
        [System.Web.Http.HttpPut, System.Web.Http.HttpGet]
        public HttpResponseMessage ObtenerLogrosJugadorPendientes(DTOLogroPartidoId dto)
        {
            try
            {
                TraductorLogroPartidoId traductorPartido = FabricaTraductor.CrearTraductorLogroPartidoId();

                Entidad partido = traductorPartido.CrearEntidad(dto);

                Comando comando = FabricaComando.CrearComandoObtenerLogrosJugadorPendientes(partido);

                comando.Ejecutar();

                TraductorMostrarLogrosPartido traductorLogros = FabricaTraductor.CrearTraductorMostrarLogrosPartidos();

                List<DTOMostrarLogrosPartido> dtos = traductorLogros.CrearListaDto(comando.GetEntidades());

                return Request.CreateResponse(HttpStatusCode.OK, dtos);
            }
            catch (ObjetoNullException exc)
            {
                logger.Error(exc, exc.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (LogrosPendientesNoExisteException exc)
            {
                logger.Error(exc, exc.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral personalizada = new ExcepcionGeneral(exc.InnerException, DateTime.Now);
                logger.Error(exc, exc.Message);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, personalizada.Mensaje);
            }

        }




        [Route("obtenerLogrosEquipoPendiente")]
        [System.Web.Http.AcceptVerbs("GET", "PUT")]
        [System.Web.Http.HttpPut, System.Web.Http.HttpGet]
        public HttpResponseMessage ObtenerLogrosEquipoPendientes(DTOLogroPartidoId dto)
        {
            try
            {
                TraductorLogroPartidoId traductorPartido = FabricaTraductor.CrearTraductorLogroPartidoId();

                Entidad partido = traductorPartido.CrearEntidad(dto);

                Comando comando = FabricaComando.CrearComandoObtenerLogrosEquipoPendientes(partido);

                comando.Ejecutar();

                TraductorMostrarLogrosPartido traductorLogros = FabricaTraductor.CrearTraductorMostrarLogrosPartidos();

                List<DTOMostrarLogrosPartido> dtos = traductorLogros.CrearListaDto(comando.GetEntidades());

                return Request.CreateResponse(HttpStatusCode.OK, dtos);
            }
            catch (ObjetoNullException exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (LogrosPendientesNoExisteException exc)
            {
                logger.Error(exc, exc.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral personalizada = new ExcepcionGeneral(exc.InnerException, DateTime.Now);
                logger.Error(exc, exc.Message);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, personalizada.Mensaje);
            }

        }

        [Route("obtenerLogrosVFPendiente")]
        [System.Web.Http.AcceptVerbs("GET", "PUT")]
        [System.Web.Http.HttpPut, System.Web.Http.HttpGet]
        public HttpResponseMessage ObtenerLogrosVFPendientes(DTOLogroPartidoId dto)
        {
            try
            {
                TraductorLogroPartidoId traductorPartido = FabricaTraductor.CrearTraductorLogroPartidoId();

                Entidad partido = traductorPartido.CrearEntidad(dto);

                Comando comando = FabricaComando.CrearComandoObtenerLogrosVFPendientes(partido);

                comando.Ejecutar();

                TraductorMostrarLogrosPartido traductorLogros = FabricaTraductor.CrearTraductorMostrarLogrosPartidos();

                List<DTOMostrarLogrosPartido> dtos = traductorLogros.CrearListaDto(comando.GetEntidades());

                return Request.CreateResponse(HttpStatusCode.OK, dtos);
            }
            catch (ObjetoNullException exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (LogrosPendientesNoExisteException exc)
            {
                logger.Error(exc, exc.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral personalizada = new ExcepcionGeneral(exc.InnerException, DateTime.Now);
                logger.Error(exc, exc.Message);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, personalizada.Mensaje);
            }

        }

    }
}
