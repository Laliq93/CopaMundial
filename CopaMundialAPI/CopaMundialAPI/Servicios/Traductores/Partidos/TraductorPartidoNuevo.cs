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
    public class TraductorPartidoNuevo : TraductorGenerico<DTOPartidoNuevo>
    {
        Logger logger = LogManager.GetLogger("fileLogger");

        public override DTOPartidoNuevo CrearDto(Entidad entidad)
        {
            if (!(entidad is Partido partido))
            {
                logger.Error("Casteo invalido de la entidad " + entidad + " a Partido");
                throw new CasteoInvalidoException("La entidad no es del tipo Partido");
            }

            DTOPartidoNuevo dto = FabricaDTO.CrearDTOPartidoNuevo();

            dto.Equipo1 = partido.Equipo1.Id;
            dto.Equipo2 = partido.Equipo2.Id;
            dto.Estadio = partido.Estadio.Id;
            dto.FechaInicioPartido = partido.FechaInicioPartido;
            dto.FechaFinPartido = partido.FechaFinPartido;
            dto.Arbitro = partido.Arbitro;

            return dto;
        }

        public override Entidad CrearEntidad(DTOPartidoNuevo dto)
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
            partido.Arbitro = dto.Arbitro;

            return partido;
        }

        public override List<DTOPartidoNuevo> CrearListaDto(List<Entidad> entidades)
        {
            List<DTOPartidoNuevo> _respuesta = new List<DTOPartidoNuevo>();

            foreach (Partido partido in entidades)
            {
                _respuesta.Add(this.CrearDto(partido));
            }

            return _respuesta;
        }

        public override List<Entidad> CrearListaEntidades(List<DTOPartidoNuevo> dtos)
        {
            List<Entidad> _respuesta = new List<Entidad>();

            foreach (DTOPartidoNuevo dto in dtos)
            {
                _respuesta.Add(this.CrearEntidad(dto));
            }

            return _respuesta;
        }
    }
}