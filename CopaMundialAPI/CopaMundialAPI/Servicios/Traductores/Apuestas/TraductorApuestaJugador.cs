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
    public class TraductorApuestaJugador : TraductorGenerico<DTOApuestaJugador, ApuestaJugador>
    {
        public override DTOApuestaJugador CrearDto(ApuestaJugador entidad)
        {
            DTOApuestaJugador dto = FabricaDTO.CrearDtoApuestaJugador();

            dto.IdLogro = entidad.Logro.Id;
            dto.IdUsuario = entidad.Usuario.Id;
            dto.IdJugador = entidad.Respuesta.Id;
            dto.Estado = entidad.Estado;

            return dto;
        }

        public override ApuestaJugador CrearEntidad(DTOApuestaJugador dto)
        {
            ApuestaJugador entidad = FabricaEntidades.CrearApuestaJugador();

            Jugador jugador = new Jugador(); //Esto será fabrica
            entidad.Respuesta = jugador;

            entidad.Logro.Id = dto.IdLogro;
            entidad.Usuario.Id = dto.IdUsuario;
            entidad.Respuesta.Id = dto.IdJugador;
            entidad.Fecha = DateTime.Now.ToShortDateString();

            return entidad;
        }

        public override List<DTOApuestaJugador> CrearListaDto(List<ApuestaJugador> entidades)
        {
            List<DTOApuestaJugador> dtos = new List<DTOApuestaJugador>();

            foreach (ApuestaJugador entidad in entidades)
            {
                dtos.Add(CrearDto(entidad));
            }

            return dtos;
        }

        public override List<ApuestaJugador> CrearListaEntidades(List<DTOApuestaJugador> dtos)
        {
            throw new NotImplementedException();
        }
    }
}