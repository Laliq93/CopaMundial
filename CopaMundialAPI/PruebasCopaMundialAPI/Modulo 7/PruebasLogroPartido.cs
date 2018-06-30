using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;
using CopaMundialAPI.Logica_de_Negocio.Comando;
using CopaMundialAPI.Presentacion.Controllers;
using CopaMundialAPI.Comun.Excepciones;
using NUnit.Framework;
using CopaMundialAPI.Logica_de_Negocio.Fabrica;
using CopaMundialAPI.Servicios.Traductores.Logros;
using CopaMundialAPI.Servicios.Traductores.Fabrica;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Servicios.DTO.Logros;
using CopaMundialAPI.Servicios.Fabrica;
using System.Net;

namespace PruebasCopaMundialAPI.Modulo_7
{
    [TestFixture]
    class PruebasLogroPartido
    {

        private DAO dao;
        private Comando comando;
        private Entidad respuesta;
        private List<Entidad> _respuestas;
        private LogrosController controller;

        public Partido FabricaEntidad { get; private set; }

        [SetUp]
        public void SetUp()
        {
            dao = FabricaDAO.CrearDAOLogroPartido();
            dao.Conectar();
            controller = new LogrosController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            _respuestas = new List<Entidad>();


        }

        /// <summary>
        /// Metodo que prueba el resultado exitoso 
        /// del metodo DaoObtenerProximosLogroPartidos
        /// </summary>
        [Test]
        public void PruebaDaoObtenerProximosLogroPartidos()
        {
            _respuestas = ((DAOLogroPartido)dao).ObtenerProximosLogroPartidos();
            
            Assert.IsNotNull(_respuestas);
        }

        /// <summary>
        /// Metodo que prueba el resultado de exito de
        /// ObtenerLogroPartidosFinalizados del DaoLogroPartido
        /// </summary>
        [Test]
        public void PruebaDaoObtenerLogroPartidosFinalizados()
        {
            _respuestas = ((DAOLogroPartido)dao).ObtenerLogroPartidosFinalizados();

            Assert.IsNotNull(_respuestas);
        }

        /// <summary>
        /// Metodo que prueba el resultado de exito del comando
        /// ObtenerLogroPartidoFinalizados 
        /// </summary>
        [Test]
        public void PruebaCmdObtenerLogroPartidosFinalizados()
        {

            comando = FabricaComando.CrearComandoObtenerLogroPartidosFinalizados();
            comando.Ejecutar();
            _respuestas = comando.GetEntidades();
            Assert.IsNotNull(_respuestas);

        }


        /// <summary>
        /// Metodo que prueba el resultado de exito del comando 
        /// ObtenerProximosLogroPartido
        /// </summary>
        [Test]
        public void PruebaCmdObtenerProximosLogroPartidos()
        {

            comando = FabricaComando.CrearComandoObtenerProximosLogrosPartidos();
            comando.Ejecutar();
            _respuestas = comando.GetEntidades();
            Assert.IsNotNull(_respuestas);

        }

        /// <summary>
        /// Metodo que prueba el resultado de exito de 
        /// CrearDto del TraductorListaPartidosLogrosDto
        /// </summary>
        [Test]
        public void PruebaTraductorListaPartidosLogrosDto()
        {
            TraductorListaPartidosLogros traductor = FabricaTraductor.CrearTraductorListaPartidosLogros();
            Partido partido = FabricaEntidades.CrearPartido();
            DTOListaPartidosLogros dtoListaPartidos = FabricaDTO.CrearDTOListaPartidosLogros();
            Equipos equiposEstaticos = new Equipos();
            partido.Id = 14;
            partido.FechaInicioPartido = DateTime.Now;
            partido.Equipo1 = equiposEstaticos.GetEquipo(1);
            partido.Equipo2 = equiposEstaticos.GetEquipo(2);

            dtoListaPartidos = traductor.CrearDto(partido);

            Assert.AreEqual(14, dtoListaPartidos.IdPartido);

          
        }

