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
    [RoutePrefix("api/M1_RegistroLoginRecuperar")]
    public class M1_RegistroLoginRecuperarController : ApiController
    {

        private DataBase _database = new DataBase();

        [Route("RegistrarUsuario/{nombreUsuario}/{nombre}/{apellido}/{fechaNacimiento}/{correo}/{genero}/{password}")]
        [HttpPost]
        public IHttpActionResult RegistrarUsuario(string nombreUsuario, string nombre, string apellido,
            string fechaNacimiento, string correo, char genero, string password)
        {
            try
            {
                AgregarUsuario(nombreUsuario, nombre, apellido, fechaNacimiento, correo, genero, password);

                return Ok("Usuario registrado exitosamente");
            }
            catch (Exception e)
            {
                _database.Desconectar();
                return BadRequest("Error en el servidor: " + e.Message);
            }

        }

        [Route("RecuperarClave/{correo}")]
        [HttpPost]
        public IHttpActionResult RecuperarClave(string correo)
        {
            try
            {
                //if (ValidarCorreo(correo))
                //{
                    EnviarCorreo(correo);
                    return Ok("correo para recuperación enviado");
                //}

               // return Ok("El correo no existe");

            }

            catch(Exception e)
            {
                _database.Desconectar();
                return BadRequest("Error en el servidor: " + e.Message);
            }

        }

        [Route("CambiarClave/{correo}/{password}")]
        [HttpPost]
        public IHttpActionResult CambiarClave(string correo, string password)
        {
            try
            {


                System.Diagnostics.Debug.WriteLine("Prueba correo");


                System.Diagnostics.Debug.WriteLine("Prueba correo " + correo);

                System.Diagnostics.Debug.WriteLine("Prueba password " + password);

                // if (ValidarCorreo(correo))
                //{
                CambiarPassword(correo, password);
                    return Ok("clave modificada exitosamente");
                //}

               // return Ok("clave no se pudo modificar");

            }

            catch (Exception e)
            {
                _database.Desconectar();
                return BadRequest("Error en el servidor: " + e.Message);
            }



        }


        [Route("Henry/")]
        [HttpPost]
        public IHttpActionResult PruebaHenry(Usuario usuario)
        {

            System.Diagnostics.Debug.WriteLine("------------------------" );

            try
            {
                System.Diagnostics.Debug.WriteLine("Prueba correo "+ usuario.Correo);
                System.Diagnostics.Debug.WriteLine("Prueba password " + usuario.Password);

                return Ok();
            }

            catch (Exception e)
            {
                _database.Desconectar();
                return BadRequest("Error en el servidor: " + e.Message);
            }


        }


        public void EnviarCorreo(string correo)
        {
            MailMessage _email = new MailMessage();
            SmtpClient _smtpServidor = new SmtpClient();

           
            _email.IsBodyHtml = true;
            _email.From = new MailAddress("copamundialucab@gmail.com");
            _email.To.Add(correo);
            _email.Subject = "Recuperar clave copamundial";
            _email.Body = "Estimado usuario, recibimos la solicitud para recuperar la contraseña de su cuenta en COPAMUNDIAL, acceda a la siguiente dirección <a href='http://www.copamundial.com/changePassword'></a>";

            _smtpServidor.Host = "smtp.gmail.com";
            _smtpServidor.Port = 587;
            _smtpServidor.Credentials = new System.Net.NetworkCredential("copamundialucab", "copamundial2018");
            _smtpServidor.EnableSsl = true;

            _smtpServidor.Send(_email);
            
        }

        private void AgregarUsuario(string nombreUsuario, string nombre, string apellido, 
            string fechaNacimiento, string correo, char genero, string password)
        {
            _database.Conectar();

            _database.StoredProcedure("AgregarUsuario(@nombreUsuario, @nombre, @apellido, @fechaNacimiento, @correo, @genero, @password)");

            _database.AgregarParametro("nombreUsuario", nombreUsuario);
            _database.AgregarParametro("nombre", nombre);
            _database.AgregarParametro("apellido", apellido);
            _database.AgregarParametro("fechaNacimiento", fechaNacimiento);
            _database.AgregarParametro("correo", correo);
            _database.AgregarParametro("genero", genero.ToString().ToUpper());
            _database.AgregarParametro("password", password);

            _database.EjecutarQuery();
        }


        private void CambiarPassword(string correo, string password)
        {

            _database.Conectar();

            _database.StoredProcedure("CambiarPassword(@correo, @password)");

            _database.AgregarParametro("correo", correo);
            _database.AgregarParametro("password", password);

            _database.EjecutarQuery();
        }

        

        private bool ValidarUsuarioPassword(string nombreUsuario, string password)
        {
            int _contador;
            _database.Conectar();

            _database.StoredProcedure("ConsultarUsuarioPassword(@nombreUsuario, @password)");

            _database.AgregarParametro("nombreUsuario", nombreUsuario);
            _database.AgregarParametro("password", password);

            _database.EjecutarReader();
            _contador = _database.GetInt(0, 0);


            if (_contador < 1)
            {
                return false;
            }

            return true;
        }

        private bool ValidarCorreoPassword(string correo, string password)
        {
            int _contador;
            _database.Conectar();

            _database.StoredProcedure("ConsultarCorreoPassword(@correo, @password)");

            _database.AgregarParametro("correo", correo);
            _database.AgregarParametro("password", password);

            _database.EjecutarReader();
            _contador = _database.GetInt(0, 0);


            if (_contador < 1)
            {
                return false;
            }

            return true;

        }

        private bool ValidarNombreUsuario(string nombreUsuario)
        {
            int _contador;
            _database.Conectar();

            _database.StoredProcedure("ConsultarNombreUsuario(@nombreUsuario)");

            _database.AgregarParametro("nombreUsuario", nombreUsuario);

            _database.EjecutarReader();
            _contador = _database.GetInt(0, 0);


            if (_contador < 1)
            {
                return false;
            }

            return true;
        }

        private bool ValidarCorreo(string correo)
        {
            int _contador; //contador de filas retornadas por la bd
            _database.Conectar();

            _database.StoredProcedure("ConsultarCorreoUsuario(@correo)");

            _database.AgregarParametro("correo", correo);

            _database.EjecutarReader();

            _contador = _database.GetInt(0, 0);

            if (_contador < 1)
            {
                return false;
            }

            return true;


        }
    }
}