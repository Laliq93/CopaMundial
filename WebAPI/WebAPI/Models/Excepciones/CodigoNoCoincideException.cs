using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.Excepciones
{
    public class CodigoNoCoincideException : Exception
    {
        private readonly string _mensaje = "El código ingresado no coincide.";
        private readonly int _codigoError = 20008;
        private int _usuarioId;
        private string _token;
        private DateTime _fechaError;


        public CodigoNoCoincideException(string token)
        {
            _token = token;
            _fechaError = DateTime.Now;
        }

        public string Token
        {
            get { return _token; }
        }

        public DateTime FechaError
        {
            get { return _fechaError; }
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