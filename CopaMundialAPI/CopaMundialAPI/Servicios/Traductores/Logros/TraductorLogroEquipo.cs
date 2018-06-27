using System;
using System.Collections.Generic;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Servicios.DTO.Logros;
using CopaMundialAPI.Servicios.Fabrica;


namespace CopaMundialAPI.Servicios.Traductores.Logros
{
    public class TraductorLogroEquipo: TraductorGenerico<DTOLogroEquipo>
    {

        /// <summary>
        /// Metodo que sirve para convertir de una entidad a un dto
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        public override DTOLogroEquipo CrearDto(Entidad entidad)
        {
            DTOLogroEquipo dto = FabricaDTO.CrearDTOLogroEquipo();

            LogroEquipo logroEquipo = entidad as LogroEquipo;

            dto.IdPartido = logroEquipo.Partido.Id;
            dto.LogroEquipo = logroEquipo.Logro;
            dto.TipoLogro = (int)logroEquipo.IdTipo;

            return dto;
        }


        /// <summary>
        /// Metodo que sirve para convertir un dto en una entidad
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public override Entidad CrearEntidad(DTOLogroEquipo dto)
        {
            LogroEquipo entidad = FabricaEntidades.CrearLogroEquipo();
            Partido partido = FabricaEntidades.CrearPartido();
            entidad.IdTipo = TipoLogro.equipo;
            entidad.Partido = partido;
            entidad.Partido.Id = dto.IdPartido;
            entidad.Logro = dto.LogroEquipo;

            return entidad;
        }

        public override List<DTOLogroEquipo> CrearListaDto(List<Entidad> entidades)
        {
            throw new NotImplementedException();
        }

        public override List<Entidad> CrearListaEntidades(List<DTOLogroEquipo> dtos)
        {
            throw new NotImplementedException();
        }
    }
}