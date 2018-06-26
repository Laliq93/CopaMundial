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
        // pa_status
        private Boolean _estatus;

        // pa_eq1_id
        private Equipo _equipo1;
        // pa_eq2_id
        private Equipo _equipo2;
        // pa_es_id
        private Estadio _estadio;

        private List<Alineacion> _alineaciones;

        public DateTime FechaInicioPartido { get => _fechaInicioPartido; set => _fechaInicioPartido = value; }
        public DateTime FechaFinPartido { get => _fechaFinPartido; set => _fechaFinPartido = value; }
        public string Arbitro { get => _arbitro; set => _arbitro = value; }
        public bool Estatus { get => _estatus; set => _estatus = value; }

        public Equipo Equipo1 { get => _equipo1; set => _equipo1 = value; }
        public Equipo Equipo2 { get => _equipo2; set => _equipo2 = value; }
        public Estadio Estadio { get => _estadio; set => _estadio = value; }

        public List<Alineacion> Alineaciones { get => _alineaciones; set => _alineaciones = value; }
    }
}