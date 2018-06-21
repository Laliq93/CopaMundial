using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Servicios.DTO.Apuestas
{
    public class DTOApuestaJugador
    {
        private int _idUsuario;
        private int _idLogro;
        private int _idJugador;
        private string _estado;

        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public int IdLogro { get => _idLogro; set => _idLogro = value; }
        public int IdJugador { get => _idJugador; set => _idJugador = value; }
        public string Estado { get => _estado; set => _estado = value; }
    }
}