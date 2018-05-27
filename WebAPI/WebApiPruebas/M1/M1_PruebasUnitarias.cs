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
     /*   _usuarioprueba = new Usuario
       {
        _nombreUsuario = "alefernandez",
        _nombre = "Alejandro"
        _apellido = "Fernandez",
        _fechaNacimiento = "14/09/1993",
        _correo = "pedropaff7@gmail.com",
        _genero = "M",
        _esAdmin = 0;
        _password "ale12345"
      };
      */
        }
        [Test]
        public void AgregarUsuarioTest()
        {
           //valida que el usuario que se esta ingresando ingresando, exista en la bd
            string _nombreusuario2 = "lauraquinones";
            _pruebacontroller.AgregarUsuario("lauraquinones","Laura","Quinones","14/09/1993","lvqp.93@gmail.com","F","laliquinones14");
            _pruebacontroller.ValidarNombreUsuario(_nombreusuario2);

        }

        [Test]
        public void EnviarCorreoTest()
        {
            //valido que envia el correo para recuperar la contrasena
        }
/* 
        [Test]
        public void IniciarSesionCorreoTest()
        {
            //valido si el usuario existe y ese es su password
            int _idprueba = 55;
            int _id = _prueba.IniciarSesionCorreo("lvqp.93@gmail.com", "laliquinones14");
            Assert.AreEqual(_idprueba,_id);
        }

        [Test]
        public void IniciarSesionUsuarioTest()
        {
            //valido si el usuario existe y ese es su password
            int _idprueba = 55;
            int _id = _prueba.IniciarSesionUsuario("lauraquinones", "laliquinones14");
            Assert.AreEqual(_idprueba,_id);
        }
*/
 [Test]
        public void CorreoExistenteExceptionTest()
        {
            //intento insertar persona con iguales correos
          _pruebacontroller.AgregarUsuario("lauraquinones","Laura","Quinones","14/09/1993","lvqp.93@gmail.com","F","laliquinones14");
          _pruebacontroller.AgregarUsuario("probando123","Laura","Quinones","14/09/1993","lvqp.93@gmail.com","F","laliquinones14");
        }
 
        [Test]
        public void NombreUsuarioExistenteExceptionTest()
        {
            //intento insertar personas con iguales nombres de usuario
          _pruebacontroller.AgregarUsuario("lauraquinones","Laura","Quinones","14/09/1993","lvqp.93@gmail.com","F","laliquinones14");
          _pruebacontroller.AgregarUsuario("lauraquinones","Laura","Quinones","14/09/1993","probando123@gmail.com","F","laliquinones14");
        }
        }
 

        [TearDown]
        public void End()
        {
            _pruebacontroller = null;
           
        }

    }
}
