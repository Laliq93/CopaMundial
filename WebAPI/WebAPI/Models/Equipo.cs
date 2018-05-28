using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    /// <summary>
    /// Clase que contiene los atributos del equipo
    /// </summary>
    public class Equipo
    {
        private Pais _pais;
        private List<I18nEquipo> _descripcion ;
        private bool _status;
        private string _grupo;
        private bool _habilitado;

        /// <summary>
        /// Constructor de la clase Equipo con parametros
        /// </summary>
        public Equipo(Pais pais, List<I18nEquipo> descripcion, bool status, string grupo, bool habilitado)
        {
            _pais = pais;
            _descripcion = descripcion;
            _status = status;
            _grupo = grupo;
            _habilitado = habilitado;
        }

        /// <summary>
        /// Constructor de la clase Equipo vacio
        /// </summary>
        public Equipo()
        {

        }
        
        /// <summary>
        /// Getters y Setters del atributo pais
        /// </summary>
        public Pais Pais
        {
            get { return _pais; }
            set { _pais = value; }
        }

        /// <summary>
        /// Getters y Setters del atributo descripcion
        /// </summary>
        public List<I18nEquipo> Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        /// <summary>
        /// Getters y Setters del atributo status
        /// </summary>
        public bool Status
        {
            get { return _status; }
            set { _status = value; }
        }

        /// <summary>
        /// Getters y Setters del atributo grupo
        /// </summary>
        public string Grupo
        {
            get { return _grupo; }
            set { _grupo = value; }
        }

        /// <summary>
        /// Getters y Setters del atributo habilitado
        /// </summary>
        public bool Habilitado
        {
            get { return _habilitado; }
            set { _habilitado = value; }
        }
    }

}