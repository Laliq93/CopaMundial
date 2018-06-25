using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Excepciones
{
    public class ApuestaRepetidaException : Exception
    {
        private string _mensaje;
        private DateTime _fecha;

        public ApuestaRepetidaException()
        {
            _mensaje = "Ya registraste esta apuesta.";
            _fecha = DateTime.Now;
        }

        public string Mensaje { get => _mensaje; set => _mensaje = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
    }
}