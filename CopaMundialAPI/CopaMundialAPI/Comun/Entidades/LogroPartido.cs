using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Entidades
{
    public class LogroPartido : Entidad
    {
        //private Partido _partido;
        private string _logro;
        
        //public Partido Partido { get => _partido; set => _partido = value; }
        public string Logro { get => _logro; set => _logro = value; }
    }
}