        /// <summary>
        /// Metodo que prueba el resultado de exito de
        /// CrearEntidad del traductor TraductorListaPartidosLogros
        /// </summary>
        [Test]
        public void PruebaTraductorListaPartidosLogrosEntidad()
        {
            TraductorListaPartidosLogros traductor = FabricaTraductor.CrearTraductorListaPartidosLogros();
            Partido partido = FabricaEntidades.CrearPartido();
            DTOListaPartidosLogros dtoListaPartidos = FabricaDTO.CrearDTOListaPartidosLogros();

            dtoListaPartidos.IdPartido = 14;

            partido = (Partido)traductor.CrearEntidad(dtoListaPartidos);

            Assert.AreEqual(14, partido.Id);

        }

        /// <summary>
        /// Metodo que prueba el resultado de exito de
        /// ObtenerProximsLogrosPartidos del LogroController
        /// </summary>
        [Test]
        public void PruebaCtrObtenerProximosLogrosPartidos()
        {

            Assert.AreEqual(HttpStatusCode.OK, controller.ObtenerProximosLogrosPartidos().StatusCode);

        }


        /// <summary>
        /// Metodo que prueba el resultado de exito de
        /// ObtenerLogrosPartidosFinalizados del LogroController
        /// </summary>
        [Test]
        public void PruebaCtrObtenerLogrosPartidosFinalizados()
        {

            Assert.AreEqual(HttpStatusCode.OK, controller.ObtenerLogrosPartidosFinalizados().StatusCode);

        }

       
        /// <summary>
        /// Metodo que prueba el resultado de exito del 
        /// metodo ObtenerLogroPartidoPorId de DaoLogroPartido
        /// </summary>
       [Test]
        public void PruebaDaoObtenerLogroPartidoPorId()
        {
            ////AQUI TENGO QUE TENER EL PARTIDO AGREGADO
            Partido partido = FabricaEntidades.CrearPartido();
            partido.Id = 15; //cambiar numero por 1
            respuesta = ((DAOLogroPartido)dao).ObtenerLogroPartidoPorId(partido);

            Assert.IsNotNull(respuesta);
        }
        

        /// <summary>
        /// Metodo que prueba el resultado exitoso del 
        /// comando ObtenerLogroPartidoPorId
        /// </summary>
        [Test]
        public void PruebaCmdObtenerLogroPartidoPorId()
        {

            Partido partido = FabricaEntidades.CrearPartido();
            partido.Id = 15; //cambiar numero por 1
            comando = FabricaComando.CrearComandoObtenerLogroPartidoPorId(partido);
            comando.Ejecutar();
            respuesta = comando.GetEntidad();
            Assert.IsNotNull(respuesta);

        }

        /// <summary>
        /// Metodo que prueba el resultado de exito del 
        /// metodo ObtenerLogroPartidoPorId de
        ///LogroController
        /// </summary>
        [Test]
        public void PruebaCtrObtenerLogroPartidoPorId()
        {
            DTOListaPartidosLogros dto = FabricaDTO.CrearDTOListaPartidosLogros();
            dto.IdPartido = 14;

            Assert.AreEqual(HttpStatusCode.OK, controller.ObtenerLogroPartidoPorId(dto).StatusCode);

        }
        /// <summary>
        /// Metodo que prueba el resultado de exito del comando
        /// AsignarResultadoLogroVF
        /// </summary>
        [Test]
        public void PruebaCmdAsignarResultadoLogroVF()
        {

            LogroVoF logro = FabricaEntidades.CrearLogroVoF();

            logro.Id = 52;//cambiar
            logro.Respuesta = true;

            comando = FabricaComando.CrearComandoAsignarResultadoLogroVF(logro);
            comando.Ejecutar();

            respuesta = comando.GetEntidad();
            Assert.IsNotNull(respuesta);

        }


        [TearDown]
        public void TearDown()
        {
            dao.Desconectar();
            dao = null;
            comando = null;
            respuesta = null;
            _respuestas = null;

        }
    }
}
