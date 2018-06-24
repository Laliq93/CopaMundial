using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Servicios.DTO.Jugadores
{
    /// <summary>
    /// 
    /// </summary>
    public class DTOJugadorId
    {

        private int _id;

        public DTOJugadorId() { }

        public int Id { get => _id; set => _id = value; }

    }
}