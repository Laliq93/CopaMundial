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
using CopaMundialAPI.Servicios.DTO.Apuestas;
using CopaMundialAPI.Servicios.Fabrica;
using CopaMundialAPI.Servicios.Traductores.Apuestas;
using CopaMundialAPI.Servicios.Traductores.Fabrica;
using CopaMundialAPI.Servicios.Traductores.Logros;
using CopaMundialAPI.Servicios.Traductores.Usuarios;
using CopaMundialAPI.Servicios.DTO.Usuario;
using CopaMundialAPI.Servicios.DTO.Logros;
using CopaMundialAPI.Comun.Excepciones;

namespace CopaMundialAPI.Presentacion.Controllers
{
    [RoutePrefix("api/Apuesta")]
    public class ApuestaController : ApiController
    {
        /// <summary>
        /// Proceso para obtener todos los partidos con una fecha de inicio estrictamente mayor a la fecha actual del sistema.
        /// </summary>
        [Route("obtenerproximospartidos")]
        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage ObtenerProximosPartidos()
        {
            try
            {
                TraductorListarProximosPartidos traductor = FabricaTraductor.CrearTraductorListarProximosPartidos();

                Comando comando = FabricaComando.CrearComandoObtenerProximosPartidos();

                comando.Ejecutar();

                List<DTOListarProximosPartidos> dtos = traductor.CrearListaDto(comando.GetEntidades());

                return Request.CreateResponse(HttpStatusCode.OK, dtos);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral personalizada = new ExcepcionGeneral(exc.InnerException, DateTime.Now);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, personalizada.Mensaje);
            }
        }

