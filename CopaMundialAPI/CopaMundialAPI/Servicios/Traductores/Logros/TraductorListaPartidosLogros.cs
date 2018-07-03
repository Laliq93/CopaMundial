using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Servicios.DTO.Logros;
using CopaMundialAPI.Servicios.Fabrica;
using System;
using System.Collections.Generic;

namespace CopaMundialAPI.Servicios.Traductores.Logros
{
    public class TraductorListaPartidosLogros : TraductorGenerico<DTOListaPartidosLogros>
    {


        public override DTOListaPartidosLogros CrearDto(Entidad entidad)
        {
            Partido partido = entidad as Partido;

            DTOListaPartidosLogros dto = FabricaDTO.CrearDTOListaPartidosLogros();

            dto.IdPartido = partido.Id;
            dto.Equipo1 = partido.Equipo1.Pais;
            dto.Equipo2 = partido.Equipo2.Pais;
            dto.Fecha = partido.FechaInicioPartido.ToShortDateString();
            dto.IdEquipo1 = partido.Equipo1.Id;
            dto.IdEquipo2 = partido.Equipo1.Id;

            return dto;

        }

        public override Entidad CrearEntidad(DTOListaPartidosLogros dto)
        {
            Partido partido = FabricaEntidades.CrearPartido();
            
            partido.Id = dto.IdPartido;
            

            return partido;
        }

        public override List<DTOListaPartidosLogros> CrearListaDto(List<Entidad> entidades)
        {
            List<DTOListaPartidosLogros> dtos = new List<DTOListaPartidosLogros>();

            foreach (Entidad partido in entidades)
            {
                dtos.Add(CrearDto(partido));
            }

            return dtos;
        }

        public override List<Entidad> CrearListaEntidades(List<DTOListaPartidosLogros> dtos)
        {
            throw new NotImplementedException();
        }
    }
}
