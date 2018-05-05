using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.Usuario
{
    public class Usuario
    {
        private int _id;
        private string _nombre;
        private string _apellido;
        private DateTime _fechaNacimiento;
        private string _correo;
        private char _genero;
        private string _fotoPath;
        private string _nombreUsuario;
        private string _password;
        private string _token;
        private bool _administrador;

        public Usuario(int id, string nombre, string apellido, DateTime fechaNacimiento, string correo, char genero, string fotoPath, string nombreUsuario, string password, bool administrador)
        {
            _id = id;
            _nombre = nombre;
            _apellido = apellido;
            _fechaNacimiento = fechaNacimiento;
            _correo = correo;
            _genero = genero;
            _fotoPath = fotoPath;
            _nombreUsuario = nombreUsuario;
            _password = password;
            _administrador = administrador;
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
        
        public string apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        public DateTime fechaNacimiento
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }

        public string correo
        {
            get { return _correo; }
            set { _correo = value; }
        }

        public char genero
        {
            get { return _genero; }
            set { _genero = value; }
        }

        public string fotoPath
        {
            get { return _fotoPath; }
            set { _fotoPath = value; }
        }

        public string nombreUsuario
        {
            get { return _nombreUsuario; }
        }

        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string token
        {
            get { return _token; }
            set { _token = value; }
        }

        public bool administrador
        {
            get { return _administrador; }
            set { _administrador = value; }
        }
    }
}