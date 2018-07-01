using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Servicios.DTO.Usuario
{
    public class DTOUsuarioConfiguracion
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
        private bool _activo; //para conocer el usuario activo

        public int Id { get => _id; set => _id = value; }
        public string NombreUsuario { get => _nombreUsuario; set => _nombreUsuario = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public string FechaNacimiento { get => _fechaNacimiento; set => _fechaNacimiento = value; }
        public string Correo { get => _correo; set => _correo = value; }
        public bool Activo { get => _activo; set => _activo = value; }
    }
}