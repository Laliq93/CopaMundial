using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Comun.Excepciones;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;
using NUnit.Framework;
using System;

namespace PruebasCopaMundialAPI
{

    [TestFixture]
    public class PruebasAlineacion
    {

        private Partido partido;
        private DaoPartido daoPartido;
        private Equipo equipo1;
        private Equipo equipo2;
        private Estadio estadio;

        [SetUp]
        public void SetUp()
        {
            daoPartido = FabricaDao.CrearDaoPartido();
            equipo1 = GetEquipo(1);
            equipo2 = GetEquipo(2);
            estadio = GetEstadio(1);
            partido = FabricaEntidades.CrearPartido("2018/06/29 1:00:00", "2018/06/29 3:00:00", "pedro", equipo1, equipo2, estadio);
            daoPartido.Agregar(partido);
            Partido partidoobtenido = (Partido)dao.ObtenerTodos().Last();
            daoJugador = FabricaDao.CrearDaoJugador();
            jugador = FabricaEntidades.CrearJugador("prueba","prueba","prueba","prueba",80.2,1.82,"Delantero",1.1,equipo1.getId(),true,true);
            daoJugador.Agregar(jugador);
            daoAlineacion = Fabrica.CrearDaoAlineacion();
            alineacion = FabricaEntidades.CrearAlineacion(true,"Delantero", true, 1, equipo1.getId(), partidoobtenido.getId();
            
        }

        [Test]
        public void AgregarAlineacion()
        {

            daoAlineacion.Agregar(alineacion);
            Alineacion alineacionobtenido = (Alineacion)dao.ConsultarPorPartido(alineacion);

            Assert.AreEqual(alineacion.id, alineacionobtenido.id);

        }

        [Test]
        public void ConsultarPorPartido()
        {

            daoAlineacion.Agregar(alineacion);
            Alineacion alineacionobtenido = (Alineacion)ConsultarPorPartido(alineacion);

            Assert.IsNotNull(alineacionbtenido);

        }

        [Test]
        public void EliminarAlineacion()
        {

            daoAlineacion.Agregar(alineacion);
            daoAlineacion.Eliminar(alineacion);
            Alineacion alineacionobtenido = (Alineacion)ConsultarPorPartido(alineacion);

            Assert.IsNull(alineacionbtenido);

        }

        [Test]
        public void ModificarAlineacion()
        {
            daoAlineacion.Agregar(alineacion);
            Alineacion alineacionobtenido = (Alineacion)dao.ObtenerTodos().Last();
            Alineacion alineacionmodificado = new Alineacion (alineacionobtenido.Id,true,"Delantero", true, 1, equipo1.getId(), partidoobtenido.getId();
            dao.Actualizar(alineacionmodificado);
            Alineacion alineacionprueba = (Alineacion)dao.ObtenerTodos.Last();

            Assert.AreEqual(alineacionprueba.arbitro, partidomodificado.arbitro);
        }
        

        [Test]
        public void AgregarAlineacionExcepcionNullReferenceException()
        {

            alineacion = null;
            Assert.Catch<NullReferenceException>(daoAlineacion.Agregar(alineacion));


        }

        [Test]
        public void AgregarAlineacionExceptionGenerica()
        {

            
        alineacion = FabricaEntidades.CrearAlineacion(true,"Delantero", true, null, null, null;
                  

            Assert.Catch<Exception>(dao.Agregar(alineacion));

        }

        [Test]
        public void ConsultarPorPartidoNullReferenceException()
        {

            daoAlineacion.Agregar(null);
            
            Assert.Catch<NullReferenceException>(daoAlineacion.ConsultarPorPartido(alineacion));

        }

        [Test]
        public void ConsultarPorPartidoExcepcionGenerica()
        {

            daoAlineacion.Agregar("prueba");
            
            Assert.Catch<Exception>(daoAlineacion.ConsultarPorPartido(alineacion));

        }

        [Test]
        public void EliminarAlineacionExcepcionNullReferenceException()
        {

            alineacion = null;
            Assert.Catch<NullReferenceException>(daoAlineacion.Eliminar(alineacion));


        }

        [Test]
        public void EliminarAlineacionExceptionGenerica()
        {

            Assert.Catch<Exception>(dao.Agregar(5444));

        }

        [Test]
        public void ModificarAlineacionExcepcionNullReferenceException()
        {
            daoAlineacion.Agregar(alineacion);
            Alineacion alineacionmodificado = null;
            Assert.Catch<NullReferenceException>(dao.Actualizar(alineacionmodificado));
            
        }

        [Test]
        public void ModificarAlineacionExcepcionNullReferenceException()
        {
            daoAlineacion.Agregar(alineacion);
            Alineacion alineacionmodificado = FabricaEntidades.CrearAlineacion(1,true,"Delantero", true, null, null, null;
                  
            Assert.Catch<NullReferenceException>(dao.Actualizar(alineacionmodificado));
            
        }

        [TearDown]
        public void TeadDown()
        {
            
            
            daoAlineacion = null;
        }
    }

}
