using CopaMundialAPI.Servicios.DTO.Ciudades;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Servicios.Fabrica;
using System.Collections.Generic;
using System;

namespace CopaMundialAPI.Servicios.Traductores.Ciudades
{
    public class TraductorCiudadID : TraductorGenerico<DTOCiudadID>
    {
        /// <summary>
        /// Metodo con el cual se transforma una entidad en un DTOCiudadID
        /// </summary>
        /// <param name="entidad">Entidad que se desea transformar</param>
        /// <returns></returns>
        public override DTOCiudadID CrearDto ( Entidad entidad )
        {
            try
            {
                Ciudad ciudad = entidad as Ciudad;

                DTOCiudadID dto = FabricaDTO.CrearDTOCiudadID(ciudad.Id);

                return dto;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override Entidad CrearEntidad ( DTOCiudadID dto )
        {
            try
            {

                return null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override List<DTOCiudadID> CrearListaDto ( List<Entidad> entidades )
        {
            throw new System.NotImplementedException ( );
        }

        public override List<Entidad> CrearListaEntidades ( List<DTOCiudadID> dtos )
        {
            throw new System.NotImplementedException ( );
        }
    }
}