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
    public class TraductorAlineacionActualizar : TraductorGenerico<DTOAlineacionActualizar>
    {
        Logger logger = LogManager.GetLogger("fileLogger");

        public override DTOAlineacionActualizar CrearDto(Entidad entidad)
        {
            if (!(entidad is Alineacion alineacion))
            {
                logger.Error("Casteo invalido de la entidad " + entidad + " a Alineacion");
                throw new CasteoInvalidoException("La entidad no es del tipo Alineacion");
            }

            DTOAlineacionActualizar dto = FabricaDTO.CrearDTOAlineacionActualizar();

            dto.Equipo = alineacion.Equipo.Id;
            dto.Jugador = alineacion.Jugador.Id;
            dto.Partido = alineacion.Partido.Id;

            dto.EsCapitan = alineacion.EsCapitan;
            dto.EsTitular = alineacion.EsTitular;
            dto.Id = alineacion.Id;
            dto.Posicion = alineacion.Posicion;

            return dto;
        }

        public override Entidad CrearEntidad(DTOAlineacionActualizar dto)
        {
            Alineacion alineacion = FabricaEntidades.CrearAlineacion();
            alineacion.Equipo = FabricaEntidades.CrearEquipo();
            alineacion.Partido = FabricaEntidades.CrearPartido();
            alineacion.Jugador = FabricaEntidades.CrearJugador();

            alineacion.EsCapitan = dto.EsCapitan;
            alineacion.EsTitular = dto.EsTitular;
            alineacion.Equipo.Id = dto.Equipo;
            alineacion.Partido.Id = dto.Partido;
            alineacion.Id = dto.Id;
            alineacion.Posicion = dto.Posicion;
            alineacion.Jugador.Id = dto.Jugador;

            return alineacion;
        }

        public override List<DTOAlineacionActualizar> CrearListaDto(List<Entidad> entidades)
        {
            List<DTOAlineacionActualizar> _respuesta = new List<DTOAlineacionActualizar>();

            foreach (Alineacion alineacion in entidades)
            {
                _respuesta.Add(this.CrearDto(alineacion));
            }

            return _respuesta;
        }

        public override List<Entidad> CrearListaEntidades(List<DTOAlineacionActualizar> dtos)
        {
            List<Entidad> _respuesta = new List<Entidad>();

            foreach (DTOAlineacionActualizar dto in dtos)
            {
                _respuesta.Add(this.CrearEntidad(dto));
            }

            return _respuesta;
        }
    }
}