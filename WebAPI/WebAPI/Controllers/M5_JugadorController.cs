using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/M5_Jugador")]
    public class M5_JugadorController : ApiController
    {

        [Route("CrearJugador/{nombre}/{apellido}/{fechaNacimiento}/{lugarNacimiento}/{peso}/{altura}/{club}/{equipo}/{numero}/{posicion}/{capitan}")]
        [HttpPost, HttpGet]
        public IHttpActionResult CrearJugador(string nombre, string apellido, string fechaNacimiento, string lugarNacimiento, double peso, 
            double altura, string club, string equipo, int numero, bool capitan)
        {
            try
            {
                //InsertarAdministrador(nombreUsuario, nombre, apellido, fechaNacimiento, correo, genero, password);

                return Ok(peso);
            }
            catch (Exception e)
            {
                return BadRequest("Error en el servidor: " + e.Message);
            }

        }

        private void InsertarJugador()
        {

        }
    }
}
