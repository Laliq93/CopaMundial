using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Servicios.DTO.Ciudades
{
    /// <summary>
    /// Clase que representa el DTOCiudadID
    /// </summary>
    public class DTOCiudadID
    {
        private int _id;//Id de la ciudad

        /// <summary>
        /// Constructor de la clase DTOCiudadID
        /// </summary>
        /// <param name="id">id de la ciudad</param>
        public DTOCiudadID ( int id )
        {
            _id = id;
        }

        /// <summary>
        /// Getters y Setters del atributo id
        /// </summary>
        public int Id { get => _id; set => _id = value; }
    }
}