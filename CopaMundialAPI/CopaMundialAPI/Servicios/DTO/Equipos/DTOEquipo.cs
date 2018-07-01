using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Servicios.DTO.Equipos
{
    public class DTOEquipo
    {
        private int _id;
        private string _pais;

        public int Id { get => _id; set => _id = value; }
        public string Pais { get => _pais; set => _pais = value; }
    }
}