using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
using WebAPI.Models.DataBase;
using WebAPI.Models.Excepciones;
using System.Data;
using System.Web;

namespace WebAPI.Controllers
{

    [RoutePrefix("api/M10_Usuario")]
    public class M10_UsuarioController : ApiController
    {
        private DataBase _database = new DataBase();
        private List<Usuario> _listaUsuarios;
        private Usuario _usuario;


        [Route("ActualizarPerfil")]
        [System.Web.Http.AcceptVerbs("GET", "PUT")]
        [System.Web.Http.HttpPut]
        public IHttpActionResult ActualizarPerfil(Usuario usuario)
        {
            try
            {

                EditarPerfil(usuario);

                return Ok(usuario.Nombre);
            }
            catch (UsuarioNullException exc)
            {
                _database.Desconectar();
                return BadRequest(exc.Message);
            }
            catch (Exception e)
            {
                _database.Desconectar();
                return BadRequest("Error en el servidor: "+e.GetType().FullName);
            }
 

        }

        //[Route("CrearUsuarioAdministrador/{nombreUsuario}/{nombre}/{apellido}/{fechaNacimiento}/{correo}/{genero}/{password}")]
        //public IHttpActionResult CrearUsuarioAdministrador(string nombreUsuario, string nombre, string apellido, string fechaNacimiento,
        //string correo, char genero, string password)
        [Route("CrearUsuarioAdministrador")]
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult CrearUsuarioAdministrador(Usuario usuario)
        {
            try
            {
                VerificarCorreoExiste(usuario);

                InsertarAdministrador(usuario);

                return Ok();
            }
            catch (UsuarioNullException exc)
            {
                _database.Desconectar();
                return BadRequest(exc.Message);
            }
            catch (CorreoEnUsoException exc)
            {
                _database.Desconectar();
                return BadRequest(exc.Message);
            }
            catch (Exception e)
            {
                _database.Desconectar();
                return BadRequest("Error en el servidor: " + e.Message);
            }

        }

        [Route("AdministradorDesactivaUsuario")]
        [System.Web.Http.AcceptVerbs("GET", "PUT")]
        [System.Web.Http.HttpPut]
        public IHttpActionResult AdministradorDesactivaUsuario(Usuario usuario)
        {
            try
            {
                GestionarActivo(usuario, false);

                return Ok();
            }
            catch (UsuarioNullException exc)
            {
                _database.Desconectar();
                return BadRequest(exc.Message);
            }
            catch (Exception e)
            {
                _database.Desconectar();
                return BadRequest("Error en el servidor: " + e.Message);
            }

        }

        [Route("DesactivarUsuarioPropio")]
        [System.Web.Http.AcceptVerbs("GET", "PUT")]
        [System.Web.Http.HttpPut]
        public IHttpActionResult DesactivarUsuarioPropio(Usuario usuario)
        {
            try
            {
                VerificarClaveUsuario(usuario);

                GestionarActivo(usuario, false);

                return Ok();
            }
            catch(UsuarioNullException exc)
            {
                _database.Desconectar();
                return BadRequest(exc.Message);
            }
            catch (Exception e)
            {
                _database.Desconectar();
                return BadRequest("Error en el servidor: " + e.Message);
            }

        }

        [Route("ActivarUsuario")]
        [System.Web.Http.AcceptVerbs("GET", "PUT")]
        [System.Web.Http.HttpPut]
        public IHttpActionResult ActivarUsuario(Usuario usuario)
        {
            try
            {
                GestionarActivo(usuario,true);

                return Ok();
            }
            catch(UsuarioNullException exc)
            {
                _database.Desconectar();
                return BadRequest(exc.Message);
            }
            catch (Exception e)
            {
                _database.Desconectar();
                return BadRequest("Error en el servidor: " + e.Message);
            }

        }

