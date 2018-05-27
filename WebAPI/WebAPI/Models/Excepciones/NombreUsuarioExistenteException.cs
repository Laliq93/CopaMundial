using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.Excepciones
{
    public class NombreUsuarioExistenteException : Exception
    {
        private readonly string _mensaje = "Nombre de usuario existente.";
        private readonly int _codigoError = 20002;
        private string _nombreUsuario;
        private DateTime _errorDate;


        public NombreUsuarioExistenteException(string nombreUsuario)
        {
            _nombreUsuario = nombreUsuario;
            _errorDate = DateTime.Now;
        }


        public string NombreUsuario
        {
            get { return _nombreUsuario; }
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