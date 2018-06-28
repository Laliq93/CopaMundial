using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Comun.Excepciones;
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
            try
            {
                ApuestaCantidad apuesta = FabricaEntidades.CrearApuestaCantidad();

                Usuario usuario = FabricaEntidades.CrearUsuarioVacio();

                LogroCantidad logro = FabricaEntidades.CrearLogroCantidad();

                apuesta.Usuario = usuario;
                apuesta.Logro = logro;


                apuesta.Logro.Id = dto.IdLogro;
                apuesta.Usuario.Id = dto.IdUsuario;
                apuesta.Respuesta = dto.ApuestaUsuario;

                return apuesta;
            }
            catch (NullReferenceException exc)
            {
                throw new ObjetoNullException(exc, "Error al recibir la información de la apuesta");
            }
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