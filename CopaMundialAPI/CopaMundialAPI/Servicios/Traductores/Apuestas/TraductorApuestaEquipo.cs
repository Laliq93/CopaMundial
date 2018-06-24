using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Servicios.DTO.Apuestas;

namespace CopaMundialAPI.Servicios.Traductores.Apuestas
{
    public class TraductorApuestaEquipo : TraductorGenerico<DTOApuestaEquipo>
    {
        public override DTOApuestaEquipo CrearDto(Entidad entidad)
        {
            throw new NotImplementedException();
        }

        public override Entidad CrearEntidad(DTOApuestaEquipo dto)
        {
            throw new NotImplementedException();
        }

        public override List<DTOApuestaEquipo> CrearListaDto(List<Entidad> entidades)
        {
            throw new NotImplementedException();
        }

        public override List<Entidad> CrearListaEntidades(List<DTOApuestaEquipo> dtos)
        {
            throw new NotImplementedException();
        }
    }
}