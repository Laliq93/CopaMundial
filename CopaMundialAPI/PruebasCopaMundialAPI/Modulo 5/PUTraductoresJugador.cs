using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Comun.Excepciones;
using CopaMundialAPI.Servicios.DTO.Jugadores;
using CopaMundialAPI.Servicios.Fabrica;
using CopaMundialAPI.Servicios.Traductores.Fabrica;
using CopaMundialAPI.Servicios.Traductores.Jugadores;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasCopaMundialAPI.Modulo_5
{
    [TestFixture]
    class PUTraductoresJugador
    {
        DTOJugador _dtoJugador;
        DTOJugadorId _dtoJugadorId;
        DTOObtenerJugadores _dtoObtenerJugadores;

        Jugador _jugador;

        TraductorJugador _traductorJugador;
        TraductorJugadorId _traductorJugadorId;
        TraductorObtenerJugadores _traductorObtenerJugadores;

        [SetUp]
        public void SetUp()
        {
            _jugador = FabricaEntidades.CrearJugador();
            _jugador.Id = 98;
        }

        [Test]
        public void TraducirJugadorTest()
        {
            Jugador _jugadorEsperado = FabricaEntidades.CrearJugador();

            _jugadorEsperado.Nombre = "Sabina";
            _jugadorEsperado.Apellido = "Quiroga";
            _jugadorEsperado.FechaNacimiento = "01-12-1992";
            _jugadorEsperado.LugarNacimiento = "Venezuela";
            _jugadorEsperado.Peso = 51;
            _jugadorEsperado.Altura = 1.61M;
            _jugadorEsperado.Posicion = "DELANTERO";
            _jugadorEsperado.Numero = 8;
            _jugadorEsperado.Equipo.Pais = "Colombia";

            _dtoJugador = FabricaDTO.CrearDTOJugador();

            _dtoJugador.Nombre = "Sabina";
            _dtoJugador.Apellido = "Quiroga";
            _dtoJugador.FechaNacimiento = "01-12-1992";
            _dtoJugador.LugarNacimiento = "Venezuela";
            _dtoJugador.Peso = 51;
            _dtoJugador.Altura = 1.61M;
            _dtoJugador.Posicion = "DELANTERO";
            _dtoJugador.Numero = 8;
            _dtoJugador.Equipo = "Colombia";

            _traductorJugador = FabricaTraductor.CrearTraductorJugador();

            _jugador = _traductorJugador.CrearEntidad(_dtoJugador) as Jugador;

            Assert.AreEqual(_jugadorEsperado.Nombre, _jugador.Nombre);
            Assert.AreEqual(_jugadorEsperado.Apellido, _jugador.Apellido);
            Assert.AreEqual(_jugadorEsperado.FechaNacimiento, _jugador.FechaNacimiento);
            Assert.AreEqual(_jugadorEsperado.LugarNacimiento, _jugador.LugarNacimiento);
            Assert.AreEqual(_jugadorEsperado.Peso, _jugador.Peso);
            Assert.AreEqual(_jugadorEsperado.Altura, _jugador.Altura);
            Assert.AreEqual(_jugadorEsperado.Posicion, _jugador.Posicion);
            Assert.AreEqual(_jugadorEsperado.Numero, _jugador.Numero);
            Assert.AreEqual(_jugadorEsperado.Equipo, _jugador.Equipo);
        }

        [Test]
        public void TraducirDTOJugadorTest()
        {
            DTOJugador _dtoEsperado = FabricaDTO.CrearDTOJugador();

            _dtoEsperado.Nombre = "Sabina";
            _dtoEsperado.Apellido = "Quiroga";
            _dtoEsperado.FechaNacimiento = "01-12-1992";
            _dtoEsperado.LugarNacimiento = "Venezuela";
            _dtoEsperado.Peso = 51;
            _dtoEsperado.Altura = 1.61M;
            _dtoEsperado.Posicion = "DELANTERO";
            _dtoEsperado.Numero = 8;
            _dtoEsperado.Equipo = "Colombia";

            _jugador = FabricaEntidades.CrearJugador();

            _jugador.Nombre = "Sabina";
            _jugador.Apellido = "Quiroga";
            _jugador.FechaNacimiento = "01-12-1992";
            _jugador.LugarNacimiento = "Venezuela";
            _jugador.Peso = 51;
            _jugador.Altura = 1.61M;
            _jugador.Posicion = "DELANTERO";
            _jugador.Numero = 8;
            _jugador.Equipo.Pais = "Colombia";

            _traductorJugador = FabricaTraductor.CrearTraductorJugador();

            _dtoJugador = _traductorJugador.CrearDto(_jugador);

            Assert.AreEqual(_dtoEsperado.Nombre, _dtoJugador.Nombre);
            Assert.AreEqual(_dtoEsperado.Apellido, _dtoJugador.Apellido);
            Assert.AreEqual(_dtoEsperado.FechaNacimiento, _dtoJugador.FechaNacimiento);
            Assert.AreEqual(_dtoEsperado.LugarNacimiento, _dtoJugador.LugarNacimiento);
            Assert.AreEqual(_dtoEsperado.Peso, _dtoJugador.Peso);
            Assert.AreEqual(_dtoEsperado.Altura, _dtoJugador.Altura);
            Assert.AreEqual(_dtoEsperado.Posicion, _dtoJugador.Posicion);
            Assert.AreEqual(_dtoEsperado.Numero, _dtoJugador.Numero);
            Assert.AreEqual(_dtoEsperado.Equipo, _dtoJugador.Equipo);

        }

        [Test]
        public void TraducirJugadorIdTest()
        {
            Jugador _jugadorEsperado = FabricaEntidades.CrearJugador();

            _jugadorEsperado.Nombre = "Sabina";
            _jugadorEsperado.Apellido = "Quiroga";
            _jugadorEsperado.FechaNacimiento = "01-12-1992";
            _jugadorEsperado.LugarNacimiento = "Venezuela";
            _jugadorEsperado.Peso = 51;
            _jugadorEsperado.Altura = 1.61M;
            _jugadorEsperado.Posicion = "DELANTERO";
            _jugadorEsperado.Numero = 8;
            _jugadorEsperado.Equipo.Pais = "Colombia";

            _dtoJugadorId = FabricaDTO.CrearDTOJugadorId();

            _dtoJugadorId.Id = 97;

            _traductorJugadorId = FabricaTraductor.CrearTraductorJugadorId();

            _jugador = _traductorJugadorId.CrearEntidad(_dtoJugadorId) as Jugador;

            Assert.AreEqual(_jugadorEsperado.Id, _jugador.Id);
        }

        [Test]
        public void TraducirDTOJugadorIdTest()
        {
            DTOJugadorId _dtoEsperado = FabricaDTO.CrearDTOJugadorId();

            _dtoEsperado.Id = 96;

            _jugador = FabricaEntidades.CrearJugador();

            _jugador.Id = 96;

            _traductorJugadorId = FabricaTraductor.CrearTraductorJugadorId();

            _dtoJugadorId = _traductorJugadorId.CrearDto(_jugador);

            Assert.AreEqual(_dtoEsperado.Id, _dtoJugadorId.Id);
        }

        [Test]
        public void TraducirObtenerJugadoresTest()
        {
            Jugador _jugadorEsperado = FabricaEntidades.CrearJugador();

            _jugadorEsperado.Id = 95;
            _jugadorEsperado.Nombre = "Sabina";
            _jugadorEsperado.Apellido = "Quiroga";
            _jugadorEsperado.FechaNacimiento = "01-12-1992";
            _jugadorEsperado.LugarNacimiento = "Venezuela";
            _jugadorEsperado.Peso = 51;
            _jugadorEsperado.Altura = 1.61M;
            _jugadorEsperado.Posicion = "DELANTERO";
            _jugadorEsperado.Numero = 8;
            _jugadorEsperado.Equipo.Pais = "Colombia";
            _jugadorEsperado.Capitan = false;

            _dtoObtenerJugadores = FabricaDTO.CrearDTOObtenerJugadores();

            _dtoObtenerJugadores.Id = 95;

            _traductorObtenerJugadores = FabricaTraductor.CrearTraductorObtenerJugadores();

            _jugador = _traductorObtenerJugadores.CrearEntidad(_dtoObtenerJugadores) as Jugador;

            Assert.AreEqual(_jugadorEsperado.Id, _jugador.Id);
        }

        [Test]
        public void TraducirDTOObtenerJugadoresTest()
        {
            DTOObtenerJugadores _dtoEsperado = FabricaDTO.CrearDTOObtenerJugadores();

            _dtoEsperado.Id = 94;

            _jugador = FabricaEntidades.CrearJugador();

            _jugador.Id = 94;

            _traductorObtenerJugadores = FabricaTraductor.CrearTraductorObtenerJugadores();

            _dtoObtenerJugadores = _traductorObtenerJugadores.CrearDto(_jugador);

            Assert.AreEqual(_dtoEsperado.Id, _dtoObtenerJugadores.Id);
        }

        [Test]
        public void TraductorDTOJugadorExceptionTest()
        {
            _traductorJugador = FabricaTraductor.CrearTraductorJugador();

            Assert.Throws<ObjetoNullException>(() => _traductorJugador.CrearEntidad(null));
        }

        [Test]
        public void TraductorDTOJugadorIdExceptionTest()
        {
            _traductorJugadorId = FabricaTraductor.CrearTraductorJugadorId();

            Assert.Throws<ObjetoNullException>(() => _traductorJugadorId.CrearEntidad(null));
        }

        [Test]
        public void TraductorDTOObtenerJugadoresExceptionTest()
        {
            _traductorObtenerJugadores = FabricaTraductor.CrearTraductorObtenerJugadores();

            Assert.Throws<ObjetoNullException>(() => _traductorObtenerJugadores.CrearEntidad(null));
        }

        [TearDown]
        public void Clean()
        {
            _dtoJugador = null;
            _dtoJugadorId = null;
            _dtoObtenerJugadores = null;

            _jugador = null;

            _traductorJugador = null;
            _traductorJugadorId = null;
            _traductorObtenerJugadores = null;
        }

    }
}
