using CopaMundialAPI.Servicios.DTO.Ciudades;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Servicios.Fabrica;
using System.Collections.Generic;
using System;

namespace CopaMundialAPI.Servicios.Traductores.Ciudades
{
    public class TraductorCiudadNombre : TraductorGenerico<DTOCiudadNombre>
    {
        /// <summary>
        /// Metodo con el cual se transforma una entidad en un DTOCiudadNombre
        /// </summary>
        /// <param name="entidad">Entidad que se desea transformar</param>
        /// <returns></returns>
        public override DTOCiudadNombre CrearDto ( Entidad entidad )
        {
            try
            {
                Ciudad ciudad = entidad as Ciudad;

                DTOCiudadNombre dto = FabricaDTO.CrearDTOCiudadNombre(ciudad.Nombre);

                return dto;
            }
            catch(InvalidCastException e)
            {
               
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override Entidad CrearEntidad ( DTOCiudadNombre dto )
        {
            try
            {
                Entidad ciudad = FabricaEntidades.CrearCiudadNombre ( dto.Nombre );

                return ciudad;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override List<DTOCiudadNombre> CrearListaDto ( List<Entidad> entidades )
        {
            throw new System.NotImplementedException ( );
        }

        public override List<Entidad> CrearListaEntidades ( List<DTOCiudadNombre> dtos )
        {
            throw new System.NotImplementedException ( );
        }
    }
}