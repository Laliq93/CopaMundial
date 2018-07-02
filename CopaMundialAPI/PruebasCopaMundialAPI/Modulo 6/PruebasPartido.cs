using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Comun.Excepciones;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace PruebasCopaMundialAPI
{

    [TestFixture]
    public class PruebasPartido
    {

        private Partido partido;
        private DAOPartido daoPartido;
        private Equipo equipo1;
        private Equipo equipo2;
        private Estadio estadio;
        private Equipos equipos;
        private Estadios estadios;

        [SetUp]
        public void SetUp()
        {
            equipos = new Equipos();
            estadios = new Estadios();
            daoPartido = FabricaDAO.CrearDAOPartido();
            equipo1 = equipos.GetEquipo(1);
            equipo2 = equipos.GetEquipo(2);
            estadio = estadios.GetEstadio(1);
            partido = FabricaEntidades.CrearPartido(0, new DateTime(2018, 06, 29, 1, 0, 0), new DateTime(2018, 06, 29, 3, 0, 0), "pedro", equipo1, equipo2, estadio);
        }

        [Test]
        public void AgregarPartido()
        {

            daoPartido.Agregar(partido);
            Partido partidoobtenido = (Partido)daoPartido.ObtenerTodos()[daoPartido.ObtenerTodos().Count - 1];

            Assert.AreEqual(partido.Id, partidoobtenido.Id);

        }

        [Test]
        public void ObtenerTodos()
        {

            daoPartido.Agregar(partido);
            Partido partidoobtenido = (Partido)daoPartido.ObtenerTodos()[daoPartido.ObtenerTodos().Count - 1];

            Assert.IsNotNull(partidoobtenido);

        }

        [Test]
        public void ObtenerSiguientes()
        {

            daoPartido.Agregar(partido);
            Partido partidoAux = FabricaEntidades.CrearPartido();
            partidoAux.FechaInicioPartido = new DateTime(2018, 06, 28, 1, 0, 0);
            List<Entidad> entidades = daoPartido.ObtenerPartidosPosterioresA(partidoAux);
            Partido partidoobtenido = (Partido) entidades[entidades.Count - 1];

            Assert.IsNotNull(partidoobtenido);

        }

        [Test]
        public void ObtenerPorId()
        {

            daoPartido.Agregar(partido);
            Partido partidoobtenido = (Partido) daoPartido.ObtenerPorId(partido);

            Assert.IsNotNull(partidoobtenido);

        }

        [Test]
        public void ModificarPartido()
        {
            daoPartido.Agregar(partido);
            Partido partidoobtenido = (Partido)daoPartido.ObtenerTodos()[daoPartido.ObtenerTodos().Count - 1];
            Partido partidomodificado = new Partido (partidoobtenido.Id, new DateTime(2018, 06, 29, 1, 0, 0), new DateTime(2018, 06, 29, 3, 0, 0), "modificado", equipo1, equipo2, estadio);
            daoPartido.Actualizar(partidomodificado);
            Partido partidoprueba = (Partido)daoPartido.ObtenerTodos()[daoPartido.ObtenerTodos().Count - 1];

            Assert.AreEqual(partidoprueba.Arbitro, partidomodificado.Arbitro);
        }

        [Test]
        public void ModificarPartidoExcepcionNullReferenceException()
        {
            daoPartido.Agregar(partido);
            Partido partidomodificado = null;

            Assert.Throws<DatosInvalidosException>(() => daoPartido.Actualizar(partidomodificado));
            
        }

        [Test]
        public void ModificarPartidoExcepcionGenerica()
        {
            daoPartido.Agregar(partido);

            Assert.Throws<DatosInvalidosException>(() => daoPartido.Actualizar(null));
            
        }

        [Test]
        public void ObtenerSiguientesNullReferenceException()
        {

            daoPartido.Agregar(partido);

            Assert.Throws<DatosInvalidosException>(() => daoPartido.ObtenerPartidosPosterioresA(null));
        }

        [Test]
        public void ObtenerPorIdNullReferenceException()
        {

            daoPartido.Agregar(partido);

            Assert.Throws<DatosInvalidosException>(() => daoPartido.ObtenerPorId(null));
        }

        [TearDown]
        public void TeadDown()
        {
            
            
            daoPartido = null;
        }


    }

}
