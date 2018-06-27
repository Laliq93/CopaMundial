using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Servicios.DTO.Logros
{
    public class DTOLogroCantidad
    {
        private int _idPartido;
        private string _logroCantidad;
        private int _tipoLogro;

      
        public int IdPartido { get => _idPartido; set => _idPartido = value; }
        public string LogroCantidad { get => _logroCantidad; set => _logroCantidad = value; }
        public int TipoLogro { get => _tipoLogro; set => _tipoLogro = value; }
     
        
    }
}