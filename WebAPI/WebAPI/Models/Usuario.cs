using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    /// <summary>
    /// Clase que contiene los datos del usuario
    /// </summary>
    public class Usuario
    {
        private int _id; //identificador unico del usuario
        private string _nombreUsuario; //nombre de usuario para iniciar sesion
        private string _nombre; //nombre del usuario
        private string _apellido; //apellido del usuario
        private string _fechaNacimiento; //fecha de nacimiento del usuario
        private string _correo; //correo del usuario
        private char _genero; //genero del usuario 
        private string _password; //contrasena del usuario
        private string _fotoPath; //
        private bool _esAdmin;
        private bool _activo;
        private string _token;


        public Usuario(string nombreUsuario, string nombre, string apellido, string fechaNacimiento, string correo, char genero,
            bool esAdmin, string clave)
        {
            _nombreUsuario = nombreUsuario;
            _nombre = nombre;
            _apellido = apellido;
            _fechaNacimiento = fechaNacimiento;
            _correo = correo;
            _genero = genero;
            _esAdmin = esAdmin;
            _password = clave;
        }

        public Usuario(int id, string nombreUsuario, string nombre, string apellido, string fechaNacimiento,
            string correo, char genero, string password, string fotoPath, bool esAdmin, bool activo, string token)
        {
            _id = id;
            _nombreUsuario = nombreUsuario;
            _nombre = nombre;
            _apellido = apellido;
            _fechaNacimiento = fechaNacimiento;
            _correo = correo;
            _genero = genero;
            _password = password;
            _fotoPath = fotoPath;
            _esAdmin = esAdmin;
            _activo = activo;
            _token = token;
        }

        public Usuario(int id, string nombreUsuario, string nombre, string apellido, string fechaNacimiento, string correo)
        {
            _id = id;
            _nombreUsuario = nombreUsuario;
            _nombre = nombre;
            _apellido = apellido;
            _fechaNacimiento = fechaNacimiento;
            _correo = correo;
        }

        public Usuario(int id, string nombre, string apellido, string fechaNacimiento, char genero, string fotoPath)
        {
            _id = id;
            _nombre = nombre;
            _apellido = apellido;
            _fechaNacimiento = fechaNacimiento;
            _genero = genero;
            _fotoPath = fotoPath;
        }

        /// <summary>
        /// Getters y Setters del atributo id
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// Getters y Setters del atributo nombreUsuario
        /// </summary>
        public string NombreUsuario
        {
            get { return _nombreUsuario; }
            set { _nombreUsuario = value; }
        }

        /// <summary>
        /// Getters y Setters del atributo nombre
        /// </summary>
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        /// <summary>
        /// Getters y Setters del atributo apellido
        /// </summary>
        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        /// <summary>
        /// Getters y Setters del atributo fechaNacimiento
        /// </summary>
        public string FechaNacimiento
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }

        /// <summary>
        /// Getters y Setters del atributo Correo
        /// </summary>
        public string Correo
        {
            get { return _correo; }
            set { _correo = value; }
        }

        /// <summary>
        /// Getters y Setters del atributo genero
        /// </summary>
        public char Genero
        {
            get { return _genero; }
            set { _genero = value; }
        }

        /// <summary>
        /// Getters y Setters del atributo password
        /// </summary>
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        /// <summary>
        /// Getters y Setters del atributo fotopath
        /// </summary>
        public string FotoPath
        {
            get { return _fotoPath; }
            set { _fotoPath = value; }
        }

        /// <summary>
        /// Getters y Setters del atributo esAdmin
        /// </summary>
        public bool EsAdmin
        {
            get { return _esAdmin; }
            set { _esAdmin = value; }
        }

        /// <summary>
        /// Getters y Setters del atributo Token
        /// </summary>
        public bool Activo
        {
            get { return _activo; }
            set { _activo = value; }
        }
    }
}