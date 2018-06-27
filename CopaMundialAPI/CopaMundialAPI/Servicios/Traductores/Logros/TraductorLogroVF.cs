using System;
using System.Collections.Generic;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Servicios.DTO.Logros;
using CopaMundialAPI.Servicios.Fabrica;


namespace CopaMundialAPI.Servicios.Traductores.Logros
{
    public class TraductorLogroVF: TraductorGenerico<DTOLogroVF>
    {

        /// <summary>
        /// Metodo que sirve para convertir de una entidad a un dto
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        public override DTOLogroVF CrearDto(Entidad entidad)
        {
            DTOLogroVF dto = FabricaDTO.CrearDTOLogroVF();

            LogroVoF logroVF = entidad as LogroVoF;

            dto.IdPartido = logroVF.Partido.Id;
            dto.LogroVF = logroVF.Logro;
            dto.TipoLogro = (int)logroVF.IdTipo;

            return dto;
        }


        /// <summary>
        /// Metodo que sirve para convertir un dto en una entidad
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public override Entidad CrearEntidad(DTOLogroVF dto)
        {
            LogroVoF entidad = FabricaEntidades.CrearLogroVoF();
            Partido partido = FabricaEntidades.CrearPartido();
            entidad.IdTipo = TipoLogro.vof;
            entidad.Partido = partido;
            entidad.Partido.Id = dto.IdPartido;
            entidad.Logro = dto.LogroVF;

            return entidad;
        }

        public override List<DTOLogroVF> CrearListaDto(List<Entidad> entidades)
        {
            throw new NotImplementedException();
        }

        public override List<Entidad> CrearListaEntidades(List<DTOLogroVF> dtos)
        {
            throw new NotImplementedException();
        }
    }
}