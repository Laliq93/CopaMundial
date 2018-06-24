using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Entidades
{
    public class ApuestaVoF : Apuesta
    {
        private bool _respuesta;
        private LogroVoF _logro;

        public bool Respuesta { get => _respuesta; set => _respuesta = value; }
        public LogroVoF Logro { get => _logro; set => _logro = value; }
    }
}