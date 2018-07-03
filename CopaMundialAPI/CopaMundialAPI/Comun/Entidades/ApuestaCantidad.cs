using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Entidades
{
    public class ApuestaCantidad : Apuesta
    {
        private int _respuesta;
        private LogroCantidad _logro;


        public int Respuesta { get => _respuesta; set => _respuesta = value; }
        public LogroCantidad Logro { get => _logro; set => _logro = value; }
    }
}