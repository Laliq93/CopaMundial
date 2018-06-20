using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Entidades.Fabrica
{
    /// <summary>
    /// Fabrica que instancia todas las entidades
    /// </summary>
    public static class FabricaEntidades
    {
        /// <summary>
        /// Metodo que realiza una instancia de tipo Ciudad
        /// </summary>
        /// <param name="nombre">Nombre de la ciudad a crear</param>
        /// <param name="habitantes">Cantidad de habitantes</param>
        /// <param name="descripcion">Descripcion de la ciudad</param>
        /// <returns></returns>
        public static Ciudad CrearCiudad ( string nombre, int habitantes , string descripcion )
        {
            return new Ciudad (nombre,habitantes,descripcion);
        }

        public static ApuestaCantidad CrearApuestaCantidad()
        {
            return new ApuestaCantidad();
        }

        public static ApuestaJugador CrearApuestaJugador()
        {
            return new ApuestaJugador();
        }

        public static ApuestaVoF CrearApuestaVoF()
        {
            return new ApuestaVoF();
        }

        public static Jugador CrearJugador()
        {
            return new Jugador();
        }
    }
}