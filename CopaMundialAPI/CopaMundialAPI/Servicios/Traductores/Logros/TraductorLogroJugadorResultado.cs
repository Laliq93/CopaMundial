using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Servicios.DTO.Logros;
using CopaMundialAPI.Servicios.Fabrica;

namespace CopaMundialAPI.Servicios.Traductores.Logros
{
    public class TraductorLogroJugadorResultado: TraductorGenerico<DTOLogroJugadorResultado>
    {


        /// <summary>
        /// Metodo que sirve para convertir de una entidad a un dto
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        public override DTOLogroJugadorResultado CrearDto(Entidad entidad)
        {
            DTOLogroJugadorResultado dto = FabricaDTO.CrearDTOLogroJugadorResultado();

            LogroJugador logroJugador = entidad as LogroJugador;
            dto.IdLogroJugador = logroJugador.Id;
            dto.LogroJugador = logroJugador.Logro;
            dto.TipoLogro = (int)logroJugador.IdTipo;
            dto.Jugador = logroJugador.Jugador.Id;

            return dto;
        }


        /// <summary>
        /// Metodo que sirve para convertir un dto en una entidad
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public override Entidad CrearEntidad(DTOLogroJugadorResultado dto)
        {
            LogroJugador entidad = FabricaEntidades.CrearLogroJugador();
            Jugador jugador = FabricaEntidades.CrearJugador();
            entidad.Jugador = jugador;

            entidad.Id = dto.IdLogroJugador;
            entidad.IdTipo = TipoLogro.jugador;
            entidad.Logro = dto.LogroJugador;
            entidad.Jugador.Id = dto.Jugador;

            return entidad;
        }

        public override List<DTOLogroJugadorResultado> CrearListaDto(List<Entidad> entidades)
        {
            List<DTOLogroJugadorResultado> _dtos = new List<DTOLogroJugadorResultado>();

            foreach (Entidad logro in entidades)
            {
                _dtos.Add(CrearDto(logro));
            }

            return _dtos;
        }

        public override List<Entidad> CrearListaEntidades(List<DTOLogroJugadorResultado> dtos)
        {
            throw new NotImplementedException();
        }
    }
}