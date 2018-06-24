using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CopaMundialAPI.Logica_de_Negocio.Comando;
using CopaMundialAPI.Logica_de_Negocio.Fabrica;
using CopaMundialAPI.Servicios.DTO.Jugadores;
using CopaMundialAPI.Servicios.Traductores.Fabrica;
using CopaMundialAPI.Servicios.Traductores.Jugadores;
using CopaMundialAPI.Comun.Excepciones;


namespace CopaMundialAPI.Presentacion.Controllers
{
    [RoutePrefix("api/Jugador")]
    public class JugadorController : ApiController
    {
        [Route("obtenerJugadores")]
        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage ObtenerJugadores()
        {
            try
            {
                TraductorObtenerJugadores traductor = FabricaTraductor.CrearTraductorObtenerJugadores();

                Comando comando = FabricaComando.CrearComandoObtenerJugadores();

                comando.Ejecutar();

                List<DTOObtenerJugadores> dtos = traductor.CrearListaDto(comando.GetEntidades());

                return Request.CreateResponse(HttpStatusCode.OK, dtos);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral personalizada = new ExcepcionGeneral(exc.InnerException, DateTime.Now);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, personalizada.Mensaje);
            }
        }
    }
}
