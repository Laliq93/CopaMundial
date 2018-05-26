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
                return BadRequest("Error en el servidor: " + e.Message);
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
    }
}