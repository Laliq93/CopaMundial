using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Jugador
    {
        private int _id;
        private string _nombre;
        private string _apellido;
        private string _fechaNacimiento;
        private string _lugarNacimiento;
        private double _peso;
        private double _altura;
        private string _club;
        private string _equipo;
        private int _numero;
        private string _posicion;
        private bool _capitan;

        public Jugador(string nombre, string apellido, string fechaNacimiento, string lugarNacimiento, double peso,
        double altura, string club, int equipo, int numero, string posicion, bool capitan)
        {
            _nombre = nombre;
            _apellido = apellido;
            _fechaNacimiento = fechaNacimiento;
            _lugarNacimiento = lugarNacimiento;
            _peso = peso;
            _altura = altura;
            _club = club;
            _equipo = equipo;
            _numero = numero;
            _posicion = posicion;
            _capitan = capitan;
        }

        public Jugador(int id, string nombre, string apellido, string fechaNacimiento, string lugarNacimiento, double peso,
        double altura, string club, int equipo, int numero, string posicion, bool capitan)
        {
            _id = id;
            _nombre = nombre;
            _apellido = apellido;
            _fechaNacimiento = fechaNacimiento;
            _lugarNacimiento = lugarNacimiento;
            _peso = peso;
            _altura = altura;
            _club = club;
            _equipo = equipo;
            _numero = numero;
            _posicion = posicion;
            _capitan = capitan;
        }

        public int Id
        {
            get { return _id; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        public DateTime FechaNacimiento
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }

        public string LugarNacimiento
        {
            get { return _lugarNacimiento; }
            set { _lugarNacimiento = value; }
        }

        public double Peso
        {
            get { return _peso; }
            set { _peso = value; }
        }

        public double Altura
        {
            get { return _altura; }
            set { _altura = value; }
        }

        public string Club
        {
            get { return _club; }
            set { _club = value; }
        }

        public string Equipo
        {
            get { return _equipo; }
            set { _equipo = value; }
        }

        public int Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

        public string Posicion
        {
            get { return _posicion; }
            set { _posicion = value; }
        }

        public bool Capitan
        {
            get { return _capitan; }
            set { _capitan = value; }
        }
    }
}