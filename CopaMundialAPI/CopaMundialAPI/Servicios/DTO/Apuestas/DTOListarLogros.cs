using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Servicios.DTO.Apuestas
{
    public class DTOListarLogros
    {
        private int _idLogro;
        private string _contenido;

        public int IdLogro { get => _idLogro; set => _idLogro = value; }
        public string Contenido { get => _contenido; set => _contenido = value; }
    }
}