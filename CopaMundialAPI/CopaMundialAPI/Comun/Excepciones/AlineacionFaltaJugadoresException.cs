using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Excepciones
{
    public class AlineacionFaltaJugadoresException : ExcepcionPersonalizada
    {
        public AlineacionFaltaJugadoresException(string mensaje)
        {
            Mensaje = mensaje;
        }
    }
}