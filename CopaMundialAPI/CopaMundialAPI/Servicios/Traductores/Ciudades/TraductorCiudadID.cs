using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Servicios.DTO.Ciudades;
using CopaMundialAPI.Servicios.Fabrica;

namespace CopaMundialAPI.Servicios.Traductores.Ciudades
{
	public class TraductorCiudadID : TraductorGenerico<DTOCiudadID>
	{
		public override DTOCiudadID CrearDto(Entidad entidad)
		{
			try
			{
				Ciudad ciudad = entidad as Ciudad;

				DTOCiudadID dto = FabricaDTO.CrearDTOCiudadId(ciudad.Id);

				return dto;
			}
			catch (InvalidCastException e)
			{

				throw e;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public override Entidad CrearEntidad(DTOCiudadID dto)
		{
			Entidad entidad = FabricaEntidades.CrearCiudadID(dto.Id);
			return entidad;
		}

		public override List<DTOCiudadID> CrearListaDto(List<Entidad> entidades)
		{
			throw new NotImplementedException();
		}

		public override List<Entidad> CrearListaEntidades(List<DTOCiudadID> dtos)
		{
			throw new NotImplementedException();
		}
	}
}