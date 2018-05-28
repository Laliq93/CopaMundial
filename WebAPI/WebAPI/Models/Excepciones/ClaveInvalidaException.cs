using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.Excepciones
{
    public class ClaveInvalidaException : Exception
    {
        private readonly string _mensaje = "La clave ingresada no coincide con la clave del usuario.";
        private readonly int _codigoError = 10002;
        private int _usuarioId;
        private string _claveUsuario;
        private DateTime _fechaError;


        public ClaveInvalidaException(int usuarioId, string claveUsuario)
        {
            _usuarioId = usuarioId;
            _claveUsuario = claveUsuario;
            _fechaError = DateTime.Now;
        }

        public int usuarioId
        {
            get { return _usuarioId; }
        }

        public string claveUsuario
        {
            get { return _claveUsuario; }
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

    }
}