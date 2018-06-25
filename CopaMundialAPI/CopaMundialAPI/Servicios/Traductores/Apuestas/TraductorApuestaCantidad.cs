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
    public class TraductorApuestaCantidad : TraductorGenerico<DTOApuestaCantidad>
    {
        public override DTOApuestaCantidad CrearDto(Entidad entidad)
        {
            DTOApuestaCantidad dto = FabricaDTO.CrearDtoApuestaCantidad();

            ApuestaCantidad apuesta = entidad as ApuestaCantidad;

            dto.IdLogro = apuesta.Logro.Id;
            dto.IdUsuario = apuesta.Usuario.Id;
            dto.ApuestaUsuario = apuesta.Respuesta;
            dto.Estado = apuesta.Estado;
            dto.Logro = apuesta.Logro.Logro;

            return dto;
        }

        public override Entidad CrearEntidad(DTOApuestaCantidad dto)
        {
            ApuestaCantidad entidad = FabricaEntidades.CrearApuestaCantidad();

            entidad.Logro.Id = dto.IdLogro;
            entidad.Usuario.Id = dto.IdUsuario;
            entidad.Respuesta = dto.ApuestaUsuario;

            return entidad;
        }

        public override List<DTOApuestaCantidad> CrearListaDto(List<Entidad> entidades)
        {
            List<DTOApuestaCantidad> dtos = new List<DTOApuestaCantidad>();

            foreach (ApuestaCantidad entidad in entidades)
            {
                dtos.Add(CrearDto(entidad));
            }

            return dtos;
        }

        public override List<Entidad> CrearListaEntidades(List<DTOApuestaCantidad> dtos)
        {
            throw new NotImplementedException();
        }
    }
}