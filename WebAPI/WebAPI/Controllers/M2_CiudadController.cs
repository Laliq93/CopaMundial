using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
using WebAPI.Models.DataBase;
using WebAPI.Models.Excepciones;
using System.Data;
using System.Web;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/M2_Ciudad")]
    public class M2_CiudadController : ApiController
    {
     /*   private DataBase _database = new DataBase();
        private List<Ciudad> _listaCiudades;
        private Ciudad _Ciudad;


        [Route("AgregarCiudad")]
        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult AgregarCiudad(Ciudad _ciudad)
        {
            try
            {
                //{nombreUsuario}/{nombre}/{apellido}/{fechaNacimiento}/{correo}/{genero}/{password}
                ValidarNombreCiudad(_ciudad.nombreCiudad);
                AgregarUsuario(_ciudad.nombreCiudad, _ciudad.poblacion, _ciudad.descripcion, 
                   _ciudad.localizacion, _ciudad.fotopath);

                return Ok("Ciudad registrado exitosamente");
            }
            catch (CorreoExistenteException e)
            {
                _database.Desconectar();
                return BadRequest(e.Message);
            }
            catch (NombreUsuarioExistenteException e)
            {
                _database.Desconectar();
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                _database.Desconectar();
                return BadRequest(e.Message);
            }


        }


        //--------------------------Procedimientos -----------------------------------------//

            //----1 procedimientos de agregar Ciudad----------//
        private void AgregarCiudad(string nombreCiudad, int poblacion, string descripcion,
        string localizacion, string fotopath)
        {
            _database.Conectar();

            _database.StoredProcedure("AgregarCiudad(@nombreCiudad, @poblacion, @descripcion, @localizacion, @fotopath)");

            _database.AgregarParametro("nombreCiudad", nombreCiudad);
            _database.AgregarParametro("poblacion", poblacion);
            _database.AgregarParametro("descripcion", descripcion);
            _database.AgregarParametro("localizacion", localizacion);
            _database.AgregarParametro("fotopath", fotopath);

            _database.EjecutarQuery();
        }

        private bool ValidarNombreCiudad(string nombreCiudad)
        {
            int _contador;
            _database.Conectar();

            _database.StoredProcedure("ConsultarCiudad(@nombreCiudad)");

            _database.AgregarParametro("nombreCiudad", nombreCiudad);

            _database.EjecutarReader();
            _contador = _database.GetInt(0, 0);


            if (_contador > 0)
            {
                throw new NombreUsuarioExistenteException(nombreCiudad); ///Poner un exceotion personalizada de ciudaddd
            }

            return true;
        }


   ////-----------------------------2  Procedimientos de editar Ciudad------------------------////



	*/
    }
}