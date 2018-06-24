using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Entidades
{
    public class ApuestaEquipo : Apuesta
    {
        private Equipo _respuesta;

        public Equipo Respuesta { get => _respuesta; set => _respuesta = value; }
    }
}