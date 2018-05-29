<<<<<<< HEAD
﻿using System;
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

                er = new EstructuraRespuesta();
                er.codigo = 200;
                er.mensaje = "Equipo agregado satisfactoriamente";
                return Request.CreateResponse(HttpStatusCode.OK, er);
            }
            catch( Exception e)
            {
                er = new EstructuraRespuesta();
                er.codigo = 410;
                er.mensaje = "";
                er.error = "Error al tratar de agregar a un equipo:" + e.Message;
                return Request.CreateResponse(HttpStatusCode.BadRequest,
                    new HttpError("Error al tratar de agregar a un equipo:" + er));
            }
        }

        /// <summary>
        /// Metodo que es llamado cuando se necesita insertar un equipo a la base de datos. Se encarga de
        /// hacer llamados a los metodos respectivos en la base de datos para asi realizar su funcion
        /// </summary>
        /// <param name="equipo">Objeto de tipo equipo que contiene los datos del equipo a ser agregado</param>
        public void AgregarEquipo( Equipo equipo )
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
        public IHttpActionResult ActulizarEquipo([FromBody] Equipo equipo)
        {
            try
            {
                EditarEquipo(equipo);
                return Ok("Equipo actualizado exitosamente");
            }
            catch (Exception e)
            {
                return BadRequest("Error en la actualizacion del equipo: " + e.Message);
            }
        }

        /// <summary>
        /// Edita la informacion del equipo en la base de datos.
        /// <param name="equipo">Onjeto de tipo equipo que sirve para guardar los datos en la BD</param>
        /// </summary>
        public void EditarEquipo(Equipo equipo)
        {
            try
            {
                _database.Conectar();

                _database.StoredProcedure("m4_modificar_equipo(@descripcionES, @descripcionEN, @grupo, " +
                    "@id_pais, @status)");
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
                er = new EstructuraRespuesta();
                er.codigo = 200;
                er.mensaje = _listaPaises;
                return Request.CreateResponse(HttpStatusCode.OK, er);
            }
            catch (Exception e)
            {
                _database.Desconectar();
                er = new EstructuraRespuesta();
                er.codigo = 410;
                er.mensaje = "";
                er.error = "Error al tratar de obtener los datos de los paises:" + e.Message;
                return Request.CreateResponse(HttpStatusCode.BadRequest, er);
            }
            
        }

        /// <summary>
        /// Metodo que retorna una lista de paises llamando a un Stored Procedure que se encarga de 
        /// devolver una tabla filtrada por el idioma con los paises registrados en el sistema.
        /// </summary>
        /// <param name="idioma">El idioma por el cual se filtrara la respuesta.</param>
        public List<Pais> ObtenerPaises(string idioma)
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
                    I18nEquipo i18nPais = new I18nEquipo(_database.GetInt(i, 3), idioma.ToLower(), _database.GetString(i, 1));
                    List<I18nEquipo> listaI18nPais = new List<I18nEquipo>();
                    listaI18nPais.Add(i18nPais);

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
=======
﻿using System;
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

                er = new EstructuraRespuesta();
                er.codigo = 200;
                er.mensaje = "Equipo agregado satisfactoriamente";
                return Request.CreateResponse(HttpStatusCode.OK, er);
            }
            catch( Exception e)
            {
                er = new EstructuraRespuesta();
                er.codigo = 410;
                er.mensaje = "";
                er.error = "Error al tratar de agregar a un equipo:" + e.Message;
                return Request.CreateResponse(HttpStatusCode.BadRequest,
                    new HttpError("Error al tratar de agregar a un equipo:" + er));
            }
        }

        /// <summary>
        /// Metodo que es llamado cuando se necesita insertar un equipo a la base de datos. Se encarga de
        /// hacer llamados a los metodos respectivos en la base de datos para asi realizar su funcion
        /// </summary>
        /// <param name="equipo">Objeto de tipo equipo que contiene los datos del equipo a ser agregado</param>
        public void AgregarEquipo( Equipo equipo )
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
        public IHttpActionResult ActulizarEquipo([FromBody] Equipo equipo)
        {
            try
            {
                EditarEquipo(equipo);
                return Ok("Equipo actualizado exitosamente");
            }
            catch (Exception e)
            {
                return BadRequest("Error en la actualizacion del equipo: " + e.Message);
            }
        }

        /// <summary>
        /// Edita la informacion del equipo en la base de datos.
        /// <param name="equipo">Onjeto de tipo equipo que sirve para guardar los datos en la BD</param>
        /// </summary>
        public void EditarEquipo(Equipo equipo)
        {
            try
            {
                _database.Conectar();

                _database.StoredProcedure("m4_modificar_equipo(@descripcionES, @descripcionEN, @grupo, " +
                    "@id_pais, @status)");
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
                er = new EstructuraRespuesta();
                er.codigo = 200;
                er.mensaje = _listaPaises;
                return Request.CreateResponse(HttpStatusCode.OK, er);
            }
            catch (Exception e)
            {
                _database.Desconectar();
                er = new EstructuraRespuesta();
                er.codigo = 410;
                er.mensaje = "";
                er.error = "Error al tratar de obtener los datos de los paises:" + e.Message;
                return Request.CreateResponse(HttpStatusCode.BadRequest, er);
            }
            
        }

        /// <summary>
        /// Metodo que retorna una lista de paises llamando a un Stored Procedure que se encarga de 
        /// devolver una tabla filtrada por el idioma con los paises registrados en el sistema.
        /// </summary>
        /// <param name="idioma">El idioma por el cual se filtrara la respuesta.</param>
        public List<Pais> ObtenerPaises(string idioma)
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
                    pais = new Pais(_database.GetString(i, 0).ToLower(), 
                        new I18nEquipo(_database.GetInt(i, 3), idioma.ToLower(), _database.GetString(i,1).ToLower()));

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
>>>>>>> Develop
}