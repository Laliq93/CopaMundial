using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Http;
using WebAPI.Models;
using WebAPI.Models.DataBase;
using WebAPI.Models.Excepciones;
using System.Net.Http;

namespace WebAPI.Controllers
{
    /// <summary>
    /// Controlador para Partido
    /// </summary>
    [RoutePrefix("api/M6_Partido")]
    public class M6_PartidoController : ApiController
    {
        private DataBase _database = new DataBase();
        private List<Partido> _listaPartido;
        private Partido _partido;



        /// <summary>
        /// Metodo para agregar Partido
        /// </summary>
        /// <param name="arbitro"></param>
        /// <param name="fecha"></param>
        /// <param name="horaInicio"></param>
        /// <param name="equipo1"></param>
        /// <param name="equipo2"></param>
        /// <param name="estadio"></param>
        /// <returns></returns>
        [Route("AgregarPartido/{arbitro}/{fecha}/{hora}/{equipo1}/{equipo2}/{estadio}")]
        [HttpPut, HttpGet]
        public IHttpActionResult RegistrarPartido(string arbitro, string fecha, string horaInicio, int equipo1,
            int equipo2, int estadio)
        {

            try
            {
                AgregarPartido(arbitro, fecha, horaInicio, equipo1, equipo2, estadio);
                return Ok("Partido registrado exitosamente.");
            }
            catch (Exception e)
            {
                _database.Desconectar();
                return BadRequest("Error en el servidor: " + e.Message);
            }

        }



        /// <summary>
        /// Metodo para consultar un partido segun su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna un HttpResponseMessage afirmativo  y los 
        /// datos del partido en caso de encontrado, de lo contrario
        /// retorna un HttpError con la descripcion del error</returns>
        [Route("ConsultarPartido/{id}")]
        [HttpGet]
        public HttpResponseMessage ConsultarPartido(int id)
        {
            
            try
            {
                _partido = ObtenerPartido(id);
                return Request.CreateResponse(HttpStatusCode.OK, _partido);
            }
            catch (Exception e)
            {
                _database.Desconectar();
                return Request.CreateResponse(HttpStatusCode.NotFound, new HttpError("Error en el servidor:" + e.Message));
            }
        }

        
        /// <summary>
        /// Metodo para consultar a la bd la informacion de un partido
        /// segun su id
        /// </summary>
        /// <param name="idPartido"></param>
        /// <returns>Retorna los datos de un partido en caso de ser
        /// encontrado</returns>
        public Partido ObtenerPartido(int idPartido)
        {
            Partido partido = new Partido();
            try
            {
                _database.Conectar();
                _database.StoredProcedure("ConsultarPartido(@idPartido)");
                _database.AgregarParametro("idPartido", idPartido);
                _database.EjecutarReader();
                partido.Id = _database.GetInt(0, 0);
                partido.Fecha = _database.GetDateTime(0, 1);
                partido.HoraInicio = _database.GetString(0, 2);
                partido.Equipo1 = _database.GetInt(0, 4);
                partido.Equipo2 = _database.GetInt(0, 5);
                partido.Estadio = _database.GetInt(0, 6);

            }
            catch (FormatException)
            {
                throw new FormatException("Error en el formato al obtener la fecha del partido");
            }
            catch (ArgumentNullException e)
            {
                throw new PartidoNotFoundException(e, "M6_PartidoController", "ObtenerPartido", idPartido);
            }
            catch (Exception e)
            {
                throw e;
            }
            
                return partido;
            
           
        }


        /// <summary>
        /// Metodo para agregar un partido a la bd
        /// </summary>
        /// <param name="arbitro"></param>
        /// <param name="fecha"></param>
        /// <param name="horaInicio"></param>
        /// <param name="equipo1"></param>
        /// <param name="equipo2"></param>
        /// <param name="estadio"></param>
        public void AgregarPartido(string arbitro, string fecha, string horaInicio, 
                                    int equipo1,int equipo2, int estadio)
        {
            _partido = new Partido();

            try
            {
                _database.Conectar();
                _database.StoredProcedure("AgregarPartido(@fecha, @horaInicio, @arbitro, @equipo1, @equipo2, @estadio)");
                _database.AgregarParametro("fecha", fecha);
                _database.AgregarParametro("horaInicio", horaInicio);
                _database.AgregarParametro("arbitro", arbitro);
                _database.AgregarParametro("equipo1", equipo1);
                _database.AgregarParametro("equipo2", equipo2);
                _database.AgregarParametro("estadio", estadio);

                _database.EjecutarReader();
                _partido.Id = _database.GetInt(0, 0);
            }
            catch (FormatException)
            {
                throw new FormatException("Error en el formato al registrar la hora del partido");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}