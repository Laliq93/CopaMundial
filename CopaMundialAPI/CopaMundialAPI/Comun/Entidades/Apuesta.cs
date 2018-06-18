using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Entidades
{
    public abstract class Apuesta : Entidad
    {
        private Usuario _usuario;
        private LogroPartido _logro;
        private DateTime _fecha;
        private string _resultado;

        public Usuario Usuario { get => _usuario; set => _usuario = value; }
        public LogroPartido Logro { get => _logro; set => _logro = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public string Resultado { get => _resultado; set => _resultado = value; }
    }
}