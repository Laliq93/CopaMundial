using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Comun.Excepciones;
using CopaMundialAPI.Servicios.DTO.Partidos;
using CopaMundialAPI.Servicios.Fabrica;
using CopaMundialAPI.Servicios.Traductores.Equipo;
using CopaMundialAPI.Servicios.Traductores.Equipos;
using CopaMundialAPI.Servicios.Traductores.Fabrica;
using CopaMundialAPI.Servicios.Traductores.Jugadores;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Servicios.Traductores.Partidos
{
    public class TraductorAlineacion : TraductorGenerico<DTOAlineacion>
    {
        Logger logger = LogManager.GetLogger("fileLogger");

        public override DTOAlineacion CrearDto(Entidad entidad)
        {
            if (!(entidad is Alineacion alineacion))
            {
                logger.Error("Casteo invalido de la entidad " + entidad.ToString() + " a Alineacion");
                throw new CasteoInvalidoException("La entidad no es del tipo Alineacion");
            }

            DTOAlineacion dto = FabricaDTO.CrearDTOAlineacion();

            TraductorEquipo traductorEquipo = FabricaTraductor.CrearTraductorEquipo();
            dto.Equipo = traductorEquipo.CrearDto(alineacion.Equipo);

            TraductorJugador traductorJugador = FabricaTraductor.CrearTraductorJugador();
            dto.Jugador = traductorJugador.CrearDto(alineacion.Jugador);

            dto.Partido.Id = alineacion.Partido.Id;
            dto.EsCapitan = alineacion.EsCapitan;
            dto.EsTitular = alineacion.EsTitular;
            dto.Id = alineacion.Id;
            dto.Posicion = alineacion.Posicion;

            return dto;
        }

        public override Entidad CrearEntidad(DTOAlineacion dto)
        {
            Alineacion alineacion = FabricaEntidades.CrearAlineacion();

            alineacion.EsCapitan = dto.EsCapitan;
            alineacion.EsTitular = dto.EsTitular;
            alineacion.Equipo.Id = dto.Equipo.Id;
            alineacion.Partido.Id = dto.Partido.Id;
            alineacion.Id = dto.Id;
            alineacion.Posicion = dto.Posicion;

            return alineacion;
        }

        public override List<DTOAlineacion> CrearListaDto(List<Entidad> entidades)
        {
            List<DTOAlineacion> _respuesta = new List<DTOAlineacion>();

            foreach (Alineacion alineacion in entidades)
            {
                _respuesta.Add(this.CrearDto(alineacion));
            }

            return _respuesta;
        }

        public override List<Entidad> CrearListaEntidades(List<DTOAlineacion> dtos)
        {
            List<Entidad> _respuesta = new List<Entidad>();

            foreach (DTOAlineacion dto in dtos)
            {
                _respuesta.Add(this.CrearEntidad(dto));
            }

            return _respuesta;
        }
    }
}