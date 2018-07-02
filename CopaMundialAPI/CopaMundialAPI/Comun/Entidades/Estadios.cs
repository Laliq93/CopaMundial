using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Entidades
{
    public class Estadios
    {
        private List<Estadio> _estadios;

        public Estadios()
        {
            _estadios = new List<Estadio>();

            _estadios.Add(new Estadio(1, "Rostov Arena"));
            _estadios.Add(new Estadio(2, "Spartak Stadium"));
            _estadios.Add(new Estadio(3, "Luzhniki Stadium"));
            _estadios.Add(new Estadio(4, "Nizhny Novgorod Stadium"));
            _estadios.Add(new Estadio(5, "Samara Arena"));
            _estadios.Add(new Estadio(6, "Kazan Arena"));
            _estadios.Add(new Estadio(7, "Saint Petersburg Stadium"));
            _estadios.Add(new Estadio(8, "Mordovia Arena"));
            _estadios.Add(new Estadio(9, "Ekaterinburg Arena"));
            _estadios.Add(new Estadio(10, "Kaliningrad Stadium"));
            _estadios.Add(new Estadio(11, "Volgogrado Arena"));
            _estadios.Add(new Estadio(12, "Fisht Stadium"));
        }

        public List<Estadio> ListaEstadios { get => _estadios; set => _estadios = value; }


        public Estadio GetEstadio(int id)
        {
            return _estadios.Where(e => e.Id == id).FirstOrDefault<Estadio>();
        }

    }
}