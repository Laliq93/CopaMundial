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
    public class TraductorLogroVFResultado: TraductorGenerico<DTOLogroVFResultado>
    {

        /// <summary>
        /// Metodo que sirve para convertir de una entidad a un dto
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        public override DTOLogroVFResultado CrearDto(Entidad entidad)
        {
            DTOLogroVFResultado dto = FabricaDTO.CrearDTOLogroVFResultado();

            LogroVoF logroVF = entidad as LogroVoF;

            dto.IdLogroVF = logroVF.Id;
            dto.LogroVF = logroVF.Logro;
            dto.TipoLogro = (int)logroVF.IdTipo;
            dto.Respuesta = logroVF.Respuesta;

            return dto;
        }


        /// <summary>
        /// Metodo que sirve para convertir un dto en una entidad
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public override Entidad CrearEntidad(DTOLogroVFResultado dto)
        {
            LogroVoF entidad = FabricaEntidades.CrearLogroVoF();

            entidad.Id = dto.IdLogroVF;
            entidad.IdTipo = TipoLogro.vof;
            entidad.Logro = dto.LogroVF;
            entidad.Respuesta = dto.Respuesta;

            return entidad;
        }

        public override List<DTOLogroVFResultado> CrearListaDto(List<Entidad> entidades)
        {

            List<DTOLogroVFResultado> _dtos = new List<DTOLogroVFResultado>();

            foreach (Entidad logro in entidades)
            {
                _dtos.Add(CrearDto(logro));
            }

            return _dtos;
        }

        public override List<Entidad> CrearListaEntidades(List<DTOLogroVFResultado> dtos)
        {
            throw new NotImplementedException();
        }
    }
}