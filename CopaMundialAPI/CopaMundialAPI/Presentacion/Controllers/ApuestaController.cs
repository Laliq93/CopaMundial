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
using NLog;

namespace CopaMundialAPI.Presentacion.Controllers
{
    [RoutePrefix("api/Apuesta")]
    public class ApuestaController : ApiController
    {
        Logger log = LogManager.GetLogger("fileLogger");

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

                List<DTOListarProximosPartidos> Listadtos = traductor.CrearListaDto(comando.GetEntidades());

                return Request.CreateResponse(HttpStatusCode.OK, Listadtos);
            }
            catch(BaseDeDatosException exc)
            {
                log.Error(exc, exc.Mensaje);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral exceptionGeneral = new ExcepcionGeneral(exc.InnerException, DateTime.Now);

                log.Error(exc, exc.Message);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exceptionGeneral.Mensaje);
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

                Comando comando = FabricaComando.CrearComandoAgregarApuestaVoF(apuesta);

                comando.Ejecutar();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (ObjetoNullException exc)
            {
                log.Error(exc, exc.Mensaje);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (BaseDeDatosException exc)
            {
                log.Error(exc, exc.Mensaje);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (ApuestaRepetidaException exc)
            {
                log.Error(exc, exc.Mensaje);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral exceptionGeneral = new ExcepcionGeneral(exc.InnerException, DateTime.Now);

                log.Error(exc, exc.Message);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exceptionGeneral.Mensaje);
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

                Comando comando = FabricaComando.CrearComandoAgregarApuestaCantidad(apuesta);

                comando.Ejecutar();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (ObjetoNullException exc)
            {
                log.Error(exc, exc.Mensaje);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (ApuestaRepetidaException exc)
            {
                log.Error(exc, exc.Mensaje);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (BaseDeDatosException exc)
            {
                log.Error(exc, exc.Mensaje);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral exceptionGeneral = new ExcepcionGeneral(exc.InnerException, DateTime.Now);

                log.Error(exc, exc.Message);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exceptionGeneral.Mensaje);
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

                Comando comando = FabricaComando.CrearComandoAgregarApuestaJugador(apuesta);

                comando.Ejecutar();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (ObjetoNullException exc)
            {
                log.Error(exc, exc.Mensaje);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (ApuestaRepetidaException exc)
            {
                log.Error(exc, exc.Mensaje);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (BaseDeDatosException exc)
            {
                log.Error(exc, exc.Mensaje);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral exceptionGeneral = new ExcepcionGeneral(exc.InnerException, DateTime.Now);

                log.Error(exc, exc.Message);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exceptionGeneral.Mensaje);
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

                Comando comando = FabricaComando.CrearComandoAgregarApuestaEquipo(apuesta);

                comando.Ejecutar();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (ObjetoNullException exc)
            {
                log.Error(exc, exc.Mensaje);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (BaseDeDatosException exc)
            {
                log.Error(exc, exc.Mensaje);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (ApuestaRepetidaException exc)
            {
                log.Error(exc, exc.Mensaje);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral exceptionGeneral = new ExcepcionGeneral(exc.InnerException, DateTime.Now);

                log.Error(exc, exc.Message);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exceptionGeneral.Mensaje);
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

                List<DTOApuestaVOF> Listadtos = traductorApuesta.CrearListaDto(comando.GetEntidades());

                return Request.CreateResponse(HttpStatusCode.OK, Listadtos);
            }
            catch (ObjetoNullException exc)
            {
                log.Error(exc, exc.Mensaje);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (BaseDeDatosException exc)
            {
                log.Error(exc, exc.Mensaje);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral exceptionGeneral = new ExcepcionGeneral(exc.InnerException, DateTime.Now);

                log.Error(exc, exc.Message);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exceptionGeneral.Mensaje);
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

                List<DTOApuestaCantidad> Listadtos = traductorApuesta.CrearListaDto(comando.GetEntidades());

                return Request.CreateResponse(HttpStatusCode.OK, Listadtos);
            }
            catch (ObjetoNullException exc)
            {
                log.Error(exc, exc.Mensaje);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (BaseDeDatosException exc)
            {
                log.Error(exc, exc.Mensaje);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral exceptionGeneral = new ExcepcionGeneral(exc.InnerException, DateTime.Now);

                log.Error(exc, exc.Message);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exceptionGeneral.Mensaje);
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
                TraductorUsuarioId traductor = FabricaTraductor.CrearTraductorUsuarioId();

                Entidad usuario = traductor.CrearEntidad(dto);

                Comando comando = FabricaComando.CrearComandoObtenerApuestasJugadorEnCurso(usuario);

                comando.Ejecutar();

                TraductorApuestaJugador traductorApuesta = FabricaTraductor.CrearTraductorApuestaJugador();

                List<DTOApuestaJugador> Listadtos = traductorApuesta.CrearListaDto(comando.GetEntidades());

                return Request.CreateResponse(HttpStatusCode.OK, Listadtos);
            }
            catch (ObjetoNullException exc)
            {
                log.Error(exc, exc.Mensaje);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (BaseDeDatosException exc)
            {
                log.Error(exc, exc.Mensaje);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral exceptionGeneral = new ExcepcionGeneral(exc.InnerException, DateTime.Now);

                log.Error(exc, exc.Message);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exceptionGeneral.Mensaje);
            }
        }

        /// <summary>
        /// Proceso para obtener las apuestas de tipo equipo en curso de un usuario especifico.
        /// </summary>
        /// <param name="DTOUsuarioId">Usuario</param>
        [Route("obtenerapuestasequipoencurso")]
        [System.Web.Http.AcceptVerbs("GET", "PUT")]
        [System.Web.Http.HttpPut]
        public HttpResponseMessage ObtenerApuestasEquipoEnCurso(DTOUsuarioId dto)
        {
            try
            {
                TraductorUsuarioId traductor = FabricaTraductor.CrearTraductorUsuarioId();

                Entidad usuario = traductor.CrearEntidad(dto);

                Comando comando = FabricaComando.CrearComandoObtenerApuestasEquipoEnCurso(usuario);

                comando.Ejecutar();

                TraductorApuestaEquipo traductorApuesta = FabricaTraductor.CrearTraductorApuestaEquipo();

                List<DTOApuestaEquipo> Listadtos = traductorApuesta.CrearListaDto(comando.GetEntidades());

                return Request.CreateResponse(HttpStatusCode.OK, Listadtos);
            }
            catch (ObjetoNullException exc)
            {
                log.Error(exc, exc.Mensaje);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (BaseDeDatosException exc)
            {
                log.Error(exc, exc.Mensaje);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral exceptionGeneral = new ExcepcionGeneral(exc.InnerException, DateTime.Now);

                log.Error(exc, exc.Message);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exceptionGeneral.Mensaje);
            }
        }

        /// <summary>
        /// Proceso para editar las apuestas de tipo verdadero/falso de un usuario específico.
        /// </summary>
        /// <param name="DTOApuestaVOF">Apuesta</param>
        [Route("actualizarapuestavof")]
        [System.Web.Http.AcceptVerbs("GET", "PUT")]
        [System.Web.Http.HttpPut]
        public HttpResponseMessage ActualizarApuestaVoF(DTOApuestaVOF dto)
        {
            try
            {
                TraductorApuestaVOF traductor = FabricaTraductor.CrearTraductorApuestaVoF();

                Entidad apuesta = traductor.CrearEntidad(dto);

                Comando comando = FabricaComando.CrearComandoActualizarApuestaVoF(apuesta);

                comando.Ejecutar();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (ObjetoNullException exc)
            {
                log.Error(exc, exc.Mensaje);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch(ApuestaInvalidaException exc)
            {
                log.Error(exc, exc.Mensaje);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (BaseDeDatosException exc)
            {
                log.Error(exc, exc.Mensaje);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral exceptionGeneral = new ExcepcionGeneral(exc.InnerException, DateTime.Now);

                log.Error(exc, exc.Message);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exceptionGeneral.Mensaje);
            }
        }

        /// <summary>
        /// Proceso para editar las apuestas de tipo cantidad de un usuario específico.
        /// </summary>
        /// <param name="DTOApuestaCantidad">Apuesta</param>
        [Route("actualizarapuestacantidad")]
        [System.Web.Http.AcceptVerbs("GET", "PUT")]
        [System.Web.Http.HttpPut]
        public HttpResponseMessage ActualizarApuestaCantidad(DTOApuestaCantidad dto)
        {
            try
            {
                TraductorApuestaCantidad traductor = FabricaTraductor.CrearTraductorApuestaCantidad();

                Entidad apuesta = traductor.CrearEntidad(dto);

                Comando comando = FabricaComando.CrearComandoActualizarApuestaCantidad(apuesta);

                comando.Ejecutar();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (ObjetoNullException exc)
            {
                log.Error(exc, exc.Mensaje);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (BaseDeDatosException exc)
            {
                log.Error(exc, exc.Mensaje);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (ApuestaInvalidaException exc)
            {
                log.Error(exc, exc.Mensaje);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral exceptionGeneral = new ExcepcionGeneral(exc.InnerException, DateTime.Now);

                log.Error(exc, exc.Message);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exceptionGeneral.Mensaje);
            }
        }

        /// <summary>
        /// Proceso para editar las apuestas de tipo jugador de un usuario específico.
        /// </summary>
        /// <param name="DTOApuestaJugador">Apuesta</param>
        [Route("actualizarapuestajugador")]
        [System.Web.Http.AcceptVerbs("GET", "PUT")]
        [System.Web.Http.HttpPut]
        public HttpResponseMessage ActualizarApuestaJugador(DTOApuestaJugador dto)
        {
            try
            {
                TraductorApuestaJugador traductor = FabricaTraductor.CrearTraductorApuestaJugador();

                Entidad apuesta = traductor.CrearEntidad(dto);

                Comando comando = FabricaComando.CrearComandoActualizarApuestaJugador(apuesta);

                comando.Ejecutar();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (ObjetoNullException exc)
            {
                log.Error(exc, exc.Mensaje);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (BaseDeDatosException exc)
            {
                log.Error(exc, exc.Mensaje);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (ApuestaInvalidaException exc)
            {
                log.Error(exc, exc.Mensaje);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral exceptionGeneral = new ExcepcionGeneral(exc.InnerException, DateTime.Now);

                log.Error(exc, exc.Message);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exceptionGeneral.Mensaje);
            }
        }

        /// <summary>
        /// Proceso para editar las apuestas de tipo equipo de un usuario específico.
        /// </summary>
        /// <param name="DTOApuestaEquipo">Apuesta</param>
        [Route("actualizarapuestaequipo")]
        [System.Web.Http.AcceptVerbs("GET", "PUT")]
        [System.Web.Http.HttpPut]
        public HttpResponseMessage ActualizarApuestaEquipo(DTOApuestaEquipo dto)
        {
            try
            {
                TraductorApuestaEquipo traductor = FabricaTraductor.CrearTraductorApuestaEquipo();

                Entidad apuesta = traductor.CrearEntidad(dto);

                Comando comando = FabricaComando.CrearComandoActualizarApuestaEquipo(apuesta);

                comando.Ejecutar();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (ObjetoNullException exc)
            {
                log.Error(exc, exc.Mensaje);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (ApuestaInvalidaException exc)
            {
                log.Error(exc, exc.Mensaje);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (BaseDeDatosException exc)
            {
                log.Error(exc, exc.Mensaje);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral exceptionGeneral = new ExcepcionGeneral(exc.InnerException, DateTime.Now);

                log.Error(exc, exc.Message);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exceptionGeneral.Mensaje);
            }

        }

        /// <summary>
        /// Proceso para eliminar las apuestas de tipo verdadero/falso de un usuario específico.
        /// </summary>
        /// <param name="DTOApuestaVOF">Apuesta</param>
        [Route("eliminarapuestavof")]
        [System.Web.Http.AcceptVerbs("GET", "PUT")]
        [System.Web.Http.HttpPut]
        public HttpResponseMessage EliminarApuestaVoF(DTOApuestaVOF dto)
        {
            try
            {
                TraductorApuestaVOF traductor = FabricaTraductor.CrearTraductorApuestaVoF();

                Entidad apuesta = traductor.CrearEntidad(dto);

                Comando comando = FabricaComando.CrearComandoEliminarApuestaVoF(apuesta);

                comando.Ejecutar();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (ObjetoNullException exc)
            {
                log.Error(exc, exc.Mensaje);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (ApuestaInvalidaException exc)
            {
                log.Error(exc, exc.Mensaje);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (BaseDeDatosException exc)
            {
                log.Error(exc, exc.Mensaje);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral exceptionGeneral = new ExcepcionGeneral(exc.InnerException, DateTime.Now);

                log.Error(exc, exc.Message);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exceptionGeneral.Mensaje);
            }
        }

        /// <summary>
        /// Proceso para eliminar las apuestas de tipo cantidad de un usuario específico.
        /// </summary>
        /// <param name="DTOApuestaCantidad">Apuesta</param>
        [Route("eliminarapuestacantidad")]
        [System.Web.Http.AcceptVerbs("GET", "PUT")]
        [System.Web.Http.HttpPut]
        public HttpResponseMessage EliminarApuestaCantidad(DTOApuestaCantidad dto)
        {
            try
            {
                TraductorApuestaCantidad traductor = FabricaTraductor.CrearTraductorApuestaCantidad();

                Entidad apuesta = traductor.CrearEntidad(dto);

                Comando comando = FabricaComando.CrearComandoEliminarApuestaCantidad(apuesta);

                comando.Ejecutar();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (ObjetoNullException exc)
            {
                log.Error(exc, exc.Mensaje);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (BaseDeDatosException exc)
            {
                log.Error(exc, exc.Mensaje);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (ApuestaInvalidaException exc)
            {
                log.Error(exc, exc.Mensaje);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral exceptionGeneral = new ExcepcionGeneral(exc.InnerException, DateTime.Now);

                log.Error(exc, exc.Message);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exceptionGeneral.Mensaje);
            }
        }

        /// <summary>
        /// Proceso para eliminar las apuestas de tipo jugador de un usuario específico.
        /// </summary>
        /// <param name="DTOApuestaJugador">Apuesta</param>
        [Route("eliminarapuestajugador")]
        [System.Web.Http.AcceptVerbs("GET", "PUT")]
        [System.Web.Http.HttpPut]
        public HttpResponseMessage EliminarApuestaJugador(DTOApuestaJugador dto)
        {
            try
            {
                TraductorApuestaJugador traductor = FabricaTraductor.CrearTraductorApuestaJugador();

                Entidad apuesta = traductor.CrearEntidad(dto);

                Comando comando = FabricaComando.CrearComandoEliminarApuestaJugador(apuesta);

                comando.Ejecutar();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (ObjetoNullException exc)
            {
                log.Error(exc, exc.Mensaje);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (BaseDeDatosException exc)
            {
                log.Error(exc, exc.Mensaje);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (ApuestaInvalidaException exc)
            {
                log.Error(exc, exc.Mensaje);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral exceptionGeneral = new ExcepcionGeneral(exc.InnerException, DateTime.Now);

                log.Error(exc, exc.Message);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exceptionGeneral.Mensaje);
            }
        }

        /// <summary>
        /// Proceso para eliminar las apuestas de tipo equipo de un usuario específico.
        /// </summary>
        /// <param name="DTOApuestaEquipo">Apuesta</param>
        [Route("eliminarapuestaequipo")]
        [System.Web.Http.AcceptVerbs("GET", "PUT")]
        [System.Web.Http.HttpPut]
        public HttpResponseMessage EliminarApuestaEquipo(DTOApuestaEquipo dto)
        {
            try
            {
                TraductorApuestaEquipo traductor = FabricaTraductor.CrearTraductorApuestaEquipo();

                Entidad apuesta = traductor.CrearEntidad(dto);

                Comando comando = FabricaComando.CrearComandoEliminarApuestaEquipo(apuesta);

                comando.Ejecutar();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (ObjetoNullException exc)
            {
                log.Error(exc, exc.Mensaje);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (BaseDeDatosException exc)
            {
                log.Error(exc, exc.Mensaje);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (ApuestaInvalidaException exc)
            {
                log.Error(exc, exc.Mensaje);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral exceptionGeneral = new ExcepcionGeneral(exc.InnerException, DateTime.Now);

                log.Error(exc, exc.Message);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exceptionGeneral.Mensaje);
            }

        }

        /// <summary>
        /// Proceso para obtener las apuestas de tipo verdadero/falso finalizadas de un usuario especifico.
        /// </summary>
        /// <param name="DTOUsuarioId">Usuario</param>
        [Route("obtenerapuestasvoffinalizadas")]
        [System.Web.Http.AcceptVerbs("GET", "PUT")]
        [System.Web.Http.HttpPut]
        public HttpResponseMessage ObtenerApuestasVoFFinalizadas(DTOUsuarioId dto)
        {
            try
            {
                TraductorUsuarioId traductor = FabricaTraductor.CrearTraductorUsuarioId();

                Entidad usuario = traductor.CrearEntidad(dto);

                Comando comando = FabricaComando.CrearComandoObtenerApuestasVoFFinalizadas(usuario);

                comando.Ejecutar();

                TraductorApuestaVOF traductorApuesta = FabricaTraductor.CrearTraductorApuestaVoF();

                List<DTOApuestaVOF> Listadtos = traductorApuesta.CrearListaDto(comando.GetEntidades());

                return Request.CreateResponse(HttpStatusCode.OK, Listadtos);
            }
            catch (ObjetoNullException exc)
            {
                log.Error(exc, exc.Mensaje);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (BaseDeDatosException exc)
            {
                log.Error(exc, exc.Mensaje);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral exceptionGeneral = new ExcepcionGeneral(exc.InnerException, DateTime.Now);

                log.Error(exc, exc.Message);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exceptionGeneral.Mensaje);
            }
        }

        /// <summary>
        /// Proceso para obtener las apuestas de tipo cantidad finalizadas de un usuario especifico.
        /// </summary>
        /// <param name="DTOUsuarioId">Usuario</param>
        [Route("obtenerapuestascantidadfinalizadas")]
        [System.Web.Http.AcceptVerbs("GET", "PUT")]
        [System.Web.Http.HttpPut]
        public HttpResponseMessage ObtenerApuestasCantidadFinalizadas(DTOUsuarioId dto)
        {
            try
            {
                TraductorUsuarioId traductor = FabricaTraductor.CrearTraductorUsuarioId();

                Entidad usuario = traductor.CrearEntidad(dto);

                Comando comando = FabricaComando.CrearComandoObtenerApuestasCantidadFinalizadas(usuario);

                comando.Ejecutar();

                TraductorApuestaCantidad traductorApuesta = FabricaTraductor.CrearTraductorApuestaCantidad();

                List<DTOApuestaCantidad> Listadtos = traductorApuesta.CrearListaDto(comando.GetEntidades());

                return Request.CreateResponse(HttpStatusCode.OK, Listadtos);
            }
            catch (ObjetoNullException exc)
            {
                log.Error(exc, exc.Mensaje);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (BaseDeDatosException exc)
            {
                log.Error(exc, exc.Mensaje);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral exceptionGeneral = new ExcepcionGeneral(exc.InnerException, DateTime.Now);

                log.Error(exc, exc.Message);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exceptionGeneral.Mensaje);
            }
        }

        /// <summary>
        /// Proceso para obtener las apuestas de tipo jugador finalizadas de un usuario especifico.
        /// </summary>
        /// <param name="DTOUsuarioId">Usuario</param>
        [Route("obtenerapuestasjugadorfinalizadas")]
        [System.Web.Http.AcceptVerbs("GET", "PUT")]
        [System.Web.Http.HttpPut]
        public HttpResponseMessage ObtenerApuestasJugadorFinalizadas(DTOUsuarioId dto)
        {
            try
            {
                TraductorUsuarioId traductor = FabricaTraductor.CrearTraductorUsuarioId();

                Entidad usuario = traductor.CrearEntidad(dto);

                Comando comando = FabricaComando.CrearComandoObtenerApuestasJugadorFinalizadas(usuario);

                comando.Ejecutar();

                TraductorApuestaJugador traductorApuesta = FabricaTraductor.CrearTraductorApuestaJugador();

                List<DTOApuestaJugador> Listadtos = traductorApuesta.CrearListaDto(comando.GetEntidades());

                return Request.CreateResponse(HttpStatusCode.OK, Listadtos);
            }
            catch (ObjetoNullException exc)
            {
                log.Error(exc, exc.Mensaje);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (BaseDeDatosException exc)
            {
                log.Error(exc, exc.Mensaje);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral exceptionGeneral = new ExcepcionGeneral(exc.InnerException, DateTime.Now);

                log.Error(exc, exc.Message);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exceptionGeneral.Mensaje);
            }
        }

        /// <summary>
        /// Proceso para obtener las apuestas de tipo equipo finalizadas de un usuario especifico.
        /// </summary>
        /// <param name="DTOUsuarioId">Usuario</param>
        [Route("obtenerapuestasequipofinalizadas")]
        [System.Web.Http.AcceptVerbs("GET", "PUT")]
        [System.Web.Http.HttpPut]
        public HttpResponseMessage ObtenerApuestasEquipoFinalizadas(DTOUsuarioId dto)
        {
            try
            {
                TraductorUsuarioId traductor = FabricaTraductor.CrearTraductorUsuarioId();

                Entidad usuario = traductor.CrearEntidad(dto);

                Comando comando = FabricaComando.CrearComandoObtenerApuestasEquipoFinalizadas(usuario);

                comando.Ejecutar();

                TraductorApuestaEquipo traductorApuesta = FabricaTraductor.CrearTraductorApuestaEquipo();

                List<DTOApuestaEquipo> Listadtos = traductorApuesta.CrearListaDto(comando.GetEntidades());

                return Request.CreateResponse(HttpStatusCode.OK, Listadtos);
            }
            catch (ObjetoNullException exc)
            {
                log.Error(exc, exc.Mensaje);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (BaseDeDatosException exc)
            {
                log.Error(exc, exc.Mensaje);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral exceptionGeneral = new ExcepcionGeneral(exc.InnerException, DateTime.Now);

                log.Error(exc, exc.Message);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exceptionGeneral.Mensaje);
            }
        }

        /// <summary>
        /// Proceso para marcar todas las apuestas de los logros finalizados como ganadas o perdidas.
        /// </summary>
        [Route("finalizarapuestas")]
        [System.Web.Http.AcceptVerbs("PUT", "GET")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage FinalizarApuestas()
        {
            try
            {
                Comando comando = FabricaComando.CrearComandoFinalizarApuestas();

                comando.Ejecutar();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (BaseDeDatosException exc)
            {
                log.Error(exc, exc.Mensaje);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral exceptionGeneral = new ExcepcionGeneral(exc.InnerException, DateTime.Now);

                log.Error(exc, exc.Message);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exceptionGeneral.Mensaje);
            }
        }

    }
}
