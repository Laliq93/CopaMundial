using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WebAPI.Controllers;
using WebAPI.Models;
using WebAPI.Models.DataBase;
using WebAPI.Models.Excepciones;
using System.Net.Http;
using System.Web;
using System.Web.Http.Results;
using System.Web.Http;
using System.Net;


namespace WebApiPruebas.M6
{
    [TestFixture]
    public class PartidoTest
    {
        private M6_PartidoController _partidoController;
        private DataBase _database = new DataBase();
        private List<Partido> _listaPartido;
        private Partido _partido;
        private Alineacion _alineacion;

        [OneTimeSetUp]
        public void OpenDatabase()
        {
            _database.Conectar();
        }

        [SetUp]
        public void Init()
        {
            _partidoController = new M6_PartidoController();
            _partidoController.Request = new HttpRequestMessage();
            _partidoController.Configuration = new HttpConfiguration();
        }

        /// <summary>
        /// Prueba para Registrar un Partido
        /// </summary>
        [Test]
        public void RegistrarPartidoTest()
        {
            _partido = new Partido("arbitroPrueba", "06-06-2018", "07:00", 1, 2, 500);


            IHttpActionResult actionResult = _partidoController.RegistrarPartido(_partido);
            var contentResult = actionResult as OkNegotiatedContentResult<string>;
            Assert.AreEqual("Partido registrado exitosamente.", contentResult.Content);
            //    CleanDatabase(_partidoController.IdPartido());

        }


        /// <summary>
        /// Prueba para verificar que no haya un  partido asignado
        /// a en el estadio  a esa hora
        /// </summary>
        [Test]
        public void RegistrarPartidoEstadioExcepcionTest()
        {

            _partido = new Partido("arbitroPrueba", "06-06-2018", "07:00", 1, 2, 1);
            Partido _partido2 = new Partido("arbitroPrueba", "06-06-2018", "07:00", 1, 2, 1);

            _partidoController.RegistrarPartido(_partido);
            IHttpActionResult actionResult = _partidoController.RegistrarPartido(_partido2);
            Assert.IsInstanceOf<BadRequestErrorMessageResult>(actionResult);
            //    CleanDatabase(_partidoController.IdPartido());

        }


        /// <summary>
        /// Prueba para obtener consulta  de un estadio disponible
        /// </summary>
        [Test]
        public void ConsultarDisponibilidadEstadioTest()
        {

            int result = _partidoController.ConsultarDisponibilidadEstadio("14-06-2090", "08:00", 1091);
            Assert.AreEqual(0, result);

        }


        /// <summary>
        /// Prueba de la EstadioNoDisponibleException
        /// acierta en caso de que no este disponible el
        /// estado a esa hora
        /// </summary>
        [Test]
        public void DisponibilidadEstadioExceptionTest()
        {

            _partido = new Partido("arbitroPrueba", "06-06-2018", "07:00", 1, 2, 1);
            _partidoController.RegistrarPartido(_partido);
            Assert.Throws<EstadioNoDisponibleException>(() => _partidoController.ConsultarDisponibilidadEstadio("06-06-2018", "07:00", 1));

        }



        /// <summary>
        /// Prueba para consultar un partido
        /// </summary>
        [Test]
        public void ConsultarPartidoTest()
        {
            Partido partido;

            _partido = new Partido("arbitroPrueba", "14-06-2018", "08:00", 1, 2, 1);
            _partidoController.AgregarPartido("arbitroPrueba", "14-06-2018", "08:00", 1, 2, 1);

            _partido.Id = _partidoController.IdPartido();
            var response = _partidoController.ConsultarPartido(_partido.Id);
            Assert.IsTrue(response.TryGetContentValue<Partido>(out partido));

            //   CleanDatabase(_partidoController.IdPartido());*/
        }

        /// <summary>
        /// Prueba cuando un partido no existe
        /// devuelve PartidoNotFoundException
        /// </summary>
        [Test]
        public void ObtenerPartidoNotFoundTest()
        {

            Assert.Throws<PartidoNotFoundException>(() => _partidoController.ObtenerPartido(2533));

        }

        /// <summary>
        /// Prueba para obtener un partido en caso de acierto
        /// de la base de datos
        /// </summary>
        [Test]
        public void ObtenerPartidoTest()
        {

            _partidoController.AgregarPartido("arbitroPrueba", "19-06-2050", "08:00", 1, 2, 1);
            Assert.IsNotNull(_partidoController.ObtenerPartido(_partidoController.IdPartido()));
            //  CleanDatabase(_partidoController.IdPartido());
        }



        /// <summary>
        /// /Prueba para verificar que el partido se modifico con exito
        /// </summary>
        [Test]
        public void ModificarPartidoTest()
        {

            _partidoController.AgregarPartido("arbitroPrueba", "31-06-2018", "08:00", 1, 2, 1);
            Partido _partidoMof = new Partido("arbitroModificado", "12-06-2018", "09:00", 1, 2, 1);
            _partidoMof.Id = _partidoController.IdPartido();
            IHttpActionResult actionResult = _partidoController.ModificarPartido(_partidoMof);
            var contentResult = actionResult as OkNegotiatedContentResult<string>;

            Assert.AreEqual("Partido actualizado exitosamente.", contentResult.Content);
            //  CleanDatabase(_partidoController.IdPartido());
        }






        /// <summary>
        /// Prueba cuando no se encuentra el partido
        /// </summary>
        [Test]
        public void PartidoNotFoundExceptionTest()
        {

            Assert.Throws<PartidoNotFoundException>(() => _partidoController.ObtenerPartido(52014));
        }



        /// <summary>
        /// /Metodo para limpiar los datos de los objetos despues de la prueba
        /// </summary>

        [TearDown]
        public void Clean()
        {
            _partido = null;
            _partidoController = null;
            _database.Desconectar();
        }


        /// <summary>
        /// Metodo para limpiar la base de datos despues de la prueba
        /// </summary>
        /// <param name="idPartido"></param>
        /* public void CleanDatabase(int idPartido)
          {
             _database.StoredProcedure("CleanPU_Partido(@idPartido)");
              _database.AgregarParametro("idPartido", idPartido);
              _database.EjecutarQuery();

          }*/


    }
}
