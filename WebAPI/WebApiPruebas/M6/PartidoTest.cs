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

namespace WebApiPruebas.M6
{
    [TestFixture]
    public class PartidoTest
    {
        private M6_PartidoController _partidoController;
        private DataBase _database;
        private List<Partido> _listaPartido;
        private Partido _partido;

        [OneTimeSetUp]
        public void OpenDatabase()
        {
            _database = new DataBase();
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
            
            IHttpActionResult actionResult= _partidoController.RegistrarPartido("arbitroPrueba","14-06-2018", "08:00", 1, 2, 1);
            var contentResult = actionResult as OkNegotiatedContentResult<string>;
            Assert.AreEqual("Partido registrado exitosamente.", contentResult.Content);
        }
        
         

        [Test]
        public void ConsultarPartidoTest()
        {

            _partidoController.AgregarPartido("arbitroPrueba", "14-06-2018", "08:00", 1, 2, 1);

            _partido.Id = _partidoController.IdPartido();
            var response = _partidoController.ConsultarPartido(_partido.Id);
            Assert.IsNotNull(response);


        }



        [TearDown]
        public void Clean()
        {
            _partido= null;
            _partidoController = null;
            _database.Desconectar();
        }





    }
}
