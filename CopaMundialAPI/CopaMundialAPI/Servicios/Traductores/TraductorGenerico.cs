using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;

namespace CopaMundialAPI.Servicios.Traductores
{
    public abstract class TraductorGenerico <TDto>
    {
        public abstract TDto CrearDto(Entidad entidad);

        public abstract Entidad CrearEntidad(TDto dto);

        public abstract List<TDto> CrearListaDto(List<Entidad> entidades);

        public abstract List<Entidad> CrearListaEntidades(List<TDto> dtos);
    }
}