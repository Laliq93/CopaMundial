using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Entidades
{
    /// <summary>
    /// Clase Logro Partido encargada de registrar 
    /// todos los logros que van a ocurrir en un partido
    /// </summary>
    public abstract class LogroPartido : Entidad
    {
        private Partido _partido; //Partido al cual se le asigna el logro
        private string _nombreTipo;//Nombre del tipo de logro  (Cantidad,VOF, Equipo, Jugador)
        private string _logro;//Nombre del logro
        private bool _status;//Status del logro (activo o no)


        /// <summary>
        /// Get y Set del Partido
        /// </summary>
        public Partido Partido { get => _partido; set => _partido = value; }

        /// <summary>
        /// Get y Set del Nombre del Tipo de logro
        /// </summary>
        public string NombreTipo { get => _nombreTipo; set => _nombreTipo = value; }

        /// <summary>
        /// Get y Set del Nombre del Logro
        /// </summary>
        public string Logro { get => _logro; set => _logro = value; }


        /// <summary>
        /// Get y Set del Status del Logro, si esta activo o no
        /// </summary>
        public bool Status { get => _status; set => _status = value; }



    }
}