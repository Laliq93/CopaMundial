using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.Usuario
{
    public class Rol
    {
        private int _id;
        private string _nombre;
        private string _descripcion;
        private List<Privilegio> _privilegios;

        public Rol (int id, string nombre, string descripcion)
        {
            _id = id;
            _nombre = nombre;
            _descripcion = descripcion;
        }

        public int id
        {
            get { return _id; }
        }

        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public List<Privilegio> privilegios
        {
            get { return _privilegios; }
            set { _privilegios = value; }
        }
    }
}