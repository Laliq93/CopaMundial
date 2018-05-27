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
        
         

        [Test]
        public void ConsultarPartidoTest()
        {

            _partido = new Partido("arbitroPrueba", "14-06-2018", "08:00", 1, 2, 1);
             _partidoController.AgregarPartido("arbitroPrueba", "14-06-2018", "08:00", 1, 2, 1);

             _partido.Id = _partidoController.IdPartido();
            // var  response =;
             //Assert.IsNotNull(response);
            Assert.AreEqual(HttpStatusCode.OK, _partidoController.ConsultarPartido(_partido.Id));
            //return Request.CreateResponse(HttpStatusCode.OK, _partido);
        }



        [TearDown]
        public void Clean()
        {
            _partido= null;
            _partidoController = null;
            _database.Desconectar();
        }

       public void CleanDatabase(int idPartido)
        {
           _database.StoredProcedure("CleanPU_Partido(@idPartido)");
            _database.AgregarParametro("idPartido", idPartido);
            _database.EjecutarQuery();

        }
        

    }
}
