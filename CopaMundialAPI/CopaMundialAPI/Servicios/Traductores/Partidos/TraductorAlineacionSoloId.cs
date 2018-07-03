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
    public class TraductorAlineacionSoloId : TraductorGenerico<DTOAlineacionSoloId>
    {
        public override DTOAlineacionSoloId CrearDto(Entidad entidad)
        {
            DTOAlineacionSoloId dto = FabricaDTO.CrearDTOAlineacionSoloId();

            dto.Id = entidad.Id;
            return dto;
        }

        public override Entidad CrearEntidad(DTOAlineacionSoloId dto)
        {
            Alineacion alineacion = FabricaEntidades.CrearAlineacion();
            alineacion.Id = dto.Id;

            return alineacion;
        }

        public override List<DTOAlineacionSoloId> CrearListaDto(List<Entidad> entidades)
        {
            List<DTOAlineacionSoloId> _respuesta = new List<DTOAlineacionSoloId>();

            foreach (Alineacion alineacion in entidades)
            {
                _respuesta.Add(this.CrearDto(alineacion));
            }

            return _respuesta;
        }

        public override List<Entidad> CrearListaEntidades(List<DTOAlineacionSoloId> dtos)
        {
            List<Entidad> _respuesta = new List<Entidad>();

            foreach (DTOAlineacionSoloId dto in dtos)
            {
                _respuesta.Add(this.CrearEntidad(dto));
            }

            return _respuesta;
        }
    }
}