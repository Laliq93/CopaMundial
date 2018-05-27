using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.Excepciones
{
    public class UsuarioNullException : Exception
    {
        private readonly string _mensaje = "Error al recibir la información del usuario.";
        private readonly int _codigoError = 10003;
        private DateTime _fechaError;
        private Exception _innerException;

        public UsuarioNullException(Exception inner)
        {
            _fechaError = DateTime.Now;
            _innerException = inner;
        }

        public DateTime fechaError
        {
            get { return _fechaError; }
        }

        public new string Message
        {
            get { return _mensaje; }
        }

        public int codigoError
        {
            get { return _codigoError; }
        }

        public new Exception InnerException
        {
            get { return _innerException; }
        }

    }
}