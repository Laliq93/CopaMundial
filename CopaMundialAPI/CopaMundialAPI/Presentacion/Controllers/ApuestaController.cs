using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;
using CopaMundialAPI.Logica_de_Negocio.Fabrica;
using CopaMundialAPI.Logica_de_Negocio.Comando;
using CopaMundialAPI.Servicios.DTO.Apuestas;
using CopaMundialAPI.Servicios.Fabrica;
using CopaMundialAPI.Servicios.Traductores.Apuestas;
using CopaMundialAPI.Servicios.Traductores.Partidos;
using CopaMundialAPI.Servicios.Traductores.Fabrica;
using CopaMundialAPI.Servicios.DTO.Partidos;

namespace CopaMundialAPI.Presentacion.Controllers
{
    [RoutePrefix("api/Apuesta")]
    public class ApuestaController : ApiController
    {
        [Route("obtenerproximospartidos")]
        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage ObtenerProximosPartidos()
        {
            TraductorListarProximosPartidos traductor = FabricaTraductor.CrearTraductorListarProximosPartidos();

            Comando comando = FabricaComando.CrearComandoObtenerProximosPartidos();

            comando.Ejecutar();

            List<DTOListarProximosPartidos> dtos = traductor.CrearListaDto(comando.GetEntidades());

            return Request.CreateResponse(HttpStatusCode.OK, dtos);
        }

        [Route("obtenerlogrosvofpartido")]
        [System.Web.Http.AcceptVerbs("GET", "PUT")]
        [System.Web.Http.HttpPut]
        public HttpResponseMessage obtenerlogrosvofpartido(DTORecibirIdPartido dto)
        {
            TraductorListarProximosPartidos traductor = FabricaTraductor.CrearTraductorListarProximosPartidos();

            Comando comando = FabricaComando.CrearComandoObtenerProximosPartidos();

            comando.Ejecutar();

            List<DTOListarProximosPartidos> dtos = traductor.CrearListaDto(comando.GetEntidades());

            return Request.CreateResponse(HttpStatusCode.OK, dtos);
        }


    }
}
