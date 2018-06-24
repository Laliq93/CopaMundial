using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Servicios.DTO.Partidos;
using CopaMundialAPI.Comun.Entidades.Fabrica;

namespace CopaMundialAPI.Servicios.Traductores.Partidos
{
    public class TraductorRecibirIdPartido : TraductorGenerico<DTORecibirIdPartido>
    {
        public override DTORecibirIdPartido CrearDto(Entidad entidad)
        {
            throw new NotImplementedException();
        }

        public override Entidad CrearEntidad(DTORecibirIdPartido dto)
        {
            Partido partido = new Partido();

            partido.Id = dto.IdPartido;

            return partido;
        }

        public override List<DTORecibirIdPartido> CrearListaDto(List<Entidad> entidades)
        {
            throw new NotImplementedException();
        }

        public override List<Entidad> CrearListaEntidades(List<DTORecibirIdPartido> dtos)
        {
            throw new NotImplementedException();
        }
    }
}