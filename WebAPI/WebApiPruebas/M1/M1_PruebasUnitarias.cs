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
        M1_RegistroLoginRecuperarController _prueba;

       [SetUp]
        public void Init()
        {
            _prueba = new M1_RegistroLoginRecuperarController();
        }

        [Test]
        public void AgregarUsuarioTest()
        {
           //valido que el usuario que estoy ingresando exista
            _nombreusuario2 = "lauraquinones";
            _prueba.AgregarUsuario("lauraquinones","Laura","Quinones","14/09/1993","lvqp.93@gmail.com","F","laliquinones14");
            _prueba.ValidarNombreUsuario(_nombreusuario2);

        }

        [Test]
        public void EnviarCorreoTest()
        {
            //valido que envia el correo para recuperar la contrasena
        }

        [Test]
        public void IniciarSesionTest()
        {
            //valido si el usuario existe y ese es su password
 
        }

        [Test]
        public void ExcepcionUsuarioNoExisteTest()
        {
            //valido que la excepcion que muestra cuando el usuario no existe sea correcta
        }
        [TearDown]
        public void End()
        {
            _prueba = null;
           
        }

    }
}
