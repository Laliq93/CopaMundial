using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.Usuario
{
    public class Privilegio
    {
        private int _id;
        private string _nombre;
        private string _descripcion; 

        public Privilegio (int id, string nombre, string descripcion)
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
    }
}