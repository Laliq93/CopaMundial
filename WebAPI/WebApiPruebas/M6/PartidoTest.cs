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
        }

        /// <summary>
        /// Prueba para Registrar un Partido
        /// </summary>
        [Test] 
        public void RegistrarPartidoTest()
        {
            _partido = new Partido("arbitroPrueba","06-06-2018","07:00",1,2,1);
      

            IHttpActionResult actionResult= _partidoController.RegistrarPartido(_partido);
            var contentResult = actionResult as OkNegotiatedContentResult<string>;
            Assert.AreEqual("Partido registrado exitosamente.", contentResult.Content);
            CleanDatabase(_partidoController.IdPartido());

        }
        
         
        /// <summary>
        /// Prueba para consultar un partido
        /// </summary>
        [Test]
        public void ConsultarPartidoTest()
        {

            _partido = new Partido("arbitroPrueba", "14-06-2018", "08:00", 1, 2, 1);
             _partidoController.AgregarPartido("arbitroPrueba", "14-06-2018", "08:00", 1, 2, 1);

             _partido.Id = _partidoController.IdPartido();
            Assert.AreEqual(HttpStatusCode.OK, _partidoController.ConsultarPartido(_partido.Id));
            CleanDatabase(_partidoController.IdPartido());
        }



        /// <summary>
        /// /Prueba para verificar que el partido se modifico con exito
        /// </summary>
        [Test]
        public void ModificarPartidoTest()
        {

            _partido = new Partido("arbitroPrueba", "14-06-2018", "08:00", 1, 2, 1);
            _partidoController.AgregarPartido("arbitroPrueba", "14-06-2018", "08:00", 1, 2, 1);
            Partido _partidoMof = new Partido("arbitroModificado", "12-06-2018", "09:00", 1, 2, 1);
            _partidoMof.Id =  _partidoController.IdPartido();
            Assert.AreEqual(HttpStatusCode.OK, _partidoController.ModificarPartido(_partidoMof));
            CleanDatabase(_partidoController.IdPartido());
        }



        /// <summary>
        /// Prueba para obtener un partido de la base de datos
        /// </summary>
        [Test]
        public void ObtenerPartidoTest()
        {

            _partido = new Partido("arbitroPrueba", "14-06-2018", "08:00", 1, 2, 1);
            _partidoController.AgregarPartido("arbitroPrueba", "14-06-2018", "08:00", 1, 2, 1);
            Assert.IsNotNull(_partidoController.ObtenerPartido(_partido.Id));
            CleanDatabase(_partidoController.IdPartido());
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
            _partido= null;
            _partidoController = null;
            _database.Desconectar();
        }


        /// <summary>
        /// Metodo para limpiar la base de datos despues de la prueba
        /// </summary>
        /// <param name="idPartido"></param>
       public void CleanDatabase(int idPartido)
        {
           _database.StoredProcedure("CleanPU_Partido(@idPartido)");
            _database.AgregarParametro("idPartido", idPartido);
            _database.EjecutarQuery();

        }
        

    }
}
