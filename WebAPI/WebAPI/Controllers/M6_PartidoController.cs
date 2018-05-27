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
        private List<Partido> _listaPartido = new List<Partido>();
        private Partido _partido = new Partido();
        Alineacion _alineacion = new Alineacion();



        /// <summary>
        /// Metodo para Agregar un partido 
        /// </summary>
        /// <param name="partido"></param>
        /// <returns></returns>
        [Route("AgregarPartido")]
        [AcceptVerbs("GET", "PUT", "POST")]
        [HttpPut, HttpGet]
        public IHttpActionResult RegistrarPartido(Partido partido)
        {
            
            try
            {
                ConsultarDisponibilidadEstadio(partido.Fecha, partido.HoraInicio, partido.Estadio);
                AgregarPartido(partido.Arbitro, partido.Fecha, partido.HoraInicio,
                                    partido.Equipo1, partido.Equipo2, partido.Estadio);
                    return Ok("Partido registrado exitosamente.");
                
            }
            catch(EstadioNoDisponibleException e)
            {
                return BadRequest("Error, el estadio se encuentra en ese tiempo: " + e.ERROR_MSG);
            }
            catch (Exception e)
            {

                return BadRequest("Error en el servidor: " + e.Message);
            }
            finally
            {
                _database.Desconectar();
            }

        }

        /// <summary>
        /// Metodo para Agregar un partido 
        /// </summary>
        /// <param name="partido"></param>
        /// <returns></returns>
        [Route("ModificarPartido")]
        [AcceptVerbs("GET", "PUT")]
        [HttpPut, HttpGet]
        public IHttpActionResult ModificarPartido(Partido partido)
        {
            
            try
            {
                ActualizarPartido(partido.Id, partido.Arbitro, partido.Fecha, partido.HoraInicio,
                                partido.Equipo1, partido.Equipo2, partido.Estadio);
                return Ok("Partido actualizado exitosamente.");
            }
            catch (Exception e)
            {

                return BadRequest("Error en el servidor: " + e.Message);
            }
            finally
            {
                _database.Desconectar();
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
        [AcceptVerbs("GET")]
        [HttpGet]
        public HttpResponseMessage ConsultarPartido(int id)
        {
            try
            {
                _partido = ObtenerPartido(id);
                return Request.CreateResponse(HttpStatusCode.OK, _partido);
            }
            catch(PartidoNotFoundException e)
            {
                return Request.CreateResponse(e.ERROR_CODE+" : "+ e.ERROR_MSG );
            }
            catch (Exception e)
            {
                
                return Request.CreateResponse(HttpStatusCode.NotFound, new HttpError("Error en el servidor:" + e.Message));
            }
            finally
            {
                _database.Desconectar();
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
                if (_database.EjecutarReader() != null)
                { 
                    partido.Id = _database.GetInt(0, 0);
                    partido.Fecha = _database.GetString(0, 1);
                    partido.HoraInicio = _database.GetString(0, 2);
                    partido.Arbitro = _database.GetString(0, 3);
                    partido.Equipo1 = _database.GetInt(0, 4);
                    partido.Equipo2 = _database.GetInt(0, 5);
                    partido.Estadio = _database.GetInt(0, 6);
                }

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
                throw new Exception(e.ToString());
            }
        }


        /// <summary>
        /// Metodo para actualizar los datos de un partido en la bd
        /// </summary>
        /// <param name="arbitro"></param>
        /// <param name="fecha"></param>
        /// <param name="horaInicio"></param>
        /// <param name="equipo1"></param>
        /// <param name="equipo2"></param>
        /// <param name="estadio"></param>
        public void ActualizarPartido(int idPartido, string arbitro, string fecha, string horaInicio,
                                    int equipo1, int equipo2, int estadio)
        {
            _partido = new Partido();

            try
            {
                _database.Conectar();
                _database.StoredProcedure("ModificarPartido(@idPartido, @fecha, @horaInicio, @arbitro, @equipo1, @equipo2, @estadio)");
                _database.AgregarParametro("idPartido", idPartido);
                _database.AgregarParametro("fecha", fecha);
                _database.AgregarParametro("horaInicio", horaInicio);
                _database.AgregarParametro("arbitro", arbitro);
                _database.AgregarParametro("equipo1", equipo1);
                _database.AgregarParametro("equipo2", equipo2);
                _database.AgregarParametro("estadio", estadio);

                _database.EjecutarReader();
                _partido.Id = _database.GetInt(0, 0);
            }
            catch (ArgumentNullException e)
            {
                throw new PartidoNotFoundException(e, "M6_PartidoController", "ObtenerPartido", idPartido);
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

        /// <summary>
        /// Metodo para consultar la informacion de todos los partidos
        /// </summary>
        /// <returns></returns>
        [Route("ConsultarPartidos")]
        [AcceptVerbs("GET")]
        [HttpGet]
        public HttpResponseMessage ConsultarPartidos()
        {
            try
            {
                ObtenerPartidos();
                return Request.CreateResponse(HttpStatusCode.OK, _listaPartido);
            }
            catch (PartidoNotFoundException e)
            {
                return Request.CreateResponse(e.ERROR_CODE + " : " + e.ERROR_MSG);
            }
            catch (Exception e)
            {

                return Request.CreateResponse(HttpStatusCode.NotFound, new HttpError("Error en el servidor:" + e.Message));
            }
            finally
            {
                _database.Desconectar();
            }
        }

        /// <summary>
        /// Metodo para devolver una lista de 
        /// partidos
        /// </summary>
        public void ObtenerPartidos()
        {

            int cantidadPartidos = 0;
            try
            {
                _database.Conectar();
                _database.StoredProcedure("ConsultarPartidos()");
                _database.EjecutarReader();
            
                    while (_database.cantidadRegistros > cantidadPartidos)
                    {
                        Partido partido = new Partido();
                        partido.Id = _database.GetInt(0, 0);
                        partido.Fecha = _database.GetString(0, 1);
                        partido.HoraInicio = _database.GetString(0, 2);
                        partido.Arbitro = _database.GetString(0, 3);
                        partido.Equipo1 = _database.GetInt(0, 4);
                        partido.Equipo2 = _database.GetInt(0, 5);
                        partido.Estadio = _database.GetInt(0, 6);
                        _listaPartido.Add(partido);
                        cantidadPartidos++;
                    }
                
          

            }
            catch (ArgumentNullException e)
            {
                throw new ArgumentNullException(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception (e.Message);
            }
            finally
            {
                _database.Desconectar();
            }



        }



        /// <summary>
        /// Metodo para obtener el id del Partido actual
        /// </summary>
        /// <returns>retorna un int del id del partido</returns>
        public int IdPartido()
        {
            return _partido.Id;
        }




        /// <summary>
        /// Metodo que consulta si el estadio esta
        /// ocupado o no para ser asignado
        /// </summary>
        /// <param name="fecha"></param>
        /// <param name="horaInicio"></param>
        /// <param name="estadio"></param>
        /// <returns></returns>
        public int ConsultarDisponibilidadEstadio(string fecha, string horaInicio, int estadio)
        {
            int check = -1; //variable que indica si se encontro un partido al mismo momento
            try
            {
                _database.Conectar();
                _database.StoredProcedure("ConsultarDisponibilidadEstadio(@fecha, @horaInicio, @estadio)");
                _database.AgregarParametro("fecha", fecha);
                _database.AgregarParametro("horaInicio", horaInicio);
                _database.AgregarParametro("estadio", estadio);
                _database.EjecutarReader();
                 check= _database.GetInt(0, 0);
                if (check >0)
                {
                    throw new EstadioNoDisponibleException("M6_PartidoController", "ConsultarDisponibilidadEstadio", fecha, horaInicio, estadio);
                }
             
            }
            catch (FormatException)
            {
                throw new FormatException("Error en el formato al obtener la fecha del partido");
            }
            catch (Exception e)
            {
                throw e;
            }

            return check;


        }





        /// <summary>
        /// Metodo que agregar la alineacion de un partido 
        /// en la base de datos
        /// </summary>
        /// <param name="capitan"></param>
        /// <param name="posicion"></param>
        /// <param name="titular"></param>
        /// <param name="jugador"></param>
        /// <param name="equipo"></param>
        /// <param name="partido"></param>
        public void AgregarAlineacion(bool capitan, string posicion, bool titular,
                                    int jugador, int equipo, int partido)
        {
            Alineacion _alineacion = new Alineacion();

            try
            {
                _database.Conectar();
                _database.StoredProcedure("AgregarAlineacion(@capitan, @posicion, @titular, @jugador, @equipo, @partido)");
                _database.AgregarParametro("capitan", capitan);
                _database.AgregarParametro("posicion", posicion);
                _database.AgregarParametro("titular", titular);
                _database.AgregarParametro("jugador", jugador);
                _database.AgregarParametro("equipo", equipo);
                _database.AgregarParametro("partido", partido);

                _database.EjecutarReader();
                _alineacion.Id = _database.GetInt(0, 0);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }



        /// <summary>
        /// Metodo para Agregar una alineacion
        /// </summary>
        /// <param name="partido"></param>
        /// <returns></returns>
        [Route("AgregarAlineacionPartido")]
        [AcceptVerbs("GET", "PUT", "POST")]
        [HttpPut, HttpGet]
        public IHttpActionResult RegistrarAlineacionPartido(Partido partido)
        {

            try
            {
                if(partido.Alineacion1!= null)
                    foreach(var alineacion in partido.Alineacion1)
                    {
                        AgregarAlineacion(alineacion.Capitan, alineacion.Posicion, alineacion.Titular,
                                          alineacion.Jugador.Id, alineacion.Equipo, partido.Id);

                    }
                 if(partido.Alineacion2!=null)
                    foreach (var alineacion in partido.Alineacion1)
                    {
                         AgregarAlineacion(alineacion.Capitan, alineacion.Posicion, alineacion.Titular,
                                           alineacion.Jugador.Id, alineacion.Equipo, partido.Id);

                     }

                return Ok("Alineacion registradas exitosamente.");

            }
            catch (ArgumentNullException e)
            {
                throw new PartidoNotFoundException(e, "M6_PartidoController", "ObtenerPartido", partido.Id);
            }
            catch (Exception e)
            {

                return BadRequest("Error en el servidor: " + e.Message);
            }
            finally
            {
                _database.Desconectar();
            }

        }



        
        /// <summary>
        /// Metodo para Agregar una alineacion
        /// </summary>
        /// <param name="partido"></param>
        /// <returns></returns>
        [Route("AgregarAlineacionPartido")]
        [AcceptVerbs("GET", "PUT", "POST")]
        [HttpPut, HttpGet]
        public IHttpActionResult ModificarAlineacionPartido(Partido partido)
        {

            try
            {
                if (partido.Alineacion1 != null)
                    foreach (var alineacion in partido.Alineacion1)
                    {
                        ModificarAlineacion(alineacion.Id,alineacion.Capitan, alineacion.Posicion, alineacion.Titular,
                                          alineacion.Jugador.Id, alineacion.Equipo, partido.Id);

                    }
                if (partido.Alineacion2 != null)
                    foreach (var alineacion in partido.Alineacion1)
                    {
                        ModificarAlineacion(alineacion.Id, alineacion.Capitan, alineacion.Posicion, alineacion.Titular,
                                          alineacion.Jugador.Id, alineacion.Equipo, partido.Id);

                    }

                return Ok("Alineacion modificada  exitosamente.");

            }
            catch (ArgumentNullException e)
            {
                throw new PartidoNotFoundException(e, "M6_PartidoController", "ObtenerPartido", partido.Id);
            }
            catch (Exception e)
            {

                return BadRequest("Error en el servidor: " + e.Message);
            }
            finally
            {
                _database.Desconectar();
            }

        }



        /// <summary>
        /// Metodo para modificar la alineacion de un partido
        /// en la base de datos
        /// </summary>
        /// <param name="idAlineacion"></param>
        /// <param name="capitan"></param>
        /// <param name="posicion"></param>
        /// <param name="titular"></param>
        /// <param name="jugador"></param>
        /// <param name="equipo"></param>
        /// <param name="partido"></param>
        public void ModificarAlineacion(int idAlineacion, bool capitan, string posicion, bool titular,
                                    int jugador, int equipo, int partido)
        {
            

            try
            {
                _database.Conectar();
                _database.StoredProcedure("ModificarAlineacion(@idAlineacion, @capitan, @posicion, @titular, @jugador, @equipo, @partido)");
                _database.AgregarParametro("idAlineacion", idAlineacion);
                _database.AgregarParametro("capitan", capitan);
                _database.AgregarParametro("posicion", posicion);
                _database.AgregarParametro("titular", titular);
                _database.AgregarParametro("jugador", jugador);
                _database.AgregarParametro("equipo", equipo);
                _database.AgregarParametro("partido", partido);

                _database.EjecutarReader();
                _alineacion.Id = _database.GetInt(0, 0);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }


        
        /// <summary>
        /// Metodo que obtiene la alineacion del partido
        /// </summary>
        /// <param name="partido"></param>
        public void ObtenerAlineacion(Partido partido, int equipoIndex)
        {
            
            int cantidadJugadores = 0;
            try
            {
                _database.Conectar();
                _database.StoredProcedure("ConsultarAlineacion(@idPartido, @equipo)");
                _database.AgregarParametro("idPartido", partido.Id);
                if(equipoIndex == 1)
                     _database.AgregarParametro("equipo",partido.Equipo1);
                else
                    _database.AgregarParametro("equipo", partido.Equipo2);
                _database.EjecutarReader();
          
                while (_database.cantidadRegistros > cantidadJugadores)
                {
                    Alineacion alineacion = new Alineacion();
                    Jugador jugador = new Jugador();
                    alineacion.Jugador = jugador;
                    alineacion.Id = _database.GetInt(0, 0);
                     alineacion.Capitan= _database.GetBool(0, 1);
                    alineacion.Posicion = _database.GetString(0, 2);
                    alineacion.Titular = _database.GetBool(0, 3);
                    alineacion.Jugador.Id = _database.GetInt(0, 4);
                    alineacion.Equipo = _database.GetInt(0, 5);
                    
                    if(equipoIndex ==1)
                      partido.Alineacion1.Add(alineacion);
                    else
                     partido.Alineacion2.Add(alineacion);
                    cantidadJugadores++;
                }



            }
            catch (ArgumentNullException e)
            {
                throw new ArgumentNullException(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                _database.Desconectar();
            }



        }

        /// <summary>
        /// Metodo para consultar la alineacion de un partido
        /// </summary>
        /// <param name="partido"></param>
        /// <returns></returns>
        [Route("ConsultarAlineacion")]
        [AcceptVerbs("GET")]
        [HttpGet]
        public HttpResponseMessage ConsultarAlineacion(Partido partido)
        {
            try
            {
                ObtenerAlineacion(partido,1);
                ObtenerAlineacion(partido, 2);
                return Request.CreateResponse(HttpStatusCode.OK, _partido);
            }
            catch (PartidoNotFoundException e)
            {
                return Request.CreateResponse(e.ERROR_CODE + " : " + e.ERROR_MSG);
            }
            catch (Exception e)
            {

                return Request.CreateResponse(HttpStatusCode.NotFound, new HttpError("Error en el servidor:" + e.Message));
            }
            finally
            {
                _database.Desconectar();
            }
        }




    }


}
