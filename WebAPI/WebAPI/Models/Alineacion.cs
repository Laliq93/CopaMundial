using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Alineacion
    {
        private int _id; //id de la alineacion
        private string _jugador;//nombre del jugador 
        private string _equipo;//nombre del equipo 
        private string _posicion;//posicion del jugador en cancha   
        private bool _capitan;//si el jugador es o no capitan
        private bool _titular;//si el jugador es titular o suplente


        /// <summary>
        /// Constructor de la clase Alineacion
        /// </summary>
        /// <param name="id"></param>
        /// <param name="jugador"></param>
        /// <param name="equipo"></param>
        /// <param name="posicion"></param>
        /// <param name="titular"></param>
        public Alineacion(int id, string jugador, string equipo, string posicion, 
                            bool titular)
       {
            _id = id;
            _jugador = jugador;
            _equipo = equipo;
            _posicion = posicion;
            _titular = titular;

        }


        /// <summary>
        /// Id de la alineacion
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        ///Get y Set del Nombre del Jugador
        /// </summary>
        public string Jugador
        {
            get { return _jugador; }
            set { _jugador = value; }
        }

        /// <summary>
        /// Get y Set del nombre del Equipo
        /// </summary>
        public string Equipo
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


    }
}