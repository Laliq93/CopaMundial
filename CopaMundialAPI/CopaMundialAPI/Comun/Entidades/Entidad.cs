using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Entidades
{
    /// <summary>
    /// Superclase Entidad
    /// </summary>
    public abstract class Entidad
    {
        private int id;

        /// <summary>
        /// Getters y Setters del atributo id
        /// </summary>
        public int Id { get => id; set => id = value; }
    }
}