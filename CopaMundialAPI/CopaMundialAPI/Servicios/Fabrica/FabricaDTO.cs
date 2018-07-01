using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Servicios.DTO.Apuestas;
using CopaMundialAPI.Servicios.DTO.Ciudades;
using CopaMundialAPI.Servicios.DTO.Jugadores;
using CopaMundialAPI.Servicios.DTO.Logros;
using CopaMundialAPI.Servicios.DTO.Usuario;

namespace CopaMundialAPI.Servicios.Fabrica
{
    /// <summary>
    /// Fabrica que instancia todos los DTO
    /// </summary>
    public class FabricaDTO
    {
        public static DTOApuestaVOF CrearDtoApuestaVOF()
        {
            return new DTOApuestaVOF();
        }

        public static DTOApuestaCantidad CrearDtoApuestaCantidad()
        {
            return new DTOApuestaCantidad();
        }

        public static DTOApuestaJugador CrearDtoApuestaJugador()
        {
            return new DTOApuestaJugador();
        }

        /// <summary>
        /// Metodo que instancia un objeto de tipo DTOCiudad
        /// </summary>
        /// <param name="nombre">Nombre de la ciudad</param>
        /// <param name="habitantes">Numero de habitantes de la ciudad</param>
        /// <param name="descripcion">Descripcion de la ciudad</param>
        /// <param name="nombreIngles">Nombre de la ciudad en ingles</param>
        /// <param name="descripcionIngles">Descripcion de la ciudad en ingles</param>
        /// <returns></returns>
        public static DTOCiudad2 CrearDTOCiudad (string nombre, int habitantes, string descripcion, string nombreIngles, string descripcionIngles)
        {
            return new DTOCiudad2 (nombre,habitantes,descripcion,nombreIngles,descripcionIngles);
        }


		public static DTOCiudad CrearDTOCiudad(int id,string nombre, int habitantes, string descripcion, string nombreIngles, string descripcionIngles)
		{
			return new DTOCiudad(id,nombre, habitantes, descripcion, nombreIngles, descripcionIngles);
		}
		/// <summary>
		/// Metodo que instancia un objeto de tipo DTOCiudadNombre
		/// </summary>
		/// <param name="nombre">Nombre de la ciudad</param>
		/// <returns></returns>
		public static DTOCiudadNombre CrearDTOCiudadNombre (string nombre)
        {
            return new DTOCiudadNombre ( nombre );
        }

		public static DTOCiudadID CrearDTOCiudadId (int id)
		{
			return new DTOCiudadID(id);
		}

        public static DTOListarProximosPartidos CrearDTOListarProximosPartidos()
        {
            return new DTOListarProximosPartidos();
        }

        public static DTOJugador CrearDTOJugador()
        {
            return new DTOJugador();
        }

        public static DTOMostrarLogrosPartido CrearDTOMostrarLogrosPartido()
        {
            return new DTOMostrarLogrosPartido();
        }

        public static DTOJugadorId CrearDTOJugadorId()
        {
            return new DTOJugadorId();
        }

        public static DTOObtenerJugadores CrearDTOObtenerJugadores()
        {
            return new DTOObtenerJugadores();
        }

        public static DTOLogroCantidad CrearDTOLogroCantidad()
        {
            return new DTOLogroCantidad();
        }

        public static DTOModificarJugador CrearDTOModificarJugador()
        {
            return new DTOModificarJugador();
        } 

        public static DTOApuestaEquipo CrearDTOApuestaEquipo()
        {
            return new DTOApuestaEquipo();
        }

        public static DTOLogroCantidadResultado CrearDTOLogroCantidadResultado()
        {
            return new DTOLogroCantidadResultado();
        }

        public static DTOLogroJugador CrearDTOLogroJugador()
        {
            return new DTOLogroJugador();
        }

        public static DTOLogroJugadorResultado CrearDTOLogroJugadorResultado()
        {
            return new DTOLogroJugadorResultado();
        }

        public static DTOLogroEquipo CrearDTOLogroEquipo()
        {
            return new DTOLogroEquipo();
        }

        public static DTOLogroEquipoResultado CrearDTOLogroEquipoResultado()
        {
            return new DTOLogroEquipoResultado();
        }

        public static DTOLogroVF CrearDTOLogroVF()
        {
            return new DTOLogroVF();
        }

        public static DTOLogroVFResultado CrearDTOLogroVFResultado()
        {
            return new DTOLogroVFResultado();
        }

        public static DTOLogroPartidoId CrearDTOLogroPartidoId()
        {
            return new DTOLogroPartidoId();
        }

        public static DTOListaPartidosLogros CrearDTOListaPartidosLogros()
        {
            return new DTOListaPartidosLogros();
        }

        public static DTOUsuarioRegistrar CrearDTOUsuarioRegistrar()
        {
            return new DTOUsuarioRegistrar();
        }
    }
}