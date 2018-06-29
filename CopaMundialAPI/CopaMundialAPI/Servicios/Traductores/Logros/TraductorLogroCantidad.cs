using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Servicios.DTO.Logros;
using CopaMundialAPI.Servicios.Fabrica;

namespace CopaMundialAPI.Servicios.Traductores.Logros
{
    public class TraductorLogroCantidad : TraductorGenerico<DTOLogroCantidad>
    {
        /// <summary>
        /// Metodo que sirve para convertir de una entidad a un dto
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        public override DTOLogroCantidad CrearDto(Entidad entidad)
        {
            DTOLogroCantidad dto = FabricaDTO.CrearDTOLogroCantidad();

            LogroCantidad logroCantidad = entidad as LogroCantidad;
            
            dto.IdPartido = logroCantidad.Partido.Id;
            dto.LogroCantidad = logroCantidad.Logro;
            dto.TipoLogro = (int)logroCantidad.IdTipo;

            return dto;
        }


        /// <summary>
        /// Metodo que sirve para convertir un dto en una entidad
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public override Entidad CrearEntidad(DTOLogroCantidad dto)
        {
            LogroCantidad entidad = FabricaEntidades.CrearLogroCantidad();
            Partido partido = FabricaEntidades.CrearPartido();
            entidad.IdTipo = TipoLogro.cantidad;
            entidad.Partido = partido;
            entidad.Partido.Id = dto.IdPartido;
            entidad.Logro = dto.LogroCantidad;

            return entidad;
        }

        public override List<DTOLogroCantidad> CrearListaDto(List<Entidad> entidades)
        {
            throw new NotImplementedException();
        }

        public override List<Entidad> CrearListaEntidades(List<DTOLogroCantidad> dtos)
        {
            throw new NotImplementedException();
        }

    }
}
