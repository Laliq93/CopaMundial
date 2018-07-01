using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Comun.Excepciones;
using CopaMundialAPI.Servicios.DTO.Partidos;
using CopaMundialAPI.Servicios.Fabrica;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Servicios.Traductores.Partidos
{
    public class TraductorPartidoFecha : TraductorGenerico<DTOPartidoFecha>
    {
        Logger logger = LogManager.GetLogger("fileLogger");

        public override DTOPartidoFecha CrearDto(Entidad entidad)
        {
            if (!(entidad is Partido partido))
            {
                logger.Error("Casteo invalido de la entidad " + entidad.ToString() + " a Partido");
                throw new CasteoInvalidoException("La entidad no es del tipo Partido");
            }

            DTOPartidoFecha dto = FabricaDTO.CrearDTOPartidoFecha();
            dto.FechaInicioPartido = partido.FechaInicioPartido;

            return dto;
        }

        public override Entidad CrearEntidad(DTOPartidoFecha dto)
        {
            Partido partido = FabricaEntidades.CrearPartido();

            partido.FechaInicioPartido = dto.FechaInicioPartido;

            return partido;
        }

        public override List<DTOPartidoFecha> CrearListaDto(List<Entidad> entidades)
        {
            List<DTOPartidoFecha> _respuesta = new List<DTOPartidoFecha>();

            foreach (Partido partido in entidades)
            {
                _respuesta.Add(this.CrearDto(partido));
            }

            return _respuesta;
        }

        public override List<Entidad> CrearListaEntidades(List<DTOPartidoFecha> dtos)
        {
            List<Entidad> _respuesta = new List<Entidad>();

            foreach (DTOPartidoFecha dto in dtos)
            {
                _respuesta.Add(this.CrearEntidad(dto));
            }

            return _respuesta;
        }
    }
}