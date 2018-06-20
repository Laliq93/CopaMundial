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
            ApuestaVoF entidad = FabricaEntidades.CrearApuestaVoF();

            Usuario apostador = new Usuario();

            apostador.Id = dto.IdUsuario;

            LogroPartido logro = new LogroPartido();

            logro.Id = dto.IdLogro;

            entidad.Logro = logro;
            entidad.Usuario = apostador;
            entidad.Respuesta = dto.ApuestaUsuario;
            entidad.Fecha = DateTime.Now.ToShortDateString();

            return entidad;

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