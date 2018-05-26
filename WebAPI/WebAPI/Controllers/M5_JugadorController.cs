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
    [RoutePrefix("api/M5_Jugador")]
    public class M5_JugadorController : ApiController
    {
        private DataBase _database = new DataBase();
        private Jugador _jugador;

        [Route("CrearJugador/{nombre}/{apellido}/{fechaNacimiento}/{lugarNacimiento}/{peso}/{altura}/{club}/{equipo}/{numero}/{posicion}/{capitan}")]
        [HttpPost, HttpGet]
        public IHttpActionResult CrearJugador(string nombre, string apellido, string fechaNacimiento, string lugarNacimiento, 
            double peso, double altura, string club, int equipo, int numero, string posicion, bool capitan)
        {
            try
            {
                _jugador = new Jugador(nombre, apellido, fechaNacimiento, lugarNacimiento, peso, altura, club,
                    equipo, numero, posicion, capitan);

                InsertarJugador(_jugador);

                return Ok();
            }
            catch (Exception e)
            {
                _database.Desconectar();
                return BadRequest("Error en el servidor: " + e.Message);
            }

        }

        [Route("EditarJugador/{nombre}/{apellido}/{fechaNacimiento}/{lugarNacimiento}/{peso}/{altura}/{club}/{equipo}/{numero}/{posicion}/{capitan}")]
        [HttpPost, HttpGet]
        public IHttpActionResult EditarJugador(int id, string nombre, string apellido, string fechaNacimiento, string lugarNacimiento,
            double peso, double altura, string club, int equipo, int numero, string posicion, bool capitan)
        {
            try
            {
                _jugador = new Jugador(id, nombre, apellido, fechaNacimiento, lugarNacimiento, peso, altura, club,
                    equipo, numero, posicion, capitan);

                EditarJugador(_jugador);

                return Ok();
            }
            catch (Exception e)
            {
                _database.Desconectar();
                return BadRequest("Error en el servidor: " + e.Message);
            }

        }

        private void InsertarJugador(Jugador jugador)
        {
            _database.Conectar();

            _database.StoredProcedure("crearjugador(@nombre, @apellido, @fechaNacimiento, @lugarNacimiento, @peso, @altura, @club, @equipo, @numero, @posicion, @capitan)");
            
            _database.AgregarParametro("nombre", jugador.Nombre);
            _database.AgregarParametro("apellido", jugador.Apellido);
            _database.AgregarParametro("fechaNacimiento", jugador.FechaNacimiento);
            _database.AgregarParametro("lugarNacimiento", jugador.LugarNacimiento);
            _database.AgregarParametro("peso", jugador.Peso);
            _database.AgregarParametro("altura", jugador.Altura);
            _database.AgregarParametro("club", jugador.Club);
            _database.AgregarParametro("equipo", jugador.Equipo);
            _database.AgregarParametro("numero", jugador.Numero);
            _database.AgregarParametro("posicion", jugador.Posicion);
            _database.AgregarParametro("capitan", jugador.Capitan);


            _database.EjecutarQuery();
        }

        private void EditarJugador(Jugador jugador)
        {
            _database.Conectar();

            _database.StoredProcedure("editarjugador(@id, @nombre, @apellido, @fechaNacimiento, @lugarNacimiento, @peso, @altura, @club, @equipo, @numero, @posicion, @capitan)");

            _database.AgregarParametro("id", jugador.Id);
            _database.AgregarParametro("nombre", jugador.Nombre);
            _database.AgregarParametro("apellido", jugador.Apellido);
            _database.AgregarParametro("fechaNacimiento", jugador.FechaNacimiento);
            _database.AgregarParametro("lugarNacimiento", jugador.LugarNacimiento);
            _database.AgregarParametro("peso", jugador.Peso);
            _database.AgregarParametro("altura", jugador.Altura);
            _database.AgregarParametro("club", jugador.Club);
            _database.AgregarParametro("equipo", jugador.Equipo);
            _database.AgregarParametro("numero", jugador.Numero);
            _database.AgregarParametro("posicion", jugador.Posicion);
            _database.AgregarParametro("capitan", jugador.Capitan);


            _database.EjecutarQuery();
        }
    }
}
