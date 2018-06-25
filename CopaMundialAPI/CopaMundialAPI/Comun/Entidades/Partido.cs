using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Entidades
{
    public class Partido : Entidad
    {
        private Equipo _equipo1;
        private Equipo _equipo2;
        private DateTime _fechaPartido;

        public Equipo Equipo1 { get => _equipo1; set => _equipo1 = value; }
        public Equipo Equipo2 { get => _equipo2; set => _equipo2 = value; }
        public DateTime FechaPartido { get => _fechaPartido; set => _fechaPartido = value; }
    }
}