using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Servicios.DTO.Ciudades
{
	public class DTOCiudadID 
	{

		private int _id;//Nombre de la ciudad

		/// <summary>
		/// Constructor de la clase DTOCiudadId
		/// </summary>
		/// <param name="id">id de la ciudad</param>
		public DTOCiudadID(int id)
		{
			Id = id;	
		}

		/// <summary>
		/// Getters y Setters del atributo _id
		/// </summary>
		public int Id { get => _id; set => _id = value; }

	}
}