using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Servicios.DTO.Logros
{
    public class DTOListaPartidosLogros
    {
        private int _idPartido;
        private string _equipo1;
        private int _idEquipo1;
        private string _equipo2;
        private string _fecha;
        private int _idEquipo2;

        public int IdPartido { get => _idPartido; set => _idPartido = value; }
        public string Equipo1 { get => _equipo1; set => _equipo1 = value; }
        public string Equipo2 { get => _equipo2; set => _equipo2 = value; }
        public string Fecha { get => _fecha; set => _fecha = value; }
        public int  IdEquipo1 { get => _idEquipo1; set => _idEquipo1 = value; }
        public int IdEquipo2 { get => _idEquipo2; set => _idEquipo2 = value; }
    }
}