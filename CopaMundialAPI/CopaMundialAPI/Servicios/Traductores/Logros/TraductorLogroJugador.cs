using System;
using System.Collections.Generic;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Servicios.DTO.Logros;
using CopaMundialAPI.Servicios.Fabrica;

namespace CopaMundialAPI.Servicios.Traductores.Logros
{
    public class TraductorLogroJugador: TraductorGenerico<DTOLogroJugador>
    {

        /// <summary>
        /// Metodo que sirve para convertir de una entidad a un dto
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        public override DTOLogroJugador CrearDto(Entidad entidad)
        {
            DTOLogroJugador dto = FabricaDTO.CrearDTOLogroJugador();

            LogroJugador logroJugador = entidad as LogroJugador;

            dto.IdPartido = logroJugador.Partido.Id;
            dto.LogroJugador = logroJugador.Logro;
            dto.TipoLogro = (int)logroJugador.IdTipo;

            return dto;
        }


        /// <summary>
        /// Metodo que sirve para convertir un dto en una entidad
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public override Entidad CrearEntidad(DTOLogroJugador dto)
        {
            LogroJugador entidad = FabricaEntidades.CrearLogroJugador();
            Partido partido = FabricaEntidades.CrearPartido();
            entidad.IdTipo = TipoLogro.jugador;
            entidad.Partido = partido;
            entidad.Partido.Id = dto.IdPartido;
            entidad.Logro = dto.LogroJugador;

            return entidad;
        }

        public override List<DTOLogroJugador> CrearListaDto(List<Entidad> entidades)
        {
            throw new NotImplementedException();
        }

        public override List<Entidad> CrearListaEntidades(List<DTOLogroJugador> dtos)
        {
            throw new NotImplementedException();
        }
    }
}