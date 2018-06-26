using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Entidades
{
    /// <summary>
    /// Almacena las alineaciones asociadas a los partidos.
    /// </summary>
    public class Alineacion: Entidad
    {
        // al_capitan
        private Boolean _esCapitan;
        // al_posicion
        private String _posicion;
        // al_titular
        private Boolean _esTitular;

        // al_ju_id
        private Jugador _jugador;
        // al_eq_id
        private Int32 _equipo;
        // al_pa_id
        private Partido _partido;

        public bool EsCapitan { get => _esCapitan; set => _esCapitan = value; }
        public string Posicion { get => _posicion; set => _posicion = value; }
        public bool EsTitular { get => _esTitular; set => _esTitular = value; }

        public Jugador Jugador { get => _jugador; set => _jugador = value; }
        public int Equipo { get => _equipo; set => _equipo = value; }
        public Partido Partido { get => _partido; set => _partido = value; }
    }
}