using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using WebAPI.Models;
using WebAPI.Models.DataBase;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/M4_GestionEquipo")]
    public class M4_GestionEquipoController : ApiController
    {
        private DataBase _database = new DataBase();
        private List<Pais> _listaPaises;
        private Pais pais;
        private EstructuraRespuesta er;


        /// <summary>
        /// Metodo para obtener todos los equipos
        /// </summary>
        /// <param name="idioma">Idioma para el filtrado</param>
        [Route("listaEquipos/{idioma}")]
        [HttpGet]
        public HttpResponseMessage ListaEquipos(string idioma)
        {
            try
            {
                List<Equipo> equipos;

                equipos = ObtenerEquipos(idioma);

                er = new EstructuraRespuesta
                {
                    codigo = 200,
                    mensaje = equipos
                };
                return Request.CreateResponse(HttpStatusCode.OK, er);
            }
            catch (Exception e)
            {
                er = new EstructuraRespuesta
                {
                    codigo = 414,
                    mensaje = "",
                    error = "Error al tratar de obtener equipos:" + e.Message
                };
                return Request.CreateResponse(HttpStatusCode.BadRequest, er);
            }
        }

        /// <summary>
        /// Llama a un SP para obtener una list de todos los equipos filtrados por idioma
        /// </summary>
        /// <param name="idioma">Idioma para el filtrado de equipos</param>
        private List<Equipo> ObtenerEquipos(string idioma)
        {
            List<Equipo> equipos = new List<Equipo>();

            try
            {
                _database.Conectar();
                _database.StoredProcedure("m4_busca_equipos(@idioma)");
                _database.AgregarParametro("idioma", idioma);
                _database.EjecutarReader();

                for (int i = 0; i < _database.cantidadRegistros; i++)
                {
                    List<I18nEquipo> listaI18nPais = new List<I18nEquipo>();

                    I18nEquipo paisI18n = new I18nEquipo(_database.GetInt(i, 5), idioma, _database.GetString(i, 1));
                    listaI18nPais.Add(paisI18n);
                    Pais pais = new Pais(_database.GetString(i, 0), listaI18nPais);

                    List<I18nEquipo> listaI18nEquipo = new List<I18nEquipo>();

                    I18nEquipo descI18n = new I18nEquipo(_database.GetInt(i, 6), idioma, _database.GetString(i, 2));
                    listaI18nEquipo.Add(descI18n);
                    Equipo equipo = new Equipo(pais, listaI18nEquipo, _database.GetBool(i, 4), 
                                               _database.GetString(i, 3), _database.GetBool(i, 7));

                    equipos.Add(equipo);
                }

                return equipos;

            }
            catch (Exception e)
            {
                _database.Desconectar();
                throw new Exception("Error al obtener los equipos. Mas informacion del error: " + e);
            }
        }

        /// <summary>
        /// Metodo para obtener un equipo usando el codigo ISO
        /// </summary>
        /// <param name="iso">Codigo ISO del pais</param>
        [Route("equipo/{iso}")]
        [HttpGet]
        public HttpResponseMessage ConsultarEquipo(string iso)
        {
            try
            {
                Equipo equipo;

                equipo = ObtenerEquipo(iso);

                er = new EstructuraRespuesta
                {
                    codigo = 200,
                    mensaje = equipo,
                };
                return Request.CreateResponse(HttpStatusCode.OK, er);
            }
            catch (Exception e)
            {
                er = new EstructuraRespuesta
                {
                    codigo = 416,
                    mensaje = "",
                    error = "Error al tratar de consultar el equipo: " + iso + ":" + e.Message
                };
                return Request.CreateResponse(HttpStatusCode.BadRequest, er);
            }
        }

        /// <summary>
        /// Llama a un SP para obtener la informacion de un país
        /// </summary>
        /// <param name="iso">Codigo ISO del equipo a buscar</param>
        private Equipo ObtenerEquipo(string iso)
        {

            try
            {
                _database.Conectar();
                _database.StoredProcedure("m4_busca_equipo_iso(@iso)");
                _database.AgregarParametro("iso", iso);
                _database.EjecutarReader();

                List<I18nEquipo> listaI18nPais = new List<I18nEquipo>();
                I18nEquipo paisI18nEs = new I18nEquipo(_database.GetInt(0, 8), "es", _database.GetString(0, 1));
                I18nEquipo paisI18nEn = new I18nEquipo(_database.GetInt(0, 8), "en", _database.GetString(0, 2));

                listaI18nPais.Add(paisI18nEs);
                listaI18nPais.Add(paisI18nEn);

                Pais pais = new Pais(_database.GetString(0, 0), listaI18nPais);

                List<I18nEquipo> listaI18nDesc = new List<I18nEquipo>();
                I18nEquipo descI18nEs = new I18nEquipo(_database.GetInt(0, 7), "es", _database.GetString(0, 3));
                I18nEquipo descI18nEn = new I18nEquipo(_database.GetInt(0, 7), "es", _database.GetString(0, 4));

                listaI18nDesc.Add(descI18nEs);
                listaI18nDesc.Add(descI18nEn);

                Equipo equipo = new Equipo(pais, listaI18nDesc, _database.GetBool(0, 6),
                                           _database.GetString(0, 5), true);

                return equipo;

            }
            catch (Exception e)
            {
                _database.Desconectar();
                throw new Exception("Error al obtener un equipo. Mas informacion del error: " + e);
            }
        }

        /// <summary>
        /// Metodo POST para agregar equipos. Realiza una conversion el idPais y pasa los datos a otro metodo.
        /// </summary>
        /// <param name="equipo">Objeto de tipo equipo que contiene los datos del equipo a ser agregado</param>
        [Route("AgregarEquipo")]
        [HttpPost]
        public HttpResponseMessage RegistrarEquipo([FromBody] Equipo equipo)
        {
            try
            {
                AgregarEquipo(equipo);

                er = new EstructuraRespuesta
                {
                    codigo = 200,
                    mensaje = "Equipo agregado satisfactoriamente"
                };
                return Request.CreateResponse(HttpStatusCode.OK, er);
            }
            catch( Exception e)
            {
                er = new EstructuraRespuesta
                {
                    codigo = 415,
                    mensaje = "",
                    error = "Error al tratar de agregar a un equipo:" + e.Message
                };
                return Request.CreateResponse(HttpStatusCode.BadRequest, er);
            }
        }

        /// <summary>
        /// Metodo que es llamado cuando se necesita insertar un equipo a la base de datos. Se encarga de
        /// hacer llamados a los metodos respectivos en la base de datos para asi realizar su funcion
        /// </summary>
        /// <param name="equipo">Objeto de tipo equipo que contiene los datos del equipo a ser agregado</param>
        private void AgregarEquipo( Equipo equipo )
        {
            //string descripcionES, string descripcionEN, string grupo, int idPais
            try
            {
                _database.Conectar();
                _database.StoredProcedure("m4_agregar_equipo(@descripcionES, @descripcionEN, @grupo, " +
                    "@id_pais)");
                for (int i = 0; i < equipo.descripcion.Count(); i++)
                {
                    if (equipo.descripcion[i].idioma.ToString().ToLower() == "es")
                        _database.AgregarParametro("descripcionES", equipo.descripcion[i].mensaje.ToString());
                    else if (equipo.descripcion[i].idioma.ToString().ToLower() == "en")
                        _database.AgregarParametro("descripcionEN", equipo.descripcion[i].mensaje.ToString());
                }
                _database.AgregarParametro("grupo", equipo.grupo.ToString());
                _database.AgregarParametro("id_pais", equipo.pais.iso.ToString());
                _database.EjecutarQuery();
                
            }
            catch( Exception e)
            {
                _database.Desconectar();
                throw new Exception("Error al agregar un equipo. Mas informacion del error: " + e);
            }
        }

        /// <summary>
        /// AEdita la informacion del equipo en la base de datos.
        /// <param name="equipo">Onjeto de tipo equipo que sirve para guardar los datos en la BD</param>
        /// </summary>
        [Route("ActualizarEquipo")]
        [HttpPut]
        public HttpResponseMessage ActulizarEquipo([FromBody] Equipo equipo)
        {
            try
            {
                EditarEquipo(equipo);
                er = new EstructuraRespuesta
                {
                    codigo = 200,
                    mensaje = "Equipo actualizado exitosamente",
                    error = ""
                };
                return Request.CreateResponse(HttpStatusCode.OK, er);
            }
            catch (Exception e)
            {
                er = new EstructuraRespuesta
                {
                    codigo = 413,
                    mensaje = "",
                    error = "Error en la actualizacion del equipo: " + e.Message
                };
                return Request.CreateResponse(HttpStatusCode.BadRequest, er);
            }
        }

        /// <summary>
        /// Edita la informacion del equipo en la base de datos.
        /// <param name="equipo">Onjeto de tipo equipo que sirve para guardar los datos en la BD</param>
        /// </summary>
        private void EditarEquipo(Equipo equipo)
        {
            try
            {
                _database.Conectar();

                _database.StoredProcedure("m4_modificar_equipo(@descripcionES, @descripcionEN, @grupo, " +
                    "@id_pais, @status, @habilitado)");
                for (int i = 0; i < equipo.descripcion.Count(); i++)
                {
                    if (equipo.descripcion[i].idioma.ToString().ToLower() == "es")
                        _database.AgregarParametro("descripcionES", equipo.descripcion[i].mensaje.ToString());
                    else if (equipo.descripcion[i].idioma.ToString().ToLower() == "en")
                        _database.AgregarParametro("descripcionEN", equipo.descripcion[i].mensaje.ToString());
                }
                _database.AgregarParametro("grupo", equipo.grupo.ToString());
                _database.AgregarParametro("id_pais", equipo.pais.iso.ToString());
                _database.AgregarParametro("status", equipo.status);
                _database.AgregarParametro("habilitado", equipo.habilitado);
                _database.EjecutarQuery();
                
            }
            catch (NullReferenceException e)
            {
                _database.Desconectar();
                throw new Exception("Error al actualizar un equipo. Mas informacion del error: " + e);
            }
        }

        /// <summary>
        /// Metodo GET para obtener los paises registrados en la BD filtrados por un idioma
        /// </summary>
        /// <param name="idioma">El idioma por el cual se filtrara la respuesta.</param>
        [Route("ObtenerPaises/{idioma}")]
        [HttpGet]
        public HttpResponseMessage getPaises(string idioma)
        {
            try
            {
                ObtenerPaises(idioma);
                er = new EstructuraRespuesta
                {
                    codigo = 200,
                    mensaje = _listaPaises
                };
                return Request.CreateResponse(HttpStatusCode.OK, er);
            }
            catch (Exception e)
            {
                _database.Desconectar();
                er = new EstructuraRespuesta
                {
                    codigo = 410,
                    mensaje = "",
                    error = "Error al tratar de obtener los datos de los paises:" + e.Message
                };
                return Request.CreateResponse(HttpStatusCode.BadRequest, er);
            }
            
        }

        /// <summary>
        /// Metodo que retorna una lista de paises llamando a un Stored Procedure que se encarga de 
        /// devolver una tabla filtrada por el idioma con los paises registrados en el sistema.
        /// </summary>
        /// <param name="idioma">El idioma por el cual se filtrara la respuesta.</param>
        private List<Pais> ObtenerPaises(string idioma)
        {
            try
            {
                _listaPaises = new List<Pais>();

                _database.Conectar();
                _database.StoredProcedure("m4_traer_pais( @idioma )");
                _database.AgregarParametro("idioma", idioma);
                _database.EjecutarReader();

                for (int i = 0; i < _database.cantidadRegistros; i++)
                {
                    I18nEquipo i18nPais = new I18nEquipo(_database.GetInt(i, 3), idioma.ToLower(), _database.GetString(i, 1).ToLower());
                    List<I18nEquipo> listaI18nPais = new List<I18nEquipo>();
                    listaI18nPais.Add(i18nPais);

                    pais = new Pais(_database.GetString(i, 0).ToLower(), listaI18nPais);

                    _listaPaises.Add(pais);
                }

                return _listaPaises;
            }
            catch (Exception e)
            {
                throw new Exception("Error al obtener la lista de paises. Mas informacion del error: " + e);
            }
        }
    }
}