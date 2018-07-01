using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Servicios.DTO.Usuario
{
    public class DTOUsuarioRegistrar
    {
        private int _idUsuario;
        private string _NombreUsuario;
        private string _Nombre;
        private string _Apellido;
        private string _FechaNacimiento;
        private string _Correo;
        private char _Genero;
        private string _Password;

        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public string NombreUsuario { get => _NombreUsuario; set => _NombreUsuario = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellido { get => _Apellido; set => _Apellido = value; }
        public string FechaNacimiento { get => _FechaNacimiento; set => _FechaNacimiento = value; }
        public string Correo { get => _Correo; set => _Correo = value; }
        public char Genero { get => _Genero; set => _Genero = value; }
        public string Password { get => _Password; set => _Password = value; }
    }
}