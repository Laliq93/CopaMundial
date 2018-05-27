using NUnit.Framework;
using WebAPI.Models.Excepciones;
using WebAPI.Models;
using WebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiPruebas.M10
{
    [TestFixture]
    public class M10_PruebaUnitaria
    {
        M10_UsuarioController _controller;
        Usuario _usuario;

       [SetUp]
        public void Init()
        {
            _controller = new M10_UsuarioController();
        }

        [Test]
        public void GetUsuarioTest()
        {
            int IdEsperado = 2;

            _usuario = _controller.GetUsuario(IdEsperado);

            Assert.AreEqual(IdEsperado, _usuario.Id);
        }

        [Test]
        public void EditarPerfilUsuarioTest()
        {
            Usuario _usuarioAnterior = null;

            _usuarioAnterior = _controller.GetUsuario(2);
            _usuarioAnterior.Nombre = "Pepito";
            _usuarioAnterior.Apellido = "Perez";
            _usuarioAnterior.FechaNacimiento = "10-10-1995";
            _usuarioAnterior.FotoPath = "C://Felix";
            _usuarioAnterior.Genero = 'M';


            _controller.EditarPerfil(_usuarioAnterior);

            _usuario = _controller.GetUsuario(2);

            Assert.AreEqual(_usuarioAnterior.Nombre, _usuario.Nombre);
            Assert.AreEqual(_usuarioAnterior.FechaNacimiento, _usuario.FechaNacimiento);
            Assert.AreEqual(_usuarioAnterior.Apellido, _usuario.Apellido);
            Assert.AreEqual(_usuarioAnterior.Genero, _usuario.Genero);
            Assert.AreEqual(_usuarioAnterior.FotoPath, _usuario.FotoPath);
        }

        [Test]
        public void ExceptionVerificarCorreoExisteTest()
        {
            _usuario = _controller.GetUsuario(2);

            Assert.Throws<CorreoEnUsoException>(() => _controller.VerificarCorreoExiste(_usuario));
        }

        [Test]
        public void ExceptionVerificarClaveValida()
        {
            _usuario = _controller.GetUsuario(2);
            _usuario.Password = "ClaveDiferenteExistenteEnLaDb"; //Clave diferente a la actual del usuario.
            Assert.Throws<ClaveInvalidaException>(() => _controller.VerificarClaveUsuario(_usuario));
        }

        [Test]
        public void VerificarCorreoExisteTest()
        {
            _usuario = _controller.GetUsuario(2);
            _usuario.Correo = "WilmerNoSabeProgramar@gmail.com"; //Correo valido (no registrado en la DB)
            Assert.DoesNotThrow(() => _controller.VerificarCorreoExiste(_usuario));
        }

        [Test]
        public void EditarClaveUsuarioTest()
        {
            string clave_vieja;
            string clave_nueva = "wilmernosabeprogramar"; //Esta clave debe ser nueva por cada test.

            _usuario = _controller.GetUsuario(2);
            clave_vieja = _usuario.Password;

            _usuario.Password = clave_nueva;

            _controller.EditarPassword(_usuario);

            _usuario = _controller.GetUsuario(2);

            Assert.AreNotEqual(clave_vieja, _usuario.Password);


        }

        [Test]
        public void EditarCorreoUsuarioTest()
        {
            string correo_viejo;
            string correo_nuevo = "Felix_@hotmail.es"; //Este correo debe ser nuevo por cada Test

            _usuario = _controller.GetUsuario(2);
            correo_viejo = _usuario.Correo;

            _usuario.Correo = correo_nuevo;

            _controller.EditarCorreo(_usuario);

            _usuario = _controller.GetUsuario(2);

            Assert.AreNotEqual(correo_viejo, _usuario.Correo);


        }


        [Test]
        public void VerificarClaveValidaTest()
        {
            _usuario = _controller.GetUsuario(2);

            _usuario.Password = "lol123";

            _controller.EditarPassword(_usuario); //Se guarda la nueva clave y luego se compara en el "VerificarClaveUsuario"

            Assert.DoesNotThrow(() => _controller.VerificarClaveUsuario(_usuario));
        }

        [Test]
        public void UsuarioNullExceptionEditarClave()
        {
            Assert.Throws<UsuarioNullException>(() => _controller.EditarPassword(null));
        }

        [Test]
        public void UsuarioNullExceptionVerificarClave()
        {
            _usuario = null;

            Assert.Throws<UsuarioNullException>(() => _controller.VerificarClaveUsuario(null));
        }

        [Test]
        public void UsuarioNullExceptionVerificarCorreo()
        {
            _usuario = null;

            Assert.Throws<UsuarioNullException>(() => _controller.VerificarCorreoExiste(null));
        }

        [Test]
        public void UsuarioNullExceptionEditarCorreo()
        {
            _usuario = null;

            Assert.Throws<UsuarioNullException>(() => _controller.EditarCorreo(null));
        }

        [Test]
        public void UsuarioNoExisteExceptionGetUsuario()
        {
            Assert.Throws<UsuarioNoExisteException>(() => _controller.GetUsuario(-1));
        }

        [TearDown]
        public void End()
        {
            _usuario = null;
            _controller = null;
        }

    }
}
