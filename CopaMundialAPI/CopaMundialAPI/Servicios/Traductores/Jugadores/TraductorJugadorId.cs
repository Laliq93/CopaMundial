using CopaMundialAPI.Servicios.DTO.Jugadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Servicios.Fabrica;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Comun.Excepciones;

namespace CopaMundialAPI.Servicios.Traductores.Jugadores
{
    public class TraductorJugadorId : TraductorGenerico<DTOJugadorId>
    {
        public override DTOJugadorId CrearDto(Entidad entidad)
        {
            DTOJugadorId dto = FabricaDTO.CrearDTOJugadorId();

            Jugador jugador = entidad as Jugador;

            dto.Id = jugador.Id;
        
            return dto;
        }

        public override Entidad CrearEntidad(DTOJugadorId dto)
        {
            try
            {
                Jugador jugador = FabricaEntidades.CrearJugador();

                jugador.Id = dto.Id;

                return jugador;
            }
            catch (NullReferenceException exc)
            {
                throw new ObjetoNullException(exc, "Error al recibir la información del jugador");
            }
        }

        public override List<DTOJugadorId> CrearListaDto(List<Entidad> entidades)
        {
            throw new NotImplementedException();
        }

        public override List<Entidad> CrearListaEntidades(List<DTOJugadorId> dtos)
        {
            throw new NotImplementedException();
        }
    }
}