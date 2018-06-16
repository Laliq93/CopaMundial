using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Fuente_de_Datos.DAO;

namespace CopaMundialAPI.Fuente_de_Datos.Fabrica
{

    /// <summary>
    /// Fabrica que instancia los DAO
    /// </summary>
    public static class FabricaDAO
    {
        /// <summary>
        /// Devuelve instancia de DAOCiudad
        /// </summary>
        /// <returns>DAOCiudad</returns>
        public static DAOCiudad CrearDAOCiudad ( )
        {
            return new DAOCiudad ( );
        }

        /// <summary>
        /// Devuelve una nueva instancia de DAOApuesta
        /// </summary>
        /// <returns>DAOApuesta</returns>
        public static DAOApuesta CrearDAOApuesta()
        {
            return new DAOApuesta();
        }
    }
}