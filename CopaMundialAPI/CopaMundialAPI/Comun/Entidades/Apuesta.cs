using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Entidades
{
    public class Apuesta : Entidad
    {
        //private Usuario _usuario;
        //private Logro _logro;
        private DateTime _fecha;
        private string _contenido;
        private string _resultado;

        public Apuesta()
        {

        }


        //public Usuario Usuario { get => _usuario; set => _usuario = value; }
        //public Logro Logro { get => _logro; set => _logro = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public string Contenido { get => _contenido; set => _contenido = value; }
        public string Resultado { get => _resultado; set => _resultado = value; }
    }
}