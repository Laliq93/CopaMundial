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
    public class PruebasDaoApuestaEquipo
    {
        Usuario _apostador;

        LogroEquipo _logroEquipo;

        DAOApuestaEquipo _daoApuestaEquipo;

        ApuestaEquipo _apuestaEquipo;

        Equipos _listaEquipos;


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

            _logroEquipo = FabricaEntidades.CrearLogroEquipo();

            _logroEquipo.Id = 102;

            _listaEquipos = new Equipos();


            _apuestaEquipo = FabricaEntidades.CrearApuestaEquipo();

            _apuestaEquipo.Logro = _logroEquipo;
            _apuestaEquipo.Usuario = _apostador;
            _apuestaEquipo.Respuesta = _listaEquipos.GetEquipo(1);

            _daoApuestaEquipo = FabricaDAO.CrearDAOApuestaEquipo();

        }

        /// <summary>
        /// Si encuentra el PK de la apuesta en la base de datos luego de insertarla,
        /// la prueba es exitosa.
        /// </summary>
        [Test]
        public void T01_AgregarApuestaVoFTest()
        {
            _daoApuestaEquipo.Agregar(_apuestaEquipo);

            EjecutarSPObtenerApuestas();

            if (_daoApuestaEquipo.cantidadRegistros > 0)
                Assert.Pass();

            Assert.Fail();        
        }

        /// <summary>
        /// Si el valor esperado coincide con el modificado, la prueba es exitosa.
        /// En este caso el id del equipo.
        /// </summary>
        [Test]
        public void T02_EditarApuestaVoFTest()
        {
            int idEquipoModificada = 2;

            _apuestaEquipo.Respuesta = _listaEquipos.GetEquipo(idEquipoModificada);

            _daoApuestaEquipo.Actualizar(_apuestaEquipo);

            EjecutarSPObtenerApuestas();

            int RespuestaModificada = _daoApuestaEquipo.GetInt(0, 6);

            Assert.AreEqual(_apuestaEquipo.Respuesta.Id, RespuestaModificada);
        }

        /// <summary>
        /// Si la funcion devuelve un count mayor que 0, significa que la apuesta ya 
        /// se encuentra registrada en la base de datos.
        /// </summary>
        [Test]
        public void T03_VerificarApuestaExiste()
        {
            int count = _daoApuestaEquipo.VerificarApuestaExiste(_apuestaEquipo);

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
            int count = _daoApuestaEquipo.VerificarApuestaValidaParaEditar(_apuestaEquipo);

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
            _daoApuestaEquipo.Eliminar(_apuestaEquipo);

            EjecutarSPObtenerApuestas();

            if (_daoApuestaEquipo.cantidadRegistros < 1)
                Assert.Pass();

            Assert.Fail();

        }

        [TearDown]
        public void Down()
        {
            _apostador = null;

            _logroEquipo = null;

            _daoApuestaEquipo = null;

            _apuestaEquipo = null;
        }

        private void EjecutarSPObtenerApuestas()
        {
            _daoApuestaEquipo.Conectar();

            _daoApuestaEquipo.StoredProcedure("obtenerapuestatest(@idusuario, @idlogro)");

            _daoApuestaEquipo.AgregarParametro("idusuario", _apuestaEquipo.Usuario.Id);
            _daoApuestaEquipo.AgregarParametro("idlogro", _apuestaEquipo.Logro.Id);

            _daoApuestaEquipo.EjecutarReader();
        }
    }
}
