using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Servicios.DTO.Logros
{
    public class DTOMostrarLogrosPartido
    {
        private int _idLogro;
        private string _logro;

        public int IdLogro { get => _idLogro; set => _idLogro = value; }
        public string Logro { get => _logro; set => _logro = value; }
    }
}