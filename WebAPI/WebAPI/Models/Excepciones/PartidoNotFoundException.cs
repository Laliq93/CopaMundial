using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WebAPI.Models.Excepciones
{   

    /// <summary>
    /// Clase excepcion cuando no se encuentra un partido
    /// consultado en la base de datos
    /// </summary>
    [Serializable()]
    public class PartidoNotFoundException: Exception
    {

       
            public readonly int ERROR_CODE = 600;
            public readonly String ERROR_MSG = "Ha ocurrido un error, el partido no existe ";
            private String _clase;  //indica la clase c# en la que se produjo la excepcion
            private String _metodo; //indica el metodo que produjo la excepcion
            private int _idPartido; //indica el id del partido que fue consultado

            /// <summary>
            /// Constructor de la excepcion PartidoNotFoundException
            /// </summary>
            /// <param name="error"></param>
            /// <param name="clase"></param>
            /// <param name="metodo"></param>
            /// <param name="idPartido"></param>
            public PartidoNotFoundException(Exception error, String clase, String metodo, int idPartido)
            {
                base.Equals(error);
                _clase = clase;
                _metodo = metodo;
                _idPartido = idPartido;
            }



            public virtual String toString()
            {
                StringBuilder str = null;


                str = new StringBuilder(ERROR_CODE + "\n");
                str.Append(ERROR_MSG + "\n");
                str.Append(base.ToString());

                return str.ToString();
            }
        
    }
}