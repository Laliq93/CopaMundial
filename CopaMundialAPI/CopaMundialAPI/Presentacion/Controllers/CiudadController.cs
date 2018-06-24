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

namespace CopaMundialAPI.Presentacion.Controllers
{
	[RoutePrefix("api/ciudad")]
	public class CiudadController : ApiController
	{
		[Route("agregarciudad")]
		[System.Web.Http.HttpPost]
		public HttpResponseMessage InsertarCiudad(JObject json)
		{
			string js = (string)json["json"];
			JObject dato = JObject.Parse(js);
			String hola;
			hola = (string)dato["nombre"];
			Console.WriteLine(hola);
			Ciudad ciudad = new Ciudad((string)dato["nombre"], (int)dato["poblacion"], (string)dato["descripcion"], (string)dato["nombreingles"], (string)dato["descripcioningles"]);

			ComandoAgregarCiudad comando = FabricaComando.CrearComandoAgregarCiudad(ciudad);
			comando.Ejecutar();
			return Request.CreateResponse(HttpStatusCode.OK);
		}


		[Route("agregarimagen")]
		[System.Web.Http.HttpPost]
		public HttpResponseMessage Insertarimagen(HttpPostedFile dato)
			{


			 

            HttpResponseMessage result = null;

            var httpRequest = HttpContext.Current.Request;
				string file = httpRequest.Files.Get(0).ToString();

			Console.WriteLine(file);
			//byte[] f = Integerdato.InputStream.ReadByte();
			
			
				Ciudad ciudad = new Ciudad("guatire", 4500,"gg","a","a");
				FabricaComando.CrearComandoAgregarCiudad(ciudad);
				return Request.CreateResponse(HttpStatusCode.OK, ciudad);
			}

			[Route("ciudad")]
			[System.Web.Http.HttpGet]
			public HttpResponseMessage GetCiudad()
			{
			//Ciudad ciudad = new Ciudad((string)dato["nombre"], (int)dato["habitantes"], (string)dato["descripcion"], (byte[])dato["imagen"]);
			//FabricaComando.CrearComandoAgregarCiudad(ciudad);
			Ciudad ciudad = new Ciudad("hola", 1, "h","a","a");

				return Request.CreateResponse(HttpStatusCode.OK, ciudad);
			}


		[HttpPost, Route("api/upload")]
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
		}
		[HttpPost,Route("ciudad")]
		public HttpResponseMessage ObtenerCiudad(JObject json)
		{
			//string js = (string)json["json"];
			//JObject dato = JObject.Parse(js);
			int id;
			id = (int)json["id"];
			Console.WriteLine(id);
			//Ciudad ciudad = new Ciudad((string)dato["nombre"], (int)dato["poblacion"], (string)dato["descripcion"], (string)dato["nombreingles"], (string)dato["descripcioningles"], (byte[])dato["imagen"]);
			ComandoObtenerCiudad comando = FabricaComando.CrearComandoObtenerCiudad(id);
			//ComandoAgregarCiudad comando = FabricaComando.CrearComandoAgregarCiudad(ciudad);
			comando.Ejecutar();
			Ciudad ciudad = (Ciudad)comando.GetEntidad();
			return Request.CreateResponse(HttpStatusCode.OK, ciudad);
		}

	}
}