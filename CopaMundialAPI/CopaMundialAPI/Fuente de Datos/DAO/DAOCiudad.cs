using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces;

namespace CopaMundialAPI.Fuente_de_Datos.DAO
{
    /// <summary>
    /// DAO de la entidad Ciudad. En esta clase se encapsula el acceso a la fuente de datos.
    /// </summary>
    public class DAOCiudad : DAO,IDAOCiudad
    {
        public Ciudad ConsultarCiudadPorId ( Ciudad ciudad )
        {
            throw new NotImplementedException ( );
        }

        public List<Ciudad> ConsultarListaCiudades ( Ciudad ciudad )
        {
            throw new NotImplementedException ( );
        }

        public void EliminarCiudad ( Ciudad ciudad )
        {
            throw new NotImplementedException ( );
        }

        /// <summary>
        /// Metodo InsertarCiudad , inserta objeto de tipo Ciudad en la base de datos
        /// </summary>
        /// <param name="objeto">Ciudad que se desea insertar</param>
        public void InsertarCiudad ( Ciudad ciudad )
        {
            StoredProcedure ( "insertarciudad" );
            Command.Parameters.AddWithValue ( "_nombre", ciudad.Nombre );
            Command.Parameters.AddWithValue ( "_capacidad", ciudad.Habitantes );
            Command.Parameters.AddWithValue ( "_descripcion", ciudad.Descripcion );
            Command.ExecuteNonQuery ( );
            Desconectar ( );
        }

        public void ModificarCiudad ( Ciudad ciudad )
        {
            throw new NotImplementedException ( );
        }
    }
}