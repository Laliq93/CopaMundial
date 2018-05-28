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
        /// <param name="descripcion">Representa la descripcion del equipo escrita en el cliente.</param>
        /// <param name="grupo">Representa el grupo al cual pertenece el equipo.</param>
        /// <param name="idPais">Representa el id del pais al que pertenece el equipo a agregar.</param>
        /// <returns></returns>
        [Route("AgregarEquipo/{descripcion}/{grupo}/{idPais}")]
        [HttpPost]
        public IHttpActionResult RegistrarEquipo(string descripcion, string grupo, string idPais)
        {
            try
            {
                var id = Convert.ToInt16(idPais);
                AgregarEquipo(descripcion, grupo, id);
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
        /// <param name="descripcion">La descripcion del pais que se va a inserntar.</param>
        /// <param name="grupo">El grupo al cual pertenece el pais que se va a insertar.</param>
        /// <param name="idPais">El id del pais al que pertenece el equipo que se va a insertart</param>
        public void AgregarEquipo( string descripcion, string grupo, int idPais)
        {
            try
            {
                _database.Conectar();
                _database.StoredProcedure("m4_agregar_equipo(@descripcion, @grupo, " +
                    "@id_pais)");
                _database.AgregarParametro("descripcion", descripcion);
                _database.AgregarParametro("grupo", grupo);
                _database.AgregarParametro("id_pais", idPais);
                _database.EjecutarQuery();
            }
            catch( Exception e)
            {
                
            }
        }

        /// <summary>
        /// Actualiza la información del perfil de usuario en la base de datos.
        /// </summary>
        public void ActulizarEquipo(Usuario usuario)
        {
            try
            {
                _database.Conectar();

                /*_database.StoredProcedure("editarperfilusuario(@id, @nombre, @apellido, @fechaNacimiento, @genero, @foto)");

                _database.AgregarParametro("id", usuario.Id);
                _database.AgregarParametro("nombre", usuario.Nombre);
                _database.AgregarParametro("apellido", usuario.Apellido);
                _database.AgregarParametro("fechaNacimiento", Convert.ToDateTime(usuario.FechaNacimiento).ToShortDateString());
                _database.AgregarParametro("genero", usuario.Genero.ToString().ToUpper());
                _database.AgregarParametro("foto", usuario.FotoPath);

                _database.EjecutarQuery();*/
            }
            catch (NullReferenceException exc)
            {
                //throw new UsuarioNullException(exc);
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
                    pais = new Pais(_database.GetString(i, 0), new I18nEquipo(_database.GetInt(i, 3), idioma, _database.GetString(i,1)));

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