using CopaMundialAPI.Comun.Excepciones;
using CopaMundialAPI.Logica_de_Negocio.Comando;
using CopaMundialAPI.Logica_de_Negocio.Fabrica;
using CopaMundialAPI.Servicios.DTO.Estadios;
using CopaMundialAPI.Servicios.Traductores.Estadios;
using CopaMundialAPI.Servicios.Traductores.Fabrica;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace CopaMundialAPI.Presentacion.Controllers
{
    [RoutePrefix("api/estadios")]
    public class EstadiosController: ApiController
    {
        Logger logger = LogManager.GetLogger("fileLogger");

        [Route("obtener")]
        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage ObtenerEstadios()
        {
            logger.Info("Entrando a ObtenerEstadios[]");
            try
            {
                Comando comando = FabricaComando.CrearComandoObtenerTodosLosEstadios();
                comando.Ejecutar();

                TraductorEstadio traductorEstadio = FabricaTraductor.CrearTraductorEstadio();
                List<DTOEstadio> respuesta = traductorEstadio.CrearListaDto(comando.GetEntidades());

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