using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Servicios.DTO.Apuestas;
using CopaMundialAPI.Servicios.Fabrica;

namespace CopaMundialAPI.Servicios.Traductores.Apuestas
{
    public class TraductorApuestaVOF : TraductorGenerico<DTOApuestaVOF, ApuestaVoF>
    {
        public override DTOApuestaVOF CrearDto(ApuestaVoF entidad)
        {
            DTOApuestaVOF dto = FabricaDTO.CrearDtoApuestaVOF();

            dto.IdLogro = entidad.Logro.Id;
            dto.IdUsuario = entidad.Usuario.Id;
            dto.ApuestaUsuario = entidad.Respuesta;
            dto.Estado = entidad.Estado;

            return dto;

        }

        public override ApuestaVoF CrearEntidad(DTOApuestaVOF dto)
        {
            ApuestaVoF entidad = FabricaEntidades.CrearApuestaVoF();

            entidad.Logro.Id = dto.IdLogro;
            entidad.Usuario.Id = dto.IdUsuario;
            entidad.Respuesta = dto.ApuestaUsuario;
            entidad.Fecha = DateTime.Now.ToShortDateString();

            return entidad;

        }

        public override List<DTOApuestaVOF> CrearListaDto(List<ApuestaVoF> entidades)
        {
            List<DTOApuestaVOF> dtos = new List<DTOApuestaVOF>();

            foreach(ApuestaVoF entidad in entidades)
            {
                dtos.Add(CrearDto(entidad));
            }

            return dtos;
        }

        public override List<ApuestaVoF> CrearListaEntidades(List<DTOApuestaVOF> dtos)
        {
            throw new NotImplementedException();
        }
    }
}