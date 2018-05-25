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
using System.Web.Http;
using System.Web.Http.Results;

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

        /*
        [Test] 
        public void RegistrarPartidoTest()
        {
            
            DateTime fecha = DateTime.ParseExact("2008-01-01", "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);


            IHttpActionResult actionResult= _partidoController.RegistrarPartido("arbitroPrueba", fecha.ToString(), "08:00", 1, 2, 1);

            Assert.IsInstanceOf<OkResult> (actionResult); 
        }
        
         */
      


        [TearDown]
        public void Clean()
        {
            _partido= null;
            _partidoController = null;
            _database.Desconectar();
        }





    }
}
