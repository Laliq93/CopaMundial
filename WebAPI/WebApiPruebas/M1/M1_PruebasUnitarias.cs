using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WebAPI.Models.Excepciones;
using WebAPI.Models;
using WebAPI.Controllers;


namespace WebApiPruebas.M1
{
   [TestFixture]
    public class M1_PruebasUnitarias
    {
        Usuario _usuarioprueba;
        M1_RegistroLoginRecuperarController _pruebacontroller;

       [SetUp]
        public void Init()
        {
        _pruebacontroller = new M1_RegistroLoginRecuperarController();
        _usuarioprueba = new Usuario();
        _usuarioprueba._id = 355;
        _usuarioprueba._nombreUsuario = "alefernandez";
        _usuarioprueba._nombre = "Alejandro";
        _usuarioprueba._apellido = "Fernandez";
        _usuarioprueba._fechaNacimiento = "14/09/1993";
        _usuarioprueba._correo = "pedropaff7@gmail.com";
        _usuarioprueba._genero = "M";
        _usuarioprueba._esAdmin = "false";
        _usuarioprueba._password "ale12345";
      
        }
        [Test]
        public void AgregarUsuarioTest()
        {
           //valida que el usuario que se esta ingresando, exista en la bd
            _pruebacontroller.AgregarUsuario(_usuarioprueba);
            _pruebacontroller.ValidarNombreUsuario(_usuarioprueba._nombreUsuario);

        }
        [Test]
        public void RegistrarUsuarioTest()
        {
        // valida que se pudo registrar al usuario
        // _pruebacontroller.ValidarNombreUsuario(_usuarioprueba._nombreUsuario);
        Assert.AreEqual(HttpStatusCode.OK, _pruebacontroller.RegistrarUsuario(_usuarioprueba));
        }

        [Test]
        public void CambiarClave()
        {
            //_pruebacontroller.AgregarUsuario(_usuarioprueba);
            //Assert.AreEqual(HttpStatusCode.OK, _pruebacontroller.CambiarClave(_usuarioprueba);
            //valido que envia el correo para recuperar la contrasena
        }

        [Test]
        public void RecuperarClave()
        {
            _pruebacontroller.AgregarUsuario(_usuarioprueba);
            Assert.AreEqual(HttpStatusCode.OK, _pruebacontroller.RecuperarClave(_usuarioprueba));
            //valido que envia el correo para recuperar la contrasena
        }

        [Test]
        public void IniciarSesionTest()
        {
            _pruebacontroller.AgregarUsuario(_usuarioprueba);
            Assert.AreEqual(HttpStatusCode.OK, _pruebacontroller.IniciarSesionUsuario(_usuarioprueba));
        }

        [Test]
        public void IniciarSesionCorreoTest()
        {
            _pruebacontroller.AgregarUsuario(_usuarioprueba);
            Assert.AreEqual(HttpStatusCode.OK, _pruebacontroller.IniciarSesionCorreo(_usuarioprueba));
        }

        [Test]
        public void CorreoExistenteExceptionTest()
        {
         //inserto a un usuario y luego cambio el usuario para que sale a la excepcion de que el correo existe
          _pruebacontroller.AgregarUsuario(_usuarioprueba);
          _usuarioprueba._nombreUsuario = "probando123";
          //_usuarioprueba._correo = "usuarioprueba@gmail.com";
          Assert.Throws<CorreoExistenteException>(() => _pruebacontroller.RegistrarUsuario(_usuarioprueba));
        }

        [Test]
        public void NombreUsuarioExistenteExceptionTest()
        {
         //inserto a la persona, 
         _pruebacontroller.AgregarUsuario(_usuarioprueba);
        // _usuarioprueba._nombreUsuario = "probando123";
         _usuarioprueba._correo = "usuarioprueba@gmail.com";
         Assert.Throws<NombreUsuarioExistenteException>(() => _pruebacontroller.RegistrarUsuario(_usuarioprueba));
        }

        [Test]
        public void NombreUsuarioNoExisteExceptionTest()
        {
         //inicio sesion con el nombre de un usuario que no exista
          _pruebacontroller.AgregarUsuario(_usuarioprueba);
          _usuarioprueba._correo = "usuarioprueba@gmail.com";
          _usuarioprueba._nombreUsuario = "probando123";
          Assert.Throws<NomnbreUsuarioNoExisteException>(() => _pruebacontroller.IniciarSesionUsuario(_usuarioprueba));
        }

        [Test]
        public void UsuarioInactivoExceptionTest()
        {
         //inicio sesion con el nombre de un usuario que no exista
         _pruebacontroller.AgregarUsuario(_usuarioprueba);
         _usuarioprueba._activo = "false";
          //_usuarioprueba._nombreUsuario = "probando123";
          Assert.Throws<UsuarioInactivoException>(() => _pruebacontroller.IniciarSesionUsuario(_usuarioprueba));
        }
        [Test]
        
        public void ClaveUsuarioNoCoincideExceptionExceptionTest()
        {
         //inicio sesion con el nombre de un usuario que no exista
          _pruebacontroller.AgregarUsuario(_usuarioprueba);
          _usuarioprueba._password = "estanoeslaquees";
         // _usuarioprueba._nombreUsuario = "probando123";
          Assert.Throws<ClaveUsuarioNoCoincideException>(() => _pruebacontroller.IniciarSesionUsuario(_usuarioprueba));
        }

        [Test]
        public void CorreoNoExisteExceptionTest()
        {
         //inserto al usuario, luego se cambia el correo que no exista para que caiga en la excepcion
          _pruebacontroller.AgregarUsuario(_usuarioprueba);
          _usuarioprueba._correo = "usuarioprueba@gmail.com";
          _usuarioprueba._nombreUsuario = "probando123";
          Assert.Throws<CorreoNoExisteException>(() => _pruebacontroller.IniciarSesionCorreo(_usuarioprueba));
        }

        [Test]
        public void ClaveCorreoNoCoincideExceptionExceptionTest()
        {
         //inicio sesion con el nombre de un usuario que no exista
          _pruebacontroller.AgregarUsuario(_usuarioprueba);
          _usuarioprueba._password = "estanoeslaquees";
         // _usuarioprueba._nombreUsuario = "probando123";
          Assert.Throws<ClaveCorreoNoCoincideException>(() => _pruebacontroller.IniciarSesionCorreo(_usuarioprueba));
        }

        [Test]
        public void RecuperarClaveCorreoNoexisteExceptionTest()
        {
         //inserto al usuario, luego se cambia el correo que no exista para que caiga en la excepcion
          _pruebacontroller.AgregarUsuario(_usuarioprueba);
          _usuarioprueba._correo = "usuarioprueba@gmail.com";
         // _usuarioprueba._nombreUsuario = "probando123";
          Assert.Throws<CorreoNoExisteException>(() => _pruebacontroller.RecuperarClave(_usuarioprueba));
        }

        [TearDown]
        public void End()
        {
            _pruebacontroller = null;
            _usuarioprueba = null;
           
        }

    }
}
