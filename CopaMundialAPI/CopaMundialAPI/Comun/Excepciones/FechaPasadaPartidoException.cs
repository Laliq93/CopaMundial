using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Excepciones
{
    public class FechaPasadaPartidoException : ExcepcionPersonalizada
    {
        public FechaPasadaPartidoException(string mensaje) : base(mensaje)
        {
        }
    }
}