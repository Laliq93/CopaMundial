using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Excepciones
{
    public class AlineacionNoExisteException : ExcepcionPersonalizada
    {
        public AlineacionNoExisteException(string mensaje) : base(mensaje)
        {
        }
    }
}