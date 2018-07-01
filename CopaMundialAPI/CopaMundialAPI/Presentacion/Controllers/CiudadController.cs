using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CopaMundialAPI.Logica_de_Negocio.Fabrica;
using CopaMundialAPI.Comun.Entidades;
using Newtonsoft.Json.Linq;
using CopaMundialAPI.Logica_de_Negocio.Comando;
using System.Threading.Tasks;
using CopaMundialAPI.Logica_de_Negocio.Comando.Ciudades;
using CopaMundialAPI.Servicios.DTO.Ciudades;
using CopaMundialAPI.Servicios.Traductores.Fabrica;
using CopaMundialAPI.Servicios.Traductores.Ciudades;
using NLog;
using Npgsql;
using CopaMundialAPI.Comun.Excepciones;
using System.Reflection;

namespace CopaMundialAPI.Presentacion.Controllers
{
	[RoutePrefix("api")]
	public class CiudadController : ApiController
	{
        Logger logger = LogManager.GetLogger ( "fileLogger" );//logger

        /// <summary>
        /// Metodo para insertar una ciudad segun su id
        /// </summary>
        /// <param name="dto">Dto de tipo DtoCiudadNombre</param>
        /// <returns></returns>
		[Route ("ciudadid")]
		[System.Web.Http.HttpPost]
		public IHttpActionResult InsertarCiudadid(DTOCiudadNombre dto)
		{

            try
            {
                System.Diagnostics.Debug.WriteLine ( dto );
                TraductorCiudadNombre traductor = FabricaTraductor.CrearTraductorCiudadNombre ( );
                Entidad ciudad = traductor.CrearEntidad ( dto );
                ComandoAgregarCiudad comando = FabricaComando.CrearComandoAgregarCiudad ( ciudad );
                comando.Ejecutar ( );
                return Ok ( );
            }
            catch (NpgsqlException e)
            {
                logger.Error ( e, e.Message );

                throw new BaseDeDatosException ( e, "Error en la base de datos en: " + GetType ( ).FullName + "." + MethodBase.GetCurrentMethod ( ).Name + ". " + e.Message );
            }

            catch (Exception e)
            {
                logger.Error ( e, e.Message );

                throw new ExcepcionGeneral ( e, DateTime.Now );

            }
        }

        /// <summary>
        /// Metodo para insertar una ciudad 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        //Agregar ciudad
        [Route ("ciudad")]
		[System.Web.Http.HttpPost]
		public HttpResponseMessage InsertarCiudad(DTOCiudad dto)
		{
            try
            {
                Console.WriteLine ( dto );
                TraductorCiudad traductor = FabricaTraductor.CrearTraductorCiudad ( );
                Entidad ciudad = traductor.CrearEntidad ( dto );
                ComandoAgregarCiudad comando = FabricaComando.CrearComandoAgregarCiudad ( ciudad );
                comando.Ejecutar ( );
                return Request.CreateResponse ( HttpStatusCode.OK );
            }
            catch (NpgsqlException e)
            {
                logger.Error ( e, e.Message );

                throw new BaseDeDatosException ( e, "Error en la base de datos en: " + GetType ( ).FullName + "." + MethodBase.GetCurrentMethod ( ).Name + ". " + e.Message );
            }

            catch (Exception e)
            {
                logger.Error ( e, e.Message );

                throw new ExcepcionGeneral ( e, DateTime.Now );

            }
        }

        /// <summary>
        /// Metodo para listar todas las ciudades
        /// </summary>
        /// <returns></returns>
		//Lista de todas las ciudades
		[Route("ciudad")]
		[System.Web.Http.HttpGet]
		public HttpResponseMessage GetCiudades()
		{

            try
            {
                ComandoListarCiudades comando = FabricaComando.CrearComandoListarCiudades ( );
                comando.Ejecutar ( );
                TraductorCiudad traductor = FabricaTraductor.CrearTraductorCiudad ( );

                List<Entidad> ciudades = comando.GetEntidades ( );
                List<DTOCiudad> dtociudades = traductor.CrearListaDto ( ciudades );
                return Request.CreateResponse ( HttpStatusCode.OK, dtociudades );
            }
            catch (NpgsqlException e)
            {
                logger.Error ( e, e.Message );

                throw new BaseDeDatosException ( e, "Error en la base de datos en: " + GetType ( ).FullName + "." + MethodBase.GetCurrentMethod ( ).Name + ". " + e.Message );
            }

            catch (Exception e)
            {
                logger.Error ( e, e.Message );

                throw new ExcepcionGeneral ( e, DateTime.Now );

            }
        }

