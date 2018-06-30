using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Servicios.DTO.Logros;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Comun.Excepciones;

namespace CopaMundialAPI.Servicios.Traductores.Logros
{
    public class TraductorLogroPartidoId: TraductorGenerico<DTOLogroPartidoId>
    {


        public override DTOLogroPartidoId CrearDto(Entidad entidad)
        {
            throw new NotImplementedException();
        }

        public override Entidad CrearEntidad(DTOLogroPartidoId dto)
        {

                Entidad partido = FabricaEntidades.CrearPartido();

                partido.Id = dto.IdPartido;

                return partido;

        }

        public override List<DTOLogroPartidoId> CrearListaDto(List<Entidad> entidades)
        {
            throw new NotImplementedException();
        }

        public override List<Entidad> CrearListaEntidades(List<DTOLogroPartidoId> dtos)
        {
            throw new NotImplementedException();
        }
    }
}