using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Entidades
{
    public class ApuestaVoF : Apuesta
    {
        private bool _respuesta;

        public bool Respuesta { get => _respuesta; set => _respuesta = value; }
    }
}