        /// <summary>
        /// Metodo para listar todas las ciudades por nombre
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
		[HttpPost, Route("ciudadnombre")]
		public HttpResponseMessage ObtenerCiudadesPorNombre(DTOCiudadNombre dto)
		{


            try
            {
                //Creando traductor de dto CiudadNombre
                TraductorCiudadNombre traductor = FabricaTraductor.CrearTraductorCiudadNombre ( );

                //Creando Traductor de DTO ciudad
                TraductorCiudad traductorciudad = FabricaTraductor.CrearTraductorCiudad ( );

                //Creando entidad ciudad apartir de dto recibido por parametro
                Entidad ciudad = traductor.CrearEntidad ( dto );

                //Creando comando que mandara a ejecutar la busqueda en la base de datos de ciudades por nombre
                Comando comando = FabricaComando.CrearComandoObtenerCiudadPorNombre ( ciudad );
                //Ejecutando el comando
                comando.Ejecutar ( );

                //Obteniendo lita de entidades de los resultados del comando y traduciendolas a dto
                List<DTOCiudad> ciudades = traductorciudad.CrearListaDto ( comando.GetEntidades ( ) );
                //retornando resultados
                return Request.CreateResponse ( HttpStatusCode.OK, ciudades );
            }
            catch (NpgsqlException e)
            {
                logger.Error ( e, e.Message );

                throw new BaseDeDatosException ( e, "Error en la base de datos en: " + GetType ( ).FullName + "." + MethodBase.GetCurrentMethod ( ).Name + ". " + e.Message );
            }

            catch (Exception e)
            {
                logger.Error ( e, e.Message );

                throw new ExcepcionGeneral ( e, DateTime.Now );

            }
        }

        /// <summary>
        /// Metodo para eliminar una ciudad
        /// </summary>
        /// <param name="dto">dto de tipo DTOCiudadID</param>
        /// <returns></returns>
		//Eliminar ciudad
		[HttpDelete, Route("ciudad")]
		public HttpResponseMessage EliminarCiudad(DTOCiudadID dto)
		{
            try
            {

                TraductorCiudadID traductor = FabricaTraductor.CrearTraductorCiudadID ( );
                Entidad ciudad = traductor.CrearEntidad ( dto );
                Comando comando = FabricaComando.CrearComandoEliminarCiudad ( ciudad );
                comando.Ejecutar ( );


                return Request.CreateResponse ( HttpStatusCode.OK );
            }
            catch (NpgsqlException e)
            {
                logger.Error ( e, e.Message );

                throw new BaseDeDatosException ( e, "Error en la base de datos en: " + GetType ( ).FullName + "." + MethodBase.GetCurrentMethod ( ).Name + ". " + e.Message );
            }

            catch (Exception e)
            {
                logger.Error ( e, e.Message );

                throw new ExcepcionGeneral ( e, DateTime.Now );

            }
        }


        /// <summary>
        /// Metodo para actualizar una ciudad 
        /// </summary>
        /// <param name="dto">dto de tipo DTOCiudad</param>
        /// <returns></returns>
		[HttpPut, Route("ciudad")]
		public HttpResponseMessage ActualizarCiudad(DTOCiudad dto)
		{
            try
            {
                TraductorCiudad traductor = FabricaTraductor.CrearTraductorCiudad ( );
                Entidad ciudad = traductor.CrearEntidad ( dto );
                Comando comando = FabricaComando.CrearComandoActualizarCiudad ( ciudad );
                comando.Ejecutar ( );
                return Request.CreateResponse ( HttpStatusCode.OK );
            }
            catch (NpgsqlException e)
            {
                logger.Error ( e, e.Message );

                throw new BaseDeDatosException ( e, "Error en la base de datos en: " + GetType ( ).FullName + "." + MethodBase.GetCurrentMethod ( ).Name + ". " + e.Message );
            }

            catch (Exception e)
            {
                logger.Error ( e, e.Message );

                throw new ExcepcionGeneral ( e, DateTime.Now );

            }
        }

        /// <summary>
        /// Metodo para obtener todas las ciudades habilitadas
        /// </summary>
        /// <returns></returns>
		[Route("ciudad/habilitada")]
		[System.Web.Http.HttpGet]
		public HttpResponseMessage GetCiudadesHabilitadas()
		{

            try
            { 
                ComandoObtenerCiudadTrue comando = FabricaComando.CrearComandoObtenerCiudadesHabilitadas ( );
                comando.Ejecutar ( );
                TraductorCiudad traductor = FabricaTraductor.CrearTraductorCiudad ( );

                List<Entidad> ciudades = comando.GetEntidades ( );
                List<DTOCiudad> dtociudades = traductor.CrearListaDto ( ciudades );
                return Request.CreateResponse ( HttpStatusCode.OK, dtociudades );

            }
            catch (NpgsqlException e)
            {
                logger.Error ( e,e.Message);

                throw new BaseDeDatosException ( e, "Error en la base de datos en: " + GetType ( ).FullName + "." + MethodBase.GetCurrentMethod ( ).Name + ". " + e.Message );
            }

            catch (Exception e)
            {
                logger.Error ( e, e.Message);

                throw new ExcepcionGeneral ( e, DateTime.Now );

            }
        }

	}
}