        [Route("ActualizarClaveUsuario/{passwordNuevo}")]
        [System.Web.Http.AcceptVerbs("GET", "PUT")]
        [System.Web.Http.HttpPut]
        public IHttpActionResult ActualizarClaveUsuario(Usuario usuario, string passwordNuevo)
        {
            try
            {
                VerificarClaveUsuario(usuario);

                usuario.Password = passwordNuevo;

                EditarPassword(usuario);

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
            catch (Exception e)
            {
                _database.Desconectar();
                return BadRequest("Error en el servidor: " + e.Message);
            }

        }

        [Route("ActualizarCorreoUsuario/{idUsuario:int}/{correo}/{clave}")]
        [System.Web.Http.AcceptVerbs("GET", "PUT")]
        [System.Web.Http.HttpPut]
        public IHttpActionResult ActualizarCorreoUsuario(Usuario usuario)
        {
            try
            {
                
                VerificarClaveUsuario(usuario);

                VerificarCorreoExiste(usuario);

                EditarCorreo(usuario);


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
            catch(CorreoEnUsoException exc)
            {

                return BadRequest(exc.Message);
            }
            catch (Exception e)
            {
                _database.Desconectar();
                return BadRequest("Error en el servidor: " + e.Message);
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
                return Request.CreateResponse(HttpStatusCode.BadRequest, new HttpError("Error en el servidor:" + e.Message));
            }
        }

        [System.Web.Http.AcceptVerbs("GET")]
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
                return Request.CreateResponse(HttpStatusCode.BadRequest, new HttpError("Error en el servidor:" + e.Message));
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
            catch(UsuarioNoExisteException exc)
            {
                _database.Desconectar();
                return Request.CreateResponse(HttpStatusCode.OK, new HttpError(exc.Message));
            }
            catch (Exception e)
            {
                _database.Desconectar();
                return Request.CreateResponse(HttpStatusCode.NotFound, new HttpError("Error en el servidor:" + e.Message));
            }
        }

        /// <summary>
        /// Devuelve los usuarios (no administradores) activos/no activos registrados en la base de datos. true = activos; false = no activos.
        /// </summary>
        public void ObtenerUsuarios(bool activo)
        {
            _listaUsuarios = new List<Usuario>();

            _database.Conectar();

            if(activo)
                _database.StoredProcedure("ObtenerUsuariosActivos()");
            else
                _database.StoredProcedure("ObtenerUsuariosNoActivos()");

            _database.EjecutarReader();

            Usuario usuarioLista;

            for(int i = 0; i < _database.cantidadRegistros; i++)
            {
                usuarioLista = new Usuario(_database.GetInt(i, 0), _database.GetString(i, 1), _database.GetString(i, 2), 
                    _database.GetString(i, 3), Convert.ToDateTime(_database.GetString(i, 4)).ToShortDateString(), _database.GetString(i, 5));

                _listaUsuarios.Add(usuarioLista);
            }
        }


        /// <summary>
        /// Actualiza la información del perfil de usuario en la base de datos.
        /// </summary>
        public void EditarPerfil(Usuario usuario)
        {
            try
            {
                _database.Conectar();

                _database.StoredProcedure("editarperfilusuario(@id, @nombre, @apellido, @fechaNacimiento, @genero, @foto)");

                _database.AgregarParametro("id", usuario.Id);
                _database.AgregarParametro("nombre", usuario.Nombre);
                _database.AgregarParametro("apellido", usuario.Apellido);
                _database.AgregarParametro("fechaNacimiento", Convert.ToDateTime(usuario.FechaNacimiento).ToShortDateString());
                _database.AgregarParametro("genero", usuario.Genero.ToString().ToUpper());
                _database.AgregarParametro("foto", usuario.FotoPath);

                _database.EjecutarQuery();
            }
            catch (NullReferenceException exc)
            {
                throw new UsuarioNullException(exc);
            }
        }

        /// <summary>
        /// Activa/Desactiva la cuenta del usuario, true = activa ; false = desactiva.
        /// </summary>
        public void GestionarActivo(Usuario usuario, bool activo)
        {
            try
            {
                _database.Conectar();

                _database.StoredProcedure("gestionaractivocuentausuario(@id, @activo)");

                _database.AgregarParametro("id", usuario.Id);
                _database.AgregarParametro("activo", activo);

                _database.EjecutarQuery();
            }
            catch(NullReferenceException exc)
            {
                throw new UsuarioNullException(exc);
            }
        }


        /// <summary>
        /// Actualiza la contraseña del usuario.
        /// </summary>
        public void EditarPassword(Usuario usuario)
        {
            try
            {
                _database.Conectar();

                _database.StoredProcedure("cambiarpasswordusuario(@id, @clave)");

                _database.AgregarParametro("id", usuario.Id);
                _database.AgregarParametro("clave", usuario.Password);

                _database.EjecutarQuery();
            }
            catch(NullReferenceException exc)
            {
                throw new UsuarioNullException(exc);
            }
        }

        /// <summary>
        /// Actualiza el correo del usuario.
        /// </summary>
        public void EditarCorreo(Usuario usuario)
        {
            try
            {
                _database.Conectar();

                _database.StoredProcedure("cambiarcorreousuario(@id, @correo)");

                _database.AgregarParametro("id", usuario.Id);
                _database.AgregarParametro("correo", usuario.Correo);

                _database.EjecutarQuery();
            }
            catch (NullReferenceException exc)
            {
                throw new UsuarioNullException(exc);
            }
        }

        /// <summary>
        /// Verifica si el correo ya se encuentra registrado en la base de datos.
        /// </summary>
        public void VerificarCorreoExiste(Usuario usuario)
        {
            try
            {

                _database.Conectar();

                _database.StoredProcedure("verificarcorreoexiste(@correo)");

                _database.AgregarParametro("correo", usuario.Correo);

                _database.EjecutarReader();

                int countCorreo = _database.GetInt(0, 0);

                if (countCorreo > 0)
                    throw new CorreoEnUsoException(usuario.Correo);

            }
            catch(NullReferenceException exc)
            {
                throw new UsuarioNullException(exc);
            }

        }

        /// <summary>
        /// Verifica si la clave ingresada coincide con la clave actual del usuario.
        /// </summary>
        public void VerificarClaveUsuario(Usuario usuario)
        {
            try
            {
                _database.Conectar();

                _database.StoredProcedure("verificarclaveusuario(@clave, @idUsuario)");

                _database.AgregarParametro("clave", usuario.Password);
                _database.AgregarParametro("idUsuario", usuario.Id);

                _database.EjecutarReader();

                int countClave = _database.GetInt(0, 0);

                if (countClave < 1)
                    throw new ClaveInvalidaException(usuario.Id, usuario.Password);
            }
            catch(NullReferenceException exc)
            {
                throw new UsuarioNullException(exc);
            }

        }

        /// <summary>
        /// Ingresa un nuevo usuario administrador en la base de datos.
        /// </summary>
        public void InsertarAdministrador(Usuario usuario)
        {
            try
            {
                _database.Conectar();

                _database.StoredProcedure("crearusuarioadministrador(@nombreU, @nombre, @apellido, @fechaNacimiento, @correo, @genero, @clave)");

                _database.AgregarParametro("nombreU", usuario.NombreUsuario);
                _database.AgregarParametro("nombre", usuario.Nombre);
                _database.AgregarParametro("apellido", usuario.Apellido);
                _database.AgregarParametro("fechaNacimiento", usuario.FechaNacimiento);
                _database.AgregarParametro("correo", usuario.Correo);
                _database.AgregarParametro("genero", usuario.Genero.ToString().ToUpper());
                _database.AgregarParametro("clave", usuario.Password);

                _database.EjecutarQuery();
            }
            catch (NullReferenceException exc)
            {
                throw new UsuarioNullException(exc);
            }
        }

        /// <summary>
        /// Extrae la información usuario de la base de datos ingresado por su id.
        /// </summary>
        public Usuario GetUsuario(int idUsuario)
        {
            try
            {
                _database.Conectar();

                _database.StoredProcedure("ObtenerUsuario(@id)");

                _database.AgregarParametro("id", idUsuario);

                _database.EjecutarReader();

                _usuario = new Usuario(idUsuario, _database.GetString(0, 0), _database.GetString(0, 1), _database.GetString(0, 2), Convert.ToDateTime(_database.GetString(0, 3)).ToShortDateString(),
                    _database.GetString(0, 4), _database.GetChar(0, 5), _database.GetString(0, 6), _database.GetString(0, 7), false, _database.GetBool(0, 8), "");

                return _usuario;
            }
            catch (IndexOutOfRangeException exc)
            {
                throw new UsuarioNoExisteException(exc, idUsuario);
            }

        }

    }
}
