using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Comun.Excepciones;
using CopaMundialAPI.Servicios.DTO.Estadios;
using CopaMundialAPI.Servicios.Fabrica;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Servicios.Traductores.Estadios
{
    public class TraductorEstadio : TraductorGenerico<DTOEstadio>
    {
        Logger logger = LogManager.GetLogger("fileLogger");

        public override DTOEstadio CrearDto(Entidad entidad)
        {
            if (!(entidad is Comun.Entidades.Estadio estadio))
            {
                logger.Error("Casteo invalido de la entidad " + entidad + " a Estadio");
                throw new CasteoInvalidoException("La entidad no es del tipo estadio");
            }

            DTOEstadio dto = FabricaDTO.CrearDTOEstadio();
            dto.Id = estadio.Id;
            dto.Nombre = estadio.Nombre;

            return dto;
        }

        public override Entidad CrearEntidad(DTOEstadio dto)
        {
            Comun.Entidades.Estadio estadio = FabricaEntidades.CrearEstadio();

            estadio.Id = dto.Id;
            estadio.Nombre = dto.Nombre;

            return estadio;
        }

        public override List<DTOEstadio> CrearListaDto(List<Entidad> entidades)
        {
            List<DTOEstadio> _respuesta = new List<DTOEstadio>();

            foreach (Comun.Entidades.Estadio estadio in entidades)
            {
                _respuesta.Add(this.CrearDto(estadio));
            }

            return _respuesta;
        }

        public override List<Entidad> CrearListaEntidades(List<DTOEstadio> dtos)
        {
            List<Entidad> _respuesta = new List<Entidad>();

            foreach (DTOEstadio dto in dtos)
            {
                _respuesta.Add(this.CrearEntidad(dto));
            }

            return _respuesta;
        }
    }
}