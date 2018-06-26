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
    public class TraductorApuestaJugador : TraductorGenerico<DTOApuestaJugador>
    {
        public override DTOApuestaJugador CrearDto(Entidad entidad)
        {
            DTOApuestaJugador dto = FabricaDTO.CrearDtoApuestaJugador();

            ApuestaJugador apuesta = entidad as ApuestaJugador;

            dto.IdLogro = apuesta.Logro.Id;
            dto.IdUsuario = apuesta.Usuario.Id;
            dto.IdJugador = apuesta.Respuesta.Id;
            dto.Estado = apuesta.Estado;
            dto.Logro = apuesta.Logro.Logro;

            return dto;
        }

        public override Entidad CrearEntidad(DTOApuestaJugador dto)
        {
            ApuestaJugador entidad = FabricaEntidades.CrearApuestaJugador();

            Jugador jugador = new Jugador(); //Esto será fabrica
            entidad.Respuesta = jugador;

            entidad.Logro.Id = dto.IdLogro;
            entidad.Usuario.Id = dto.IdUsuario;
            entidad.Respuesta.Id = dto.IdJugador;

            return entidad;
        }

        public override List<DTOApuestaJugador> CrearListaDto(List<Entidad> entidades)
        {
            List<DTOApuestaJugador> dtos = new List<DTOApuestaJugador>();

            foreach (ApuestaJugador entidad in entidades)
            {
                dtos.Add(CrearDto(entidad));
            }

            return dtos;
        }

        public override List<Entidad> CrearListaEntidades(List<DTOApuestaJugador> dtos)
        {
            throw new NotImplementedException();
        }
    }
}