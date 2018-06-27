using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Excepciones
{
    /// <summary>
    /// Excepcion personalizada para errores generales 
    /// </summary>
    public class ExcepcionGeneral :Exception
    {
        private Exception _excepcion;   //Tipo de excepcion que se genero.
        private DateTime _fechaHora;   //Hora y fecha de cuando se genero la excepción.
        private string _mensaje;       //Breve descripción de la excepción genereda.

        public ExcepcionGeneral ( Exception excepcion, DateTime fechaHora)
        {
            _excepcion = excepcion;
            _fechaHora = fechaHora;
            _mensaje = "Error general";
        }

        /// <summary>
        /// Getters y Setters del atributo _excepcion
        /// </summary>
        public Exception Excepcion { get => _excepcion; set => _excepcion = value; }
        
        /// <summary>
        /// Getters y Setters del atributo _fechaHora
        /// </summary>
        public DateTime FechaHora { get => _fechaHora; set => _fechaHora = value; }
        
        /// <summary>
        /// Getters y Setters del atributo _mensaje
        /// </summary>
        public string Mensaje { get => _mensaje; set => _mensaje = value; }




    }
}