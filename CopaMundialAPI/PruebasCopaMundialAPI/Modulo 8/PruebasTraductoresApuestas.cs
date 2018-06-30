using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Excepciones;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Servicios.DTO.Apuestas;
using CopaMundialAPI.Servicios.Traductores.Apuestas;
using CopaMundialAPI.Servicios.Fabrica;
using CopaMundialAPI.Servicios.Traductores.Fabrica;

namespace PruebasCopaMundialAPI.Modulo_8
{
    [TestFixture]
    public class PruebasTraductoresApuestas
    {
        DTOApuestaVOF _dtoApuestaVOF;
        DTOApuestaJugador _dtoApuestaJugador;
        DTOApuestaEquipo _dtoApuestaEquipo;
        DTOApuestaCantidad _dtoApuestaCantidad;

        ApuestaVoF _apuestaVoF;
        ApuestaCantidad _apuestaCantidad;
        ApuestaEquipo _apuestaEquipo;
        ApuestaJugador _apuestaJugador;

        TraductorApuestaCantidad _traductorApuestaCantidad;
        TraductorApuestaJugador _traductorApuestaJugador;
        TraductorApuestaEquipo _traductorApuestaEquipo;
        TraductorApuestaVOF _traductorApuestaVoF;


        LogroVoF _logroVoF;
        LogroCantidad _logroCantidad;
        LogroJugador _logroJugador;
        LogroEquipo _logroEquipo;

        Usuario _apostador;

        Equipos _equiposEstaticos;

        [SetUp]
        public void Init()
        {
            _apostador = FabricaEntidades.CrearUsuarioVacio();
            _apostador.Id = 1;

            _logroVoF = FabricaEntidades.CrearLogroVoF();
            _logroVoF.Id = 1;

            _logroCantidad = FabricaEntidades.CrearLogroCantidad();
            _logroCantidad.Id = 1;

            _logroEquipo = FabricaEntidades.CrearLogroEquipo();
            _logroEquipo.Id = 1;

            _logroJugador = FabricaEntidades.CrearLogroJugador();
            _logroJugador.Id = 1;
        }

        [Test]
        public void TraducirApuestaVoFTest()
        {
            ApuestaVoF _apuestaEsperada = FabricaEntidades.CrearApuestaVoF();

            _apuestaEsperada.Respuesta = false;
            _apuestaEsperada.Logro = _logroVoF;
            _apuestaEsperada.Usuario = _apostador;


            _dtoApuestaVOF = FabricaDTO.CrearDtoApuestaVOF();

            _dtoApuestaVOF.IdLogro = 1;
            _dtoApuestaVOF.IdUsuario = 1;
            _dtoApuestaVOF.ApuestaUsuario = false;


            _traductorApuestaVoF = FabricaTraductor.CrearTraductorApuestaVoF();

            _apuestaVoF = _traductorApuestaVoF.CrearEntidad(_dtoApuestaVOF) as ApuestaVoF;

            Assert.AreEqual(_apuestaEsperada.Logro.Id, _apuestaVoF.Logro.Id);
            Assert.AreEqual(_apuestaEsperada.Usuario.Id, _apuestaVoF.Usuario.Id);
            Assert.AreEqual(_apuestaEsperada.Respuesta, _apuestaVoF.Respuesta);
            
        }

        [Test]
        public void TraducirDTOApuestaVoFTest()
        {
            DTOApuestaVOF _dtoEsperado = FabricaDTO.CrearDtoApuestaVOF();

            _dtoEsperado.IdLogro = 1;
            _dtoEsperado.IdUsuario = 1;
            _dtoEsperado.ApuestaUsuario = true;
            _dtoEsperado.Estado = "en curso";


            _apuestaVoF = FabricaEntidades.CrearApuestaVoF();
            
            _apuestaVoF.Logro = _logroVoF as LogroVoF;
            _apuestaVoF.Usuario = _apostador;
            _apuestaVoF.Respuesta = true;
            _apuestaVoF.Estado = "en curso";

            _traductorApuestaVoF = FabricaTraductor.CrearTraductorApuestaVoF();

            _dtoApuestaVOF = _traductorApuestaVoF.CrearDto(_apuestaVoF);

            Assert.AreEqual(_dtoEsperado.IdLogro, _dtoApuestaVOF.IdLogro);
            Assert.AreEqual(_dtoEsperado.IdUsuario, _dtoApuestaVOF.IdUsuario);
            Assert.AreEqual(_dtoEsperado.ApuestaUsuario, _dtoApuestaVOF.ApuestaUsuario);
            Assert.AreEqual(_dtoEsperado.Estado, _dtoApuestaVOF.Estado);

        }

