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
using CopaMundialAPI.Servicios.DTO.Logros;
using CopaMundialAPI.Comun.Excepciones;

namespace CopaMundialAPI.Presentacion.Controllers
{
    [RoutePrefix("api/Apuesta")]
    public class ApuestaController : ApiController
    {
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
            catch(ObjetoNullException exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral personalizada = new ExcepcionGeneral(exc.InnerException, DateTime.Now);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, personalizada.Mensaje);
            }

        }

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
            catch(Exception exc)
            {
                ExcepcionGeneral personalizada = new ExcepcionGeneral(exc.InnerException, DateTime.Now);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, personalizada.Mensaje);
            }
        }

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

                comando = FabricaComando.CrearComandoAgregarApuestaVoF(apuesta);

                comando.Ejecutar();

                return Request.CreateResponse(HttpStatusCode.OK);
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
