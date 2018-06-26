using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Excepciones
{
    public class LogroNoExisteException: Exception
    {

        private string _mensaje;
        private DateTime _fecha;
        private int _idLogro;
        private string _tipoLogro;

        public LogroNoExisteException(int idLogro, string tipoLogro)
        {
            _mensaje = "El partido seleccionado no posee logros pendientes.";
            _fecha = DateTime.Now;
            _tipoLogro = tipoLogro;
        }

        public string Mensaje { get => _mensaje; set => _mensaje = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public int IdLogro { get => _idLogro; set => _idLogro = value; }
        public string Tipologro { get => _tipoLogro; set => _tipoLogro = value; }
    }
}