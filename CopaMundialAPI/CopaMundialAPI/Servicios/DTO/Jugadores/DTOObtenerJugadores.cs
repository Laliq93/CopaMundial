using CopaMundialAPI.Comun.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Servicios.DTO.Jugadores
{
    public class DTOObtenerJugadores
    {
        private int _id;
        private string _nombre;
        private string _apellido;
        private string _fechaNacimiento;
        private string _lugarNacimiento;
        private decimal _peso;
        private decimal _altura;
        private string _posicion;
        private decimal _numero;
        private string _equipo;
        private bool _capitan;


        public DTOObtenerJugadores() { }

        public int Id { get => _id; set => _id = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public string FechaNacimiento { get => _fechaNacimiento; set => _fechaNacimiento = value; }
        public string LugarNacimiento { get => _lugarNacimiento; set => _lugarNacimiento = value; }
        public decimal Peso { get => _peso; set => _peso = value; }
        public decimal Altura { get => _altura; set => _altura = value; }
        public string Posicion { get => _posicion; set => _posicion = value; }
        public decimal Numero { get => _numero; set => _numero = value; }
        public string Equipo { get => _equipo; set => _equipo = value; }
        public bool Capitan { get => _capitan; set => _capitan = value; }
    }
}