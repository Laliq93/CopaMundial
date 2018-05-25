using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    /// <summary>
    /// Clase que contiene los datos del partido
    /// </summary>
    public class Partido
    {
        private int _id; //identificador unico del partido
        private string _arbitro; //nombre del arbitro
        private DateTime _fecha; //fecha del partido
        private string _horaInicio; //hora de inicio
        private string _horaFin; //hora de fin
        private int  _equipo1; //equipo 2
        private int _equipo2; //equipo 2
        private bool _status;//Estatus del partido 
        private int _estadio;//Estadio donde se jugara el partido
        private List<Alineacion> _alineacion1;//Alineacion del primer equipo
        private List<Alineacion> _alineacion2;//Alineacion del segundo equipo



        /// <summary>
        /// Metodo Constructor de la clase Partido
        /// </summary>
        /// <param name="id"></param>
        /// <param name="arbitro"></param>
        /// <param name="fecha"></param>
        /// <param name="horaInicio"></param>
        /// <param name="equipo1"></param>
        /// <param name="equipo2"></param>
        /// <param name="_status"></param>
        public Partido(int id, string arbitro, DateTime fecha, string horaInicio, int equipo1,
            int equipo2, int estadio, bool _status)
        {
            _id = id;
            _arbitro = arbitro;
            _fecha = fecha;
            _horaInicio = horaInicio;
            _equipo1= equipo1;
            _equipo2 = equipo2;
            _estadio = estadio;

        }

        /// <summary>
        /// Constructor de la clase Partido
        /// </summary>
        /// <param name="arbitro"></param>
        /// <param name="fecha"></param>
        /// <param name="horaInicio"></param>
        /// <param name="equipo1"></param>
        /// <param name="equipo2"></param>
        /// <param name="estadio"></param>
        public Partido(string arbitro, DateTime fecha, string horaInicio, int equipo1,
           int equipo2, int estadio)
        {
       
            _arbitro = arbitro;
            _fecha = fecha;
            _horaInicio = horaInicio;
            _equipo1 = equipo1;
            _equipo2 = equipo2;
            _estadio = estadio;

        }

        public Partido()
        {
        }

        /// <summary>
        /// Get y Set del Id del partido
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }


        /// <summary>
        /// Get y Set del nombre del arbitro
        /// </summary>
        public string Arbitro
        {
            get { return _arbitro; }
            set { _arbitro = value; }
        }

        /// <summary>
        /// Get y Set de la fecha del partido
        /// </summary>
        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value;}

        }


        /// <summary>
        /// Get y Set de la hora de inicio del partido
        /// </summary>
        public string HoraInicio
        {
            get { return _horaInicio; }
            set { _horaInicio = value; }

        }


        /// <summary>
        /// Get y Set de la hora fin del partido
        /// </summary>
        public string HoraFin
        {
            get { return _horaFin; }
            set { _horaFin = value;  }
        }


        /// <summary>
        /// Get y Set del id del primer equipo
        /// </summary>
        public int Equipo1
        {
            get { return _equipo1; }
            set { _equipo1 = value; }
        }

        /// <summary>
        /// Get y Set del id del segundo equipo
        /// </summary>
        public int Equipo2
        {
            get { return _equipo2; }
            set { _equipo2 = value; }
        }

        /// <summary>
        /// Get y set del id del estadio del partido
        /// </summary>
        public int Estadio
        {
            get { return _estadio; }
            set { _estadio = value; }
        }


        /// <summary>
        /// Get y set del status del partido 
        /// true si esta habilitado 
        /// false si esta deshabilitado el partido
        /// </summary>
        public bool Status
        {
            get { return _status; }
            set { _status = value; }
        }



        /// <summary>
        /// Get y Set de la alineacion del primer equipo
        /// </summary>
        public List<Alineacion> Alineacion1
        {
            get { return _alineacion1; }
            set { _alineacion1 = value; }
        }


        /// <summary>
        /// Get y Set de la alineacion del segundo equipo
        /// </summary>
        public List<Alineacion> Alineacion2
        {
            get { return _alineacion2; }
            set { _alineacion2 = value; }
        }

   

    }
}