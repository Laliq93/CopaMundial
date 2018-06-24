using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Entidades
{
    public class Usuario : Entidad
    {
        /// <summary>
        /// Clase de la entidad Usuario
        /// </summary>
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

            /// <summary>
            /// Getters y Setters del atributo _nombreUsuario
            /// </summary>
            public string NombreUsuario { get => _nombreUsuario; set => _nombreUsuario = value; }


            /// <summary>
            /// Getters y Setters del atributo _nombre
            /// </summary>
            public string Nombre { get => _nombre; set => _nombre = value; }

            /// <summary>
            /// Getters y Setters del atributo _apellido
            /// </summary>
            public string Apellido { get => _apellido; set => _apellido = value; }

            /// <summary>
            /// Getters y Setters del atributo _fechaNacimiento
            /// </summary>
            public string FechaNacimiento { get => _fechaNacimiento; set => _fechaNacimiento = value; }

            /// <summary>
            /// Getters y Setters del atributo _correo
            /// </summary>
            public string Correo { get => _correo; set => _correo = value; }

            /// <summary>
            /// Getters y Setters del atributo _genero
            /// </summary>
            public char Genero { get => _genero; set => _genero = value; }

            /// <summary>
            /// Getters y Setters del atributo _password
            /// </summary>
            public string Password { get => _password; set => _password = value; }

            /// <summary>
            /// Getters y Setters del atributo _fotoPath
            /// </summary>
            public string FotoPath { get => _fotoPath; set => _fotoPath = value; }

            /// <summary>
            /// Getters y Setters del atributo _esAdmin
            /// </summary>
            public bool EsAdmin { get => _esAdmin; set => _esAdmin = value; }

            /// <summary>
            /// Getters y Setters del atributo _activo
            /// </summary>
            public bool Activo { get => _activo; set => _activo = value; }

            /// <summary>
            /// Getters y Setters del atributo _token
            /// </summary>
            public string Token { get => _token; set => _token = value; }

    }

}