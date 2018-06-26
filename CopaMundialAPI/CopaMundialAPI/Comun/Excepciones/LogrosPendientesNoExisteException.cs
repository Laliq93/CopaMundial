using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Excepciones
{
    /// <summary>
    /// Excepcion personalizada que valida si un partido
    /// tiene logros pendientes por asignar resultado
    /// </summary>
    public class LogrosPendientesNoExisteException: Exception
    {

        private string _mensaje;
        private DateTime _fecha;
        private int _idPartido;
        private string _tipoLogro;

        public LogrosPendientesNoExisteException(int idPartido, string tipoLogro)
        {
            _mensaje = "El partido seleccionado no posee logros pendientes.";
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