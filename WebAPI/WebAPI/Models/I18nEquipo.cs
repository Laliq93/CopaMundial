using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    /// <summary>
    /// Clase que contiene los atributos de i18nEquipo
    /// </summary>
    public class I18nEquipo
    {
        private int _id;
        private string _idioma;
        private string _mensaje;

        /// <summary>
        /// Constructor de la clase I18nEquipo con parametros
        /// </summary>
        public I18nEquipo(int id, string idioma, string mensaje)
        {
            _id = id;
            _idioma = idioma;
            _mensaje = mensaje;
        }

        /// <summary>
        /// Constructor de la clase I18nEquipo vacio
        /// </summary>
        public I18nEquipo()
        {

        }

        /// <summary>
        /// Getters y Setters del atributo id
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// Getters y Setters del atributo isioma
        /// </summary>
        public string Idioma
        {
            get { return _idioma; }
            set { _idioma = value; }
        }

        /// <summary>
        /// Getters y Setters del atributo pais
        /// </summary>
        public string Mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }

    }
}