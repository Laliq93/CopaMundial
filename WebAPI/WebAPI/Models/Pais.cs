using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    /// <summary>
    /// Clase que contiene los atributos del pais
    /// </summary>
    public class Pais
    {
        private string _iso;
        private I18nEquipo _nombre;

        /// <summary>
        /// Constructor de la clase Pais con parametros
        /// </summary>
        public Pais(string iso, I18nEquipo nombre)
        {
            _iso = iso;
            _nombre = nombre;
        }

        /// <summary>
        /// Constructor de la clase Pais vacio
        /// </summary>
        public Pais()
        {

        }

        /// <summary>
        /// Getters y Setters del atributo iso
        /// </summary>
        public string Iso
        {
            get { return _iso; }
            set { _iso = value; }
        }

        /// <summary>
        /// Getters y Setters del atributo nombre
        /// </summary>
        public I18nEquipo Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

    }
}