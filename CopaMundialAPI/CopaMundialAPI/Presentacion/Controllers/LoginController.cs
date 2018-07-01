using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NLog;

using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Servicios.DTO.Usuario;

using CopaMundialAPI.Servicios.Traductores.Fabrica;
using CopaMundialAPI.Servicios.Traductores.Usuarios;

using CopaMundialAPI.Logica_de_Negocio.Comando;
using CopaMundialAPI.Logica_de_Negocio.Fabrica;

using CopaMundialAPI.Comun.Excepciones;

namespace CopaMundialAPI.Presentacion.Controllers
{
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
        Logger log = LogManager.GetLogger("fileLogger");


        [Route("RegistrarUsuario")]
        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage RegistrarUsuario(DTOUsuarioRegistrar dto)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine(dto.Nombre + " " + dto.Apellido);

                TraductorUsuarioRegistrar traductor = FabricaTraductor.CrearTraductorUsuarioRegistrar();

                Entidad usuario = traductor.CrearEntidad(dto);

                Comando comando = FabricaComando.CrearComandoAgregarUsuario(usuario);

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

        [Route("Test/{hola}")]
        [System.Web.Http.AcceptVerbs("GET", "PUT")]
        [System.Web.Http.HttpPut]
        public HttpResponseMessage Testing(string hola)
        {
            return Request.CreateResponse(HttpStatusCode.OK, "String: " + hola);
        }

    }
}
