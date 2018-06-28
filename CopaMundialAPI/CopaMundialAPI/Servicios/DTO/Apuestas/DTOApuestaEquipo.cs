using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace CopaMundialAPI.Servicios.DTO.Apuestas
{
    public class DTOApuestaEquipo
    {
        private int _idUsuario;
        private int _idLogro;
        private int _idEquipo;
        private string _nombreEquipo;
        private string _estado;
        private string _logro;
        private string _fecha;

        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public int IdLogro { get => _idLogro; set => _idLogro = value; }
        public int IdEquipo { get => _idEquipo; set => _idEquipo = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public string Logro { get => _logro; set => _logro = value; }
        public string Fecha { get => _fecha; set => _fecha = value; }
        public string NombreEquipo { get => _nombreEquipo; set => _nombreEquipo = value; }
    }
}