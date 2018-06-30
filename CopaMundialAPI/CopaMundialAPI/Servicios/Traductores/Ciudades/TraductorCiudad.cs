using System;
using System.Collections.Generic;
using CopaMundialAPI.Servicios.DTO.Ciudades;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Servicios.Fabrica;

namespace CopaMundialAPI.Servicios.Traductores.Ciudades
{
    /// <summary>
    /// Clase del Traductor Ciudad
    /// </summary>
    public class TraductorCiudad : TraductorGenerico<DTOCiudad>
    {
        /// <summary>
        /// Metodo con el cual se transforma una entidad en un DTOCiudad
        /// </summary>
        /// <param name="entidad">Entidad que se desea transformar</param>
        /// <returns></returns>
        public override DTOCiudad CrearDto ( Entidad entidad )
        {
            try
            {
                Ciudad ciudad = entidad as Ciudad;
				DTOCiudad dto = null;
				
					dto = FabricaDTO.CrearDTOCiudad(ciudad.Id,ciudad.Nombre, ciudad.Habitantes, ciudad.Descripcion, ciudad.NombreIngles, ciudad.DescripcionIngles);
					dto.Habilitado = ciudad.Habilitado;
				return dto;
				
			
				
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        /// <summary>
        /// Metodo con el cual se transforma un DTOCiudad a una Entidad Ciudad
        /// </summary>
        /// <param name="dto">Objeto dto que se desea transformar</param>
        /// <returns></returns>
        public override Entidad CrearEntidad ( DTOCiudad dto )
        {
            try
            {
                Ciudad ciudad = FabricaEntidades.CrearCiudad ( dto.Id,dto.Nombre, dto.Habitantes, dto.Descripcion, dto.NombreIngles, dto.DescripcionIngles );
				ciudad.Habilitado = dto.Habilitado;
                return ciudad;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Metodo con el cual se transforma de una lista de entidades a una lista de dtos
        /// </summary>
        /// <param name="entidades">Lista de entidades que se va a transformar</param>
        /// <returns></returns>
        public override List<DTOCiudad> CrearListaDto ( List<Entidad> entidades )
        {
            try
            {
                List<DTOCiudad> dtos = new List<DTOCiudad> ( );

                foreach (Entidad ciudad in entidades)
                {
                    dtos.Add ( CrearDto ( ciudad ) );
                }

                return dtos;

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        /// <summary>
        /// Metodo con el cual se transforma de una lista de dtos a una lista de entidades
        /// </summary>
        /// <param name="dtos">Lista de dtos que se va a transformar</param>
        /// <returns></returns>
        public override List<Entidad> CrearListaEntidades ( List<DTOCiudad> dtos )
        {
            try
            {
                List<Entidad> ciudades = new List<Entidad> ( );

                foreach (DTOCiudad dtociudad in dtos)
                {
                    ciudades.Add ( CrearEntidad ( dtociudad ) );
                }

                return ciudades;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}