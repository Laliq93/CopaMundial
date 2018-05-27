using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{

    /// <summary>
    /// Clase que contiene los datos del la alineacion
    /// del partido
    /// </summary>
    public class Alineacion
    {
        private int _id; //id de la alineacion
        private Jugador _jugador;//jugador 
        private int _equipo;//id del equipo 
        private string _posicion;//posicion del jugador en cancha   
        private bool _capitan;//si el jugador es o no capitan
        private bool _titular;//si el jugador es titular o suplente
       

        /// <summary>
        /// Constructor para la clase Alineacion
        /// </summary>
        /// <param name="id"></param>
        /// <param name="jugador"></param>
        /// <param name="equipo"></param>
        /// <param name="posicion"></param>
        /// <param name="capitan"></param>
        /// <param name="titular"></param>
        public Alineacion(int id, Jugador jugador, int equipo, 
                          string posicion, bool capitan, bool titular)
       {
            _id = id;
            _jugador = jugador;
            _equipo = equipo;
            _posicion = posicion;
            _capitan = capitan;
            _titular = titular;

        }

        public Alineacion()
        { }


        /// <summary>
        /// Id de la alineacion
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        ///Get y Set del los datos del Jugador
        /// </summary>
        public Jugador Jugador
        {
            get { return _jugador; }
            set { _jugador = value; }
        }

        /// <summary>
        /// Get y Set del nombre del Equipo
        /// </summary>
        public int Equipo
        {
            get { return _equipo; }
            set { _equipo = value; }
        }



        /// <summary>
        /// Posicion del jugador en la cancha
        /// </summary>
        public string Posicion
        {
            get { return _posicion; }
            set { _posicion = value; }
        }


        /// <summary>
        /// Get y set si el jugador es o no 
        /// el capitan del equipo
        /// </summary>
        public bool Capitan
        {
            get { return _capitan; }
            set { _capitan = value; }
        }


        /// <summary>
        /// Get y set si el jugador es titular= true
        /// si el jugador es suplente= false
        /// </summary>
        public bool Titular
        {
            get { return _titular; }
            set { _titular = value; }
        }
    }
}