using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Entidades.Fabrica
{
    /// <summary>
    /// Fabrica que instancia todas las Entidades
    /// </summary>
    public static class FabricaEntidades
    {
        /// <summary>
        /// Metodo que realiza una instancia de tipo Ciudad solo con su nombre
        /// </summary>
        /// <param name="nombre">Nombre de la ciudad</param>
        /// <returns></returns>
        public static Ciudad CrearCiudadNombre(string nombre )
        {
            return new Ciudad ( nombre );
        }

		/// <summary>
		/// Metodo que realiza una instancia de tipo Ciudad
		/// </summary>
		/// <param name="nombre">Nombre de la ciudad a crear</param>
		/// <param name="habitantes">Cantidad de habitantes</param>
		/// <param name="descripcion">Descripcion de la ciudad</param>
		/// <param name="nombreIngles">Nombre de la ciudad en ingles</param>
		/// <param name="descripcionIngles">Descripcion de la ciudad en ingles</param>
		/// <returns></returns>

		public static Ciudad CrearCiudad(string nombre, int habitantes, string descripcion, string nombreIngles, string descripcionIngles)
		{
			return new Ciudad(nombre, habitantes, descripcion, nombreIngles, descripcionIngles);

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
        public static Usuario CrearUsuarioVacio()
        {
            return new Usuario();
        }
        public static Usuario CrearUsuario(string nombreUsuario, string nombre, string apellido, string fechaNacimiento,
            string correo, char genero, string password, string fotoPath, bool esAdmin, bool activo, string token)
        {
            return new Usuario(nombreUsuario, nombre, apellido, fechaNacimiento, correo, genero, password, fotoPath, esAdmin, activo, token);
        }
        public static Usuario CrearConfigurarUsuario( string nombre, string apellido, string fechaNacimiento,
         char genero, string fotoPath)
        {
            return new Usuario(nombre, apellido, fechaNacimiento, genero, fotoPath);
        }

        public static Alineacion CrearAlineacion()
        {
            return new Alineacion();
        }

        public static Partido CrearPartido()
        {
            return new Partido();
        }
    }

}