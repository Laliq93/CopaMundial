using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Entidades
{
    /// <summary>
    /// Clase de la entidad Ciudad
    /// </summary>
    public class Ciudad : Entidad
    {

        private string _nombre;//Nombre de la ciudad en español
        private int _habitantes;//Numero de habitantes de la ciudad
        private string _descripcion;//Descripcion de la ciudad en español
        private string _nombreIngles;//Nombre de la ciudad en ingles
        private string _descripcionIngles;//Descripcion de la ciudad en ingles
		private byte[] _imagen;

		public Ciudad()
		{
		}

		/// <summary>
		/// Constructor de la entidad Ciudad
		/// </summary>
		/// <param name="nombre">Nombre de la ciudad en español</param>
		/// <param name="habitantes">Numero de habitantes de la ciudad</param>
		/// <param name="descripcion">Descripcion de la ciudad en español</param>
		/// <param name="nombreIngles">Nombre de la ciudad en ingles</param>
		/// <param name="descripcionIngles">Descripcion de la ciudad en ingles</param>
		/// <param name="imagen">Imagen en bytes de la ciudad</param>
		public Ciudad(string nombre, int habitantes, string descripcion, string nombreIngles, string descripcionIngles, byte[] imagen)

		{
			Nombre = nombre;
            Habitantes = habitantes;
            Descripcion = descripcion;

			Imagen = imagen;

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
		/// Getters y Setters del atributo _imagen
		/// </summary>
		public byte[] Imagen { get => _imagen; set => _imagen = value; }

        /// <summary>
        /// Getters y Setters del atributo _nombreIngles
        /// </summary>
        public string NombreIngles { get => _nombreIngles; set => _nombreIngles = value; }
        /// <summary>
        /// Getters y Setters del atributo _descripcionIngles
        /// </summary>
        public string DescripcionIngles { get => _descripcionIngles; set => _descripcionIngles = value; }

    }
}