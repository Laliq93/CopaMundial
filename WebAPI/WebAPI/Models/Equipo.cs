using System;

namespace WebAPI.Models
{
    /// <summary>
    /// Clase que contiene los atributos del equipo
    /// </summary>
    public class Equipo
    {

        private int _id; //identificador unico para el equipo
        private string _descripcion; //descripcion del pais al que pertenece el equipo
        private Boolean _status; //permite saber si el equipo sigue participando o no
        private Char _grupo; //grupo al que pertene el equipo
        private string _pais; //es el id del pais(nombre, ISO, bandera) al que pertenece el equipo
        private Boolean _habilitado; //fecha de nacimiento del usuario
        
        public Equipo(int id, string descripcion, string status, char grupo, 
            string pais, Boolean habilitado)
        {

            _id = id;
            _descripcion = descripcion;
            _status = status;
            _grupo = grupo;
            _pais = pais;
            _habilitado = habilitado;



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
        /// Getters y Setters del atributo descripcion
        /// </summary>
        public int Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        /// <summary>
        /// Getters y Setters del atributo status
        /// </summary>
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        /// <summary>
        /// Getters y Setters del atributo grupo
        /// </summary>
        public int Grupo
        {
            get { return _grupo; }
            set { _grupo = value; }
        }

        /// <summary>
        /// Getters y Setters del atributo pais
        /// </summary>
        public int Pais
        {
            get { return _pais; }
            set { _pais = value; }
        }

        /// <summary>
        /// Getters y Setters del atributo habilitado
        /// </summary>
        public int Habilitado
        {
            get { return _habilitado; }
            set { _habilitado = value; }
        }
    }

}