using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Servicios.DTO.Logros
{
    public class DTOMostrarLogrosPartidos
    {
        private int _idLogro;
        private int _idTipo;
        private string _logro;

        public int IdLogro { get => _idLogro; set => _idLogro = value; }
        public int IdTipo { get => _idTipo; set => _idTipo = value; }
        public string Logro { get => _logro; set => _logro = value; }
    }
}