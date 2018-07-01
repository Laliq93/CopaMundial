using System;
using System.Collections.Generic;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Servicios.DTO.Logros;
using CopaMundialAPI.Servicios.Fabrica;


namespace CopaMundialAPI.Servicios.Traductores.Logros
{
    public class TraductorLogroEquipoResultado: TraductorGenerico<DTOLogroEquipoResultado>
    {

        /// <summary>
        /// Metodo que sirve para convertir de una entidad a un dto
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        public override DTOLogroEquipoResultado CrearDto(Entidad entidad)
        {
            DTOLogroEquipoResultado dto = FabricaDTO.CrearDTOLogroEquipoResultado();

            LogroEquipo logroEquipo = entidad as LogroEquipo;
            Comun.Entidades.Equipos listaEquipos = new Comun.Entidades.Equipos();

            dto.IdLogroEquipo = logroEquipo.Id;
            dto.LogroEquipo = logroEquipo.Logro;
            dto.TipoLogro = (int)logroEquipo.IdTipo;
            dto.Equipo = logroEquipo.Equipo.Id;
            dto.NombreEquipo =listaEquipos.GetEquipo(logroEquipo.Equipo.Id).Pais;

            return dto;
        }


        /// <summary>
        /// Metodo que sirve para convertir un dto en una entidad
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public override Entidad CrearEntidad(DTOLogroEquipoResultado dto)
        {
            LogroEquipo entidad = FabricaEntidades.CrearLogroEquipo();

            entidad.Id = dto.IdLogroEquipo;
            entidad.IdTipo = TipoLogro.equipo;
            entidad.Logro = dto.LogroEquipo;
            entidad.Equipo.Id = dto.Equipo;
            entidad.Equipo.Pais = dto.NombreEquipo;
            entidad.Id = dto.IdLogroEquipo;

            return entidad;
        }

        public override List<DTOLogroEquipoResultado> CrearListaDto(List<Entidad> entidades)
        {
            List<DTOLogroEquipoResultado> _dtos = new List<DTOLogroEquipoResultado>();

            foreach (Entidad logro in entidades)
            {
                _dtos.Add(CrearDto(logro));
            }

            return _dtos;
        }

        public override List<Entidad> CrearListaEntidades(List<DTOLogroEquipoResultado> dtos)
        {
            throw new NotImplementedException();
        }
    }
}