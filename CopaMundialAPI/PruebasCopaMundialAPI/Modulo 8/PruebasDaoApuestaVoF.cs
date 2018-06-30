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
    public class PruebasDaoApuestaVoF
    {
        Usuario _apostador;

        LogroVoF _logroVoF;

        DAOApuestaVoF _daovof;

        ApuestaVoF _apuestaVoF;


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

            _logroVoF = FabricaEntidades.CrearLogroVoF();

            _logroVoF.Id = 103;

            _apuestaVoF = FabricaEntidades.CrearApuestaVoF();

            _apuestaVoF.Logro = _logroVoF;
            _apuestaVoF.Usuario = _apostador;
            _apuestaVoF.Respuesta = true;

            _daovof = FabricaDAO.CrearDAOApuestaVoF();

        }

        /// <summary>
        /// Si encuentra el PK de la apuesta en la base de datos luego de insertarla,
        /// la prueba es exitosa.
        /// </summary>
        [Test]
        public void T01_AgregarApuestaVoFTest()
        {
            _daovof.Agregar(_apuestaVoF);

            EjecutarSPObtenerApuestas();

            if (_daovof.cantidadRegistros > 0)
                Assert.Pass();

            Assert.Fail();        
        }

        /// <summary>
        /// Si el valor esperado coincide con el modificado, la prueba es exitosa.
        /// </summary>
        [Test]
        public void T02_EditarApuestaVoFTest()
        {
            _apuestaVoF.Respuesta = false;

            _daovof.Actualizar(_apuestaVoF);

            EjecutarSPObtenerApuestas();

            bool RespuestaModificada = _daovof.GetBool(0, 3);

            Assert.AreEqual(_apuestaVoF.Respuesta, RespuestaModificada);
        }

        /// <summary>
        /// Si la funcion devuelve un count mayor que 0, significa que la apuesta ya 
        /// se encuentra registrada en la base de datos.
        /// </summary>
        [Test]
        public void T03_VerificarApuestaExiste()
        {
            int count = _daovof.VerificarApuestaExiste(_apuestaVoF);

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
            int count = _daovof.VerificarApuestaValidaParaEditar(_apuestaVoF);

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
            _daovof.Eliminar(_apuestaVoF);

            EjecutarSPObtenerApuestas();

            if (_daovof.cantidadRegistros < 1)
                Assert.Pass();

            Assert.Fail();

        }

        [TearDown]
        public void Down()
        {
            _apostador = null;

            _logroVoF = null;

            _daovof = null;

            _apuestaVoF = null;
        }

        private void EjecutarSPObtenerApuestas()
        {
            _daovof.Conectar();

            _daovof.StoredProcedure("obtenerapuestatest(@idusuario, @idlogro)");

            _daovof.AgregarParametro("idusuario", _apuestaVoF.Usuario.Id);
            _daovof.AgregarParametro("idlogro", _apuestaVoF.Logro.Id);

            _daovof.EjecutarReader();
        }
    }
}
