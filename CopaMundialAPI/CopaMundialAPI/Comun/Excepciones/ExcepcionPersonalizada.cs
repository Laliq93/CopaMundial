using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Excepciones
{
    public class ExcepcionPersonalizada: Exception
    {

        private string _mensaje; //Breve descripción de la excepción generada.

        public ExcepcionPersonalizada(string mensaje)
        {
            _mensaje = mensaje;
        }

        public ExcepcionPersonalizada()
        {
            _mensaje = "Ocurrio un error desconocido";
        }

        /// <summary>
        /// Getters y Setters del atributo _mensaje
        /// </summary>
        public string Mensaje { get => _mensaje; set => _mensaje = value; }
    }
}