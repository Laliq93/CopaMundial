using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using WebAPI.Models;
using WebAPI.Models.DataBase;
using WebAPI.Models.Excepciones;


namespace WebAPI.Controllers
{
    [RoutePrefix("api/M1_RegistroLoginRecuperar")]
    public class M1_RegistroLoginRecuperarController : ApiController
    {

        private DataBase _database = new DataBase();

        [Route("RegistrarUsuario")]
        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult RegistrarUsuario(Usuario usuario)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine(usuario);
                //{nombreUsuario}/{nombre}/{apellido}/{fechaNacimiento}/{correo}/{genero}/{password}

                ValidarNombreUsuario(usuario.NombreUsuario);
                ValidarCorreoNoExiste(usuario.Correo);
                AgregarUsuario(usuario.NombreUsuario, usuario.Nombre, usuario.Apellido, usuario.FechaNacimiento,
                  usuario.Correo, usuario.Genero, usuario.Password);

                return Ok("Usuario registrado exitosamente");
            }
            catch (NombreUsuarioExistenteException e)
            {
                _database.Desconectar();
                return BadRequest(e.Message);
            }
            catch (CorreoExistenteException e)
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

        [Route("IniciarSesionUsuario")]
        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult IniciarSesionUsuario(Usuario usuario)
        {
            try
            {
                //{nombreUsuario}/{nombre}/{apellido}/{fechaNacimiento}/{correo}/{genero}/{password}

                System.Diagnostics.Debug.WriteLine(usuario);
                ValidarNombreUsuarioNoExiste(usuario.NombreUsuario);
                ValidarUsuarioPassword(usuario.NombreUsuario, usuario.Password);
                usuario.Id = IniciarSesionUsuario(usuario.NombreUsuario, usuario.Password);
                return Ok(usuario.Id);
            }
            catch(NombreUsuarioNoExisteException e)
            {
                _database.Desconectar();
                return BadRequest("Error en el servidor: " + e.Message);
            }
            catch(ClaveUsuarioNoCoincideException e)
            {
                _database.Desconectar();
                return BadRequest("Error en el servidor: " + e.Message);
            }
            catch (Exception e)
            {
                _database.Desconectar();
                return BadRequest("Error en el servidor: " + e.Message);
            }

        }

        [Route("IniciarSesionCorreo")]
        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult IniciarSesionCorreo(Usuario usuario)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine(usuario);
                ValidarCorreoNoExiste(usuario.Correo);
                ValidarCorreoPassword(usuario.Correo, usuario.Password);
                usuario.Id = IniciarSesionCorreo(usuario.Correo, usuario.Password);

                return Ok(usuario.Id);
            }
            catch(CorreoNoExisteException e)
            {
                _database.Desconectar();
                return BadRequest("Error en el servidor: " + e.Message);
            }
            catch( ClaveCorreoNoCoincideException e)
            {
                _database.Desconectar();
                return BadRequest("Error en el servidor: " + e.Message);
            }
            catch (Exception e)
            {
                _database.Desconectar();
                return BadRequest("Error en el servidor: " + e.Message);
            }

        }

        [Route("RecuperarClave")]
        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult RecuperarClave(Usuario usuario)
        {
            try
            {
                    ValidarCorreo(usuario.Correo);
                    EnviarCorreo(usuario.Correo);
                    return Ok("correo para recuperación enviado");

            }

            catch(CorreoNoExisteException e)
            {
                _database.Desconectar();
                return BadRequest("Error en el servidor: " + e.Message);
            }
            catch(Exception e)
            {
                _database.Desconectar();
                return BadRequest("Error en el servidor: " + e.Message);
            }

        }

        [Route("CambiarClave")]
        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult CambiarClave(Usuario usuario)
        {
            try
            {

                ValidarCorreo(usuario.Correo);
                CambiarPassword(usuario.Correo, usuario.Password);
                return Ok("clave modificada exitosamente");


            }

            catch(CorreoNoExisteException e)
            {
                _database.Desconectar();
                return BadRequest("Error en el servidor: " + e.Message);
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
            _email.Body = ("Estimado usuario, recibimos la solicitud para recuperar la contraseña de su cuenta en COPAMUNDIAL con el siguiente correo: "+ correo);

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


        private int IniciarSesionCorreo(string correo, string password)
        {

            int _id;
            _database.Conectar();

            _database.StoredProcedure("IniciarSesionCorreo(@correo, @password)");

            
            _database.AgregarParametro("correo", correo);
            _database.AgregarParametro("password", password);

            _database.EjecutarReader();
            _id = _database.GetInt(0, 0);

            return _id;
        }

        private int IniciarSesionUsuario(string nombreUsuario, string password)
        {
            int _id;
            _database.Conectar();

            _database.StoredProcedure("IniciarSesionUsuario(@nombreUsuario, @password)");


            _database.AgregarParametro("nombreUsuario", nombreUsuario);
            _database.AgregarParametro("password", password);

            _database.EjecutarReader();
            _id = _database.GetInt(0, 0);

            return _id;
        }


        private void CambiarPassword(string correo, string password)
        {

            _database.Conectar();

            _database.StoredProcedure("CambiarPassword(@correo, @password)");

            _database.AgregarParametro("correo", correo);
            _database.AgregarParametro("password", password);

            _database.EjecutarQuery();
        }

        

        private void ValidarUsuarioPassword(string nombreUsuario, string password)
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
                throw new ClaveUsuarioNoCoincideException(nombreUsuario, password);
            }

            //System.Diagnostics.Debug.WriteLine("------------------------");

        }

        private void ValidarCorreoPassword(string correo, string password)
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
                throw new ClaveCorreoNoCoincideException(correo, password);
            }


        }

        private void ValidarNombreUsuario(string nombreUsuario)
        {
            int _contador;
            _database.Conectar();

            _database.StoredProcedure("ConsultarNombreUsuario(@nombreUsuario)");

            _database.AgregarParametro("nombreUsuario", nombreUsuario);

            _database.EjecutarReader();
            _contador = _database.GetInt(0, 0);


            if (_contador > 0)
            {
                throw new NombreUsuarioExistenteException(nombreUsuario);
            }
        }

        private void ValidarNombreUsuarioNoExiste(string nombreUsuario)
        {
            int _contador; //contador de filas retornadas por la bd

            _database.Conectar();

            _database.StoredProcedure("ConsultarNombreUsuario(@nombreUsuario)");

            _database.AgregarParametro("nombreUsuario", nombreUsuario);

            _database.EjecutarReader();

            _contador = _database.GetInt(0, 0);

            if (_contador < 1)
                throw new NombreUsuarioNoExisteException(nombreUsuario);


        }

        private void ValidarCorreo(string correo)
        {
            int _contador; //contador de filas retornadas por la bd
            _database.Conectar();

            _database.StoredProcedure("ConsultarCorreoUsuario(@correo)");

            _database.AgregarParametro("correo", correo);

            _database.EjecutarReader();

            _contador = _database.GetInt(0, 0);

            if (_contador < 1)
                throw new CorreoNoExisteException(correo);


        }

        private void ValidarCorreoNoExiste(string correo)
        {
            int _contador; //contador de filas retornadas por la bd

            _database.Conectar();

            _database.StoredProcedure("ConsultarCorreoUsuario(@correo)");

            _database.AgregarParametro("correo", correo);

            _database.EjecutarReader();

            _contador = _database.GetInt(0, 0);

            if (_contador > 0)
                throw new CorreoExistenteException(correo);


        }
    }
}
