using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Excepciones
{
    public class CasteoInvalidoException : ExcepcionPersonalizada
    {
        public CasteoInvalidoException(string mensaje) : base(mensaje)
        {
        }
    }
}