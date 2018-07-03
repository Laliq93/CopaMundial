using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Servicios.DTO.Logros
{
    public class DTOLogroVFResultado
    {
        private int _idLogroVF;
        private string _logroVF;
        private int _tipoLogro;
        private bool _respuesta;

        public int IdLogroVF { get => _idLogroVF; set => _idLogroVF = value; }
        public string LogroVF { get => _logroVF; set => _logroVF = value; }
        public int TipoLogro { get => _tipoLogro; set => _tipoLogro = value; }
        public bool Respuesta { get => _respuesta; set => _respuesta = value; }
    }
}