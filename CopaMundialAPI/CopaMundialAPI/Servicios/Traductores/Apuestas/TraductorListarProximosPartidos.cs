using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Servicios.DTO.Apuestas;
using CopaMundialAPI.Servicios.Fabrica;

namespace CopaMundialAPI.Servicios.Traductores.Apuestas
{
    public class TraductorListarProximosPartidos : TraductorGenerico<DTOListarProximosPartidos>
    {
        public override DTOListarProximosPartidos CrearDto(Entidad entidad)
        {
            Partido partido = entidad as Partido;

            DTOListarProximosPartidos dto = FabricaDTO.CrearDTOListarProximosPartidos();

            dto.IdPartido = partido.Id;
            dto.Equipo1 = partido.Equipo1.Pais;
            dto.Equipo2 = partido.Equipo2.Pais;
            dto.Fecha = partido.FechaInicioPartido.ToShortDateString();

            return dto;

        }

        public override Entidad CrearEntidad(DTOListarProximosPartidos dto)
        {
            throw new NotImplementedException();
        }

        public override List<DTOListarProximosPartidos> CrearListaDto(List<Entidad> entidades)
        {
            List<DTOListarProximosPartidos> dtos = new List<DTOListarProximosPartidos>();

            foreach(Entidad partido in entidades)
            {
                dtos.Add(CrearDto(partido));
            }

            return dtos;
        }

        public override List<Entidad> CrearListaEntidades(List<DTOListarProximosPartidos> dtos)
        {
            throw new NotImplementedException();
        }
    }
}