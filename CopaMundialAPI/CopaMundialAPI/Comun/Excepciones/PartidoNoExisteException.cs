using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Excepciones
{
    public class PartidoNoExisteException : ExcepcionPersonalizada
    {
        public PartidoNoExisteException(string mensaje)
        {
            Mensaje = mensaje;
        }
    }
}