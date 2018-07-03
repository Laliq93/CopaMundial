using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Servicios.DTO.Partidos
{
    public class DTOAlineacionNuevo
    {
        private Boolean _esCapitan;
        private String _posicion;
        private Boolean _esTitular;

        private int _jugador;
        private int _equipo;
        private int _partido;

        public bool EsCapitan { get => _esCapitan; set => _esCapitan = value; }
        public string Posicion { get => _posicion; set => _posicion = value; }
        public bool EsTitular { get => _esTitular; set => _esTitular = value; }

        public int Jugador { get => _jugador; set => _jugador = value; }
        public int Equipo { get => _equipo; set => _equipo = value; }
        public int Partido { get => _partido; set => _partido = value; }
    }
}