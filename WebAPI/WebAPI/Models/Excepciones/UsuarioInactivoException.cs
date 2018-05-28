using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.Excepciones
{
    public class UsuarioInactivoException : Exception
    {

        private readonly string _mensaje = "El usuario ingresado esta inactivo.";
        private readonly int _codigoError = 20007;
        private string _usuario;
        private DateTime _errorDate;


        public UsuarioInactivoException(string usuario)
        {
            _usuario = usuario;
            _errorDate = DateTime.Now;
        }


        public string Usuario
        {
            get { return _usuario; }
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