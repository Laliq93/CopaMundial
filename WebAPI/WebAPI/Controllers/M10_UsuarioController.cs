using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
using WebAPI.Models.DataBase;
using System.Data;
using System.Web;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/M10_Usuario")]
    public class M10_UsuarioController : ApiController
    {
        private DataBase _database = new DataBase();
        private List<Usuario> _listaUsuarios;

        [Route("ActualizarPerfil/{idUsuario:int}/{nombre}/{apellido}/{fechaNacimiento}/{genero}/{fotoPath}")]
        [HttpPut, HttpGet]
        public IHttpActionResult ActualizarPerfil(int idUsuario, string nombre, string apellido, string fechaNacimiento, char genero, string fotoPath)
        {
            try
            {
                EditarPerfil(idUsuario, nombre, apellido, fechaNacimiento, genero, fotoPath);

                return Ok("Usuario editado con exito.");
            }
            catch (Exception e)
            {
                _database.Desconectar();
                return BadRequest("Error en el servidor: "+e.Message);
            }

        }


        [Route("DesactivarUsuario/{idUsuario:int}")]
        [HttpPut, HttpGet]
        public IHttpActionResult DesactivarUsuario(int idUsuario)
        {
            try
            {
                GestionarActivo(idUsuario, false);

                return Ok("Usuario desactivado con exito.");
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

                return Ok("Usuario activado con exito.");
            }
            catch (Exception e)
            {
                _database.Desconectar();
                return BadRequest("Error en el servidor: " + e.Message);
            }

        }

        [Route("ActualizarClaveUsuario/{idUsuario:int}/{password}")]
        [HttpPut, HttpGet]
        public IHttpActionResult ActualizarClaveUsuario(int idUsuario, string password)
        {
            try
            {
                EditarPassword(idUsuario, password);

                return Ok("Clave actualizada con exito.");
            }
            catch (Exception e)
            {
                _database.Desconectar();
                return BadRequest("Error en el servidor: " + e.Message);
            }

        }

        [HttpGet]
        public HttpResponseMessage ObtenerUsuarioActivos()
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



        private void ObtenerUsuarios(bool activo)
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
                    _database.GetString(i, 3), _database.GetDateTime(i, 4), _database.GetString(i, 5));

                _listaUsuarios.Add(usuarioLista);
            }
        }

        private void EditarPerfil(int idUsuario, string nombre, string apellido, string fechaNacimiento, char genero, string fotoPath)
        {
            _database.Conectar();

            _database.StoredProcedure("editarperfilusuario(@id, @nombre, @apellido, @fechaNacimiento, @genero, @foto)");

            _database.AgregarParametro("id", idUsuario);
            _database.AgregarParametro("nombre", nombre);
            _database.AgregarParametro("apellido", apellido);
            _database.AgregarParametro("fechaNacimiento", fechaNacimiento);
            _database.AgregarParametro("genero", genero.ToString().ToUpper());
            _database.AgregarParametro("foto", fotoPath);

            _database.EjecutarQuery();
        }

        private void GestionarActivo(int idUsuario, bool activo)
        {
            _database.Conectar();

            _database.StoredProcedure("gestionaractivocuentausuario(@id, @activo)");

            _database.AgregarParametro("id", idUsuario);
            _database.AgregarParametro("activo", activo);

            _database.EjecutarQuery();
        }

        
        private void EditarPassword(int idUsuario, string clave)
        {
            _database.Conectar();

            _database.StoredProcedure("cambiarpasswordusuario(@id, @clave)");

            _database.AgregarParametro("id", idUsuario);
            _database.AgregarParametro("clave", clave);

            _database.EjecutarQuery();
        }




    }
}
