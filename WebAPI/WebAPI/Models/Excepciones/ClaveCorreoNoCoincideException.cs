using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.Excepciones
{
    public class ClaveCorreoNoCoincideException : Exception
    {
        private readonly string _mensaje = "El correo de usuario y su clave no coinciden.";
        private readonly int _codigoError = 20005;
        private string _correo;
        private string _password;
        private DateTime _errorDate;


        public ClaveCorreoNoCoincideException(string correo, string password)
        {
            _correo = correo;
            _password = password;
            _errorDate = DateTime.Now;
        }


        public string Correo
        {
            get { return _correo; }
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