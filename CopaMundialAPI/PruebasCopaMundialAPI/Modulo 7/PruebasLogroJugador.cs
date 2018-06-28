using System.Collections.Generic;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Comun.Excepciones;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;
using CopaMundialAPI.Logica_de_Negocio.Comando;
using CopaMundialAPI.Logica_de_Negocio.Fabrica;
using CopaMundialAPI.Servicios.DTO.Logros;
using CopaMundialAPI.Servicios.Fabrica;
using CopaMundialAPI.Servicios.Traductores.Logros;
using CopaMundialAPI.Servicios.Traductores.Fabrica;
using CopaMundialAPI.Presentacion.Controllers;
using NUnit.Framework;
using System.Net.Http;
using System.Net;
using System.Web.Http;

namespace PruebasCopaMundialAPI.Modulo_7
{
    [TestFixture]
    public class PruebasLogroJugador
    {
  
        private DAO dao;
        private Comando comando;
        private Entidad respuesta;
        private List<Entidad> _respuestas;
        private LogrosController controller;

        [SetUp]
        public void SetUp()
        {
            dao = FabricaDAO.CrearDAOLogroJugador();
            dao.StoredProcedure("AsignarLogroPU(500,'PruebaLogroJugador',1,1)");
            dao.EjecutarQuery();
            dao.Conectar();
            controller = new LogrosController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

        }


        /// <summary>
        /// Metodo que prueba el resultado de exito
        /// del dao de Agregar logrocantidad
        /// </summary>
        [Test]
        public void PruebaDaoLogroJugadorAgregar()
        {

            LogroJugador logro = FabricaEntidades.CrearLogroJugador();
            Partido partido = FabricaEntidades.CrearPartido();
            logro.Partido = partido;
            logro.Partido.Id = 14; //cambiar por 1
            logro.IdTipo = TipoLogro.jugador;
            logro.Logro = "Logro Jugador Prueba Agregar";


            ((DAOLogroJugador)dao).Agregar(logro);
            respuesta = FabricaEntidades.CrearLogroJugador();

            respuesta = ((DAOLogroJugador)dao).ObtenerLogroPorId(logro);

            Assert.IsNotNull(respuesta);
        }

        /// <summary>
        /// Metodo que prueba el resultado de exito del 
        /// comando logroCantidadAgregar
        /// </summary>
        [Test]
        public void PruebaComandoLogroJugadorAgregar()
        {

            LogroJugador logro = FabricaEntidades.CrearLogroJugador();
            Partido partido = FabricaEntidades.CrearPartido();

            logro.Partido = partido;
            logro.Partido.Id = 14; //cambiar a 1
            logro.IdTipo = TipoLogro.jugador;
            logro.Logro = "Logro jugador Prueba Comando agregar";

            comando = FabricaComando.CrearComandoAgregarLogroJugador(logro);
            comando.Ejecutar();
            respuesta = comando.GetEntidad();
            Assert.IsNotNull(respuesta);

        }

        /// <summary>
        /// Metodo que prueba la traduccion de una entidad 
        /// a un dtoLogroJugador
        /// </summary>
        [Test]
        public void PruebaTraductorLogroJugadorDto()
        {
            TraductorLogroJugador traductor = FabricaTraductor.CrearTraductorLogroJugador();
            LogroJugador logro = FabricaEntidades.CrearLogroJugador();
            DTOLogroJugador dtoLogro = FabricaDTO.CrearDTOLogroJugador();

            Partido partido = FabricaEntidades.CrearPartido();
            logro.Partido = partido;
            logro.Partido.Id = 1;
            logro.IdTipo = TipoLogro.jugador;
            logro.Logro = "Logro Prueba Traductor";

            dtoLogro = traductor.CrearDto(logro);
            
            Assert.AreEqual(1, dtoLogro.IdPartido);

        }

        /// <summary>
        /// Metodo que prueba la traduccion de un dtoLogroJugador
        /// a una entidad logroJugador
        /// </summary>
        [Test]
        public void PruebaTraductorLogroJugadorEntidad()//NO ESTA IMPLEMENTADO EL TRADUCTOR TODAVIA
        {
            TraductorLogroJugador traductor = FabricaTraductor.CrearTraductorLogroJugador();
            LogroJugador logro = FabricaEntidades.CrearLogroJugador();
            DTOLogroJugador dtoLogro = FabricaDTO.CrearDTOLogroJugador();

            dtoLogro.IdPartido = 1;
            dtoLogro.LogroJugador = "Prueba de dto a entidad logro jugador";
            dtoLogro.TipoLogro = (int)TipoLogro.jugador;

            logro = (LogroJugador)traductor.CrearEntidad(dtoLogro);

            Assert.AreEqual(1, logro.Partido.Id);

        }

