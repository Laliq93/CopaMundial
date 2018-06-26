using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Entidades
{
    /// <summary>
    /// Clase LogroVoF, registra cualquier logro
    /// que puede ocurrir en un partido, que no dependa de un
    /// jugador o equipo
    /// </summary>
    public class LogroVoF: LogroPartido
    {
        private bool _respuesta;//Respuesta para identificar si ocurrio o no el logro
        private TipoLogro _idTipo; //id del tipo de logro (Cantidad,VOF, Equipo, Jugador)

        /// <summary>
        /// Get y Set para asignar la respuesta si ocurrio o no el logro 
        /// </summary>
        public bool Respuesta { get => _respuesta; set => _respuesta = value; }

        /// <summary>
        /// Get y Set del tipo de logro
        /// </summary>
        public TipoLogro IdTipo { get => _idTipo; set => _idTipo = value; }
    }
}