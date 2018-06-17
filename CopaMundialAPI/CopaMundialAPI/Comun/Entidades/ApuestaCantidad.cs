using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Entidades
{
    public class ApuestaCantidad : Apuesta
    {
        private int _respuesta;

        public int Respuesta { get => _respuesta; set => _respuesta = value; }
    }
}