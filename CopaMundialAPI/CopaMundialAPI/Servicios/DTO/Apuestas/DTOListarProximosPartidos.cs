using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Servicios.DTO.Apuestas
{
    public class DTOListarProximosPartidos
    {
        private int _idPartido;
        private string _equipo1;
        private string _equipo2;
        private string _fecha;

        public int IdPartido { get => _idPartido; set => _idPartido = value; }
        public string Equipo1 { get => _equipo1; set => _equipo1 = value; }
        public string Equipo2 { get => _equipo2; set => _equipo2 = value; }
        public string Fecha { get => _fecha; set => _fecha = value; }
    }
}