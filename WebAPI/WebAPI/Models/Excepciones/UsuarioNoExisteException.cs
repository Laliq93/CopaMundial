using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.Excepciones
{
    public class UsuarioNoExisteException : Exception
    {
        private readonly string _mensaje = "Error al encontrar el usuario en la base de datos";
        private readonly int _codigoError = 10004;
        private DateTime _fechaError;
        private Exception _innerException;
        private int _idUsuario;

        public UsuarioNoExisteException(Exception inner, int idUsuario)
        {
            _fechaError = DateTime.Now;
            _innerException = inner;
            _idUsuario = idUsuario;
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

        public int IdUsuario
        {
            get { return _idUsuario; }
        }

    }
}