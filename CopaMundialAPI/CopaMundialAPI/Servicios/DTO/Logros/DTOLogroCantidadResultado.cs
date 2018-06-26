using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Servicios.DTO.Logros
{
    public class DTOLogroCantidadResultado
    {
        private int _idLogroCantidad;
        private int _idPartido;
        private string _logroCantidad;
        private int _tipoLogro;
        private int _cantidad; 

        public int IdLogroCantidad { get => _idLogroCantidad; set => _idLogroCantidad = value; }
        public int IdPartido { get => _idPartido; set => _idPartido = value; }
        public string LogroCantidad { get => _logroCantidad; set => _logroCantidad = value; }
        public int TipoLogro { get => _tipoLogro; set => _tipoLogro = value; }
        public int Cantidad { get => _cantidad; set => _cantidad = value; }
    }
}