using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Excepciones
{
    public class DatabaseException : ExcepcionPersonalizada
    {
        public DatabaseException(string mensaje) : base(mensaje)
        {
        }
    }
}