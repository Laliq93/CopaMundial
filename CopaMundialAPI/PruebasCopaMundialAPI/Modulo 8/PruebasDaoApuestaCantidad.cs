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
    public class PruebasDaoApuestaCantidad
    {
        Usuario _apostador;

        LogroCantidad _logroCantidad;

        DAOApuestaCantidad _daoCantidad;

        ApuestaCantidad _apuestaCantidad;


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

            _logroCantidad = FabricaEntidades.CrearLogroCantidad();

            _logroCantidad.Id = 100;

            _apuestaCantidad = FabricaEntidades.CrearApuestaCantidad();

            _apuestaCantidad.Logro = _logroCantidad;
            _apuestaCantidad.Usuario = _apostador;
            _apuestaCantidad.Respuesta = 10;

            _daoCantidad = FabricaDAO.CrearDAOApuestaCantidad();

        }

        /// <summary>
        /// Si encuentra el PK de la apuesta en la base de datos luego de insertarla,
        /// la prueba es exitosa.
        /// </summary>
        [Test]
        public void T01_AgregarApuestaVoFTest()
        {
            _daoCantidad.Agregar(_apuestaCantidad);

            EjecutarSPObtenerApuestas();

            if (_daoCantidad.cantidadRegistros > 0)
                Assert.Pass();

            Assert.Fail();        
        }

        /// <summary>
        /// Si el valor esperado coincide con el modificado, la prueba es exitosa.
        /// </summary>
        [Test]
        public void T02_EditarApuestaVoFTest()
        {
            _apuestaCantidad.Respuesta = 8;

            _daoCantidad.Actualizar(_apuestaCantidad);

            EjecutarSPObtenerApuestas();

            int RespuestaModificada = _daoCantidad.GetInt(0, 4);

            Assert.AreEqual(_apuestaCantidad.Respuesta, RespuestaModificada);
        }

        /// <summary>
        /// Si la funcion devuelve un count mayor que 0, significa que la apuesta ya 
        /// se encuentra registrada en la base de datos.
        /// </summary>
        [Test]
        public void T03_VerificarApuestaExiste()
        {
            int count = _daoCantidad.VerificarApuestaExiste(_apuestaCantidad);

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
            int count = _daoCantidad.VerificarApuestaValidaParaEditar(_apuestaCantidad);

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
            _daoCantidad.Eliminar(_apuestaCantidad);

            EjecutarSPObtenerApuestas();

            if (_daoCantidad.cantidadRegistros < 1)
                Assert.Pass();

            Assert.Fail();

        }

        [TearDown]
        public void Down()
        {
            _apostador = null;

            _logroCantidad = null;

            _daoCantidad = null;

            _apuestaCantidad = null;
        }

        private void EjecutarSPObtenerApuestas()
        {
            _daoCantidad.Conectar();

            _daoCantidad.StoredProcedure("obtenerapuestatest(@idusuario, @idlogro)");

            _daoCantidad.AgregarParametro("idusuario", _apuestaCantidad.Usuario.Id);
            _daoCantidad.AgregarParametro("idlogro", _apuestaCantidad.Logro.Id);

            _daoCantidad.EjecutarReader();
        }
    }
}
