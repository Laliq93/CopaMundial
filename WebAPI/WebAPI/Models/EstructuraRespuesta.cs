using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class EstructuraRespuesta
    {
        private int _codigo;
        private Object _mensaje;
        private string _error;

        public EstructuraRespuesta()
        {

        }

        public string error
        {
            get { return _error; }
            set { _error = value; }
        }


        public Object mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }


        public int codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

    }
}