using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Servicios.DTO.Partidos;
using CopaMundialAPI.Servicios.Fabrica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Servicios.Traductores.Partidos
{
    public class TraductorPartidoSoloId : TraductorGenerico<DTOPartidoSoloId>
    {
        public override DTOPartidoSoloId CrearDto(Entidad entidad)
        {
            DTOPartidoSoloId dto = FabricaDTO.CrearDTOPartidoSoloId();

            dto.Id = entidad.Id;
            return dto;
        }

        public override Entidad CrearEntidad(DTOPartidoSoloId dto)
        {
            Partido partido = FabricaEntidades.CrearPartido();
            partido.Id = dto.Id;

            return partido;
        }

        public override List<DTOPartidoSoloId> CrearListaDto(List<Entidad> entidades)
        {
            List<DTOPartidoSoloId> _respuesta = new List<DTOPartidoSoloId>();

            foreach (Partido partido in entidades)
            {
                _respuesta.Add(this.CrearDto(partido));
            }

            return _respuesta;
        }

        public override List<Entidad> CrearListaEntidades(List<DTOPartidoSoloId> dtos)
        {
            List<Entidad> _respuesta = new List<Entidad>();

            foreach (DTOPartidoSoloId dto in dtos)
            {
                _respuesta.Add(this.CrearEntidad(dto));
            }

            return _respuesta;
        }
    }
}