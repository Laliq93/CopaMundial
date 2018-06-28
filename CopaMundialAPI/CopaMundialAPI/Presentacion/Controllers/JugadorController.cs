using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;
using CopaMundialAPI.Logica_de_Negocio.Fabrica;
using CopaMundialAPI.Logica_de_Negocio.Comando;
using CopaMundialAPI.Servicios.DTO.Jugadores;
using CopaMundialAPI.Servicios.Fabrica;
using CopaMundialAPI.Comun.Excepciones;
using CopaMundialAPI.Servicios.Traductores.Jugadores;
using CopaMundialAPI.Servicios.Traductores.Fabrica;

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

        [Route("agregarJugador")]
        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage AgregarJugador(DTOJugador dto)
        {
            try
            {
                TraductorJugador traductor = FabricaTraductor.CrearTraductorJugador();

                Entidad jugador = traductor.CrearEntidad(dto);

                Comando comando;

                comando = FabricaComando.CrearComandoAgregarJugador(jugador);

                comando.Ejecutar();

                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral personalizada = new ExcepcionGeneral(exc.InnerException, DateTime.Now);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, personalizada.Mensaje);
            }
        }

        [Route("modificarJugador")]
        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage ModificarJugador(DTOModificarJugador dto)
        {
            try
            {
                TraductorModificarJugador traductor = FabricaTraductor.CrearTraductorModificarJugador();

                Entidad jugador = traductor.CrearEntidad(dto);

                Comando comando;

                comando = FabricaComando.CrearComandoModificarJugador(jugador);

                comando.Ejecutar();

                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral personalizada = new ExcepcionGeneral(exc.InnerException, DateTime.Now);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, personalizada.Mensaje);
            }
        }

        [Route("activarJugador")]
        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage ActivarJugador(DTOJugadorId dto)
        {
            try
            {
                TraductorJugadorId traductor = FabricaTraductor.CrearTraductorJugadorId();

                Entidad jugador = traductor.CrearEntidad(dto);

                Comando comando;

                comando = FabricaComando.CrearComandoActivarJugador(jugador);

                comando.Ejecutar();

                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral personalizada = new ExcepcionGeneral(exc.InnerException, DateTime.Now);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, personalizada.Mensaje);
            }
        }

        [Route("desactivarJugador")]
        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage DesactivarJugador(DTOJugadorId dto)
        {
            try
            {
                TraductorJugadorId traductor = FabricaTraductor.CrearTraductorJugadorId();

                Entidad jugador = traductor.CrearEntidad(dto);

                Comando comando;

                comando = FabricaComando.CrearComandoDesactivarJugador(jugador);

                comando.Ejecutar();

                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral personalizada = new ExcepcionGeneral(exc.InnerException, DateTime.Now);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, personalizada.Mensaje);
            }
        }


    }
}
