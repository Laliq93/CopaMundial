using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Entidades
{
    public class Jugador : Entidad
    {
        private string _nombre;
        private string _apellido;
        private string _fechaNacimiento;
        private string _lugarNacimiento;
        private double _peso;
        private double _altura;
        private string _posicion;
        private int _numero;
        private string _equipo;
        private Boolean _capitan;
        private Boolean _activo;


        public Jugador() { }

        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public string FechaNacimiento { get => _fechaNacimiento; set => _fechaNacimiento = value; }
        public string LugarNacimiento { get => _lugarNacimiento; set => _lugarNacimiento = value; }
        public double Peso { get => _peso; set => _peso = value; }
        public double Altura { get => _altura; set => _altura = value; }
        public string Posicion { get => _posicion; set => _posicion = value; }
        public int Numero { get => _numero; set => _numero = value; }
        public string Equipo { get => _equipo; set => _equipo = value; }
        public Boolean Capitan { get => _capitan; set => _capitan = value; }
        public Boolean Activo { get => _activo; set => _activo = value; }
    }
}