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
        /// Devuelve instancia de DAOUsuario
        /// </summary>
        /// <returns>DAOUsuario</returns>
        public static DAOUsuario CrearDAOUsuario()
        {
            return new DAOUsuario();
        }

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
        public static DAOApuestaCantidad CrearDAOApuestaCantidad()
        {
            return new DAOApuestaCantidad();
        }

        /// <summary>
        /// Devuelve una nueva instancia de DAOJugador
        /// </summary>
        /// <returns>DAOJugador</returns>
        public static DAOJugador CrearDAOJugador()
        {
            return new DAOJugador();
        }

        /// <summary>
        /// Devuelve una nueva instancia de DAOApuesta
        /// </summary>
        /// <returns>DAOApuesta</returns>
        public static DAOApuesta CrearDAOApuesta()
        {
            return new DAOApuesta();
        }

        /// <summary>
        /// Devuelve una nueva instancia de DAOApuestaEquipo
        /// </summary>
        /// <returns>DAOApuestaCantidad</returns>
        public static DAOApuestaEquipo CrearDAOApuestaEquipo()
        {
            return new DAOApuestaEquipo();
        }

        /// Devuelve una nueva instancia de DAOLogroCantidad
        /// </summary>
        /// <returns></returns>
        public static DAOLogroCantidad CrearDAOLogroCantidad()
        {
            return new DAOLogroCantidad();

        }

        /// <summary>
        /// Devuelve una nueva instancia de DAOLogroJugador
        /// </summary>
        /// <returns></returns>
        public static DAOLogroJugador CrearDAOLogroJugador()
        {
            return new DAOLogroJugador();
        }

        /// <summary>
        /// Devuelve una nueva instancia de DAOLogroEquipo
        /// </summary>
        /// <returns></returns>
        public static DAOLogroEquipo CrearDAOLogroEquipo()
        {
            return new DAOLogroEquipo();
        }


        /// <summary>
        /// Devuelve una nueva instancia de DAOLogroVF
        /// </summary>
        /// <returns></returns>
        public static DAOLogroVF CrearDAOLogroVF()
        {
            return new DAOLogroVF();
        }


        /// <summary>
        /// Devuelve una nueva instancia de DAOLogroPartido
        /// </summary>
        /// <returns></returns>
        public static DAOLogroPartido CrearDAOLogroPartido()
        {
            return new DAOLogroPartido();
        }
    }
}