using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI.Models.DataBase;
using WebAPI.Models.Exceptiones;
using WebAPI.Models;

namespace WebAPI.Controllers
{

    /// <summary>
    /// Controlador del Modulo 1 de Autoregistro, inicio de sesion y recuperar contrasena
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class M1_RegistroLofinRecuperarController : ApiController
    {
        private Usuario _usuario;
        private DataBase _conexion;


        /// <summary>
        /// Consulta un usuario con los datos recibidos (correo y clave)
        /// </summary>
        /// <param name="datos">datos del usuario. Formato JSON</param>
        /// <returns>El id del usuario(0 si no existe). Formato JSON</returns>
        [HttpPost]
        public int IniciarSesionCorreo(String datos)
        {
            
        }
    }
}