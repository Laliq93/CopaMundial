using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Excepciones
{
    public class ObjetoNullException : Exception
    {
        private DateTime _fecha;
        private string _mensaje;
        private NullReferenceException _excepcion;

        public ObjetoNullException(NullReferenceException excepcion, string mensaje)
        {
            _fecha = DateTime.Now;
            _mensaje = mensaje;
            _excepcion = excepcion;
        }

        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public string Mensaje { get => _mensaje; set => _mensaje = value; }
        public NullReferenceException Excepcion { get => _excepcion; set => _excepcion = value; }

    }
}