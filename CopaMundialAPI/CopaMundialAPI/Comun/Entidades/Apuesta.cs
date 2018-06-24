using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Entidades
{
    public abstract class Apuesta : Entidad
    {
        private Usuario _usuario;
        private string _fecha;
        private string _estado;

        public Usuario Usuario { get => _usuario; set => _usuario = value; }
        public string Fecha { get => _fecha; set => _fecha = value; }
        public string Estado { get => _estado; set => _estado = value; }
    }
}