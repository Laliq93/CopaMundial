using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WebAPI.Models.Excepciones;
using WebAPI.Models;
using WebAPI.Controllers;
using System.Net;

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

            _usuarioprueba.Id = 355;
            _usuarioprueba.NombreUsuario = "alefernandez";
            _usuarioprueba.Nombre = "Alejandro";
            _usuarioprueba.Apellido = "Fernandez";
            _usuarioprueba.FechaNacimiento = "14/09/1993";
            _usuarioprueba.Correo = "pedropaff7@gmail.com";
            _usuarioprueba.Genero = 'M';
            _usuarioprueba.EsAdmin = false;
            _usuarioprueba.Password = "ale12345";
      
        }
        [Test]
        public void AgregarUsuarioTest()
        {
           //valida que el usuario que se esta ingresando, exista en la bd
            _pruebacontroller.AgregarUsuario("alefernandez","Alejandro","Fernandez","14/09/1993","pedropaff7@gmail.com",'M',"ale12345");
            _pruebacontroller.ValidarNombreUsuario(_usuarioprueba.NombreUsuario);

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
            _pruebacontroller.AgregarUsuario("alefernandez", "Alejandro", "Fernandez", "14/09/1993", "pedropaff7@gmail.com", 'M', "ale12345");
            Assert.AreEqual(HttpStatusCode.OK, _pruebacontroller.RecuperarClave(_usuarioprueba));
            //valido que envia el correo para recuperar la contrasena
        }

        [Test]
        public void IniciarSesionTest()
        {
            _pruebacontroller.AgregarUsuario("alefernandez", "Alejandro", "Fernandez", "14/09/1993", "pedropaff7@gmail.com", 'M', "ale12345");
            Assert.AreEqual(HttpStatusCode.OK, _pruebacontroller.IniciarSesionUsuario(_usuarioprueba));
        }

        [Test]
        public void IniciarSesionCorreoTest()
        {
            _pruebacontroller.AgregarUsuario("alefernandez", "Alejandro", "Fernandez", "14/09/1993", "pedropaff7@gmail.com", 'M', "ale12345");
            Assert.AreEqual(HttpStatusCode.OK, _pruebacontroller.IniciarSesionCorreo(_usuarioprueba));
        }

        [Test]
        public void CorreoExistenteExceptionTest()
        {
         //inserto a un usuario y luego cambio el usuario para que sale a la excepcion de que el correo existe
            _pruebacontroller.AgregarUsuario("alefernandez", "Alejandro", "Fernandez", "14/09/1993", "pedropaff7@gmail.com", 'M', "ale12345");
            _usuarioprueba.NombreUsuario = "probando123";
          Assert.Throws<CorreoExistenteException>(() => _pruebacontroller.RegistrarUsuario(_usuarioprueba));
        }

        [Test]
        public void NombreUsuarioExistenteExceptionTest()
        {
         //inserto a la persona, y le cambia el correo, pero el nombre del usuario ya existe 
           _pruebacontroller.AgregarUsuario("alefernandez", "Alejandro", "Fernandez", "14/09/1993", "pedropaff7@gmail.com", 'M', "ale12345");
            _usuarioprueba.Correo = "usuarioprueba@gmail.com";
         Assert.Throws<NombreUsuarioExistenteException>(() => _pruebacontroller.RegistrarUsuario(_usuarioprueba));
        }

        [Test]
        public void NombreUsuarioNoExisteExceptionTest()
        {
         //inicio sesion con el nombre de un usuario que no exista
            _usuarioprueba = null;
          Assert.Throws<NombreUsuarioNoExisteException>(() => _pruebacontroller.IniciarSesionUsuario(_usuarioprueba));
        }

        [Test]
        public void UsuarioInactivoExceptionTest()
        {
            //inicio sesion con el nombre de un usuario que no exista
            _usuarioprueba.Activo = false;
             Assert.Throws<UsuarioInactivoException>(() => _pruebacontroller.IniciarSesionUsuario(_usuarioprueba));
        }

        [Test]
        
        public void ClaveUsuarioNoCoincideExceptionExceptionTest()
        {
            //la clave del usuario no debe coincidir 
            _pruebacontroller.AgregarUsuario("alefernandez", "Alejandro", "Fernandez", "14/09/1993", "pedropaff7@gmail.com", 'M', "ale12345");
            Assert.Throws<ClaveUsuarioNoCoincideException>(() => _pruebacontroller.ValidarUsuarioPassword("alefernandez", "estanoeslaquees"));
        }

        [Test]
        public void CorreoNoExisteExceptionTest()
        {
         //verifica que el correo del usuario no exista
            _usuarioprueba = null;
          Assert.Throws<CorreoNoExisteException>(() => _pruebacontroller.IniciarSesionCorreo(_usuarioprueba));
        }

        [Test]
        public void ClaveCorreoNoCoincideExceptionExceptionTest()
        {
         //inicio sesion con el nombre de un usuario que no exista
            _pruebacontroller.AgregarUsuario("alefernandez", "Alejandro", "Fernandez", "14/09/1993", "pedropaff7@gmail.com", 'M', "ale12345");
            _usuarioprueba.Password = "estanoeslaquees";
          Assert.Throws<ClaveCorreoNoCoincideException>(() => _pruebacontroller.IniciarSesionCorreo(_usuarioprueba));
        }

        [Test]
        public void RecuperarClaveCorreoNoexisteExceptionTest()
        {
            //verifico que el correo no exista para que caiga en la excepcion
            _usuarioprueba = null;
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
