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
    public class DAOCiudad : DAO, IDAOCiudad
    {
        public void Actualizar ( Entidad entidad )
        {
            throw new NotImplementedException ( );
        }

        public void Agregar ( Entidad entidad )
        {

            Ciudad ciudad = entidad as Ciudad;

            Conectar ( );

            StoredProcedure ( "insertarciudad(@_nombre,@_capacidad,@_descripcion)" );

            AgregarParametro ( "_nombre", ciudad.Nombre );
            AgregarParametro ( "_capacidad", ciudad.Habitantes );
            AgregarParametro ( "_descripcion", ciudad.Descripcion );

            EjecutarQuery ( );
        }

        public Ciudad ConsultarCiudadPorId ( Ciudad ciudad )
        {
            throw new NotImplementedException ( );
        }

        public void Eliminar ( Entidad entidad )
        {
            throw new NotImplementedException ( );
        }

        public List<Entidad> ObtenerTodos ( )
        {
            throw new NotImplementedException ( );
        }

    }
}