using CopaMundialAPI.Servicios.DTO.Equipos;
using CopaMundialAPI.Servicios.DTO.Jugadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Servicios.DTO.Partidos
{
    public class DTOAlineacion
    {
        private int _id;
        private Boolean _esCapitan;
        private String _posicion;
        private Boolean _esTitular;

        private DTOJugador _jugador;
        private DTOEquipo _equipo;
        private DTOPartido _partido;

        public int Id { get => _id; set => _id = value; }
        public bool EsCapitan { get => _esCapitan; set => _esCapitan = value; }
        public string Posicion { get => _posicion; set => _posicion = value; }
        public bool EsTitular { get => _esTitular; set => _esTitular = value; }

        public DTOJugador Jugador { get => _jugador; set => _jugador = value; }
        public DTOEquipo Equipo { get => _equipo; set => _equipo = value; }
        public DTOPartido Partido { get => _partido; set => _partido = value; }
    }
}