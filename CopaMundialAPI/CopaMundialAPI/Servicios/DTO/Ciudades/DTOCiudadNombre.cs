using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Servicios.DTO.Ciudades
{
    /// <summary>
    /// Clase que representa el DTOCiudadNombre
    /// </summary>
    public class DTOCiudadNombre
    {
        private string _nombre;//Nombre de la ciudad

        /// <summary>
        /// Constructor de la clase DTOCiudadNombre
        /// </summary>
        /// <param name="nombre">nombre de la ciudad</param>
        public DTOCiudadNombre ( string nombre )
        {
            _nombre = nombre;
        }

        /// <summary>
        /// Getters y Setters del atributo _nombre
        /// </summary>
        public string Nombre { get => _nombre; set => _nombre = value; }
    }
}