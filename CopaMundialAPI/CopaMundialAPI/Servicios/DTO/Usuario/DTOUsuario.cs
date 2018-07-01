using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Servicios.DTO.Usuario
{
    public class DTOUsuario
    {
        /// <summary>
        /// Clase de la entidad Usuario
        /// </summary>
        private int _id; //id del usuario
        private string _nombreUsuario; //nombre de Usuario para iniciar la sesion
        private string _nombre; //nombre del usuario
        private string _apellido; //apellido del usuario
        private string _fechaNacimiento; //fecha de nacimiento del usuario
        private string _correo; //correo del usuario
        private char _genero; //genero del usuario 
        private string _password; //contrasena del usuario
        private string _fotoPath; //foto del usuario
        private bool _esAdmin; //para el usuario administrador o no
        private bool _activo; //para conocer el usuario activo
        private string _token; //token para el usuario

        public int Id { get => _id; set => _id = value; }
        public string NombreUsuario { get => _nombreUsuario; set => _nombreUsuario = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public string FechaNacimiento { get => _fechaNacimiento; set => _fechaNacimiento = value; }
        public string Correo { get => _correo; set => _correo = value; }
        public char Genero { get => _genero; set => _genero = value;}
        public string Password { get => _password; set => _password = value; }
        public string FotoPath { get => _fotoPath; set => _fotoPath = value; }
        public bool EsAdmin { get => _esAdmin; set => _esAdmin = value; }
        public bool Activo { get => _activo; set => _activo = value; }
        public string Token { get => _token; set => _token = value; }
    }
}