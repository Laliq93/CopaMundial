using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Entidades
{
    public class Equipos
    {
        private List<Equipo> _equipos;

        public Equipos()
        {
            _equipos = new List<Equipo>();

            _equipos.Add(new Equipo(1, "Argentina"));
            _equipos.Add(new Equipo(2, "Brasil"));
            _equipos.Add(new Equipo(3, "España"));
            _equipos.Add(new Equipo(4, "Islandia"));
            _equipos.Add(new Equipo(5, "Irán"));
            _equipos.Add(new Equipo(6, "Inglaterra"));
            _equipos.Add(new Equipo(7, "Colombia"));
            _equipos.Add(new Equipo(8, "Mexico"));
            _equipos.Add(new Equipo(9, "Rusia"));
            _equipos.Add(new Equipo(10, "Alemania"));
            _equipos.Add(new Equipo(11, "Portugal"));
            _equipos.Add(new Equipo(12, "Peru"));
            _equipos.Add(new Equipo(13, "Arabia Saudita"));
            _equipos.Add(new Equipo(14, "Francia"));
            _equipos.Add(new Equipo(15, "Uruguay"));
        }

        public List<Equipo> ListaEquipos { get => _equipos; set => _equipos = value; }


        public Equipo GetEquipo(int id)
        {
            return _equipos.Find(e => e.Id == id);
        }

    }
}