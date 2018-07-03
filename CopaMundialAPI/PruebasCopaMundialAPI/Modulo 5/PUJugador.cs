using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;
using CopaMundialAPI.Presentacion.Controllers;
using CopaMundialAPI.Servicios.DTO.Jugadores;
using CopaMundialAPI.Servicios.Fabrica;
using NUnit.Framework;
using System;

namespace PruebasCopaMundialAPI.Modulo_5
{
    [TestFixture]
    public class PUJugador
    {
        /*private JugadorController controlador;

        private DTOJugador jugador;*/

        Jugador _jugador;

        DAOJugador _daoJugador;

        [SetUp]
        public void SetUp ()
        {
            _jugador = FabricaEntidades.CrearJugador();

            _jugador.Id = 99; //cambiar este id a conveniencia sobre la BD o hacer insert especifico
            _jugador.Nombre = "Sabina";
            _jugador.Apellido = "Quiroga";
            _jugador.FechaNacimiento = "01-12-1992";
            _jugador.LugarNacimiento = "Rusia";
            _jugador.Peso = 50;
            _jugador.Altura = 1.60M;
            _jugador.Posicion = "PORTERO";
            _jugador.Numero = 15;
            _jugador.Equipo.Pais = "Rusia";

            _daoJugador = FabricaDAO.CrearDAOJugador();
        }

        [Test]
        public void TestAgregarJugador()
        {
            _daoJugador.Agregar(_jugador);
            SPObtenerJugadorId();

            if (_daoJugador.cantidadRegistros > 0)
                Assert.Pass();

            Assert.Fail();

        }

        [Test]
        public void TestDesactivarJugador()
        {
            _daoJugador.DesactivarJugador(_jugador);
            SPObtenerJugadoresInactivo();

            if (_daoJugador.cantidadRegistros > 0)
                Assert.Pass();

            Assert.Fail();

        }

        [Test]
        public void TestActivarJugador()
        {
            _daoJugador.DesactivarJugador(_jugador);
            _daoJugador.ActivarJugador(_jugador);
            SPObtenerJugadoresActivo();

            if (_daoJugador.cantidadRegistros > 0)
                Assert.Pass();

            Assert.Fail();

        }

        [TearDown]
        public void TearDown ()
        {
            _jugador = null;
            _daoJugador = null;
        }

        private void SPObtenerJugadorId()
        {
            _daoJugador.Conectar();

            _daoJugador.StoredProcedure("consultarJugadorId(@idJugador)");

            _daoJugador.AgregarParametro("idJugador", _jugador.Id);
            _daoJugador.EjecutarReader();
        }

        private void SPObtenerJugadores()
        {
            _daoJugador.Conectar();

            _daoJugador.StoredProcedure("consultarJugadores()");

            _daoJugador.EjecutarReader();
        }

        private void SPObtenerJugadoresActivo()
        {
            _daoJugador.Conectar();

            _daoJugador.StoredProcedure("consultarJugadoresActivo()");

            _daoJugador.EjecutarReader();
        }

        private void SPObtenerJugadoresInactivo()
        {
            _daoJugador.Conectar();

            _daoJugador.StoredProcedure("consultarJugadoresInactivo()");

            _daoJugador.EjecutarReader();
        }
    }
}
