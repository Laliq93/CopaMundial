using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.Excepciones
{
    public class ClaveUsuarioNoCoincideException : Exception
    {
        private readonly string _mensaje = "El nombre de usuario y su clave no coinciden.";
        private readonly int _codigoError = 20004;
        private string _nombreUsuario;
        private string _password;
        private DateTime _errorDate;


        public ClaveUsuarioNoCoincideException(string nombreUsuario, string password)
        {
            _nombreUsuario = nombreUsuario;
            _password = password;
            _errorDate = DateTime.Now;
        }


        public string NombreUsuario
        {
            get { return _nombreUsuario; }
        }

        public string Password
        {
            get { return _password; }
        }

        public DateTime ErrorDate
        {
            get { return _errorDate; }
        }

        public new string Message
        {
            get { return _mensaje; }
        }

        public int CodigoError
        {
            get { return _codigoError; }
        }
    }
}