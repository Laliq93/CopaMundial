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

        /// <summary>
        /// Metodo POST para agregar equipos. Realiza una conversion el idPais y pasa los datos a otro metodo.
        /// </summary>
        /// <param name="equipo">Objeto de tipo equipo que contiene los datos del equipo a ser agregado</param>
        [Route("AgregarEquipo")]
        [HttpPost]
        public IHttpActionResult RegistrarEquipo([FromBody] Equipo equipo)
        {
            try
            {
                //return Ok("lista de equipo " + equipo.Descripcion[0].Idioma.ToString());
                AgregarEquipo(equipo);
                return Ok("Equipo registrado exitosamente");
            }
            catch( Exception e)
            {
                return BadRequest("Error en el registro del equipo: " + e.Message);
            }
        }

        /// <summary>
        /// Metodo que es llamado cuando se necesita insertar un equipo a la base de datos. Se encarga de
        /// hacer llamados a los metodos respectivos en la base de datos para asi realizar su funcion
        /// </summary>
        /// <param name="equipo">Objeto de tipo equipo que contiene los datos del equipo a ser agregado</param>
        public HttpResponseMessage AgregarEquipo( Equipo equipo )
        {
            //string descripcionES, string descripcionEN, string grupo, int idPais
            try
            {
                _database.Conectar();
                _database.StoredProcedure("m4_agregar_equipo(@descripcionES, @descripcionEN, @grupo, " +
                    "@id_pais)");
                for (int i = 0; i < equipo.Descripcion.Count(); i++)
                {
                    if (equipo.Descripcion[i].Idioma.ToString().ToLower() == "es")
                        _database.AgregarParametro("descripcionES", equipo.Descripcion[i].Mensaje.ToString());
                    else if (equipo.Descripcion[i].Idioma.ToString().ToLower() == "en")
                        _database.AgregarParametro("descripcionEN", equipo.Descripcion[i].Mensaje.ToString());
                }
                _database.AgregarParametro("grupo", equipo.Grupo.ToString());
                _database.AgregarParametro("id_pais", equipo.Pais.Iso.ToString());
                _database.EjecutarQuery();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch( Exception e)
            {
                _database.Desconectar();
                return Request.CreateResponse(HttpStatusCode.BadRequest,
                    new HttpError("Error al tratar de agregar equipo:" + e.Message));
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
        public HttpResponseMessage EditarEquipo(Equipo equipo)
        {
            try
            {
                _database.Conectar();

                _database.StoredProcedure("m4_modificar_equipo(@descripcionES, @descripcionEN, @grupo, " +
                    "@id_pais, @status)");
                for (int i = 0; i < equipo.Descripcion.Count(); i++)
                {
                    if (equipo.Descripcion[i].Idioma.ToString().ToLower() == "es")
                        _database.AgregarParametro("descripcionES", equipo.Descripcion[i].Mensaje.ToString());
                    else if (equipo.Descripcion[i].Idioma.ToString().ToLower() == "en")
                        _database.AgregarParametro("descripcionEN", equipo.Descripcion[i].Mensaje.ToString());
                }
                _database.AgregarParametro("grupo", equipo.Grupo.ToString());
                _database.AgregarParametro("id_pais", equipo.Pais.Iso.ToString());
                _database.EjecutarQuery();

				return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (NullReferenceException e)
            {
                _database.Desconectar();
                return Request.CreateResponse(HttpStatusCode.BadRequest,
                    new HttpError("Error al tratar de agregar equipo:" + e.Message));
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
                return Request.CreateResponse(HttpStatusCode.OK, _listaPaises);
            }
            catch (Exception e)
            {
                _database.Desconectar();
                return Request.CreateResponse(HttpStatusCode.BadRequest, 
                    new HttpError("Error al tratar de obtener los datos de los paises:" + e.Message));
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
            catch (Exception exc)
            {
                return null;
            }
        }
    }
}