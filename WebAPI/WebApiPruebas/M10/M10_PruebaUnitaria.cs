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

        [TearDown]
        public void End()
        {
            _usuario = null;
            _controller = null;
        }

    }
}
