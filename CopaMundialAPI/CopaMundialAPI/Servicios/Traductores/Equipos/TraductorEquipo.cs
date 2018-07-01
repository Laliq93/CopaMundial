using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Comun.Excepciones;
using CopaMundialAPI.Servicios.DTO.Equipos;
using CopaMundialAPI.Servicios.Fabrica;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Servicios.Traductores.Equipos
{
    public class TraductorEquipo : TraductorGenerico<DTOEquipo>
    {
        Logger logger = LogManager.GetLogger("fileLogger");

        public override DTOEquipo CrearDto(Entidad entidad)
        {
            if (!(entidad is Comun.Entidades.Equipo equipo))
            {
                logger.Error("Casteo invalido de la entidad " + entidad.ToString() + " a Equipo");
                throw new CasteoInvalidoException("La entidad no es del tipo equipo");
            }

            DTOEquipo dto = FabricaDTO.CrearDTOEquipo();
            dto.Id = equipo.Id;
            dto.Pais = equipo.Pais;

            return dto;
        }

        public override Entidad CrearEntidad(DTOEquipo dto)
        {
            Comun.Entidades.Equipo equipo = FabricaEntidades.CrearEquipo();

            equipo.Id = dto.Id;
            equipo.Pais = dto.Pais;

            return equipo;
        }

        public override List<DTOEquipo> CrearListaDto(List<Entidad> entidades)
        {
            List<DTOEquipo> _respuesta = new List<DTOEquipo>();

            foreach(Comun.Entidades.Equipo equipo in entidades)
            {
                _respuesta.Add(this.CrearDto(equipo));
            }

            return _respuesta;
        }

        public override List<Entidad> CrearListaEntidades(List<DTOEquipo> dtos)
        {
            List<Entidad> _respuesta = new List<Entidad>();

            foreach(DTOEquipo dto in dtos)
            {
                _respuesta.Add(this.CrearEntidad(dto));
            }

            return _respuesta;
        }
    }
}