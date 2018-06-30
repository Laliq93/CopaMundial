using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Entidades
{
    public class Estadio : Entidad
    {
        private string _nombre;

        public Estadio()
        {

        }

        public Estadio(int id, string nombre)
        {
            Id = id;
            _nombre = nombre.ToLower();
        }

        public string Nombre { get => _nombre; set => _nombre = value; }
    }
}