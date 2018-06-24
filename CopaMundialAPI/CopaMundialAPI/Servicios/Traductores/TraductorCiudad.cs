using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Servicios.DTO.Ciudades;
using CopaMundialAPI.Comun.Entidades.Fabrica;


namespace CopaMundialAPI.Servicios.Traductores
{
    public class TraductorCiudad : TraductorGenerico<DTOCiudad, Ciudad>
    {
        public override DTOCiudad CrearDto ( Ciudad entidad )
        {
            throw new NotImplementedException ( );
        }

        public override Ciudad CrearEntidad ( DTOCiudad dto )
        {
			Ciudad ciudad = FabricaEntidades.CrearCiudad(dto.Nombre, dto.Habitantes, dto.Descripcion, dto.NombreIngles, dto.DescripcionIngles, dto.Imagen);
			return ciudad;
		}

        public override List<DTOCiudad> CrearListaDto ( List<Ciudad> entidades )
        {
            throw new NotImplementedException ( );
        }

        public override List<Ciudad> CrearListaEntidades ( List<DTOCiudad> dtos )
        {
            throw new NotImplementedException ( );
        }
    }
}