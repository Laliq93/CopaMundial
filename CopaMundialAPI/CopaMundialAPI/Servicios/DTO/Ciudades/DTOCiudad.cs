using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Servicios.DTO.Ciudades
{
    /// <summary>
    /// Clase que representa el DTOCiudad
    /// </summary>
    public class DTOCiudad
    {
        private int _id;//Id de la ciudad
        private string _nombre;//Nombre de la ciudad en español
        private int _habitantes;//Numero de habitantes de la ciudad
        private string _descripcion;//Descripcion de la ciudad en español
        private string _nombreIngles;//Nombre de la ciudad en ingles
        private string _descripcionIngles;//Descripcion de la ciudad en ingles
		private Boolean _habilitado;
     /*   /// <summary>
        /// Constructor de la entidad DTOCiudad
        /// </summary>
        /// <param name="nombre">Nombre de la ciudad en español</param>
        /// <param name="habitantes">Numero de habitantes de la ciudad</param>
        /// <param name="descripcion">Descripcion de la ciudad en español</param>
        /// <param name="nombreIngles">Nombre de la ciudad en ingles</param>
        /// <param name="descripcionIngles">Descripcion de la ciudad en ingles</param>
        public DTOCiudad ( string nombre, int habitantes, string descripcion, string nombreIngles, string descripcionIngles)
        {
            Nombre = nombre;
            Habitantes = habitantes;
            Descripcion = descripcion;
            NombreIngles = nombreIngles;
            DescripcionIngles = descripcionIngles;
        }*/

		public DTOCiudad(int id, string nombre, int habitantes, string descripcion, string nombreIngles, string descripcionIngles)
		{
			Id = id;
			Nombre = nombre;
			Habitantes = habitantes;
			Descripcion = descripcion;
			NombreIngles = nombreIngles;
			DescripcionIngles = descripcionIngles;
		}

		/// <summary>
		/// Getters y Setters del atributo _nombre
		/// </summary>
		public string Nombre { get => _nombre; set => _nombre = value; }
        
        /// <summary>
        /// Getters y Setters del atributo _habitantes
        /// </summary>
        public int Habitantes { get => _habitantes; set => _habitantes = value; }
        
        /// <summary>
        /// Getters y Setters del atributo _descripcion
        /// </summary>
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        
        /// <summary>
        /// Getters y Setters del atributo _nombreIngles
        /// </summary>
        public string NombreIngles { get => _nombreIngles; set => _nombreIngles = value; }
        
        /// <summary>
        /// Getters y Setters del atributo _descripcionIngles
        /// </summary>
        public string DescripcionIngles { get => _descripcionIngles; set => _descripcionIngles = value; }
        
        /// <summary>
        /// Getters y Setters del atributo _id
        /// </summary>
        public int Id { get => _id; set => _id = value; }

		public Boolean Habilitado { get => _habilitado; set => _habilitado = value; }

    }
}