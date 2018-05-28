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

        /// <summary>
        /// Ingresa dentro de la base de datos del sistema un usuario
        /// </summary>
        /// <param Usuario="usuario">Objeto usuario</param>
        /// <returns>Retorna mensaje de exito</returns>
        /// <exception cref="NombreUsuarioExistenteException">Excepcion HTTP cuando el nombre de
        ///  usuario ya existe en el sistema, con su respectivo codigo</exception>
        /// <exception cref="CorreoExistenteException">Excepcion HTTP cuando el correo 
        /// ingresado ya existe en el sistema, con su respectivo codigo</exception>
        /// <exception cref="Exception">Excepcion HTTP que le brinda robustez al metodo</exception>
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

        /// <summary>
        /// Inicia sesion dentro del sistema con el nombre de usuario
        /// </summary>
        /// <param Usuario="usuario">Objeto usuario</param>
        /// <returns>Retorna el id del usuario que ingresa en el sistema</returns>
        /// <exception cref="NombreUsuarioNoExisteException">Excepcion HTTP cuando el nombre de
        ///  usuario no existe en el sistema, con su respectivo codigo</exception>
        /// <exception cref="UsuarioInactivoException">Excepcion HTTP cuando el usuario
        /// se encuentra inactivo en el sistema, con su respectivo codigo</exception>
        /// <exception cref="ClaveUsuarioNoCoincideException">Excepcion HTTP cuando el nombre del usuario
        /// no coincide con la clave ingresada, con su respectivo codigo</exception>
        /// <exception cref="Exception">Excepcion HTTP que le brinda robustez al metodo</exception>
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
                ValidarUsuarioActivo(usuario.NombreUsuario);
                ValidarUsuarioPassword(usuario.NombreUsuario, usuario.Password);
     
                usuario.Id = IniciarSesionUsuario(usuario.NombreUsuario, usuario.Password);
                return Ok(usuario.Id);
            }
            catch(NombreUsuarioNoExisteException e)
            {
                _database.Desconectar();
                return BadRequest("Error en el servidor: " + e.Message);
            }
            catch(UsuarioInactivoException e)
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
                ValidarCorreoActivo(usuario.Correo);
                ValidarCorreoPassword(usuario.Correo, usuario.Password);
                usuario.Id = IniciarSesionCorreo(usuario.Correo, usuario.Password);

                return Ok(usuario.Id);
            }
            catch(CorreoNoExisteException e)
            {
                _database.Desconectar();
                return BadRequest("Error en el servidor: " + e.Message);
            }
            catch(UsuarioInactivoException e)
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
                ValidarToken(usuario.Token);
                ValidarCorreo(usuario.Correo);
                CambiarPassword(usuario.Token, usuario.Correo, usuario.Password);

                return Ok("clave modificada exitosamente");


            }
            catch(CodigoNoCoincide e)
            {
                _database.Desconectar();
                return BadRequest("Error en el servidor: " + e.Message);
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

            int _minimo = 1000;
            int _maximo = 9999;
            Random _random = new Random();
            string _token = _random.Next(_minimo, _maximo).ToString();


            _email.IsBodyHtml = true;
            _email.From = new MailAddress("copamundialucab@gmail.com");
            _email.To.Add(correo);
            _email.Subject = "Recuperar clave copamundial";
            _email.Body = ("Estimado usuario, recibimos la solicitud para recuperar la contraseña de su cuenta en COPAMUNDIAL, este es su codigo de recuperación: "+ _token);

            _smtpServidor.Host = "smtp.gmail.com";
            _smtpServidor.Port = 587;
            _smtpServidor.Credentials = new System.Net.NetworkCredential("copamundialucab", "copamundial2018");
            _smtpServidor.EnableSsl = true;
            

            _smtpServidor.Send(_email);

            _database.Conectar();

            _database.StoredProcedure("SetearToken(@_token, @correo)");

            _database.AgregarParametro("_token", _token);
            _database.AgregarParametro("correo", correo);

            _database.EjecutarQuery();

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


        private void CambiarPassword(string token, string correo, string password)
        {

            _database.Conectar();



            _database.StoredProcedure("CambiarPassword(@token, @correo, @password)");

            _database.AgregarParametro("token", token);
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

            if (_contador < 1)
                throw new CorreoNoExisteException(correo);


        }

        private void ValidarUsuarioActivo(string nombreUsuario)
        {
            int _contador; //contador de filas retornadas por la bd
            _database.Conectar();

            _database.StoredProcedure("ConsultarNombreUsuarioActivo(@nombreUsuario)");

            _database.AgregarParametro("nombreUsuario", nombreUsuario);

            _database.EjecutarReader();

            _contador = _database.GetInt(0, 0);

            if (_contador < 1)
                throw new UsuarioInactivoException(nombreUsuario);


        }

        private void ValidarCorreoActivo(string correo)
        {
            int _contador; //contador de filas retornadas por la bd
            _database.Conectar();

            _database.StoredProcedure("ConsultarCorreoActivo(@correo)");

            _database.AgregarParametro("correo", correo);

            _database.EjecutarReader();

            _contador = _database.GetInt(0, 0);

            if (_contador < 1)
                throw new UsuarioInactivoException(correo);


        }

        private void ValidarToken(string token)
        {
            int _contador; //contador de filas retornadas por la bd
            _database.Conectar();

            _database.StoredProcedure("ConsultarToken(@token)");

            _database.AgregarParametro("token", token);

            _database.EjecutarReader();

            _contador = _database.GetInt(0, 0);

            if (_contador < 1)
                throw new CodigoNoCoincide(token);


        }
    }
}
