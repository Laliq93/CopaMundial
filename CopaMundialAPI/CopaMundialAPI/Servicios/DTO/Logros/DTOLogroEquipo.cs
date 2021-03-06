﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Servicios.DTO.Logros
{
    public class DTOLogroEquipo
    {
        private int _idPartido;
        private string _logroEquipo;
        private int _tipoLogro;


        public int IdPartido { get => _idPartido; set => _idPartido = value; }
        public string LogroEquipo { get => _logroEquipo; set => _logroEquipo = value; }
        public int TipoLogro { get => _tipoLogro; set => _tipoLogro = value; }
    }
}