using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Entidades
{
    /// <summary>
    /// Clase LogroCantidad registra todos los logros
    /// por cantidad de un partido
    /// </summary>
    public class LogroCantidad: LogroPartido
    {

        private int _cantidad;//Registra la cantidad obtenida dentro de un logro
        private TipoLogro _idTipo; //id del tipo de logro (Cantidad,VOF, Equipo, Jugador)

        public LogroCantidad() { }
        /// <summary>
        /// Get y Set de la cantidad asignada a un logro
        /// </summary>
        public int Cantidad { get => _cantidad; set => _cantidad = value; }

        /// <summary>
        /// Get y Set del tipo de logro
        /// </summary>
        public TipoLogro IdTipo { get => _idTipo; set => _idTipo = value; }
    }
}