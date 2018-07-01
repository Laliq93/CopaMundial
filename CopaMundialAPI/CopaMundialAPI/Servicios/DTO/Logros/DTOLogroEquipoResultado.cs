using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Servicios.DTO.Logros
{
    public class DTOLogroEquipoResultado
    {

        private int _idLogroEquipo;
        private string _logroEquipo;
        private int _tipoLogro;
        private int _equipo;
        private string _nombreEquipo;
     

        public int IdLogroEquipo { get => _idLogroEquipo; set => _idLogroEquipo = value; }
        public string LogroEquipo { get => _logroEquipo; set => _logroEquipo = value; }
        public int TipoLogro { get => _tipoLogro; set => _tipoLogro = value; }
        public int Equipo { get => _equipo; set => _equipo = value; }
        public string NombreEquipo { get => _nombreEquipo; set => _nombreEquipo = value; }
      
    }
}