        [Test]
        public void TraducirApuestaCantidadTest()
        {
            ApuestaCantidad _apuestaEsperada = FabricaEntidades.CrearApuestaCantidad();

            _apuestaEsperada.Respuesta = 1;
            _apuestaEsperada.Logro = _logroCantidad;
            _apuestaEsperada.Usuario = _apostador;


            _dtoApuestaCantidad = FabricaDTO.CrearDtoApuestaCantidad();

            _dtoApuestaCantidad.IdLogro = 1;
            _dtoApuestaCantidad.IdUsuario = 1;
            _dtoApuestaCantidad.ApuestaUsuario = 1;


            _traductorApuestaCantidad = FabricaTraductor.CrearTraductorApuestaCantidad();

            _apuestaCantidad = _traductorApuestaCantidad.CrearEntidad(_dtoApuestaCantidad) as ApuestaCantidad;

            Assert.AreEqual(_apuestaEsperada.Logro.Id, _apuestaCantidad.Logro.Id);
            Assert.AreEqual(_apuestaEsperada.Usuario.Id, _apuestaCantidad.Usuario.Id);
            Assert.AreEqual(_apuestaEsperada.Respuesta, _apuestaCantidad.Respuesta);

        }

        [Test]
        public void TraducirDTOApuestaCantidadTest()
        {
            DTOApuestaCantidad _dtoEsperado = FabricaDTO.CrearDtoApuestaCantidad();

            _dtoEsperado.IdLogro = 1;
            _dtoEsperado.IdUsuario = 1;
            _dtoEsperado.ApuestaUsuario = 1;
            _dtoEsperado.Estado = "en curso";


            _apuestaCantidad = FabricaEntidades.CrearApuestaCantidad();

            _apuestaCantidad.Logro = _logroCantidad as LogroCantidad;
            _apuestaCantidad.Usuario = _apostador;
            _apuestaCantidad.Respuesta = 1;
            _apuestaCantidad.Estado = "en curso";

            _traductorApuestaCantidad = FabricaTraductor.CrearTraductorApuestaCantidad();

            _dtoApuestaCantidad = _traductorApuestaCantidad.CrearDto(_apuestaCantidad);

            Assert.AreEqual(_dtoEsperado.IdLogro, _dtoApuestaCantidad.IdLogro);
            Assert.AreEqual(_dtoEsperado.IdUsuario, _dtoApuestaCantidad.IdUsuario);
            Assert.AreEqual(_dtoEsperado.ApuestaUsuario, _dtoApuestaCantidad.ApuestaUsuario);
            Assert.AreEqual(_dtoEsperado.Estado, _dtoApuestaCantidad.Estado);

        }

        [Test]
        public void TraducirApuestaEquipoTest()
        {
            ApuestaEquipo _apuestaEsperada = FabricaEntidades.CrearApuestaEquipo();

            _equiposEstaticos = new Equipos();

            _apuestaEsperada.Respuesta = _equiposEstaticos.GetEquipo(1);
            _apuestaEsperada.Logro = _logroEquipo;
            _apuestaEsperada.Usuario = _apostador;


            _dtoApuestaEquipo = FabricaDTO.CrearDTOApuestaEquipo();

            _dtoApuestaEquipo.IdLogro = 1;
            _dtoApuestaEquipo.IdUsuario = 1;
            _dtoApuestaEquipo.IdEquipo = 1;

            _traductorApuestaEquipo = FabricaTraductor.CrearTraductorApuestaEquipo();

            _apuestaEquipo = _traductorApuestaEquipo.CrearEntidad(_dtoApuestaEquipo) as ApuestaEquipo;

            Assert.AreEqual(_apuestaEsperada.Logro.Id, _apuestaEquipo.Logro.Id);
            Assert.AreEqual(_apuestaEsperada.Usuario.Id, _apuestaEquipo.Usuario.Id);
            Assert.AreEqual(_apuestaEsperada.Respuesta.Id, _apuestaEquipo.Respuesta.Id);

        }

        [Test]
        public void TraducirDTOApuestaEquipoTest()
        {
            _equiposEstaticos = new Equipos();

            DTOApuestaEquipo _dtoEsperado = FabricaDTO.CrearDTOApuestaEquipo();

            _dtoEsperado.IdLogro = 1;
            _dtoEsperado.IdUsuario = 1;
            _dtoEsperado.IdEquipo = 1;
            _dtoEsperado.Estado = "en curso";


            _apuestaEquipo = FabricaEntidades.CrearApuestaEquipo();

            _apuestaEquipo.Logro = _logroEquipo;
            _apuestaEquipo.Usuario = _apostador;
            _apuestaEquipo.Respuesta = _equiposEstaticos.GetEquipo(1);
            _apuestaEquipo.Estado = "en curso";

            _traductorApuestaEquipo = FabricaTraductor.CrearTraductorApuestaEquipo();

            _dtoApuestaEquipo = _traductorApuestaEquipo.CrearDto(_apuestaEquipo);

            Assert.AreEqual(_dtoEsperado.IdLogro, _dtoApuestaEquipo.IdLogro);
            Assert.AreEqual(_dtoEsperado.IdUsuario, _dtoApuestaEquipo.IdUsuario);
            Assert.AreEqual(_dtoEsperado.IdEquipo, _dtoApuestaEquipo.IdEquipo);
            Assert.AreEqual(_dtoEsperado.Estado, _dtoApuestaEquipo.Estado);


        }

