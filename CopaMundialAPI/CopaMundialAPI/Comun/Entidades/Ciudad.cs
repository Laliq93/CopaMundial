using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Entidades
{
    public class Ciudad : Entidad
    {
        private string _nombre;
        private int _habitantes;
        private string _descripcion;
		private byte[] _imagen;

        public Ciudad ( string nombre, int habitantes, string descripcion,byte[] imagen)
        {
            Nombre = nombre;
            Habitantes = habitantes;
            Descripcion = descripcion;
			Imagen = imagen;
        }

        public string Nombre { get => _nombre; set => _nombre = value; }
        public int Habitantes { get => _habitantes; set => _habitantes = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
		public byte[] Imagen { get => _imagen; set => _imagen = value; }
    }
}