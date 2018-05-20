using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models.Usuario;
using WebAPI.Models.DataBase;
using System.Data;
using System.Web;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/M10_Usuario")]
    public class M10_UsuarioController : ApiController
    {
        DataBase DataBase = new DataBase();

        [Route("ActualizarPerfil/{idUsuario:int}/{nombre}/{apellido}/{fechaNacimiento}/{genero}/{fotoPath}")]
        [HttpPut, HttpGet]
        public IHttpActionResult ActualizarPerfil(int idUsuario, string nombre, string apellido, string fechaNacimiento, char genero, string fotoPath)
        {
            if (!DataBase.Conectar())
            {
                DataBase.Desconectar();
                return BadRequest("Error al conectarse a la base de datos.");
            }

            try
            {
                DataBase.StoredProcedure("editarperfilusuario(@id, @nombre, @apellido, @fechaNacimiento, @genero, @foto)");

                DataBase.AgregarParametro("id", idUsuario);
                DataBase.AgregarParametro("nombre", nombre);
                DataBase.AgregarParametro("apellido", apellido);
                DataBase.AgregarParametro("fechaNacimiento", fechaNacimiento);
                DataBase.AgregarParametro("genero", genero.ToString().ToUpper());
                DataBase.AgregarParametro("foto", fotoPath);

                DataBase.EjecutarQuery();

                return Ok("Usuario editado con exito.");
            }
            catch (Exception e)
            {
                DataBase.Desconectar();
                return BadRequest("Error en el servidor: "+e.Message);
            }

        }

        // api/Usuario/ObtenerUsuario/?idUsuario=id
        [HttpGet]
        [Route("ObtenerUsuario/{idUsuario:int}")]
        public HttpResponseMessage ObtenerUsuario(int idUsuario)
        {
            try
            {
                if (!DataBase.Conectar()) //se abre la conexión con la base de datos
                {
                    DataBase.Desconectar();
                    return Request.CreateResponse(HttpStatusCode.NotFound, new HttpError("Error al conectarse con la base de datos"));
                }

                Usuario usuario = GetUsuario(idUsuario);

                if (usuario == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound, new HttpError("El usuario no existe."));

                return Request.CreateResponse(HttpStatusCode.OK, usuario);
            }
            catch (Exception e)
            {
                DataBase.Desconectar();
                return Request.CreateResponse(HttpStatusCode.NotFound, new HttpError("Error en el servidor:"+e.Message));
            }
           
        }

        private Usuario GetUsuario(int idUsario)
        {
            DataBase.StoredProcedure("ConsultarUsuarioId(@Id)");

            DataBase.AgregarParametro("Id", idUsario);

            DataBase.EjecutarReader();

            //string path = HttpContext.Current.Server.MapPath("");

            Usuario user = new Usuario(DataBase.GetInt(0, 0), DataBase.GetString(0, 1), DataBase.GetString(0, 2), DataBase.GetString(0, 3), DataBase.GetDateTime(0, 4),
               DataBase.GetString(0, 5), DataBase.GetString(0, 6), "password2", "path_foto", false, null);

            return user;
        }

        
       

    }
}