        [Test]
        public void TraducirApuestaJugadorTest()
        {
            ApuestaJugador _apuestaEsperada = FabricaEntidades.CrearApuestaJugador();

            Jugador _jugador = FabricaEntidades.CrearJugador();
            _jugador.Id = 1;

            _apuestaEsperada.Respuesta = _jugador;
            _apuestaEsperada.Logro = _logroJugador;
            _apuestaEsperada.Usuario = _apostador;


            _dtoApuestaJugador = FabricaDTO.CrearDtoApuestaJugador();

            _dtoApuestaJugador.IdLogro = 1;
            _dtoApuestaJugador.IdUsuario = 1;
            _dtoApuestaJugador.IdJugador = 1;

            _traductorApuestaJugador = FabricaTraductor.CrearTraductorApuestaJugador();

            _apuestaJugador = _traductorApuestaJugador.CrearEntidad(_dtoApuestaJugador) as ApuestaJugador;

            Assert.AreEqual(_apuestaEsperada.Logro.Id, _apuestaJugador.Logro.Id);
            Assert.AreEqual(_apuestaEsperada.Usuario.Id, _apuestaJugador.Usuario.Id);
            Assert.AreEqual(_apuestaEsperada.Respuesta.Id, _apuestaJugador.Respuesta.Id);

        }

        [Test]
        public void TraducirDTOApuestaJugadorTest()
        {

            DTOApuestaJugador _dtoEsperado = FabricaDTO.CrearDtoApuestaJugador();
            Jugador _jugador = FabricaEntidades.CrearJugador();

            _jugador.Id = 1;

            _dtoEsperado.IdLogro = 1;
            _dtoEsperado.IdUsuario = 1;
            _dtoEsperado.IdJugador = 1;
            _dtoEsperado.Estado = "en curso";


            _apuestaJugador = FabricaEntidades.CrearApuestaJugador();

            _apuestaJugador.Logro = _logroJugador;
            _apuestaJugador.Usuario = _apostador;
            _apuestaJugador.Respuesta = _jugador;
            _apuestaJugador.Estado = "en curso";

            _traductorApuestaJugador = FabricaTraductor.CrearTraductorApuestaJugador();

            _dtoApuestaJugador = _traductorApuestaJugador.CrearDto(_apuestaJugador);

            Assert.AreEqual(_dtoEsperado.IdLogro, _dtoApuestaJugador.IdLogro);
            Assert.AreEqual(_dtoEsperado.IdUsuario, _dtoApuestaJugador.IdUsuario);
            Assert.AreEqual(_dtoEsperado.IdJugador, _dtoApuestaJugador.IdJugador);
            Assert.AreEqual(_dtoEsperado.Estado, _dtoApuestaJugador.Estado);


        }

        [Test]
        public void TraductorDTOApuestaVOFExceptionTest()
        {
            _traductorApuestaVoF = FabricaTraductor.CrearTraductorApuestaVoF();

            Assert.Throws<ObjetoNullException>(() => _traductorApuestaVoF.CrearEntidad(null));
        }

        [Test]
        public void TraductorDTOApuestaCantidadExceptionTest()
        {
            _traductorApuestaCantidad = FabricaTraductor.CrearTraductorApuestaCantidad();

            Assert.Throws<ObjetoNullException>(() => _traductorApuestaCantidad.CrearEntidad(null));
        }

        [Test]
        public void TraductorDTOApuestaEquipoExceptionTest()
        {
            _traductorApuestaEquipo = FabricaTraductor.CrearTraductorApuestaEquipo();

            Assert.Throws<ObjetoNullException>(() => _traductorApuestaEquipo.CrearEntidad(null));
        }

        [Test]
        public void TraductorDTOApuestaJugadorExceptionTest()
        {
            _traductorApuestaJugador = FabricaTraductor.CrearTraductorApuestaJugador();

            Assert.Throws<ObjetoNullException>(() => _traductorApuestaJugador.CrearEntidad(null));
        }

        [TearDown]
        public void End()
        {
            _dtoApuestaVOF = null;
            _dtoApuestaJugador = null;
            _dtoApuestaEquipo = null;
            _dtoApuestaCantidad = null;

            _apuestaVoF = null;
            _apuestaCantidad = null;
            _apuestaEquipo = null;
            _apuestaJugador = null;

            _traductorApuestaCantidad = null;
            _traductorApuestaJugador = null;
            _traductorApuestaEquipo = null;
            _traductorApuestaVoF = null;


            _logroVoF = null;
            _logroCantidad = null;
            _logroJugador = null;
            _logroEquipo = null;

            _apostador = null;

            _equiposEstaticos = null;
        }
    }
}
