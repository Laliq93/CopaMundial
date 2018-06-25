using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Servicios.DTO.Apuestas;
using CopaMundialAPI.Servicios.Fabrica;
using CopaMundialAPI.Comun.Excepciones;

namespace CopaMundialAPI.Servicios.Traductores.Apuestas
{
    public class TraductorApuestaVOF : TraductorGenerico<DTOApuestaVOF>
    {
        public override DTOApuestaVOF CrearDto(Entidad entidad)
        {
            DTOApuestaVOF dto = FabricaDTO.CrearDtoApuestaVOF();

            ApuestaVoF apuesta = entidad as ApuestaVoF;

            dto.IdLogro = apuesta.Logro.Id;
            dto.IdUsuario = apuesta.Usuario.Id;
            dto.ApuestaUsuario = apuesta.Respuesta;
            dto.Estado = apuesta.Estado;
            dto.Logro = apuesta.Logro.Logro;

            return dto;

        }

        public override Entidad CrearEntidad(DTOApuestaVOF dto)
        {
            try
            {
                ApuestaVoF apuesta = FabricaEntidades.CrearApuestaVoF();

                Usuario apostador = new Usuario();

                apostador.Id = dto.IdUsuario;

                LogroVoF logro = FabricaEntidades.CrearLogroVoF();

                logro.Id = dto.IdLogro;

                apuesta.Logro = logro;
                apuesta.Usuario = apostador;
                apuesta.Respuesta = dto.ApuestaUsuario;

                return apuesta;
            }
            catch (NullReferenceException exc)
            {
                throw new ObjetoNullException(exc, "Error al recibir la información de la apuesta");
            }

        }

        public override List<DTOApuestaVOF> CrearListaDto(List<Entidad> entidades)
        {
            List<DTOApuestaVOF> dtos = new List<DTOApuestaVOF>();

            foreach(ApuestaVoF entidad in entidades)
            {
                dtos.Add(CrearDto(entidad));
            }

            return dtos;
        }

        public override List<Entidad> CrearListaEntidades(List<DTOApuestaVOF> dtos)
        {
            throw new NotImplementedException();
        }
    }
}