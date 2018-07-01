using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Excepciones
{
    public class DatosInvalidosException : ExcepcionPersonalizada
    {
        public DatosInvalidosException(string mensaje)
        {
            Mensaje = mensaje;
        }
    }
}