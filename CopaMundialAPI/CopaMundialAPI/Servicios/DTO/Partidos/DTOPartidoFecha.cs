using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Servicios.DTO.Partidos
{
    public class DTOPartidoFecha
    {
        private DateTime _fechaInicioPartido;

        public DateTime FechaInicioPartido { get => _fechaInicioPartido; set => _fechaInicioPartido = value; }
    }
}