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

        [Route("ActualizarPerfil/{idUsuario:int}/{nombre}/{apellido}/{fechaNacimiento}/{genero}/{fotoPath}")]
        [HttpPut, HttpGet]
        public IHttpActionResult ActualizarPerfil(int idUsuario, string nombre, string apellido, string fechaNacimiento, char genero, string fotoPath)
        {
            try
            {
                _usuario = new Usuario(idUsuario, nombre, apellido, fechaNacimiento, genero, fotoPath);

                EditarPerfil(_usuario);

                return Ok("Usuario editado con exito.");
            }
            catch (Exception e)
            {
                _database.Desconectar();
                return BadRequest("Error en el servidor: "+e.Message);
            }

        }

        [Route("CrearUsuarioAdministrador/{nombreUsuario}/{nombre}/{apellido}/{fechaNacimiento}/{correo}/{genero}/{password}")]
        [HttpPost, HttpGet]
        public IHttpActionResult CrearUsuarioAdministrador(string nombreUsuario, string nombre, string apellido, string fechaNacimiento,
            string correo, char genero, string password)
        {
            try
            {
                VerificarCorreoExiste(correo);

                _usuario = new Usuario(nombreUsuario,nombre,apellido, fechaNacimiento, correo,genero,true, password);

                InsertarAdministrador(_usuario);

                return Ok();
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


        [Route("DesactivarUsuario/{idUsuario:int}")]
        [HttpPut, HttpGet]
        public IHttpActionResult DesactivarUsuario(int idUsuario)
        {
            try
            {
                GestionarActivo(idUsuario, false);

                return Ok();
            }
            catch (Exception e)
            {
                _database.Desconectar();
                return BadRequest("Error en el servidor: " + e.Message);
            }

        }

        [Route("ActivarUsuario/{idUsuario:int}")]
        [HttpPut, HttpGet]
        public IHttpActionResult ActivarUsuario(int idUsuario)
        {
            try
            {
                GestionarActivo(idUsuario,true);

                return Ok();
            }
            catch (Exception e)
            {
                _database.Desconectar();
                return BadRequest("Error en el servidor: " + e.Message);
            }

        }

        [Route("ActualizarClaveUsuario/{idUsuario:int}/{password}/{passwordAnterior}")]
        [HttpPut, HttpGet]
        public IHttpActionResult ActualizarClaveUsuario(int idUsuario, string password, string passwordAnterior)
        {
            try
            {
                VerificarClaveUsuario(idUsuario, passwordAnterior);

                EditarPassword(idUsuario, password);

                return Ok();
            }
            catch(ClaveInvalidaException exc)
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
        [HttpPut, HttpGet]
        public IHttpActionResult ActualizarCorreoUsuario(int idUsuario, string correo, string clave)
        {
            try
            {
                
                VerificarClaveUsuario(idUsuario, clave);

                VerificarCorreoExiste(correo, idUsuario);

                EditarCorreo(idUsuario, correo);


                return Ok();
            }
            catch(ClaveInvalidaException exc)
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

        [HttpGet]
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
                return Request.CreateResponse(HttpStatusCode.NotFound, new HttpError("Error en el servidor:" + e.Message));
            }
        }

        [HttpGet]
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
                return Request.CreateResponse(HttpStatusCode.NotFound, new HttpError("Error en el servidor:" + e.Message));
            }
        }
        [Route("ObtenerUsuario/{idUsuario:int}")]
        [HttpGet]
        public HttpResponseMessage ObtenerUsuario(int idUsuario)
        {
            try
            {
                GetUsuario(idUsuario);

                return Request.CreateResponse(HttpStatusCode.OK, _usuario);
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
                    _database.GetString(i, 3), _database.GetString(i, 4), _database.GetString(i, 5));

                _listaUsuarios.Add(usuarioLista);
            }
        }


        /// <summary>
        /// Actualiza la información del perfil de usuario en la base de datos.
        /// </summary>
        public void EditarPerfil(Usuario usuario)
        {
            _database.Conectar();

            _database.StoredProcedure("editarperfilusuario(@id, @nombre, @apellido, @fechaNacimiento, @genero, @foto)");

            _database.AgregarParametro("id", usuario.Id);
            _database.AgregarParametro("nombre", usuario.Nombre);
            _database.AgregarParametro("apellido", usuario.Apellido);
            _database.AgregarParametro("fechaNacimiento", usuario.FechaNacimiento);
            _database.AgregarParametro("genero", usuario.Genero.ToString().ToUpper());
            _database.AgregarParametro("foto", usuario.FotoPath);

            _database.EjecutarQuery();
        }

        /// <summary>
        /// Activa/Desactiva la cuenta del usuario, true = activa ; false = desactiva.
        /// </summary>
        public void GestionarActivo(int idUsuario, bool activo)
        {
            _database.Conectar();

            _database.StoredProcedure("gestionaractivocuentausuario(@id, @activo)");

            _database.AgregarParametro("id", idUsuario);
            _database.AgregarParametro("activo", activo);

            _database.EjecutarQuery();
        }


        /// <summary>
        /// Actualiza la contraseña del usuario.
        /// </summary>
        public void EditarPassword(int idUsuario, string clave)
        {
            _database.Conectar();

            _database.StoredProcedure("cambiarpasswordusuario(@id, @clave)");

            _database.AgregarParametro("id", idUsuario);
            _database.AgregarParametro("clave", clave);

            _database.EjecutarQuery();
        }

        /// <summary>
        /// Actualiza el correo del usuario.
        /// </summary>
        public void EditarCorreo(int idUsuario, string correo)
        {
            _database.Conectar();

            _database.StoredProcedure("cambiarcorreousuario(@id, @correo)");

            _database.AgregarParametro("id", idUsuario);
            _database.AgregarParametro("correo", correo);

            _database.EjecutarQuery();
        }

        /// <summary>
        /// Verifica si el correo ya se encuentra registrado en la base de datos.
        /// </summary>
        public void VerificarCorreoExiste(string correo, int idUsuario = -1)
        {
            _database.Conectar();

            _database.StoredProcedure("verificarcorreoexiste(@correo)");

            _database.AgregarParametro("correo", correo);

            _database.EjecutarReader();

            int countCorreo = _database.GetInt(0, 0);

            if (countCorreo > 0)
                throw new CorreoEnUsoException(idUsuario,correo);

        }

        /// <summary>
        /// Verifica si la clave ingresada coincide con la clave actual del usuario.
        /// </summary>
        public void VerificarClaveUsuario(int idUsuario, string clave)
        {
            _database.Conectar();

            _database.StoredProcedure("verificarclaveusuario(@clave, @idUsuario)");

            _database.AgregarParametro("clave", clave);
            _database.AgregarParametro("idUsuario", idUsuario);

            _database.EjecutarReader();

            int countClave = _database.GetInt(0, 0);

            if (countClave < 1)
                throw new ClaveInvalidaException(idUsuario, clave);

        }

        /// <summary>
        /// Ingresa un nuevo usuario administrador en la base de datos.
        /// </summary>
        public void InsertarAdministrador(Usuario usuario)
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

        public void GetUsuario(int idUsuario)
        {
            _database.Conectar();

            _database.StoredProcedure("ObtenerUsuario(@id)");

            _database.AgregarParametro("id", idUsuario);

            _database.EjecutarReader();

            _usuario = new Usuario("", _database.GetString(0, 0), _database.GetString(0, 1), _database.GetString(0, 2), 
                null,_database.GetChar(0, 3),null,_database.GetString(0,4),false,null);
        }

    }
}
