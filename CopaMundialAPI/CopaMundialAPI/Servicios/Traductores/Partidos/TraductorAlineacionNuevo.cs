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
    public class TraductorAlineacionNuevo : TraductorGenerico<DTOAlineacionNuevo>
    {
        Logger logger = LogManager.GetLogger("fileLogger");

        public override DTOAlineacionNuevo CrearDto(Entidad entidad)
        {
            if (!(entidad is Alineacion alineacion))
            {
                logger.Error("Casteo invalido de la entidad " + entidad + " a Alineacion");
                throw new CasteoInvalidoException("La entidad no es del tipo Alineacion");
            }

            DTOAlineacionNuevo dto = FabricaDTO.CrearDTOAlineacionNuevo();

            dto.Equipo = alineacion.Equipo.Id;
            dto.Jugador = alineacion.Jugador.Id;
            dto.Partido = alineacion.Partido.Id;

            dto.EsCapitan = alineacion.EsCapitan;
            dto.EsTitular = alineacion.EsTitular;
            dto.Posicion = alineacion.Posicion;

            return dto;
        }

        public override Entidad CrearEntidad(DTOAlineacionNuevo dto)
        {
            Alineacion alineacion = FabricaEntidades.CrearAlineacion();
            alineacion.Equipo = FabricaEntidades.CrearEquipo();
            alineacion.Partido = FabricaEntidades.CrearPartido();
            alineacion.Jugador = FabricaEntidades.CrearJugador();

            alineacion.EsCapitan = dto.EsCapitan;
            alineacion.EsTitular = dto.EsTitular;
            alineacion.Equipo.Id = dto.Equipo;
            alineacion.Partido.Id = dto.Partido;
            alineacion.Posicion = dto.Posicion;
            alineacion.Jugador.Id = dto.Jugador;

            return alineacion;
        }

        public override List<DTOAlineacionNuevo> CrearListaDto(List<Entidad> entidades)
        {
            List<DTOAlineacionNuevo> _respuesta = new List<DTOAlineacionNuevo>();

            foreach (Alineacion alineacion in entidades)
            {
                _respuesta.Add(this.CrearDto(alineacion));
            }

            return _respuesta;
        }

        public override List<Entidad> CrearListaEntidades(List<DTOAlineacionNuevo> dtos)
        {
            List<Entidad> _respuesta = new List<Entidad>();

            foreach (DTOAlineacionNuevo dto in dtos)
            {
                _respuesta.Add(this.CrearEntidad(dto));
            }

            return _respuesta;
        }
    }
}