using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Entidades
{
    /// <summary>
    /// Almacena la información asociada a los partidos jugados o por jugar.
    /// </summary>
    public class Partido : Entidad
    {
        // pa_fechaInicio
        private DateTime _fechaInicioPartido;
        // pa_fechaFin
        private DateTime _fechaFinPartido;
        // pa_arbitro
        private String _arbitro;

        // pa_eq1_id
        private Equipo _equipo1;
        // pa_eq2_id
        private Equipo _equipo2;
        // pa_es_id
        private Estadio _estadio;

        private List<Alineacion> _alineaciones;

        /// <summary>
        /// Constructor de la entidad Partido con todos los parametros
        /// </summary>
        /// <param name="id">Id del partido</param>
        /// <param name="fechaInicioPartido">Fecha de inicio del partido</param>
        /// <param name="fechaFinPartido">Fecha de fin del partido</param>
        /// <param name="arbitro">Arbitro principal del partido</param>
        /// <param name="equipo1">Primer equipo que participara en el partido</param>
        /// <param name="equipo2">Segundo equipo que participara en el partido</param>
        /// <param name="estadio">Estadio donde se jugara</param>
        public Partido(int id, DateTime fechaInicioPartido, DateTime fechaFinPartido, string arbitro, 
                       Equipo equipo1, Equipo equipo2, Estadio estadio)
        {
            Id = id;
            FechaInicioPartido = fechaInicioPartido;
            FechaFinPartido = fechaFinPartido;
            Arbitro = arbitro;
            Equipo1 = equipo1;
            Equipo2 = equipo2;
            Estadio = estadio;
        }

        public Partido() {}

        public DateTime FechaInicioPartido { get => _fechaInicioPartido; set => _fechaInicioPartido = value; }
        public DateTime FechaFinPartido { get => _fechaFinPartido; set => _fechaFinPartido = value; }
        public string Arbitro { get => _arbitro; set => _arbitro = value; }

        public Equipo Equipo1 { get => _equipo1; set => _equipo1 = value; }
        public Equipo Equipo2 { get => _equipo2; set => _equipo2 = value; }
        public Estadio Estadio { get => _estadio; set => _estadio = value; }

        public List<Alineacion> Alineaciones { get => _alineaciones; set => _alineaciones = value; }
    }
}