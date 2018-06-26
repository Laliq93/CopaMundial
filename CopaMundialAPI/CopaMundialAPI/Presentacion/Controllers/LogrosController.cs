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
using CopaMundialAPI.Servicios.DTO.Logros;
using CopaMundialAPI.Servicios.Fabrica;
using CopaMundialAPI.Comun.Excepciones;
using CopaMundialAPI.Servicios.Traductores.Logros;
using CopaMundialAPI.Servicios.Traductores.Fabrica;

namespace CopaMundialAPI.Presentacion.Controllers
{
    [RoutePrefix ( "api/logros" )]
    public class LogrosController : ApiController
    {

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

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, personalizada.Mensaje);
            }
        }
    }
}
