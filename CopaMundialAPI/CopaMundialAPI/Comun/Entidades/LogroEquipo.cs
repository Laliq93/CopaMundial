using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Entidades
{
    /// <summary>
    /// Clase LogroEquipo, registra un logro hecho por 
    /// un equipo dentro de un partido
    /// </summary>
    public class LogroEquipo: LogroPartido
    {
        private Equipo _equipo;//equipo que realiza el logro

        /// <summary>
        /// Get y Set del nombre del equipo que realizo el logro
        /// </summary>
        public Equipo Equipo { get => _equipo; set => _equipo = value; }
    }
}