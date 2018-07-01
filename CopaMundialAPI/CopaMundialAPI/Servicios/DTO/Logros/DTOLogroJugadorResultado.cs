using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Servicios.DTO.Logros
{
    public class DTOLogroJugadorResultado
    {
        private int _idLogroJugador;
        private string _logroJugador;
        private int _tipoLogro;
        private int _jugador;


        public int IdLogroJugador { get => _idLogroJugador; set => _idLogroJugador = value; }
        public string LogroJugador { get => _logroJugador; set => _logroJugador = value; }
        public int TipoLogro { get => _tipoLogro; set => _tipoLogro = value; }
        public int Jugador { get => _jugador; set => _jugador = value; }

    }
}