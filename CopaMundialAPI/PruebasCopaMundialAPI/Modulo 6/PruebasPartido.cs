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
    public class PruebasPartido
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
            partido = FabricaEntidades.CrearPartido("2018/06/29 1:00:00", "2018/06/29 3:00:00", "pedro", equipo1.getId(), equipo2Id(), estadioId());
        }

        [Test]
        public void AgregarPartido()
        {

            daoPartido.Agregar(partido);
            Partido partidoobtenido = (Partido)dao.ObtenerTodos().Last();

            Assert.AreEqual(partido.id, partidoobtenido.id);

        }

        [Test]
        public void ObtenerTodos()
        {

            daoPartido.Agregar(partido);
            Partido partidoobtenido = (Partido)dao.ObtenerTodos().Last();

            Assert.IsNotNull(partidobtenido);

        }

        [Test]
        public void ObtenerSiguientes()
        {

            daoPartido.Agregar(partido);
            Partido partidoobtenido = (Partido)ObtenerPartidosPosterioresA("2018/06/28 1:00:00").Last();

            Assert.IsNotNull(partidobtenido);

        }

        [Test]
        public void ObtenerPorId()
        {

            daoPartido.Agregar(partido);
            Partido partidoobtenido = (Partido)ObtenerPorId(1).Last();

            Assert.IsNotNull(partidobtenido);

        }

        [Test]
        public void ModificarPartido()
        {
            daoPartido.Agregar(partido);
            Partido partidoobtenido = (Partido)dao.ObtenerTodos().Last();
            Partido partidomodificado = new Partido (partidoobtenido.Id,"2018/06/29 1:00:00", "2018/06/29 3:00:00", "modificado", equipo1getId(), equipo2getId(), estadiogetId());
            dao.Actualizar(partidomodificado);
            Partido partidoprueba = (Partido)dao.ObtenerTodos.Last();

            Assert.AreEqual(partidoprueba.arbitro, partidomodificado.arbitro);
        }

        [Test]
        public void ModificarPartidoExcepcionNullReferenceException()
        {
            daoPartido.Agregar(partido);
            Partido partidomodificado = null;
            Assert.Catch<NullReferenceException>(dao.Actualizar(partidomodificado));
            
        }

        [Test]
        public void ModificarPartidoExcepcionGenerica()
        {
            daoPartido.Agregar(partido);
            Partido partidomodificado = new Partido (null,null, "2018/06/29 3:00:00", "modificado", equipo1, equipo2, estadio);
            Assert.Catch<NullReferenceException>(dao.Actualizar(partidomodificado));
            
        }



        [Test]
        public void AgregarPartidoNullReferenceException()
        {

            partido = null;

            Assert.Catch<NullReferenceException>(dao.Agregar(partido));

        }

        [Test]
        public void AgregarPartidoExceptionGenerica()
        {

            
            partido = FabricaEntidades.CrearPartido(null, null, "pedro", equipo1, equipo2, estadio);
        

            Assert.Catch<Exception>(dao.Agregar(partido));

        }

        [Test]
        public void ObtenerSiguientesNullReferenceException()
        {

            daoPartido.Agregar(partido);

            Assert.Catch<NullReferenceException>(dao.ObtenerPartidosPosterioresA(null));
        }

        [Test]
        public void ObtenerSiguientesExceptionGenerica()
        {

            daoPartido.Agregar(partido);

            Assert.Catch<Exception>(dao.ObtenerPartidosPosterioresA(7));
        }

        [Test]
        public void ObtenerPorIdNullReferenceException()
        {

            daoPartido.Agregar(partido);

            Assert.Catch<NullReferenceException>(dao.ObtenerPorId(null));
        }

        [Test]
        public void ObtenerPorIdExceptionGenerica()
        {

            daoPartido.Agregar(partido);

            Assert.Catch<Exception>(dao.ObtenerPorId('error'));
        }

        [TearDown]
        public void TeadDown()
        {
            
            
            daoPartido = null;
        }


    }

}
