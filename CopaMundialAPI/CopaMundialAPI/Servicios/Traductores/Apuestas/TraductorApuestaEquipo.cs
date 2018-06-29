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
    public class TraductorApuestaEquipo : TraductorGenerico<DTOApuestaEquipo>
    {
        public override DTOApuestaEquipo CrearDto(Entidad entidad)
        {
            DTOApuestaEquipo dto = FabricaDTO.CrearDTOApuestaEquipo();

            ApuestaEquipo apuesta = entidad as ApuestaEquipo;

            dto.IdLogro = apuesta.Logro.Id;
            dto.IdUsuario = apuesta.Usuario.Id;
            dto.IdEquipo = apuesta.Respuesta.Id;
            dto.NombreEquipo = apuesta.Respuesta.Pais;
            dto.Estado = apuesta.Estado;
            dto.Logro = apuesta.Logro.Logro;
            dto.Fecha = apuesta.Fecha.ToShortDateString();

            return dto;
        }

        public override Entidad CrearEntidad(DTOApuestaEquipo dto)
        {
            try
            {
                ApuestaEquipo apuesta = FabricaEntidades.CrearApuestaEquipo();

                Usuario apostador = FabricaEntidades.CrearUsuarioVacio();
                Equipos equipos = new Equipos();
                LogroEquipo logro = FabricaEntidades.CrearLogroEquipo();

                apuesta.Usuario = apostador;
                apuesta.Logro = logro;

                apuesta.Respuesta = equipos.GetEquipo(dto.IdEquipo);
                apuesta.Logro.Id = dto.IdLogro;
                apuesta.Usuario.Id = dto.IdUsuario;

                return apuesta;
            }
            catch (NullReferenceException exc)
            {
                throw new ObjetoNullException(exc, "Error al recibir la información de la apuesta");
            }
        }

        public override List<DTOApuestaEquipo> CrearListaDto(List<Entidad> entidades)
        {
            List<DTOApuestaEquipo> dtos = new List<DTOApuestaEquipo>();

            foreach (ApuestaEquipo entidad in entidades)
            {
                dtos.Add(CrearDto(entidad));
            }

            return dtos;
        }

        public override List<Entidad> CrearListaEntidades(List<DTOApuestaEquipo> dtos)
        {
            throw new NotImplementedException();
        }
    }
}