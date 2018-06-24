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
		/// <param name="nombreIngles">Descripcion de la ciudad</param>
		/// <param name="descripcionIngles">Descripcion de la ciudad</param>
		/// <returns></returns>

		public static Ciudad CrearCiudad(string nombre, int habitantes, string descripcion, string nombreIngles, string descripcionIngles, byte[] imagen)
		{
			return new Ciudad(nombre, habitantes, descripcion, nombreIngles, descripcionIngles, imagen);

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

        public static LogroCantidad CrearLogroCantidad()
        {
            return new LogroCantidad();
        }

        public static LogroEquipo CrearLogroEquipo()
        {
            return new LogroEquipo();
        }

        public static LogroJugador CrearLogroJugador()
        {
            return new LogroJugador();
        }

        public static LogroVoF CrearLogroVoF()
        {
            return new LogroVoF();
        }

        public static ApuestaEquipo CrearApuestaEquipo()
        {
            return new ApuestaEquipo();
        }
    }

}