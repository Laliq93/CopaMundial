using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Excepciones
{
    public class LogrosFinalizadosNoExisteException: Exception
    {
        private string _mensaje;
        private DateTime _fecha;
        private int _idPartido;
        private string _tipoLogro;

        public LogrosFinalizadosNoExisteException(int idPartido, string tipoLogro)
        {
            _mensaje = "El partido seleccionado no posee logros con resultados asignados.";
            _fecha = DateTime.Now;
            _idPartido = idPartido;
            _tipoLogro = tipoLogro;
        }

        public string Mensaje { get => _mensaje; set => _mensaje = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public int IdPartido { get => _idPartido; set => _idPartido = value; }
        public string Tipologro { get => _tipoLogro; set => _tipoLogro = value; }
    }
}