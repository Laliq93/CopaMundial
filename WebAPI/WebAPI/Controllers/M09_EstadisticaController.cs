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
	[RoutePrefix("api/M09_estadisticas")]
	public class M09_EstadisticaController : ApiController
	{
		private EstEquipo _estEquipo;
		private EstPartido _estPartido;
		private List<EstJugador> _estJugador;
		private EstJugGen _jugEst;
		private DataBase _database = new DataBase();


		private List<equipo> _listequipo;

		// GET api/<controller>


		[Route("equipo/{idEquipo:int}")]
		[HttpGet]
		public IHttpActionResult ObtenerEstEquipo(int idEquipo)
		{
			try
			{

				_database.Conectar();
				_database.StoredProcedure("getEstEquipo(@id)");
				_database.AgregarParametro("id", idEquipo);
				_database.EjecutarReader();


				_listequipo = new List<equipo>();
				for (int i = 0; i < _database.cantidadRegistros; i++)
				{
					equipo estequipo = new equipo(_database.GetString(i, 0), _database.GetInt(i, 1));
					_listequipo.Add(estequipo);
				}
				_estEquipo = new EstEquipo();
				for (int i = 0; i < _listequipo.Count; i++)
				{
					switch (_listequipo.ElementAt(i).nombre)
					{
						case "GOL":
							_estEquipo.goles = _estEquipo.goles + _listequipo.ElementAt(i).valor;
							break;
						case "FALTACOMETIDA":
							_estEquipo.faltasC = _estEquipo.faltasC + _listequipo.ElementAt(i).valor;
							break;
						case "FALTARECIBIDA":
							_estEquipo.faltasR = _estEquipo.faltasR + _listequipo.ElementAt(i).valor;
							break;
						case "TARJETAA":
							_estEquipo.tarjetasA = _estEquipo.tarjetasA + _listequipo.ElementAt(i).valor;
							break;
						case "TARJETAR":
							_estEquipo.tarjetasR = _estEquipo.tarjetasR + _listequipo.ElementAt(i).valor;
							break;
						case "OFFSIDE":
							_estEquipo.offsides = _estEquipo.offsides + _listequipo.ElementAt(i).valor;
							break;
						case "TIROS":
							_estEquipo.tiros = _estEquipo.tiros + _listequipo.ElementAt(i).valor;
							break;


					}
				}





				//equipo = _database() respuesta de la db
				return Ok(_estEquipo);
			}
			catch (Exception e)
			{
				_database.Desconectar();
				return BadRequest("Error en el servidor: " + e.Message);
			}

		}



		[Route("partido/{idPartido:int}")]
		[HttpGet]
		public IHttpActionResult ObtenerEstPartido(int idPartido)
		{
			try
			{

				_database.Conectar();
				_database.StoredProcedure("ObtenerEstPartido(@id)");
				_database.AgregarParametro("id", idPartido);
				_database.EjecutarQuery();
				//equipo = _database() respuesta de la db
				return Ok(_estPartido);
			}
			catch (Exception e)
			{
				_database.Desconectar();
				return BadRequest("Error en el servidor: " + e.Message);
			}

		}

		//getestadisticas de un jugador generales
		[Route("jugador/{idJugador:int}")]
		[HttpGet]
		public IHttpActionResult ObtenerEstJugador(int idJugador)
		{
			try
			{

				_database.Conectar();
				_database.StoredProcedure("GetEstJugador(@id)");
				_database.AgregarParametro("id", idJugador);
				_database.EjecutarReader();

				String nombre = _database.GetString(0, 0);
				int valor = _database.GetInt(0, 1);
				int minuto = _database.GetInt(0, 2);
				_estJugador = new List<EstJugador>();
				for (int i = 0; i < _database.cantidadRegistros; i++)
				{
					EstJugador estJugador = new EstJugador(_database.GetString(i, 0), _database.GetInt(i, 1), _database.GetInt(i, 2));
					_estJugador.Add(estJugador);
				}
				_jugEst = new EstJugGen();
				for (int i = 0; i < _estJugador.Count; i++)
				{
					switch (_estJugador.ElementAt(i).nombre)
					{
						case "GOL":
							_jugEst.goles = _jugEst.goles + _estJugador.ElementAt(i).valor;
							break;
						case "ASISTENCIA":
							_jugEst.asistencias = _jugEst.asistencias + _estJugador.ElementAt(i).valor;
							break;
						case "FALTACOMETIDA":
							_jugEst.faltasC = _jugEst.faltasC + _estJugador.ElementAt(i).valor;
							break;
						case "FALTARECIBIDA":
							_jugEst.faltasR = _jugEst.faltasR + _estJugador.ElementAt(i).valor;
							break;
						case "TARJETAA":
							_jugEst.tarjetasA = _jugEst.tarjetasA + _estJugador.ElementAt(i).valor;
							break;
						case "TARJETAR":
							_jugEst.tarjetasR = _jugEst.tarjetasR + _estJugador.ElementAt(i).valor;
							break;
						case "OFFSIDE":
							_jugEst.offsides = _jugEst.offsides + _estJugador.ElementAt(i).valor;
							break;
						case "TIROS":
							_jugEst.tiros = _jugEst.tiros + _estJugador.ElementAt(i).valor;
							break;
						case "TIEMPOJUGADO":
							_jugEst.tiempojugado = _jugEst.tiempojugado + _estJugador.ElementAt(i).valor;
							break;

					}
				}
				//'GOL' OR eve_nombre = 'ASISTENCIA' OR eve_nombre = 'FALTACOMETIDA' OR eve_nombre = 'TIROESQUINA'  OR  eve_nombre = 'FALTARECIBIDA'  OR  eve_nombre = 'TARJETAA'  OR eve_nombre = 'TARJETAR'  OR  eve_nombre = 'OFFSIDE'  OR  eve_nombre = 'TIEMPOJUGADO'  OR  eve_nombre = 'TIROS'  OR  eve_nombre = 'GOLESREC'  OR  eve_nombre = 'PENALESATAJADOS'),

				//equipo = _database() respuesta de la db
				return Ok(_jugEst);
			}
			catch (Exception e)
			{
				_database.Desconectar();
				return BadRequest("Error en el servidor: " + e.Message);
			}

		}


		[Route("prediccion/partido/{idPartido:int}")]
		[HttpGet]
		public IHttpActionResult ObtenerPrediccionPartido(int idPartido)
		{
			try
			{

				_database.Conectar();
				_database.StoredProcedure("ObtenerPredPartido(@id)");
				_database.AgregarParametro("id", idPartido);
				_database.EjecutarQuery();
				//equipo = _database() respuesta de la db
				return Ok(_estPartido);
			}
			catch (Exception e)
			{
				_database.Desconectar();
				return BadRequest("Error en el servidor: " + e.Message);
			}

		}


		[Route("prediccion/jugador/{idJugador:int}")]
		[HttpGet]
		public IHttpActionResult ObtenerPredJugador(int idJugador)
		{
			EstJugGen estJugGen;
			try
			{
				_database.Conectar();
				estJugGen = obtenerObjetoEstJugador(idJugador);


				DataBase data = new DataBase();
				data.Conectar();
				data.StoredProcedure("getCountPartidosJugador(@id)");
				data.AgregarParametro("id", idJugador);
				data.EjecutarReader();

				int partidos = data.GetInt(0, 0);
				data.Desconectar();
				estJugGen.goles = estJugGen.goles / partidos;
				estJugGen.asistencias = estJugGen.asistencias / partidos;
				estJugGen.tiempojugado = estJugGen.tiempojugado / partidos;
				estJugGen.tiros = estJugGen.tiros / partidos;
				estJugGen.tarjetasA = estJugGen.tarjetasA / partidos;
				estJugGen.tarjetasR = estJugGen.tarjetasR / partidos;
				estJugGen.faltasR = estJugGen.faltasR / partidos;
				estJugGen.faltasC = estJugGen.faltasC / partidos;
				estJugGen.golesrec = estJugGen.golesrec / partidos;
				estJugGen.penaltisA = estJugGen.penaltisA / partidos;
				estJugGen.portimb = estJugGen.portimb / partidos;


				//equipo = _database() respuesta de la db

			}
			catch (Exception e)
			{
				_database.Desconectar();
				return BadRequest("Error en el servidor: " + e.Message);
			}
			return Ok(estJugGen);

		}

		

		public int CalcularPromedio(List<int> array)
		{

			int promedio = 0;
			foreach (var item in array)
			{
				promedio = promedio + item;
			}
			return promedio;
		}

		public int CalcularSuma(List<int> array)
		{
			int suma = 0;
			foreach (var item in array)
			{
				suma = suma + item;
			}
			return suma;

		}

		public void calcular()
		{

		}

		public EstJugGen obtenerObjetoEstJugador(int id)
		{
			_database.StoredProcedure("GetEstJugador(@id)");
			_database.AgregarParametro("id", id);
			_database.EjecutarReader();

			String nombre = _database.GetString(0, 0);
			int valor = _database.GetInt(0, 1);
			int minuto = _database.GetInt(0, 2);
			_estJugador = new List<EstJugador>();
			for (int i = 0; i < _database.cantidadRegistros; i++)
			{
				EstJugador estJugador = new EstJugador(_database.GetString(i, 0), _database.GetInt(i, 1), _database.GetInt(i, 2));
				_estJugador.Add(estJugador);
			}
			_jugEst = new EstJugGen();
			for (int i = 0; i < _estJugador.Count; i++)
			{
				switch (_estJugador.ElementAt(i).nombre)
				{
					case "GOL":
						_jugEst.goles = _jugEst.goles + _estJugador.ElementAt(i).valor;
						break;
					case "ASISTENCIA":
						_jugEst.asistencias = _jugEst.asistencias + _estJugador.ElementAt(i).valor;
						break;
					case "FALTACOMETIDA":
						_jugEst.faltasC = _jugEst.faltasC + _estJugador.ElementAt(i).valor;
						break;
					case "FALTARECIBIDA":
						_jugEst.faltasR = _jugEst.faltasR + _estJugador.ElementAt(i).valor;
						break;
					case "TARJETAA":
						_jugEst.tarjetasA = _jugEst.tarjetasA + _estJugador.ElementAt(i).valor;
						break;
					case "TARJETAR":
						_jugEst.tarjetasR = _jugEst.tarjetasR + _estJugador.ElementAt(i).valor;
						break;
					case "OFFSIDE":
						_jugEst.offsides = _jugEst.offsides + _estJugador.ElementAt(i).valor;
						break;
					case "TIROS":
						_jugEst.tiros = _jugEst.tiros + _estJugador.ElementAt(i).valor;
						break;
					case "TIEMPOJUGADO":
						_jugEst.tiempojugado = _jugEst.tiempojugado + _estJugador.ElementAt(i).valor;
						break;

				}
			}
			//'GOL' OR eve_nombre = 'ASISTENCIA' OR eve_nombre = 'FALTACOMETIDA' OR eve_nombre = 'TIROESQUINA'  OR  eve_nombre = 'FALTARECIBIDA'  OR  eve_nombre = 'TARJETAA'  OR eve_nombre = 'TARJETAR'  OR  eve_nombre = 'OFFSIDE'  OR  eve_nombre = 'TIEMPOJUGADO'  OR  eve_nombre = 'TIROS'  OR  eve_nombre = 'GOLESREC'  OR  eve_nombre = 'PENALESATAJADOS'),

			//equipo = _database() respuesta de la db
			return _jugEst;
		}


		[Route("prediccion/equipo/{equipo:int}")]
		[HttpGet]
		public IHttpActionResult ObtenerPredEquipo(int idEquipo)
		{
			EstEquipo estJugGen;
			try
			{
				_database.Conectar();

				 estJugGen = ObtenerObjEstEquipo(idEquipo);
				_database.StoredProcedure("getCountPartidosJugador(@id)");
				_database.AgregarParametro("id", idEquipo);
				_database.EjecutarReader();

				int partidos = _database.GetInt(0, 0);

				estJugGen.goles = estJugGen.goles / partidos;
				
				estJugGen.tiros = estJugGen.tiros / partidos;
				estJugGen.tarjetasA = estJugGen.tarjetasA / partidos;
				estJugGen.tarjetasR = estJugGen.tarjetasR / partidos;
				estJugGen.faltasR = estJugGen.faltasR / partidos;
				estJugGen.faltasC = estJugGen.faltasC / partidos;
				


				//equipo = _database() respuesta de la db

			}
			catch (Exception e)
			{
				_database.Desconectar();
				return BadRequest("Error en el servidor: " + e.Message);
			}
			return Ok(estJugGen);

		}



		public EstEquipo ObtenerObjEstEquipo(int idequipo)
		{


			_database.StoredProcedure("getEstEquipo(@id)");
			_database.AgregarParametro("id", idequipo);
			_database.EjecutarReader();


			_listequipo = new List<equipo>();
			for (int i = 0; i < _database.cantidadRegistros; i++)
			{
				equipo estequipo = new equipo(_database.GetString(i, 0), _database.GetInt(i, 1));
				_listequipo.Add(estequipo);
			}
			_estEquipo = new EstEquipo();
			for (int i = 0; i < _listequipo.Count; i++)
			{
				switch (_listequipo.ElementAt(i).nombre)
				{
					case "GOL":
						_estEquipo.goles = _estEquipo.goles + _listequipo.ElementAt(i).valor;
						break;
					case "FALTACOMETIDA":
						_estEquipo.faltasC = _estEquipo.faltasC + _listequipo.ElementAt(i).valor;
						break;
					case "FALTARECIBIDA":
						_estEquipo.faltasR = _estEquipo.faltasR + _listequipo.ElementAt(i).valor;
						break;
					case "TARJETAA":
						_estEquipo.tarjetasA = _estEquipo.tarjetasA + _listequipo.ElementAt(i).valor;
						break;
					case "TARJETAR":
						_estEquipo.tarjetasR = _estEquipo.tarjetasR + _listequipo.ElementAt(i).valor;
						break;
					case "OFFSIDE":
						_estEquipo.offsides = _estEquipo.offsides + _listequipo.ElementAt(i).valor;
						break;
					case "TIROS":
						_estEquipo.tiros = _estEquipo.tiros + _listequipo.ElementAt(i).valor;
						break;


				}
			}
			//equipo = _database() respuesta de la db
			return _estEquipo;
		}






	}





}