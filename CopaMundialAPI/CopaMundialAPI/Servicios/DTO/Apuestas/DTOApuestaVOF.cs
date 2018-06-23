using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Servicios.DTO.Apuestas
{
    public class DTOApuestaVOF
    {
        private int _idUsuario;
        private int _idLogro;
        private bool _apuestaUsuario;
        private string _estado;
        private string _logro;

        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public int IdLogro { get => _idLogro; set => _idLogro = value; }
        public bool ApuestaUsuario { get => _apuestaUsuario; set => _apuestaUsuario = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public string Logro { get => _logro; set => _logro = value; }
    }
}