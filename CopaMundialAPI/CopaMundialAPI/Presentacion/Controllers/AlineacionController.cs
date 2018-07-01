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
    [RoutePrefix("api/alineacion")]
    public class AlineacionController : ApiController
    {
        Logger logger = LogManager.GetLogger("fileLogger");

        [Route("crear")]
        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage CrearAlineacion(DTOAlineacionNuevo dto)
        {
            logger.Info("Entrando a CrearAlineacion[]");
            try
            {
                TraductorAlineacionNuevo traductor = FabricaTraductor.CrearTraductorAlineacionNuevo();
                Entidad entidad = traductor.CrearEntidad(dto);

                Comando comando = FabricaComando.CrearComandoCrearAlineacion(entidad);
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
        public HttpResponseMessage ActualizarAlineacion(DTOAlineacionActualizar dto)
        {
            logger.Info("Entrando a ActualizarAlineacion[]");
            try
            {
                TraductorAlineacionActualizar traductor = FabricaTraductor.CrearTraductorAlineacionActualizar();
                Entidad entidad = traductor.CrearEntidad(dto);

                Comando comando = FabricaComando.CrearComandoActualizarAlineacion(entidad);
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

        [Route("eliminar")]
        [System.Web.Http.AcceptVerbs("DELETE")]
        [System.Web.Http.HttpDelete]
        public HttpResponseMessage EliminarAlineacion(DTOAlineacionSoloId dto)
        {
            logger.Info("Entrando a EliminarAlineacion[]");
            try
            {
                TraductorAlineacionSoloId traductor = FabricaTraductor.CrearTraductorAlineacionSoloId();
                Entidad entidad = traductor.CrearEntidad(dto);

                Comando comando = FabricaComando.CrearComandoEliminarAlineacion(entidad);
                comando.Ejecutar();

                return Request.CreateResponse(HttpStatusCode.OK, "Eliminado exitosamente");
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
