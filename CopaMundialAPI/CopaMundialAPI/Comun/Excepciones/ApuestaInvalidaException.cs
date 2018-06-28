using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Excepciones
{
    public class ApuestaInvalidaException : Exception
    {
        private string _mensaje;
        private DateTime _fecha;

        public ApuestaInvalidaException()
        {
            _mensaje = "No puedes modificar una apuesta cuando el partido ya ha iniciado.";
            _fecha = DateTime.Now;
        }

        public string Mensaje { get => _mensaje; set => _mensaje = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
    }
}