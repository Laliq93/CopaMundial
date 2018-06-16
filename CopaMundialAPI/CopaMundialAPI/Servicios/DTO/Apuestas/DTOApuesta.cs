using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Servicios.DTO.Apuestas
{
    public class DTOApuesta
    {
        private int _idUsuario;
        private int _idLogro;
        private string _contenido;

        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public int IdLogro { get => _idLogro; set => _idLogro = value; }
        public string Contenido { get => _contenido; set => _contenido = value; }
    }
}