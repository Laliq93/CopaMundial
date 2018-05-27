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
        private List<Jugador> _listaJugadores;

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

        [Route("EditarJugador/{id}/{nombre}/{apellido}/{fechaNacimiento}/{lugarNacimiento}/{peso}/{altura}/{club}/{equipo}/{numero}/{posicion}/{capitan}")]
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

        [Route("ListarJugador/{equipo}")]
        [HttpPost, HttpGet]
        public HttpResponseMessage ListarJugador(int equipo)
        {
            
            try
            {
                Jugador _equipo = new Jugador(equipo);
                BuscarJugadores(_equipo);
                return Request.CreateResponse(statusCode: HttpStatusCode.OK, value: _listaJugadores);
            }
            catch (Exception e)
            {
                _database.Desconectar();
                return Request.CreateResponse(HttpStatusCode.NotFound, new HttpError("Error en el servidor:" + e.Message));
            }

        }

        [Route("BuscarJugador/{id}")]
        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage BuscarJugador(int id)
        {
            try
            {
                GetJugador(id);

                return Request.CreateResponse(HttpStatusCode.OK, _jugador);
            }
            catch (Exception e)
            {
                _database.Desconectar();
                return Request.CreateResponse(HttpStatusCode.NotFound, new HttpError("Error en el servidor:" + e.Message));
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

        private void BuscarJugadores(Jugador jugador)
        {
            _listaJugadores = new List<Jugador>();
            _database.Conectar();

            if (jugador.Equipo < 0)
                _database.StoredProcedure("buscartodos()");
            else
            {
                _database.StoredProcedure("buscarequipo(@equipo)"); 
                _database.AgregarParametro("equipo", jugador.Equipo);

            }

            
            _database.EjecutarReader();

            Jugador jugadorLista;

            for (int i = 0; i < _database.cantidadRegistros; i++)
            {
                jugadorLista = new Jugador(_database.GetInt(i, 0), _database.GetString(i, 1), _database.GetString(i, 2),
                    Convert.ToDateTime(_database.GetString(i, 3)).ToShortDateString(), _database.GetString(i, 4), _database.GetDouble(i, 5), _database.GetDouble(i, 6), _database.GetString(i, 7), 
                    _database.GetInt(i, 8), _database.GetInt(i, 9), _database.GetString(i, 10), _database.GetBool(i, 11));

                _listaJugadores.Add(jugadorLista);
            }
        }

        public Jugador GetJugador(int id)
        {
            _database.Conectar();

            _database.StoredProcedure("buscarjugador(@id)");

            _database.AgregarParametro("id", id);

            _database.EjecutarReader();

            _jugador = new Jugador(_database.GetInt(0, 0), _database.GetString(0, 1), _database.GetString(0, 2),
                    Convert.ToDateTime(_database.GetString(0, 3)).ToShortDateString(), _database.GetString(0, 4), _database.GetDouble(0, 5), _database.GetDouble(0, 6), _database.GetString(0, 7),
                    _database.GetInt(0, 8), _database.GetInt(0, 9), _database.GetString(0, 10), _database.GetBool(0, 11));

            return _jugador;

        }

    }
}
