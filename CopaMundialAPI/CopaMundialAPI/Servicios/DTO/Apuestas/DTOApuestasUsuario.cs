using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Servicios.DTO.Apuestas
{
    public class DTOApuestasUsuario
    {
        private int _idUsuario;
        private int _idLogro;
        private string _contenido;
        private string _resultado;
        private string _fechaApuesta;

        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public int IdLogro { get => _idLogro; set => _idLogro = value; }
        public string Contenido { get => _contenido; set => _contenido = value; }
        public string Resultado { get => _resultado; set => _resultado = value; }
        public string FechaApuesta { get => _fechaApuesta; set => _fechaApuesta = value; }
    }
}