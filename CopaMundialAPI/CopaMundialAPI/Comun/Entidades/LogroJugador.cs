using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Entidades
{
    /// <summary>
    /// Clase LogroJugador, registra un logro realizado por 
    /// un jugador
    /// </summary>
    public class LogroJugador: LogroPartido
    {
        private Jugador _jugador;//Jugador que realiza el logro
        private TipoLogro _idTipo; //id del tipo de logro (Cantidad,VOF, Equipo, Jugador)
        
        public LogroJugador() { }
        /// <summary>
        /// Get y Set del jugador que realizo el logro
        /// </summary>
        public Jugador Jugador { get => _jugador; set => _jugador = value; }
        
        /// <summary>
        /// Get y Set del tipo del logro
        /// </summary>
        public TipoLogro IdTipo { get => _idTipo; set => _idTipo = value; }
    }
}