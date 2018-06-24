using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Servicios.DTO.Partidos;
using CopaMundialAPI.Servicios.Fabrica;

namespace CopaMundialAPI.Servicios.Traductores.Partidos
{
    public class TraductorListarProximosPartidos : TraductorGenerico<DTOListarProximosPartidos>
    {
        public override DTOListarProximosPartidos CrearDto(Entidad entidad)
        {
            throw new NotImplementedException();
        }

        public override Entidad CrearEntidad(DTOListarProximosPartidos dto)
        {
            throw new NotImplementedException();
        }

        public override List<DTOListarProximosPartidos> CrearListaDto(List<Entidad> entidades)
        {
            throw new NotImplementedException();
        }

        public override List<Entidad> CrearListaEntidades(List<DTOListarProximosPartidos> dtos)
        {
            throw new NotImplementedException();
        }
    }
}