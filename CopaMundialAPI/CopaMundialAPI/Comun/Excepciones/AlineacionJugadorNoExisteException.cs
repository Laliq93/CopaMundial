using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Excepciones
{
    public class AlineacionJugadorNoExisteException : ExcepcionPersonalizada
    {
        public AlineacionJugadorNoExisteException(string mensaje) : base(mensaje)
        {
        }
    }
}