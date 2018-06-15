using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Servicios.Traductores
{
    public abstract class TraductorGenerico <TDto, TEntidad>
    {
        public abstract TDto CrearDto(TEntidad entidad);

        public abstract TEntidad CrearEntidad(TDto dto);

        public abstract List<TDto> CrearListaDto(List<TEntidad> entidades);

        public abstract List<TEntidad> CrearListaEntidades(List<TDto> dtos);
    }
}