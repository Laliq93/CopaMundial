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

namespace CopaMundialAPI.Presentacion.Controllers
{
    [RoutePrefix("api/Apuesta")]
    public class ApuestaController : ApiController
    {
        [Route("Testing")]
        [System.Web.Http.AcceptVerbs("GET", "PUT")]
        [System.Web.Http.HttpPut]
        public HttpResponseMessage Testing()
        {
            TraductorApuestaVOF traductor = new TraductorApuestaVOF();

            Entidad apostador = new Usuario();

            apostador.Id = 1;

            Comando comando = FabricaComando.CrearComandoObtenerApuestasVoFEnCurso(apostador);

            comando.Ejecutar();
           
            List<DTOApuestaVOF> dtos = traductor.CrearListaDto(comando.GetEntidades());

            return Request.CreateResponse(HttpStatusCode.OK, dtos);
        }
    }
}
