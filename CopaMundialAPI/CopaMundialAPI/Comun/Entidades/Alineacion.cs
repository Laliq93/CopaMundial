using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Entidades
{
    /// <summary>
    /// Almacena las alineaciones asociadas a los partidos.
    /// </summary>
    public class Alineacion : Entidad
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
        private Equipo _equipo;
        // al_pa_id
        private Partido _partido;

        /// <summary>
        /// Constructor de la entidad Alineacion
        /// </summary>
        /// <param name="id">Id de la alineacion</param>
        /// <param name="esCapitan">Indica si el jugador es Capitan</param>
        /// <param name="posicion">Posicion en la juega el jugador</param>
        /// <param name="esTitular">Si es titular o suplente</param>
        /// <param name="jugador">Entidad jugador correspondiente</param>
        /// <param name="equipo">Entidad equipo asociada al jugador</param>
        /// <param name="partido">Entidad partido asociada a la alineacion</param>
        public Alineacion(int id, bool esCapitan, string posicion, bool esTitular, Jugador jugador,
                          Equipo equipo, Partido partido)
        {
            Id = id;
            EsCapitan = esCapitan;
            Posicion = posicion;
            EsTitular = esTitular;
            Jugador = jugador;
            Equipo = equipo;
            Partido = partido;
        }

        public Alineacion() {}

        public Boolean EsCapitan { get => _esCapitan; set => _esCapitan = value; }
        public string Posicion { get => _posicion; set => _posicion = value; }
        public Boolean EsTitular { get => _esTitular; set => _esTitular = value; }

        public Jugador Jugador { get => _jugador; set => _jugador = value; }
        public Equipo Equipo { get => _equipo; set => _equipo = value; }
        public Partido Partido { get => _partido; set => _partido = value; }
    }
}