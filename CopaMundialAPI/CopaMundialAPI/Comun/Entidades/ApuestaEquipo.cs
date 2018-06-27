using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Entidades
{
    public class ApuestaEquipo : Apuesta
    {
        private Equipo _respuesta;
        private LogroEquipo _logro;

        public Equipo Respuesta { get => _respuesta; set => _respuesta = value; }
        public LogroEquipo Logro { get => _logro; set => _logro = value; }
    }
}