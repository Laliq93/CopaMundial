using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Excepciones;
using CopaMundialAPI.Logica_de_Negocio.Comando;
using CopaMundialAPI.Logica_de_Negocio.Fabrica;
using CopaMundialAPI.Servicios.DTO.Equipos;
using CopaMundialAPI.Servicios.Traductores.Equipos;
using CopaMundialAPI.Servicios.Traductores.Fabrica;
using CopaMundialAPI.Servicios.Traductores.Partidos;
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
    [RoutePrefix("api/equipos")]
    public class EquiposController: ApiController
    {
        Logger logger = LogManager.GetLogger("fileLogger");

        [Route("obtener")]
        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage ObtenerEquipos()
        {
            logger.Info("Entrando a obtenerEquipos[]");
            try
            {
                Comando comando = FabricaComando.CrearComandoObtenerTodosLosEquipos();
                comando.Ejecutar();

                TraductorEquipo traductorEquipo = FabricaTraductor.CrearTraductorEquipo();
                List<DTOEquipo> respuesta = traductorEquipo.CrearListaDto(comando.GetEntidades());

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