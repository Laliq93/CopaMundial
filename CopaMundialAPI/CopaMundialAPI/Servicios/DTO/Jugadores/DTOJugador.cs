using CopaMundialAPI.Comun.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Servicios.DTO.Jugadores
{
    public class DTOJugador
    {
        private string _nombre;
        private string _apellido;
        private string _fechaNacimiento;
        private string _lugarNacimiento;
        private double _peso;
        private double _altura;
        private string _posicion;
        private int _numero;
        private Equipo _equipo;
        private bool _capitan;
        private bool _activo;

        public DTOJugador() { }

        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public string FechaNacimiento { get => _fechaNacimiento; set => _fechaNacimiento = value; }
        public string LugarNacimiento { get => _lugarNacimiento; set => _lugarNacimiento = value; }
        public double Peso { get => _peso; set => _peso = value; }
        public double Altura { get => _altura; set => _altura = value; }
        public string Posicion { get => _posicion; set => _posicion = value; }
        public int Numero { get => _numero; set => _numero = value; }
        public Equipo Equipo { get => _equipo; set => _equipo = value; }
        public bool Capitan { get => _capitan; set => _capitan = value; }
        public bool Activo { get => _activo; set => _activo = value; }

    }

    
}