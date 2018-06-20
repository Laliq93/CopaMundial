using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Entidades
{
    public class Equipo : Entidad
    {
        private string _pais;

        public Equipo(int id, string pais)
        {
            Id = id;
            _pais = pais.ToLower();
        }

        public string Pais { get => _pais; set => _pais = value; }
    }
}