        /// <summary>
        /// Proceso para obtener los logros de tipo verdadero/falso de un partido especifico
        /// </summary>
        /// <param name="DTORecibirIdPartido">Partido</param>
        [Route("obtenerlogrosvofpartido")]
        [System.Web.Http.AcceptVerbs("GET", "PUT")]
        [System.Web.Http.HttpPut, System.Web.Http.HttpGet]
        public HttpResponseMessage ObtenerLogrosvofPartido(DTORecibirIdPartido dto)
        {
            try
            {
                TraductorRecibirIdPartido traductorPartido = FabricaTraductor.CrearTraductorRecibirIdPartido();

                Entidad partido = traductorPartido.CrearEntidad(dto);

                Comando comando = FabricaComando.CrearComandoObtenerLogrosVofPartido(partido);

                comando.Ejecutar();

                TraductorMostrarLogrosPartido traductorLogros = FabricaTraductor.CrearTraductorMostrarLogrosPartidos();

                List<DTOMostrarLogrosPartido> dtos = traductorLogros.CrearListaDto(comando.GetEntidades());

                return Request.CreateResponse(HttpStatusCode.OK, dtos);
            }
            catch (ObjetoNullException exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral personalizada = new ExcepcionGeneral(exc.InnerException, DateTime.Now);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, personalizada.Mensaje);
            }

        }

        /// <summary>
        /// Proceso para obtener los logros de tipo cuantificativo de un partido especifico
        /// </summary>
        /// <param name="DTORecibirIdPartido">Partido</param>
        [Route("obtenerlogroscantidadpartido")]
        [System.Web.Http.AcceptVerbs("GET", "PUT")]
        [System.Web.Http.HttpPut]
        public HttpResponseMessage ObtenerLogrosCantidadPartido(DTORecibirIdPartido dto)
        {
            try
            {
                TraductorRecibirIdPartido traductorPartido = FabricaTraductor.CrearTraductorRecibirIdPartido();

                Entidad partido = traductorPartido.CrearEntidad(dto);

                Comando comando = FabricaComando.CrearComandoObtenerLogrosCantidadPartido(partido);

                comando.Ejecutar();

                TraductorMostrarLogrosPartido traductorLogros = FabricaTraductor.CrearTraductorMostrarLogrosPartidos();

                List<DTOMostrarLogrosPartido> dtos = traductorLogros.CrearListaDto(comando.GetEntidades());

                return Request.CreateResponse(HttpStatusCode.OK, dtos);
            }
            catch (ObjetoNullException exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral personalizada = new ExcepcionGeneral(exc.InnerException, DateTime.Now);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, personalizada.Mensaje);
            }
        }

        /// <summary>
        /// Proceso para obtener los logros de tipo Equipo de un partido especifico
        /// </summary>
        /// <param name="DTORecibirIdPartido">Partido</param>
        [Route("obtenerlogrosequipopartido")]
        [System.Web.Http.AcceptVerbs("GET", "PUT")]
        [System.Web.Http.HttpPut]
        public HttpResponseMessage ObtenerLogrosEquipoPartido(DTORecibirIdPartido dto)
        {
            try
            {
                TraductorRecibirIdPartido traductorPartido = FabricaTraductor.CrearTraductorRecibirIdPartido();

                Entidad partido = traductorPartido.CrearEntidad(dto);

                Comando comando = FabricaComando.CrearComandoObtenerLogrosEquipoPartido(partido);

                comando.Ejecutar();

                TraductorMostrarLogrosPartido traductorLogros = FabricaTraductor.CrearTraductorMostrarLogrosPartidos();

                List<DTOMostrarLogrosPartido> dtos = traductorLogros.CrearListaDto(comando.GetEntidades());

                return Request.CreateResponse(HttpStatusCode.OK, dtos);
            }
            catch (ObjetoNullException exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral personalizada = new ExcepcionGeneral(exc.InnerException, DateTime.Now);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, personalizada.Mensaje);
            }
        }

        /// <summary>
        /// Proceso para obtener los logros de tipo Jugador de un partido especifico
        /// </summary>
        /// <param name="DTORecibirIdPartido">Partido</param>
        [Route("obtenerlogrosjugadorpartido")]
        [System.Web.Http.AcceptVerbs("GET", "PUT")]
        [System.Web.Http.HttpPut]
        public HttpResponseMessage ObtenerLogrosJugadorPartido(DTORecibirIdPartido dto)
        {
            try
            {
                TraductorRecibirIdPartido traductorPartido = FabricaTraductor.CrearTraductorRecibirIdPartido();

                Entidad partido = traductorPartido.CrearEntidad(dto);

                Comando comando = FabricaComando.CrearComandoObtenerLogrosJugadorPartido(partido);

                comando.Ejecutar();

                TraductorMostrarLogrosPartido traductorLogros = FabricaTraductor.CrearTraductorMostrarLogrosPartidos();

                List<DTOMostrarLogrosPartido> dtos = traductorLogros.CrearListaDto(comando.GetEntidades());

                return Request.CreateResponse(HttpStatusCode.OK, dtos);
            }
            catch (ObjetoNullException exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral personalizada = new ExcepcionGeneral(exc.InnerException, DateTime.Now);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, personalizada.Mensaje);
            }
        }

        /// <summary>
        /// Proceso para registrar una apuesta de tipo verdadero/falso de un usuario y logro especifico
        /// </summary>
        /// <param name="DTOApuestaVoF">Apuesta</param>
        [Route("registrarapuestavof")]
        [System.Web.Http.AcceptVerbs("GET", "PUT")]
        [System.Web.Http.HttpPut]
        public HttpResponseMessage RegistrarApuestaVoF(DTOApuestaVOF dto)
        {
            try
            {
                TraductorApuestaVOF traductor = FabricaTraductor.CrearTraductorApuestaVoF();

                Entidad apuesta = traductor.CrearEntidad(dto);

                Comando comando;

                comando = FabricaComando.CrearComandoVerificarApuestaVoFExiste(apuesta);

                comando.Ejecutar();

                comando = FabricaComando.CrearComandoAgregarApuestaVoF(apuesta);

                comando.Ejecutar();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (ObjetoNullException exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (ApuestaRepetidaException exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral personalizada = new ExcepcionGeneral(exc.InnerException, DateTime.Now);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, personalizada.Mensaje);
            }

        }

        /// <summary>
        /// Proceso para registrar una apuesta de tipo cuantifico de un usuario y logro especifico
        /// </summary>
        /// <param name="DTOApuestaVoF">Apuesta</param>
        [Route("registrarapuestacantidad")]
        [System.Web.Http.AcceptVerbs("GET", "PUT")]
        [System.Web.Http.HttpPut]
        public HttpResponseMessage RegistrarApuestaCantidad(DTOApuestaCantidad dto)
        {
            try
            {
                TraductorApuestaCantidad traductor = FabricaTraductor.CrearTraductorApuestaCantidad();

                Entidad apuesta = traductor.CrearEntidad(dto);

                Comando comando;

                comando = FabricaComando.CrearComandoVerificarApuestaCantidadExiste(apuesta);

                comando.Ejecutar();

                comando = FabricaComando.CrearComandoAgregarApuestaCantidad(apuesta);

                comando.Ejecutar();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (ObjetoNullException exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (ApuestaRepetidaException exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral personalizada = new ExcepcionGeneral(exc.InnerException, DateTime.Now);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, personalizada.Mensaje);
            }

        }

        /// <summary>
        /// Proceso para registrar una apuesta de tipo jugador de un usuario y logro especifico
        /// </summary>
        /// <param name="DTOApuestaJugador">Apuesta</param>
        [Route("registrarapuestajugador")]
        [System.Web.Http.AcceptVerbs("GET", "PUT")]
        [System.Web.Http.HttpPut]
        public HttpResponseMessage RegistrarApuestaJugador(DTOApuestaJugador dto)
        {
            try
            {
                TraductorApuestaJugador traductor = FabricaTraductor.CrearTraductorApuestaJugador();

                Entidad apuesta = traductor.CrearEntidad(dto);

                Comando comando;

                comando = FabricaComando.CrearComandoVerificaApuestaJugadorExiste(apuesta);

                comando.Ejecutar();

                comando = FabricaComando.CrearComandoAgregarApuestaJugador(apuesta);

                comando.Ejecutar();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (ObjetoNullException exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (ApuestaRepetidaException exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral personalizada = new ExcepcionGeneral(exc.InnerException, DateTime.Now);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, personalizada.Mensaje);
            }

        }

        /// <summary>
        /// Proceso para registrar una apuesta de tipo equipo de un usuario y logro especifico
        /// </summary>
        /// <param name="DTOApuestaEquipo">Apuesta</param>
        [Route("registrarapuestaequipo")]
        [System.Web.Http.AcceptVerbs("GET", "PUT")]
        [System.Web.Http.HttpPut]
        public HttpResponseMessage RegistrarApuestaEquipo(DTOApuestaEquipo dto)
        {
            try
            {
                TraductorApuestaEquipo traductor = FabricaTraductor.CrearTraductorApuestaEquipo();

                Entidad apuesta = traductor.CrearEntidad(dto);

                Comando comando;

                comando = FabricaComando.CrearComandoVerificaApuestaEquipoExiste(apuesta);

                comando.Ejecutar();

                comando = FabricaComando.CrearComandoAgregarApuestaEquipo(apuesta);

                comando.Ejecutar();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (ObjetoNullException exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (ApuestaRepetidaException exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral personalizada = new ExcepcionGeneral(exc.InnerException, DateTime.Now);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, personalizada.Mensaje);
            }

        }

        /// <summary>
        /// Proceso para obtener las apuestas de tipo verdadero/falso en curso de un usuario especifico.
        /// </summary>
        /// <param name="DTOUsuarioId">Usuario</param>
        [Route("obtenerapuestasvofencurso")]
        [System.Web.Http.AcceptVerbs("GET", "PUT")]
        [System.Web.Http.HttpPut]
        public HttpResponseMessage ObtenerApuestasVoFEnCurso (DTOUsuarioId dto)
        {
            try
            {
                TraductorUsuarioId traductor = FabricaTraductor.CrearTraductorUsuarioId();

                Entidad usuario = traductor.CrearEntidad(dto);

                Comando comando = FabricaComando.CrearComandoObtenerApuestasVoFEnCurso(usuario);

                comando.Ejecutar();

                TraductorApuestaVOF traductorApuesta = FabricaTraductor.CrearTraductorApuestaVoF();

                List<DTOApuestaVOF> dtos = traductorApuesta.CrearListaDto(comando.GetEntidades());

                return Request.CreateResponse(HttpStatusCode.OK, dtos);
            }
            catch (ObjetoNullException exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral personalizada = new ExcepcionGeneral(exc.InnerException, DateTime.Now);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }

        /// <summary>
        /// Proceso para obtener las apuestas de tipo cantidad en curso de un usuario especifico.
        /// </summary>
        /// <param name="DTOUsuarioId">Usuario</param>
        [Route("obtenerapuestascantidadencurso")]
        [System.Web.Http.AcceptVerbs("GET", "PUT")]
        [System.Web.Http.HttpPut]
        public HttpResponseMessage ObtenerApuestasCantidadEnCurso(DTOUsuarioId dto)
        {
            try
            {
                TraductorUsuarioId traductor = FabricaTraductor.CrearTraductorUsuarioId();

                Entidad usuario = traductor.CrearEntidad(dto);

                Comando comando = FabricaComando.CrearComandoObtenerApuestasCantidadEnCurso(usuario);

                comando.Ejecutar();

                TraductorApuestaCantidad traductorApuesta = FabricaTraductor.CrearTraductorApuestaCantidad();

                List<DTOApuestaCantidad> dtos = traductorApuesta.CrearListaDto(comando.GetEntidades());

                return Request.CreateResponse(HttpStatusCode.OK, dtos);
            }
            catch (ObjetoNullException exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral personalizada = new ExcepcionGeneral(exc.InnerException, DateTime.Now);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }

        /// <summary>
        /// Proceso para obtener las apuestas de tipo jugador en curso de un usuario especifico.
        /// </summary>
        /// <param name="DTOUsuarioId">Usuario</param>
        [Route("obtenerapuestasjugadorencurso")]
        [System.Web.Http.AcceptVerbs("GET", "PUT")]
        [System.Web.Http.HttpPut]
        public HttpResponseMessage ObtenerApuestasJugadorEnCurso(DTOUsuarioId dto)
        {
            try
            {
                //terminar
                TraductorUsuarioId traductor = FabricaTraductor.CrearTraductorUsuarioId();

                Entidad usuario = traductor.CrearEntidad(dto);

                Comando comando = FabricaComando.CrearComandoObtenerApuestasCantidadEnCurso(usuario);

                comando.Ejecutar();

                TraductorApuestaCantidad traductorApuesta = FabricaTraductor.CrearTraductorApuestaCantidad();

                List<DTOApuestaCantidad> dtos = traductorApuesta.CrearListaDto(comando.GetEntidades());

                return Request.CreateResponse(HttpStatusCode.OK, dtos);
            }
            catch (ObjetoNullException exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral personalizada = new ExcepcionGeneral(exc.InnerException, DateTime.Now);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }


    }
}
