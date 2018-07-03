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
    public class TraductorPartidoActualizar : TraductorGenerico<DTOPartidoActualizar>
    {
        Logger logger = LogManager.GetLogger("fileLogger");

        public override DTOPartidoActualizar CrearDto(Entidad entidad)
        {
            if (!(entidad is Partido partido))
            {
                logger.Error("Casteo invalido de la entidad " + entidad + " a Partido");
                throw new CasteoInvalidoException("La entidad no es del tipo Partido");
            }

            DTOPartidoActualizar dto = FabricaDTO.CrearDTOPartidoActualizar();

            dto.Equipo1 = partido.Equipo1.Id;
            dto.Equipo2 = partido.Equipo2.Id;
            dto.Estadio = partido.Estadio.Id;
            dto.FechaInicioPartido = partido.FechaInicioPartido;
            dto.FechaFinPartido = partido.FechaFinPartido;
            dto.Arbitro = partido.Arbitro;
            dto.Id = partido.Id;

            return dto;
        }

        public override Entidad CrearEntidad(DTOPartidoActualizar dto)
        {
            Partido partido = FabricaEntidades.CrearPartido();

            partido.Equipo1 = FabricaEntidades.CrearEquipo();
            partido.Equipo2 = FabricaEntidades.CrearEquipo();
            partido.Estadio = FabricaEntidades.CrearEstadio();

            partido.Equipo1.Id = dto.Equipo1;
            partido.Equipo2.Id = dto.Equipo2;
            partido.Estadio.Id = dto.Estadio;
            partido.FechaFinPartido = dto.FechaFinPartido;
            partido.FechaInicioPartido = dto.FechaInicioPartido;
            partido.Id = dto.Id;
            partido.Arbitro = dto.Arbitro;

            return partido;
        }

        public override List<DTOPartidoActualizar> CrearListaDto(List<Entidad> entidades)
        {
            List<DTOPartidoActualizar> _respuesta = new List<DTOPartidoActualizar>();

            foreach (Partido partido in entidades)
            {
                _respuesta.Add(this.CrearDto(partido));
            }

            return _respuesta;
        }

        public override List<Entidad> CrearListaEntidades(List<DTOPartidoActualizar> dtos)
        {
            List<Entidad> _respuesta = new List<Entidad>();

            foreach (DTOPartidoActualizar dto in dtos)
            {
                _respuesta.Add(this.CrearEntidad(dto));
            }

            return _respuesta;
        }
    }
}