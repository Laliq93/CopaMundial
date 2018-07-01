using System;
using System.Collections.Generic;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Servicios.DTO.Logros;
using CopaMundialAPI.Servicios.Fabrica;

namespace CopaMundialAPI.Servicios.Traductores.Logros
{
    public class TraductorLogroCantidadResultado: TraductorGenerico<DTOLogroCantidadResultado>
    {

        /// <summary>
        /// Metodo que sirve para convertir de una entidad a un dto
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        public override DTOLogroCantidadResultado CrearDto(Entidad entidad)
        {
            DTOLogroCantidadResultado dto = FabricaDTO.CrearDTOLogroCantidadResultado();

            LogroCantidad logroCantidad = entidad as LogroCantidad;

            dto.IdLogroCantidad = logroCantidad.Id;
            dto.LogroCantidad = logroCantidad.Logro;
            dto.TipoLogro = (int)logroCantidad.IdTipo;
            dto.Cantidad = logroCantidad.Cantidad;

            return dto;
        }


        /// <summary>
        /// Metodo que sirve para convertir un dto en una entidad
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public override Entidad CrearEntidad(DTOLogroCantidadResultado dto)
        {
            LogroCantidad entidad = FabricaEntidades.CrearLogroCantidad();

            entidad.Id= dto.IdLogroCantidad;
            entidad.IdTipo = TipoLogro.cantidad; 
            entidad.Logro = dto.LogroCantidad;
            entidad.Cantidad = dto.Cantidad;

            return entidad;
        }

        /// <summary>
        /// Metodo para crear una lista de dto de logrosCantidad con resultados
        /// </summary>
        /// <param name="entidades"></param>
        /// <returns></returns>
        public override List<DTOLogroCantidadResultado> CrearListaDto(List<Entidad> entidades)
        {
            List<DTOLogroCantidadResultado> _dtos = new List<DTOLogroCantidadResultado>();

            foreach (Entidad logro in entidades)
            {
                _dtos.Add(CrearDto(logro));
            }

            return _dtos;
        }

        public override List<Entidad> CrearListaEntidades(List<DTOLogroCantidadResultado> dtos)
        {
            throw new NotImplementedException();
        }

    }
}