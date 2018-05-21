using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
using WebAPI.Models.DataBase;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/M1_RegistroLoginRecuperar")]
    public class M1_RegistroLoginRecuperarController : ApiController
    {

        private DataBase _database = new DataBase();
        private List<Usuario> _listaUsuarios;

        [Route("RegistrarUsuario/{nombreUsuario}/{nombre}/{apellido}/{fechaNacimiento}/{correo}/{genero}/{password}")]
        [HttpPost]
        public IHttpActionResult PostUsuario(string nombreUsuario, string nombre, string apellido, 
            string fechaNacimiento, string correo, char genero, string password)
        {
            try
            {
                AgregarUsuario(nombreUsuario, nombre, apellido, fechaNacimiento, correo, genero, password);

                return Ok("Usuario registrado exitosamente");
            }
            catch (Exception e)
            {
                _database.Desconectar();
                return BadRequest("Error en el servidor: " + e.Message);
            }

        }

        private void AgregarUsuario(string nombreUsuario, string nombre, string apellido, 
            string fechaNacimiento, string correo, char genero, string password)
        {
            _database.Conectar();

            _database.StoredProcedure("AgregarUsuario(@nombreUsuario, @nombre, @apellido, @fechaNacimiento, @correo, @genero, @password)");

            _database.AgregarParametro("nombreUsuario", nombreUsuario);
            _database.AgregarParametro("nombre", nombre);
            _database.AgregarParametro("apellido", apellido);
            _database.AgregarParametro("fechaNacimiento", fechaNacimiento);
            _database.AgregarParametro("correo", correo);
            _database.AgregarParametro("genero", genero.ToString().ToUpper());
            _database.AgregarParametro("password", password);

            _database.EjecutarQuery();
        }
    }
}