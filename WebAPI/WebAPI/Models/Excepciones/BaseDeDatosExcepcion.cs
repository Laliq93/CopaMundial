using Npgsql;
using System;
using System.Collections.Generic;

namespace WebAPI.Models.Excepciones
{

    /// <summary>
    /// Excepcion que atrapa las excepciones de la base de datos
    /// </summary>
    public class BaseDeDatosExcepcion : NpgsqlException
    {
        private NpgsqlException excepcion;
        private List<String> metodos; //lista de los metodos que atrapan la excepcion
        private DateTime fecha; //fecha y hora del momento en el que atrapan la excepcion
        private string datos; //datos de la excepcion
        private string mensaje; //mensaje de error


        /// <summary>
        /// Getter y setter del atributo excepcion
        /// </summary>
        public NpgsqlException Excepcion
        {
            get { return excepcion; }
            set { excepcion = value; }
        }

        /// <summary>
        /// Getter y setter de la lista de metodos
        /// </summary>
        public List<string> Metodos
        {
            get { return metodos; }
            set { metodos = value; }
        }

        /// <summary>
        /// Getter y setter del atributo fecha
        /// </summary>
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        /// <summary>
        /// Getter y setter del atributo datos
        /// </summary>
        public string Datos
        {
            get { return datos; }
            set { datos = value; }
        }

        /// <summary>
        /// Getter y setter del atributo mensaje
        /// </summary>
        public string Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; }
        }

        /// <summary>
        /// Constructor que recibe la excepcion, instacia la lista de metodos y, registra el momento exacto de la incidencia
        /// </summary>
        /// <param name="e">Excepcion de la base de datos</param>
        public BaseDeDatosExcepcion (NpgsqlException e)
        {
            excepcion = e;

            fecha = DateTime.Now;
            metodos = new List<String>();
        }
    }
}