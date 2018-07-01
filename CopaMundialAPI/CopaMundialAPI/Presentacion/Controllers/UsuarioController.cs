using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NLog;
using Npgsql;
using CopaMundialAPI.Logica_de_Negocio.Fabrica;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Logica_de_Negocio.Comando;
using CopaMundialAPI.Logica_de_Negocio.Comando.Usuarios;
using CopaMundialAPI.Servicios.DTO.Usuario;
using CopaMundialAPI.Servicios.Traductores.Fabrica;
using CopaMundialAPI.Servicios.Traductores.Usuarios;
using CopaMundialAPI.Comun.Excepciones;
using System.Reflection;

namespace CopaMundialAPI.Presentacion.Controllers
{
    [RoutePrefix("api/M10_Usuario")]
    public class UsuarioController : ApiController
    {
            Logger logger = LogManager.GetLogger("fileLogger");


        /// <summary>
        /// Metodo para actualizar el perfil de un usuario
        /// </summary>
        /// <param name="dto">Dto de tipo DtoUsuarioConfiguracion</param>
        /// <returns></returns>
        [Route("ActualizarPerfil")]
            [System.Web.Http.AcceptVerbs("GET", "PUT")]
            [System.Web.Http.HttpPut]
            public HttpResponseMessage ActualizarPerfil(DTOUsuarioConfiguracion dto)
            {
            try
            {
                TraductorUsuarioConfiguracion traductor = FabricaTraductor.CrearTraductorUsuarioConfiguracion();
                Entidad usuario = traductor.CrearEntidad( dto );
                Comando comando = FabricaComando.CrearComandoActualizarUsuario(usuario);
                comando.Ejecutar();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (NpgsqlException e)
            {
                logger.Error(e, e.Message);

                throw new BaseDeDatosException(e, "Error en la base de datos: " + GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ". " + e.Message);
            }

            catch (Exception e)
            {
                logger.Error(e, e.Message);

                throw new ExcepcionGeneral(e, DateTime.Now);

            }

        }

            //[Route("CrearUsuarioAdministrador/{nombreUsuario}/{nombre}/{apellido}/{fechaNacimiento}/{correo}/{genero}/{password}")]
            //public IHttpActionResult CrearUsuarioAdministrador(string nombreUsuario, string nombre, string apellido, string fechaNacimiento,
            //string correo, char genero, string password)
            [Route("CrearUsuarioAdministrador")]
            [System.Web.Http.AcceptVerbs("GET", "POST")]
            [System.Web.Http.HttpPost]
            public HttpResponseMessage CrearUsuarioAdministrador(DTOUsuarioRegistrar dto)
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
                logger.Error(exc, exc.Mensaje);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc.Mensaje);
            }
            catch (Exception exc)
            {
                ExcepcionGeneral exceptionGeneral = new ExcepcionGeneral(exc.InnerException, DateTime.Now);

                logger.Error(exc, exc.Message);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exceptionGeneral.Mensaje);
            }

        }

            [Route("AdministradorDesactivaUsuario")]
            [System.Web.Http.AcceptVerbs("GET", "PUT")]
            [System.Web.Http.HttpPut]
            public HttpResponseMessage AdministradorDesactivaUsuario(DTOUsuario dto)
            {
                try
                {

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                catch (Exception e)
                {
                    logger.Error(e, e.Message);

                    throw new ExcepcionGeneral(e, DateTime.Now);

                }
            }

        [Route("DesactivarUsuarioPropio")]
            [System.Web.Http.AcceptVerbs("GET", "PUT")]
            [System.Web.Http.HttpPut]
            public HttpResponseMessage DesactivarUsuarioPropio(DTOUsuario dto)
            {
                try
                {

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                catch (Exception e)
                {
                    logger.Error(e, e.Message);

                    throw new ExcepcionGeneral(e, DateTime.Now);

                }

            }

            [Route("ActivarUsuario")]
            [System.Web.Http.AcceptVerbs("GET", "PUT")]
            [System.Web.Http.HttpPut]
            public HttpResponseMessage ActivarUsuario(DTOUsuario dto)
            {
            try
            {

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                logger.Error(e, e.Message);

                throw new ExcepcionGeneral(e, DateTime.Now);

            }

        }

            [Route("ActualizarClaveUsuario/{passwordNuevo}")]
            [System.Web.Http.AcceptVerbs("GET", "PUT")]
            [System.Web.Http.HttpPut]
            public HttpResponseMessage ActualizarClaveUsuario(DTOUsuarioConfiguracion dto, string passwordNuevo)
            {
            try
            {
                TraductorUsuarioConfiguracion traductor = FabricaTraductor.CrearTraductorUsuarioConfiguracion();
                Entidad usuario = traductor.CrearEntidad(dto);
                Comando comando = FabricaComando.CrearComandoActualizarPassword(usuario);
                comando.Ejecutar();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (NpgsqlException e)
            {
                logger.Error(e, e.Message);

                throw new BaseDeDatosException(e, "Error en la base de datos: " + GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ". " + e.Message);
            }

            catch (Exception e)
            {
                logger.Error(e, e.Message);

                throw new ExcepcionGeneral(e, DateTime.Now);

            }
        }

            [Route("ActualizarCorreoUsuario")]
            [System.Web.Http.AcceptVerbs("GET", "PUT")]
            [System.Web.Http.HttpPut]
            public HttpResponseMessage ActualizarCorreoUsuario(DTOUsuarioConfiguracion dto)
            {
            try
            {
                TraductorUsuarioConfiguracion traductor = FabricaTraductor.CrearTraductorUsuarioConfiguracion();
                Entidad usuario = traductor.CrearEntidad(dto);
                Comando comando = FabricaComando.CrearComandoActualizarCorreo(usuario);
                comando.Ejecutar();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (NpgsqlException e)
            {
                logger.Error(e, e.Message);

                throw new BaseDeDatosException(e, "Error en la base de datos: " + GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ". " + e.Message);
            }

            catch (Exception e)
            {
                logger.Error(e, e.Message);

                throw new ExcepcionGeneral(e, DateTime.Now);

            }

        }

            [Route("AgregarJugadorFavorito/{idUsuario:int}/{idJugador:int}")]
            [System.Web.Http.AcceptVerbs("GET", "PUT")]
            [System.Web.Http.HttpPut]
            public IHttpActionResult AgregarJugadorFavorito(int idUsuario, int idJugador)
            {
            try
            {
                return Ok();
            }
            catch (NpgsqlException e)
            {
                logger.Error(e, e.Message);

                throw new BaseDeDatosException(e, "Error en la base de datos: " + GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ". " + e.Message);
            }

            catch (Exception e)
            {
                logger.Error(e, e.Message);

                throw new ExcepcionGeneral(e, DateTime.Now);

            }
        }


            [System.Web.Http.AcceptVerbs("GET")]
            [System.Web.Http.HttpGet]
            public HttpResponseMessage ObtenerUsuariosActivos()
            {
            try
            {
                ComandoObtenerUsuarioActivo comando = FabricaComando.CrearComandoObtenerUsuarioActivo();
                comando.Ejecutar();
                TraductorUsuarioConfiguracion traductor = FabricaTraductor.CrearTraductorUsuarioConfiguracion();

                List<Entidad> usuarios = comando.GetEntidades();
                List<DTOUsuarioConfiguracion> dtousuarios = traductor.CrearListaDto(usuarios);
                return Request.CreateResponse(HttpStatusCode.OK, dtousuarios);
            }
            catch (NpgsqlException e)
            {
                logger.Error(e, e.Message);

                throw new BaseDeDatosException(e, "Error en la base de datos: " + GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ". " + e.Message);
            }

            catch (Exception e)
            {
                logger.Error(e, e.Message);

                throw new ExcepcionGeneral(e, DateTime.Now);

            }
        }

            [System.Web.Http.AcceptVerbs("GET")]
            [System.Web.Http.HttpGet]
            public HttpResponseMessage ObtenerUsuariosNoActivos()
            {
            try
            {
                ComandoObtenerUsuarioNoActivo comando = FabricaComando.CrearComandoObtenerUsuarioNoActivo();
                comando.Ejecutar();
                TraductorUsuarioConfiguracion traductor = FabricaTraductor.CrearTraductorUsuarioConfiguracion();

                List<Entidad> usuarios = comando.GetEntidades();
                List<DTOUsuarioConfiguracion> dtousuarios = traductor.CrearListaDto(usuarios);
                return Request.CreateResponse(HttpStatusCode.OK, dtousuarios);
            }
            catch (NpgsqlException e)
            {
                logger.Error(e, e.Message);

                throw new BaseDeDatosException(e, "Error en la base de datos: " + GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ". " + e.Message);
            }

            catch (Exception e)
            {
                logger.Error(e, e.Message);

                throw new ExcepcionGeneral(e, DateTime.Now);

            }
        }
            [Route("ObtenerUsuario/{idUsuario:int}")]
            [System.Web.Http.AcceptVerbs("GET")]
            [System.Web.Http.HttpGet]
            public HttpResponseMessage ObtenerUsuario( DTOUsuarioId dto)
            {
            try
            {
                TraductorUsuarioId traductor = FabricaTraductor.CrearTraductorUsuarioId();

                TraductorUsuarioId traductorusuario = FabricaTraductor.CrearTraductorUsuarioId();

                Entidad usuario = traductor.CrearEntidad(dto);

                Comando comando = FabricaComando.CrearComandoObtenerUsuarioDatos(usuario);
                comando.Ejecutar();

                //usuario = traductorusuario.CrearEntidad(comando.GetEntidad());

                return Request.CreateResponse(HttpStatusCode.OK, "falta este" );
            }
            catch (NpgsqlException e)
            {
                logger.Error(e, e.Message);

                throw new BaseDeDatosException(e, "Error en la base de datos: " + GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ". " + e.Message);
            }

            catch (Exception e)
            {
                logger.Error(e, e.Message);

                throw new ExcepcionGeneral(e, DateTime.Now);

            }
        }

        }
}