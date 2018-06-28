using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Servicios.DTO.Logros
{
    public class DTOLogroJugador
    {
        private int _idPartido;
        private string _logroJugador;
        private int _tipoLogro;


        public int IdPartido { get => _idPartido; set => _idPartido = value; }
        public string LogroJugador { get => _logroJugador; set => _logroJugador = value; }
        public int TipoLogro { get => _tipoLogro; set => _tipoLogro = value; }
    }
}