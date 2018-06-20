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
        /// Devuelve una nueva instancia de DAOApuestaVoF
        /// </summary>
        /// <returns>DAOApuestaVoF</returns>
        public static DAOApuestaVoF CrearDAOApuestaVoF()
        {
            return new DAOApuestaVoF();
        }

        /// <summary>
        /// Devuelve una nueva instancia de DAOApuestaJugador
        /// </summary>
        /// <returns>DAOApuestaJugador</returns>
        public static DAOApuestaJugador CrearDAOApuestaJugador()
        {
            return new DAOApuestaJugador();
        }

        /// <summary>
        /// Devuelve una nueva instancia de DAOApuestaCantidad
        /// </summary>
        /// <returns>DAOApuestaCantidad</returns>
        public static DAOApuestaCantidad DAOApuestaCantidad()
        {
            return new DAOApuestaCantidad();
        }

    }
}