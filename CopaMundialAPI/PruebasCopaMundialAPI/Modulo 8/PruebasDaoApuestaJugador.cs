using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Excepciones;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;
using CopaMundialAPI.Comun.Entidades.Fabrica;

namespace PruebasCopaMundialAPI.Modulo_8
{
    [TestFixture]
    public class PruebasDaoApuestaJugador
    {
        Usuario _apostador;

        LogroJugador _logroJugador;

        DAOApuestaJugador _daoApuestaJugador;

        ApuestaJugador _apuestaJugador;

        Jugador _jugador1, _jugador2;


        /// <summary>
        /// Id usuario test: 100, idlogrocantidad test = 100, idlogrojugador test = 101
        /// idlogroequipo test = 102, idlogrovof test = 103, idpartido test = 100, idjugador1 test = 100
        /// idjugador2 test = 101
        /// </summary>
        [SetUp]
        public void Init()
        {
            _apostador = FabricaEntidades.CrearUsuarioVacio();

            _apostador.Id = 100;

            _logroJugador = FabricaEntidades.CrearLogroJugador();

            _logroJugador.Id = 101;

            _jugador1 = FabricaEntidades.CrearJugador();
            _jugador1.Id = 100;

            _jugador2 = FabricaEntidades.CrearJugador();
            _jugador2.Id = 101;

            _apuestaJugador = FabricaEntidades.CrearApuestaJugador();

            _apuestaJugador.Logro = _logroJugador;
            _apuestaJugador.Usuario = _apostador;
            _apuestaJugador.Respuesta = _jugador1;

            _daoApuestaJugador = FabricaDAO.CrearDAOApuestaJugador();

        }

        /// <summary>
        /// Si encuentra el PK de la apuesta en la base de datos luego de insertarla,
        /// la prueba es exitosa.
        /// </summary>
        [Test]
        public void T01_AgregarApuestaVoFTest()
        {
            _daoApuestaJugador.Agregar(_apuestaJugador);

            EjecutarSPObtenerApuestas();

            if (_daoApuestaJugador.cantidadRegistros > 0)
                Assert.Pass();

            Assert.Fail();        
        }

        /// <summary>
        /// Si el valor esperado coincide con el modificado, la prueba es exitosa
        /// en este caso, el id del jugador.
        /// </summary>
        [Test]
        public void T02_EditarApuestaVoFTest()
        {
            _apuestaJugador.Respuesta = _jugador2;

            _daoApuestaJugador.Actualizar(_apuestaJugador);

            EjecutarSPObtenerApuestas();

            int RespuestaModificada = _daoApuestaJugador.GetInt(0, 5);

            Assert.AreEqual(_apuestaJugador.Respuesta.Id, RespuestaModificada);
        }

        /// <summary>
        /// Si la funcion devuelve un count mayor que 0, significa que la apuesta ya 
        /// se encuentra registrada en la base de datos.
        /// </summary>
        [Test]
        public void T03_VerificarApuestaExiste()
        {
            int count = _daoApuestaJugador.VerificarApuestaExiste(_apuestaJugador);

            if (count > 0)
                Assert.Pass();

            Assert.Fail();

        }

        /// <summary>
        /// Si la funcion devuelve un count menor que 1, significa que la apuesta no es valida
        /// para ser modificada.
        /// </summary>
        [Test]
        public void T04_VerificarApuestaValida()
        {
            int count = _daoApuestaJugador.VerificarApuestaValidaParaEditar(_apuestaJugador);

            if (count < 1)
                Assert.Pass();

            Assert.Fail();

        }

        /// <summary>
        /// Si la cantidad de registros es menor que 1 luego de consultar la apuesta
        /// por su PK, la prueba es exitosa.
        /// </summary>
        [Test]
        public void T05_EliminarApuestaVoFTest()
        {
            _daoApuestaJugador.Eliminar(_apuestaJugador);

            EjecutarSPObtenerApuestas();

            if (_daoApuestaJugador.cantidadRegistros < 1)
                Assert.Pass();

            Assert.Fail();

        }

        [TearDown]
        public void Down()
        {
            _apostador = null;

            _logroJugador = null;

            _daoApuestaJugador = null;

            _apuestaJugador = null;

            _jugador2 = null;

            _jugador1 = null;
        }

        private void EjecutarSPObtenerApuestas()
        {
            _daoApuestaJugador.Conectar();

            _daoApuestaJugador.StoredProcedure("obtenerapuestatest(@idusuario, @idlogro)");

            _daoApuestaJugador.AgregarParametro("idusuario", _apuestaJugador.Usuario.Id);
            _daoApuestaJugador.AgregarParametro("idlogro", _apuestaJugador.Logro.Id);

            _daoApuestaJugador.EjecutarReader();
        }
    }
}