        /// <summary>
        /// Metodo que prueba la respuesta exitosa de
        ///del metodo agregarLogrojugador del 
        ///LogroCotroller
        /// </summary>
        [Test]
        public void PruebaControllerAgregarLogroJugador()
        {
            DTOLogroJugador dtoLogro = FabricaDTO.CrearDTOLogroJugador();
            dtoLogro.IdPartido = 14; //cambiar a 1
            dtoLogro.LogroJugador = "Prueba controller Agregar logro jugador";
            dtoLogro.TipoLogro = (int)TipoLogro.jugador;

            Assert.AreEqual(HttpStatusCode.OK, controller.AgregarLogroJugador(dtoLogro).StatusCode);
            
        }

        /// <summary>
        /// Metodo que prueba el resultado de exito 
        /// del dao ObtenerLogrosPendientes
        /// </summary>
        [Test]
        public void PruebaDaoObtenerLogrosJugadorPendientes()
        {

            Partido partido = FabricaEntidades.CrearPartido();
            partido.Id = 14; //cambiar por 1

            _respuestas = ((DAOLogroJugador)dao).ObtenerLogrosPendientes(partido);
            Assert.IsNotNull(_respuestas);
        }


        /// <summary>
        /// Metodo que prueba el resultado de la
        /// excepcion LogrosPendientesNoExisteException
        /// en el Dao
        /// </summary>
        [Test]
        public void PruebaDaoObtenerLogrosJugadorPendientesException()
        {

            Partido partido = FabricaEntidades.CrearPartido();
            partido.Id = 15; //cambiar numero

            Assert.Throws<LogrosPendientesNoExisteException>(() => ((DAOLogroJugador)dao).ObtenerLogrosPendientes(partido));
        }

        /// <summary>
        /// Metodo que prueba el resultado de exito del 
        /// comando ObtenerLogrosJugadorPendientes
        /// </summary>
        [Test]
        public void PruebaComandoObtenerLogrosJugadorPendientes()
        {
            Partido partido = FabricaEntidades.CrearPartido();

            partido.Id = 14; //cambiar a 1

            comando = FabricaComando.CrearComandoObtenerLogrosJugadorPendientes(partido);
            comando.Ejecutar();
            _respuestas = comando.GetEntidades();
            Assert.AreNotEqual(0, _respuestas.Count);

        }

        /// <summary>
        /// Metodo que prueba el resultado de la
        /// excepcion LogrosPendientesNoExisteException en el
        /// comando
        /// </summary>
        [Test]
        public void PruebaCmdObtenerLogrosJugadorPendientesException()
        {

            Partido partido = FabricaEntidades.CrearPartido();
            partido.Id = 15; //cambiar numero

            comando = FabricaComando.CrearComandoObtenerLogrosJugadorPendientes(partido);
            Assert.Throws<LogrosPendientesNoExisteException>(() => comando.Ejecutar());
        }



        /// <summary>
        /// Metodo que prueba la respuesta exitosa del
        /// metodo ObtenerLogrosJugadorPendiente del 
        /// LogroController
        /// </summary>
        [Test]
        public void PruebaControllerObtenerLogrosJugadorPendiente()
        {
            DTOLogroPartidoId dtoLogroPartidoId = FabricaDTO.CrearDTOLogroPartidoId();
            dtoLogroPartidoId.IdPartido = 14;//Cambiar

            Assert.AreEqual(HttpStatusCode.OK, controller.ObtenerLogrosJugadorPendientes(dtoLogroPartidoId).StatusCode);

        }


        /// <summary>
        /// Metodo que prueba la excepcion Logros
        /// pendientes not found exception del metodo 
        /// ObtenerLogrosJugadorPendientes de
        /// LogrosController
        /// </summary>
        [Test]
        public void PruebaControllerObtenerLogrosJugadorPendienteExc()
        {
            DTOLogroPartidoId dtoLogroPartidoId = FabricaDTO.CrearDTOLogroPartidoId();
            dtoLogroPartidoId.IdPartido = 16;//Cambiar
            Assert.AreEqual(HttpStatusCode.InternalServerError, controller.ObtenerLogrosJugadorPendientes(dtoLogroPartidoId).StatusCode);

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
