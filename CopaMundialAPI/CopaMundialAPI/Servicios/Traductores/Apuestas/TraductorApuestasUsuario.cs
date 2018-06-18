using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Servicios.DTO.Apuestas;
using CopaMundialAPI.Servicios.Fabrica;

namespace CopaMundialAPI.Servicios.Traductores.Apuestas
{
    public class TraductorApuestasUsuario : TraductorGenerico<DTOApuestasUsuario, Apuesta>
    {
        public override DTOApuestasUsuario CrearDto(Apuesta entidad)
        {
            DTOApuestasUsuario dto = FabricaDTO.CrearDtoApuestasUsuario();

            //dto.IdLogro = entidad.Logro.Id;
            //dto.IdUsuario = entidad.Usuario.Id;
            //dto.Contenido = entidad.Contenido;
            dto.Resultado = entidad.Resultado;
            dto.FechaApuesta = entidad.Fecha.ToShortDateString();

            return dto;
        }

        public override Apuesta CrearEntidad(DTOApuestasUsuario dto)
        {
            throw new NotImplementedException();
        }

        public override List<DTOApuestasUsuario> CrearListaDto(List<Apuesta> entidades)
        {
            List<DTOApuestasUsuario> dtos = new List<DTOApuestasUsuario>();

            foreach(Apuesta apuesta in entidades)
            {
                dtos.Add(CrearDto(apuesta));
            }

            return dtos;
        }

        public override List<Apuesta> CrearListaEntidades(List<DTOApuestasUsuario> dtos)
        {
            throw new NotImplementedException();
        }
    }
}