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
	public class TraductorCiudad2 : TraductorGenerico<DTOCiudad2>
	{
		/// <summary>
		/// Metodo con el cual se transforma una entidad en un DTOCiudad
		/// </summary>
		/// <param name="entidad">Entidad que se desea transformar</param>
		/// <returns></returns>
		public override DTOCiudad2 CrearDto(Entidad entidad)
		{
			try
			{
				Ciudad ciudad = entidad as Ciudad;
				DTOCiudad2 dto = null;

				dto = FabricaDTO.CrearDTOCiudad(ciudad.Nombre, ciudad.Habitantes, ciudad.Descripcion, ciudad.NombreIngles, ciudad.DescripcionIngles);
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
		public override Entidad CrearEntidad(DTOCiudad2 dto)
		{
			try
			{
				Entidad ciudad = FabricaEntidades.CrearCiudad(dto.Nombre, dto.Habitantes, dto.Descripcion, dto.NombreIngles, dto.DescripcionIngles);

				return ciudad;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public override List<DTOCiudad2> CrearListaDto(List<Entidad> entidades)
		{
			try
			{
				List<DTOCiudad2> dtos = new List<DTOCiudad2>();

				foreach (Entidad ciudad in entidades)
				{
					dtos.Add(CrearDto(ciudad));
				}

				return dtos;

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



		/// <summary>
		/// Metodo con el cual se transforma de una lista de dtos a una lista de entidades
		/// </summary>
		/// <param name="dtos">Lista de dtos que se va a transformar</param>
		/// <returns></returns>


		public override List<Entidad> CrearListaEntidades(List<DTOCiudad2> dtos)
		{
			try
			{
				List<Entidad> ciudades = new List<Entidad>();

				foreach (DTOCiudad2 dtociudad in dtos)
				{
					ciudades.Add(CrearEntidad(dtociudad));
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