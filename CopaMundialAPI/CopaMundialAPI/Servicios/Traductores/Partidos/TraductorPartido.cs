using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Comun.Excepciones;
using CopaMundialAPI.Servicios.DTO.Partidos;
using CopaMundialAPI.Servicios.Fabrica;
using CopaMundialAPI.Servicios.Traductores.Equipos;
using CopaMundialAPI.Servicios.Traductores.Estadios;
using CopaMundialAPI.Servicios.Traductores.Fabrica;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Servicios.Traductores.Partidos
{
    public class TraductorPartido : TraductorGenerico<DTOPartido>
    {
        Logger logger = LogManager.GetLogger("fileLogger");

        public override DTOPartido CrearDto(Entidad entidad)
        {
            if (!(entidad is Partido partido))
            {
                logger.Error("Casteo invalido de la entidad " + entidad.ToString() + " a Partido");
                throw new CasteoInvalidoException("La entidad no es del tipo Partido");
            }

            DTOPartido dto = FabricaDTO.CrearDTOPartido();

            TraductorEquipo traductorEquipo = FabricaTraductor.CrearTraductorEquipo();
            dto.Equipo1 = traductorEquipo.CrearDto(partido.Equipo1);
            dto.Equipo2 = traductorEquipo.CrearDto(partido.Equipo2);

            TraductorEstadio traductorEstadio = FabricaTraductor.CrearTraductorEstadio();
            dto.Estadio = traductorEstadio.CrearDto(partido.Estadio);

            TraductorAlineacion traductorAlineacion = FabricaTraductor.CrearTraductorAlineacion();
            dto.Alineaciones = traductorAlineacion.CrearListaDto(partido.Alineaciones.Cast<Entidad>().ToList());

            dto.FechaInicioPartido = partido.FechaInicioPartido;
            dto.FechaFinPartido = partido.FechaFinPartido;
            dto.Arbitro = partido.Arbitro;
            dto.Id = partido.Id;

            return dto;
        }

        public override Entidad CrearEntidad(DTOPartido dto)
        {
            Partido partido = FabricaEntidades.CrearPartido();

            partido.Equipo1.Id = dto.Equipo1.Id;
            partido.Equipo2.Id = dto.Equipo2.Id;
            partido.Estadio.Id = dto.Estadio.Id;
            partido.FechaFinPartido = dto.FechaFinPartido;
            partido.FechaInicioPartido = dto.FechaInicioPartido;
            partido.Id = dto.Id;
            partido.Arbitro = dto.Arbitro;

            return partido;
        }

        public override List<DTOPartido> CrearListaDto(List<Entidad> entidades)
        {
            List<DTOPartido> _respuesta = new List<DTOPartido>();

            foreach (Partido partido in entidades)
            {
                _respuesta.Add(this.CrearDto(partido));
            }

            return _respuesta;
        }

        public override List<Entidad> CrearListaEntidades(List<DTOPartido> dtos)
        {
            List<Entidad> _respuesta = new List<Entidad>();

            foreach (DTOPartido dto in dtos)
            {
                _respuesta.Add(this.CrearEntidad(dto));
            }

            return _respuesta;
        }
    }
}