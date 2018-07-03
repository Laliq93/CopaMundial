using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Comun.Excepciones;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;
using CopaMundialAPI.Servicios.DTO.Partidos;
using CopaMundialAPI.Servicios.Fabrica;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;

namespace PruebasCopaMundialAPI
{

    [TestFixture]
    public class PruebasAlineacion
    {

        private Partido partido;
        private DAOPartido daoPartido;
        private Equipo equipo1;
        private Equipo equipo2;
        private Estadio estadio;
        private Alineacion alineacion;
        private DAOAlineacion daoAlineacion;
        private Partido partidoobtenido;
        private Jugador jugador;

        [SetUp]
        public void SetUp()
        {
            Equipos equipos = new Equipos();
            Estadios estadios = new Estadios();
            daoPartido = FabricaDAO.CrearDAOPartido();
            equipo1 = equipos.GetEquipo(1);
            equipo2 = equipos. GetEquipo(2);
            estadio = estadios.GetEstadio(1);
            partido = FabricaEntidades.CrearPartido(0, new DateTime(2018,06,29,1,0,0), new DateTime(2018, 06, 29, 3, 0, 0), "pedro", equipo1, equipo2, estadio);
            daoPartido.Agregar(partido);
            partidoobtenido = (Partido)daoPartido.ObtenerTodos()[daoPartido.ObtenerTodos().Count - 1];
            DAOJugador daoJugador = FabricaDAO.CrearDAOJugador();
            jugador = FabricaEntidades.CrearJugador();
            jugador.Equipo = equipo1;
            jugador.Altura = 180;
            jugador.Apellido = "Prueba";
            jugador.Nombre = "PruebaDos";
            jugador.Numero = 10;
            jugador.Posicion = "Delantero";
            jugador.Peso = 90;
            jugador.LugarNacimiento = "Perdido";
            jugador.FechaNacimiento = "2012/12/12";
            daoJugador.Agregar(jugador);
            daoAlineacion = FabricaDAO.CrearDAOAlineacion();
            alineacion = FabricaEntidades.CrearAlineacion(0, true,"Delantero", true, jugador, equipo1, partidoobtenido);
            
        }

        [Test]
        public void AgregarAlineacion()
        {

            daoAlineacion.Agregar(alineacion);
            List<Entidad> alineacionobtenido = daoAlineacion.ConsultarPorPartido(alineacion.Partido);

            Assert.IsTrue(alineacionobtenido.Contains(alineacion));

        }

        [Test]
        public void ConsultarPorPartido()
        {

            daoAlineacion.Agregar(alineacion);
            List<Entidad> alineacionobtenido = daoAlineacion.ConsultarPorPartido(alineacion.Partido);

            Assert.IsNotNull(alineacionobtenido);

        }

        [Test]
        public void EliminarAlineacion()
        {

            daoAlineacion.Agregar(alineacion);
            daoAlineacion.Eliminar(alineacion);
            List<Entidad> alineacionobtenido = daoAlineacion.ConsultarPorPartido(alineacion.Partido);

            Assert.IsNull(alineacionobtenido);

        }

        [Test]
        public void ModificarAlineacion()
        {
            daoAlineacion.Agregar(alineacion);
            Alineacion alineacionobtenido = (Alineacion)daoAlineacion.ObtenerTodos()[daoAlineacion.ObtenerTodos().Count - 1];
            Alineacion alineacionmodificado = new Alineacion (alineacionobtenido.Id,true,"Delantero", true, jugador, equipo1, partidoobtenido);
            daoAlineacion.Actualizar(alineacionmodificado);
            Alineacion alineacionprueba = (Alineacion) daoAlineacion.ObtenerTodos()[daoAlineacion.ObtenerTodos().Count - 1];

            Assert.AreEqual(alineacionprueba.Posicion, alineacionmodificado.Posicion);
        }
        

        [Test]
        public void AgregarAlineacionExcepcionNullReferenceException()
        {

            alineacion = null;

            Assert.Throws<DatosInvalidosException>(() => daoAlineacion.Agregar(alineacion));


        }

        [Test]
        public void AgregarAlineacionExceptionGenerica()
        {

            
        alineacion = FabricaEntidades.CrearAlineacion(0, true,"Delantero", true, null, null, null);

        Assert.Throws<ExcepcionPersonalizada>(() => daoAlineacion.Agregar(alineacion));

        }

        [Test]
        public void ConsultarPorPartidoNullReferenceException()
        {
            Assert.Throws<DatosInvalidosException>(() => daoAlineacion.ConsultarPorPartido(null));

        }

        [Test]
        public void EliminarAlineacionExcepcionNullReferenceException()
        {

            alineacion = null;
            Assert.Throws<DatosInvalidosException>(() => daoAlineacion.Eliminar(null));


        }

        [Test]
        public void ModificarAlineacionExcepcionNullReferenceException()
        {
            daoAlineacion.Agregar(alineacion);
            Alineacion alineacionmodificado = null;
            Assert.Throws<DatosInvalidosException>(() => daoAlineacion.Actualizar(alineacionmodificado));
            
        }

        [TearDown]
        public void TeadDown()
        {
            daoAlineacion = null;
        }
}

}
