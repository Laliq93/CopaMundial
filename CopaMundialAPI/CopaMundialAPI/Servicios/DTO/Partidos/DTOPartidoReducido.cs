using CopaMundialAPI.Servicios.DTO.Equipos;
using CopaMundialAPI.Servicios.DTO.Estadios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Servicios.DTO.Partidos
{
    public class DTOPartidoReducido
    {
        private int _id;
        private DateTime _fechaInicioPartido;
        private DateTime _fechaFinPartido;
        private String _arbitro;

        private DTOEquipo _equipo1;
        private DTOEquipo _equipo2;
        private DTOEstadio _estadio;

        public int Id { get => _id; set => _id = value; }
        public DateTime FechaInicioPartido { get => _fechaInicioPartido; set => _fechaInicioPartido = value; }
        public DateTime FechaFinPartido { get => _fechaFinPartido; set => _fechaFinPartido = value; }
        public string Arbitro { get => _arbitro; set => _arbitro = value; }

        public DTOEquipo Equipo1 { get => _equipo1; set => _equipo1 = value; }
        public DTOEquipo Equipo2 { get => _equipo2; set => _equipo2 = value; }
        public DTOEstadio Estadio { get => _estadio; set => _estadio = value; }
    }
}