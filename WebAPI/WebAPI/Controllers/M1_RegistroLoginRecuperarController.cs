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
        /// <param name="usuario">Objeto usuario</param>
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
                ValidarCorreo(usuario.Correo);
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
        /// <param name="usuario">Objeto usuario</param>
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
     
                usuario = IniciarSesionUsuario(usuario.NombreUsuario, usuario.Password);
                return Ok(usuario);
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


        /// <summary>
        /// Inicia sesion dentro del sistema con el correo del usuario
        /// </summary>
        /// <param name="usuario">Objeto usuario</param>
        /// <returns>Retorna el id del usuario que ingresa en el sistema</returns>
        /// <exception cref="CorreoNoExisteException">Excepcion HTTP cuando el correo de
        ///  usuario no existe en el sistema, con su respectivo codigo</exception>
        /// <exception cref="UsuarioInactivoException">Excepcion HTTP cuando el usuario
        /// se encuentra inactivo en el sistema, con su respectivo codigo</exception>
        /// <exception cref="ClaveCorreoNoCoincideException">Excepcion HTTP cuando el correo del usuario
        /// no coincide con la clave ingresada, con su respectivo codigo</exception>
        /// <exception cref="Exception">Excepcion HTTP que le brinda robustez al metodo</exception>
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
                usuario = IniciarSesionCorreo(usuario.Correo, usuario.Password);

                return Ok(usuario);
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


        /// <summary>
        /// Recupera la contraseña del cliente mandandole un codigo de recuperacion al correo del usuario
        /// </summary>
        /// <param name="usuario">Objeto usuario</param>
        /// <returns>Retorna un mensaje de exito</returns>
        /// <exception cref="CorreoNoExisteException">Excepcion HTTP cuando el correo de
        ///  usuario no existe en el sistema, con su respectivo codigo</exception>
        /// <exception cref="Exception">Excepcion HTTP que le brinda robustez al metodo</exception>
        [Route("RecuperarClave")]
        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult RecuperarClave(Usuario usuario)
        {

            try
            {
                    ValidarCorreoNoExiste(usuario.Correo);
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


        /// <summary>
        /// Cambia la clave del usuario dentro del sistema
        /// </summary>
        /// <param name="usuario">Objeto usuario</param>
        /// <returns>Retorna el id del usuario que ingresa en el sistema</returns>
        /// <exception cref="CodigoNoCoincideException">Excepcion HTTP cuando el ccodigo ingresado no 
        /// coincide con el enviado al correo del usuario, con su respectivo codigo</exception>
        /// <exception cref="CorreoNoExisteException">Excepcion HTTP cuando el correo del usuario
        /// no existe dentro del sistema, con su respectivo codigo</exception>
        /// <exception cref="Exception">Excepcion HTTP que le brinda robustez al metodo</exception>
        [Route("CambiarClave")]
        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult CambiarClave(Usuario usuario)
        {
            try
            {
                ValidarToken(usuario.Token);
                ValidarCorreoNoExiste(usuario.Correo);
                CambiarPassword(usuario.Token, usuario.Correo, usuario.Password);

                return Ok("clave modificada exitosamente");


            }
            catch(CodigoNoCoincideException e)
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


        /// <summary>
        /// Envia el correo de recuperacion de contraseña
        /// </summary>
        /// <param name="correo">correo del usuario</param>
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


        /// <summary>
        /// Agrega al usuario en la bd
        /// </summary>
        /// <param name="nombreUsuario">nombre del usuario</param>
        /// <param name="nombre">nombre</param>
        /// <param name="apellido">apellido del usuario</param>   
        /// <param name="fechaNacimiento">fecha de nacimiento del usuario</param>
        /// <param name="correo">correo del usuario</param>
        /// <param name="genero">genero del usuario</param>   
        /// <param name="password">password del usuario</param>
        public void AgregarUsuario(string nombreUsuario, string nombre, string apellido, 
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


        /// <summary>
        /// Iniciar sesion en el sistema con el correo verificando en la bd los datos
        /// </summary>
        /// <param name="correo">correo del usuario</param>
        /// <param name="password">password del usuario</param>
        public Usuario IniciarSesionCorreo(string correo, string password)
        {

            Usuario _usuario = new Usuario();
            _database.Conectar();

            _database.StoredProcedure("IniciarSesionCorreo(@correo, @password)");

            
            _database.AgregarParametro("correo", correo);
            _database.AgregarParametro("password", password);

            _database.EjecutarReader();
            _usuario.Id = _database.GetInt(0, 0);
            _usuario.EsAdmin = _database.GetBool(0, 1);


            return _usuario;
        }

        /// <summary>
        /// Iniciar sesion en el sistema con el nombre de usuario verificando en la bd los datos
        /// </summary>
        /// <param name="nombreUsuario">nombre del usuario</param>
        /// <param name="password">password del usuario</param>
        public Usuario IniciarSesionUsuario(string nombreUsuario, string password)
        {
            Usuario _usuario = new Usuario();
            _database.Conectar();

            _database.StoredProcedure("IniciarSesionUsuario(@nombreUsuario, @password)");


            _database.AgregarParametro("nombreUsuario", nombreUsuario);
            _database.AgregarParametro("password", password);

            _database.EjecutarReader();
            _usuario.Id = _database.GetInt(0, 0);
            _usuario.EsAdmin = _database.GetBool(0, 1);


            return _usuario;
        }


        /// <summary>
        /// cambia la contraseña del usuario en la bd
        /// </summary>
        /// <param name="token">codigo de recuperacion del usuario</param>
        /// <param name="correo">correo del usuario</param>
        /// <param name="password">password del usuario</param>
        public void CambiarPassword(string token, string correo, string password)
        {

            _database.Conectar();



            _database.StoredProcedure("CambiarPassword(@token, @correo, @password)");

            _database.AgregarParametro("token", token);
            _database.AgregarParametro("correo", correo);
            _database.AgregarParametro("password", password);

            _database.EjecutarQuery();
        }


        /// <summary>
        /// validar que el usuario y la contraseña coincidan
        /// </summary>
        /// <param name="nombreUsuario">nombre del usuario</param>
        /// <param name="password">password del usuario</param>
        public void ValidarUsuarioPassword(string nombreUsuario, string password)
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


        /// <summary>
        /// validar que el correo y la contraseña coincidan
        /// </summary>
        /// <param name="correo">correo del usuario</param>
        /// <param name="password">password del usuario</param>
        public void ValidarCorreoPassword(string correo, string password)
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


        /// <summary>
        /// validar que el nombre de usuario exista en la bd
        /// </summary>
        /// <param name="nombreUsuario">nombre del usuario</param>
        public void ValidarNombreUsuario(string nombreUsuario)
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


        /// <summary>
        /// validar que el nombre de usuario no exista en la bd
        /// </summary>
        /// <param name="nombreUsuario">nombre del usuario</param>
        public void ValidarNombreUsuarioNoExiste(string nombreUsuario)
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


        /// <summary>
        /// validar que el correo de usuario exista en la bd
        /// </summary>
        /// <param name="correo">correo del usuario</param>
        public void ValidarCorreo(string correo)
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


        /// <summary>
        /// validar que el correo de usuario no exista en la bd
        /// </summary>
        /// <param name="correo">correo del usuario</param>
        public void ValidarCorreoNoExiste(string correo)
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


        /// <summary>
        /// validar que el usuario se encuentre activo
        /// </summary>
        /// <param name="nombreUsuario">nombre del usuario</param>
        public void ValidarUsuarioActivo(string nombreUsuario)
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


        /// <summary>
        /// validar que el usuario se encuentre activo
        /// </summary>
        /// <param name="correo">correo del usuario</param>
        public void ValidarCorreoActivo(string correo)
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



        /// <summary>
        /// validar que el codigo de recuperacion de contraseña coincida 
        /// </summary>
        /// <param name="nombreUsuario">nombre del usuario</param>
        public void ValidarToken(string token)
        {
            int _contador; //contador de filas retornadas por la bd
            _database.Conectar();

            _database.StoredProcedure("ConsultarToken(@token)");

            _database.AgregarParametro("token", token);

            _database.EjecutarReader();

            _contador = _database.GetInt(0, 0);

            if (_contador < 1)
                throw new CodigoNoCoincideException(token);
        
        }
    }
}
