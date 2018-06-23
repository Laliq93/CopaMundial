using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Entidades
{
    public class ApuestaJugador : Apuesta
    {
        private Jugador _respuesta;

        public Jugador Respuesta { get => _respuesta; set => _respuesta = value; }
    }
}