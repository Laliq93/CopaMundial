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
            partido = FabricaEntidades.CrearPartido("2018/06/29 1:00:00", "2018/06/29 3:00:00", "pedro", equipo1, equipo2, estadio);
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



    }

}
