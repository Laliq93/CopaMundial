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
using Newtonsoft.Json.Linq;
using CopaMundialAPI.Logica_de_Negocio.Comando;
using System.Threading.Tasks;
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


            [Route("ActualizarPerfil")]
            [System.Web.Http.AcceptVerbs("GET", "PUT")]
            [System.Web.Http.HttpPut]
            public HttpResponseMessage ActualizarPerfil(DTOUsuarioConfiguracion)
            {
                try
                {

                    EditarPerfil(usuario);

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                catch (UsuarioNullException exc)
                {
                    _database.Desconectar();
                    return Request.CreateResponse(HttpStatusCode.OK, new HttpError(exc.Message));//exc.Message);
                }
                catch (NpgsqlException e)
                {
                    _database.Desconectar();
                    return Request.CreateResponse(HttpStatusCode.OK, new HttpError("Error en la base de datos"));
                }
                catch (Exception e)
                {
                    _database.Desconectar();
                    return Request.CreateResponse(HttpStatusCode.OK, new HttpError("Error general."));
                }


            }

            //[Route("CrearUsuarioAdministrador/{nombreUsuario}/{nombre}/{apellido}/{fechaNacimiento}/{correo}/{genero}/{password}")]
            //public IHttpActionResult CrearUsuarioAdministrador(string nombreUsuario, string nombre, string apellido, string fechaNacimiento,
            //string correo, char genero, string password)
            [Route("CrearUsuarioAdministrador")]
            [System.Web.Http.AcceptVerbs("GET", "POST")]
            [System.Web.Http.HttpPost]
            public HttpResponseMessage CrearUsuarioAdministrador(Usuario usuario)
            {
                try
                {
                    VerificarCorreoExiste(usuario);

                    InsertarAdministrador(usuario);

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                catch (UsuarioNullException exc)
                {
                    _database.Desconectar();
                    return Request.CreateResponse(HttpStatusCode.OK, new HttpError(exc.Message));
                }
                catch (CorreoEnUsoException exc)
                {
                    _database.Desconectar();
                    return Request.CreateResponse(HttpStatusCode.OK, new HttpError(exc.Message));
                }
                catch (Exception e)
                {
                    _database.Desconectar();
                    return Request.CreateResponse(HttpStatusCode.OK, new HttpError("Error general"));
                }

            }

            [Route("AdministradorDesactivaUsuario")]
            [System.Web.Http.AcceptVerbs("GET", "PUT")]
            [System.Web.Http.HttpPut]
            public HttpResponseMessage AdministradorDesactivaUsuario(Usuario usuario)
            {
                try
                {
                    GestionarActivo(usuario, false);

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                catch (UsuarioNullException exc)
                {
                    _database.Desconectar();
                    return Request.CreateResponse(HttpStatusCode.OK, new HttpError(exc.Message));
                }
                catch (Exception e)
                {
                    _database.Desconectar();
                    return Request.CreateResponse(HttpStatusCode.OK, new HttpError("Error general"));
                }

            }

            [Route("DesactivarUsuarioPropio")]
            [System.Web.Http.AcceptVerbs("GET", "PUT")]
            [System.Web.Http.HttpPut]
            public HttpResponseMessage DesactivarUsuarioPropio(Usuario usuario)
            {
                try
                {
                    VerificarClaveUsuario(usuario);

                    GestionarActivo(usuario, false);

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                catch (UsuarioNullException exc)
                {
                    _database.Desconectar();
                    return Request.CreateResponse(HttpStatusCode.OK, new HttpError(exc.Message));
                }
                catch (ClaveInvalidaException exc)
                {
                    _database.Desconectar();
                    return Request.CreateResponse(HttpStatusCode.OK, new HttpError(exc.Message));
                }
                catch (Exception e)
                {
                    _database.Desconectar();
                    return Request.CreateResponse(HttpStatusCode.OK, new HttpError("Error general"));
                }

            }

            [Route("ActivarUsuario")]
            [System.Web.Http.AcceptVerbs("GET", "PUT")]
            [System.Web.Http.HttpPut]
            public HttpResponseMessage ActivarUsuario(Usuario usuario)
            {
                try
                {
                    GestionarActivo(usuario, true);

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                catch (UsuarioNullException exc)
                {
                    _database.Desconectar();
                    return Request.CreateResponse(HttpStatusCode.OK, new HttpError(exc.Message));
                }
                catch (Exception e)
                {
                    _database.Desconectar();
                    return Request.CreateResponse(HttpStatusCode.OK, new HttpError("Error general"));
                }

            }

            [Route("ActualizarClaveUsuario/{passwordNuevo}")]
            [System.Web.Http.AcceptVerbs("GET", "PUT")]
            [System.Web.Http.HttpPut]
            public HttpResponseMessage ActualizarClaveUsuario(Usuario usuario, string passwordNuevo)
            {
                try
                {
                    VerificarClaveUsuario(usuario);

                    usuario.Password = passwordNuevo;

                    EditarPassword(usuario);

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                catch (UsuarioNullException exc)
                {
                    _database.Desconectar();
                    return Request.CreateResponse(HttpStatusCode.OK, new HttpError(exc.Message));
                }
                catch (ClaveInvalidaException exc)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new HttpError(exc.Message));
                }
                catch (Exception e)
                {
                    _database.Desconectar();
                    return Request.CreateResponse(HttpStatusCode.OK, new HttpError("Error general"));
                }

            }

            [Route("ActualizarCorreoUsuario")]
            [System.Web.Http.AcceptVerbs("GET", "PUT")]
            [System.Web.Http.HttpPut]
            public HttpResponseMessage ActualizarCorreoUsuario(Usuario usuario)
            {
                try
                {

                    VerificarClaveUsuario(usuario);

                    VerificarCorreoExiste(usuario);

                    EditarCorreo(usuario);

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                catch (UsuarioNullException exc)
                {
                    _database.Desconectar();
                    return Request.CreateResponse(HttpStatusCode.OK, new HttpError(exc.Message));
                }
                catch (ClaveInvalidaException exc)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new HttpError(exc.Message));
                }
                catch (CorreoEnUsoException exc)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new HttpError(exc.Message));
                }
                catch (Exception e)
                {
                    _database.Desconectar();
                    return Request.CreateResponse(HttpStatusCode.OK, new HttpError("Error general"));
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
                catch (UsuarioNullException exc)
                {
                    _database.Desconectar();
                    return BadRequest(exc.Message);
                }
                catch (ClaveInvalidaException exc)
                {
                    return BadRequest(exc.Message);
                }
                catch (CorreoEnUsoException exc)
                {

                    return BadRequest(exc.Message);
                }
                catch (Exception e)
                {
                    _database.Desconectar();
                    return BadRequest("Error en el servidor: " + e.Message);
                }

            }


            [System.Web.Http.AcceptVerbs("GET")]
            [System.Web.Http.HttpGet]
            public HttpResponseMessage ObtenerUsuariosActivos()
            {
                try
                {
                    ObtenerUsuarios(true);

                    return Request.CreateResponse(HttpStatusCode.OK, _listaUsuarios);
                }
                catch (Exception e)
                {
                    _database.Desconectar();
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new HttpError("Error general"));
                }
            }

            [System.Web.Http.AcceptVerbs("GE T")]
            [System.Web.Http.HttpGet]
            public HttpResponseMessage ObtenerUsuariosNoActivos()
            {
                try
                {
                    ObtenerUsuarios(false);

                    return Request.CreateResponse(HttpStatusCode.OK, _listaUsuarios);
                }
                catch (Exception e)
                {
                    _database.Desconectar();
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new HttpError("Error general"));
                }
            }
            [Route("ObtenerUsuario/{idUsuario:int}")]
            [System.Web.Http.AcceptVerbs("GET")]
            [System.Web.Http.HttpGet]
            public HttpResponseMessage ObtenerUsuario(int idUsuario)
            {
                try
                {
                    GetUsuario(idUsuario);

                    return Request.CreateResponse(HttpStatusCode.OK, _usuario);
                }
                catch (UsuarioNullException exc)
                {
                    _database.Desconectar();
                    return Request.CreateResponse(HttpStatusCode.OK, new HttpError(exc.Message));
                }
                catch (Exception e)
                {
                    _database.Desconectar();
                    return Request.CreateResponse(HttpStatusCode.NotFound, new HttpError("Error general"));
                }
            }

        }
}