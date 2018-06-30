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

namespace CopaMundialAPI.Presentacion.Controllers
{
	[RoutePrefix("api")]
	public class CiudadController : ApiController
	{


		[Route("ciudadid")]
		[System.Web.Http.HttpPost]
		public IHttpActionResult InsertarCiudadid(DTOCiudadNombre dto)
		{
			
			System.Diagnostics.Debug.WriteLine(dto);
			TraductorCiudadNombre traductor = FabricaTraductor.CrearTraductorCiudadNombre();
			Entidad ciudad = traductor.CrearEntidad(dto);
			ComandoAgregarCiudad comando = FabricaComando.CrearComandoAgregarCiudad(ciudad);
			comando.Ejecutar();
			return Ok();
		}
		//Agregar ciudad
		[Route("ciudad")]
		[System.Web.Http.HttpPost]
		public HttpResponseMessage InsertarCiudad(DTOCiudad dto)
		{
			
			Console.WriteLine(dto);
			TraductorCiudad traductor = FabricaTraductor.CrearTraductorCiudad();
			Entidad ciudad = traductor.CrearEntidad(dto);
			ComandoAgregarCiudad comando = FabricaComando.CrearComandoAgregarCiudad(ciudad);
			comando.Ejecutar();
			return Request.CreateResponse(HttpStatusCode.OK);
		}


		


		//Lista de todas las ciudades
		[Route("ciudad")]
		[System.Web.Http.HttpGet]
		public HttpResponseMessage GetCiudades()
		{
			
			ComandoListarCiudades comando = FabricaComando.CrearComandoListarCiudades();
			comando.Ejecutar();
			TraductorCiudad traductor = FabricaTraductor.CrearTraductorCiudad();

			List<Entidad> ciudades = comando.GetEntidades();
			List<DTOCiudad> dtociudades = traductor.CrearListaDto(ciudades);
			return Request.CreateResponse(HttpStatusCode.OK, dtociudades);
		}

		//codigo para guardar imagen, no borrar por si acaso
		/*[HttpPost, Route("api/upload")]
		public async Task<IHttpActionResult> Upload()
		{
			if (!Request.Content.IsMimeMultipartContent())
				throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
			byte[] buffer= null;
			var provider = new MultipartMemoryStreamProvider();
			await Request.Content.ReadAsMultipartAsync(provider);
			foreach (var file in provider.Contents)

			{
				var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
				buffer = await file.ReadAsByteArrayAsync();
				//Do whatever you want with filename and its binaray data.
			}
			Ciudad ciudad = new Ciudad("guatire", 100, "a","aa","bb");
			ComandoAgregarCiudad comando = FabricaComando.CrearComandoAgregarCiudad(ciudad);
			comando.Ejecutar();
			return Ok(ciudad);
		}*/
		[HttpPost, Route("ciudadnombre")]
		public HttpResponseMessage ObtenerCiudadesPorNombre(DTOCiudadNombre dto)
		{
			

			//Creando traductor de dto CiudadNombre
			TraductorCiudadNombre traductor = FabricaTraductor.CrearTraductorCiudadNombre();

			//Creando Traductor de DTO ciudad
			TraductorCiudad traductorciudad = FabricaTraductor.CrearTraductorCiudad();

			//Creando entidad ciudad apartir de dto recibido por parametro
			Entidad ciudad = traductor.CrearEntidad(dto);

			//Creando comando que mandara a ejecutar la busqueda en la base de datos de ciudades por nombre
			Comando comando = FabricaComando.CrearComandoObtenerCiudadPorNombre(ciudad);
			//Ejecutando el comando
			comando.Ejecutar();

			//Obteniendo lita de entidades de los resultados del comando y traduciendolas a dto
			List<DTOCiudad> ciudades = traductorciudad.CrearListaDto(comando.GetEntidades());
			//retornando resultados
			return Request.CreateResponse(HttpStatusCode.OK, ciudades);
		}

		//Eliminar ciudad
		[HttpDelete, Route("ciudad")]
		public HttpResponseMessage EliminarCiudad(DTOCiudadID dto)
		{

			TraductorCiudadID traductor = FabricaTraductor.CrearTraductorCiudadID();
			Entidad ciudad = traductor.CrearEntidad(dto);
			Comando comando = FabricaComando.CrearComandoEliminarCiudad(ciudad);
			comando.Ejecutar();


			return Request.CreateResponse(HttpStatusCode.OK);
		}

		[HttpPut, Route("ciudad")]
		public HttpResponseMessage ActualizarCiudad(DTOCiudad dto)
		{
			TraductorCiudad traductor = FabricaTraductor.CrearTraductorCiudad();
			Entidad ciudad = traductor.CrearEntidad(dto);
			Comando comando = FabricaComando.CrearComandoActualizarCiudad(ciudad);
			comando.Ejecutar();
			return Request.CreateResponse(HttpStatusCode.OK);
		}

		[Route("ciudad/habilitada")]
		[System.Web.Http.HttpGet]
		public HttpResponseMessage GetCiudadesHabilitadas()
		{

			ComandoObtenerCiudadTrue comando = FabricaComando.CrearComandoObtenerCiudadesHabilitadas();
			comando.Ejecutar();
			TraductorCiudad traductor = FabricaTraductor.CrearTraductorCiudad();

			List<Entidad> ciudades = comando.GetEntidades();
			List<DTOCiudad> dtociudades = traductor.CrearListaDto(ciudades);
			return Request.CreateResponse(HttpStatusCode.OK, dtociudades);
		}

	}
}