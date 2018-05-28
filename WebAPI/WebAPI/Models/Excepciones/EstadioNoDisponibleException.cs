using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WebAPI.Models.Excepciones
{

    /// <summary>
    /// Clase excepcion cuando un estadio esta ocupado 
    /// cuando se va asignar un nuevo partido
    /// </summary>
    [Serializable()]
    public class EstadioNoDisponibleException : Exception
    {

        public readonly int ERROR_CODE = 602;
        public readonly String ERROR_MSG = "Ha ocurrido un error, el estadio ya tiene asignado un partido en ese momento";
        private String _clase;  //indica la clase c# en la que se produjo la excepcion
        private String _metodo; //indica el metodo que produjo la excepcion
        private int _idPartido; //indica el id del partido que ocupa el estadio en ese momento
        private string _fecha; //fecha del partido
        private string _hora; //hora del partido
        private int _estadio;//estadio del partido

        /// <summary>
        ///  Constructor de la excepcion  EstadioNoDisponibleException
        /// </summary>
        /// <param name="error"></param>
        /// <param name="clase"></param>
        /// <param name="metodo"></param>
        /// <param name="idPartido"></param>
        /// <param name="fecha"></param>
        /// <param name="hora"></param>
        /// <param name="estadio"></param>
        public EstadioNoDisponibleException(Exception error, String clase, String metodo,
                                            int idPartido, string fecha, string hora, int estadio)
        {
            base.Equals(error);
            _clase = clase;
            _metodo = metodo;
            _idPartido = idPartido;
        }


        /// <summary>
        /// Segundo constructor de la clase EstadioNoDisponibleException
        /// </summary>
        /// <param name="error"></param>
        /// <param name="clase"></param>
        /// <param name="metodo"></param>
        /// <param name="fecha"></param>
        /// <param name="hora"></param>
        /// <param name="estadio"></param>
        public EstadioNoDisponibleException(String clase, String metodo,
                                           string fecha, string hora, int estadio)
        {
            _clase = clase;
            _metodo = metodo;
            _fecha = fecha;
            _hora = hora;
            _estadio = estadio;
        }

        /// <summary>
        /// Metodo para construir el mensaje de error
        /// </summary>
        /// <returns></returns>
        public virtual String toString()
        {
            StringBuilder str = null;


            str = new StringBuilder(ERROR_CODE + "\n");
            str.Append(ERROR_MSG + "\n");
            str.Append(base.ToString());

            return str.ToString();
        }

    }
}