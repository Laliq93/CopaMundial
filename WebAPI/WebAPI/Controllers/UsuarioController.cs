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
    [RoutePrefix("api/Usuario_")]
    public class UsuarioController : ApiController
    {
        DataBase DataBase = new DataBase();


        [HttpGet]
        public HttpResponseMessage Testing()
        {
            string mensaje = "Ejecutado";
            if (!DataBase.Conectar()) //se abre la conexión con la base de datos
            {
                DataBase.Desconectar();
                return Request.CreateResponse(HttpStatusCode.NotFound, new HttpError("Error al conectarse con la base de datos"));
            }

            DataBase.StoredProcedure("test()");

            DataBase.EjecutarReader();

            mensaje = DataBase.GetString(0,0);


            return Request.CreateResponse(HttpStatusCode.OK, mensaje);
        }

        // api/Usuario/ObtenerUsuario/?idUsuario=id
        [HttpGet]
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
                return Request.CreateResponse(HttpStatusCode.NotFound, new HttpError("Error en el servidor:"+e.GetType().FullName));
            }
           
        }

        private Usuario GetUsuario(int idUsario)
        {
            try
            {
                DataBase.StoredProcedure("ConsultarUsuarioId(@Id)");

                DataBase.AgregarParametro("Id", idUsario);

                DataBase.EjecutarReader();

                //string path = HttpContext.Current.Server.MapPath("");

                Usuario user = new Usuario(DataBase.GetInt(0,0), DataBase.GetString(0,1), DataBase.GetString(0, 2), DataBase.GetString(0, 3), DataBase.GetDateTime(0, 4),
                   DataBase.GetString(0, 5), DataBase.GetString(0, 6), "password2", "path_foto", false, null);

                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
       

    }
}
