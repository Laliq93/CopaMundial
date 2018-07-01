using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Excepciones;
using CopaMundialAPI.Logica_de_Negocio.Comando;
using CopaMundialAPI.Logica_de_Negocio.Fabrica;
using CopaMundialAPI.Servicios.DTO.Partidos;
using CopaMundialAPI.Servicios.Traductores.Fabrica;
using CopaMundialAPI.Servicios.Traductores.Partidos;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CopaMundialAPI.Presentacion.Controllers
{
    [RoutePrefix("api/partido")]
    public class PartidoController : ApiController
    {
        Logger logger = LogManager.GetLogger("fileLogger");

        [Route("crear")]
        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage CrearPartido(DTOPartidoNuevo dto)
        {
            logger.Info("Entrando a CrearPartido[" + dto.ToString() + "]");
            try
            {
                TraductorPartidoNuevo traductor = FabricaTraductor.CrearTraductorPartidoNuevo();
                Entidad entidad = traductor.CrearEntidad(dto);

                Comando comando = FabricaComando.CrearComandoCrearPartido(entidad);
                comando.Ejecutar();

                return Request.CreateResponse(HttpStatusCode.OK, "Creado exitosamente");
            }
            catch (ExcepcionPersonalizada ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Mensaje);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ocurrio un error inesperado");
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error desconocido");
            }
        }

        [Route("actualizar")]
        [System.Web.Http.AcceptVerbs("PUT")]
        [System.Web.Http.HttpPut]
        public HttpResponseMessage ActualizarPartido(DTOPartidoActualizar dto)
        {
            logger.Info("Entrando a ActualizarPartido[" + dto.ToString() + "]");
            try
            {
                TraductorPartidoActualizar traductor = FabricaTraductor.CrearTraductorPartidoActualizar();
                Entidad entidad = traductor.CrearEntidad(dto);

                Comando comando = FabricaComando.CrearComandoActualizarPartido(entidad);
                comando.Ejecutar();

                return Request.CreateResponse(HttpStatusCode.OK, "Actualizado exitosamente");
            }
            catch (ExcepcionPersonalizada ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Mensaje);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ocurrio un error inesperado");
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error desconocido");
            }
        }

        [Route("obtenertodos")]
        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage ObtenerTodos()
        {
            logger.Info("Entrando a ObtenerTodos[]");
            try
            {
                TraductorPartidoReducido traductorPartidoReducido = FabricaTraductor.CrearTraductorPartidoReducido();

                Comando comando = FabricaComando.CrearComandoObtenerPartidos();
                comando.Ejecutar();

                List<DTOPartidoReducido> respuesta = traductorPartidoReducido.CrearListaDto(comando.GetEntidades());

                return Request.CreateResponse(HttpStatusCode.OK, respuesta);
            }
            catch (ExcepcionPersonalizada ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Mensaje);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ocurrio un error inesperado");
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error desconocido");
            }
        }

        [Route("obtenerporfecha")]
        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage ObtenerPorFecha(DTOPartidoFecha dto)
        {
            logger.Info("Entrando a ObtenerPorFecha[" + dto.ToString() + "]");
            try
            {
                TraductorPartidoFecha traductor = FabricaTraductor.CrearTraductorPartidoFecha();
                Entidad entidad = traductor.CrearEntidad(dto);

                Comando comando = FabricaComando.CrearComandoObtenerListaPartidosPorFecha(entidad);
                comando.Ejecutar();

                TraductorPartidoReducido traductorPartidoReducido = FabricaTraductor.CrearTraductorPartidoReducido();
                List<DTOPartidoReducido> respuesta = traductorPartidoReducido.CrearListaDto(comando.GetEntidades());

                return Request.CreateResponse(HttpStatusCode.OK, respuesta);
            }
            catch (ExcepcionPersonalizada ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Mensaje);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ocurrio un error inesperado");
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error desconocido");
            }
        }

        [Route("obtener")]
        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage ObtenerPorId(DTOPartidoSoloId dto)
        {
            logger.Info("Entrando a ObtenerPorId[" + dto.ToString() + "]");
            try
            {
                TraductorPartidoSoloId traductor = FabricaTraductor.CrearTraductorPartidoSoloId();
                Entidad entidad = traductor.CrearEntidad(dto);

                Comando comando = FabricaComando.CrearComandoObtenerPartido(entidad);
                comando.Ejecutar();

                TraductorPartido traductorPartido = FabricaTraductor.CrearTraductorPartido();
                DTOPartido respuesta = traductorPartido.CrearDto(comando.GetEntidad());

                return Request.CreateResponse(HttpStatusCode.OK, respuesta);
            }
            catch (ExcepcionPersonalizada ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Mensaje);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ocurrio un error inesperado");
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error desconocido");
            }
        }
    }
}
