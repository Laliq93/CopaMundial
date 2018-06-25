using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Servicios.Traductores.Apuestas;
using CopaMundialAPI.Servicios.Traductores.Jugadores;
using CopaMundialAPI.Servicios.Traductores.Logros;
using CopaMundialAPI.Servicios.Traductores.Ciudades;

namespace CopaMundialAPI.Servicios.Traductores.Fabrica
{
    public class FabricaTraductor
    {
        public static TraductorApuestaCantidad CrearTraductorApuestaCantidad() 
        {
            return new TraductorApuestaCantidad();
        }

        public static TraductorApuestaJugador CrearTraductorApuestaJugador()
        {
            return new TraductorApuestaJugador();
        }

        public static TraductorApuestaVOF CrearTraductorApuestaVoF()
        {
            return new TraductorApuestaVOF();
        }

        public static TraductorApuestaEquipo CrearTraductorApuestaEquipo()
        {
            return new TraductorApuestaEquipo();
        }

        public static TraductorJugador CrearTraductorJugador()
        {
            return new TraductorJugador();
        }

        public static TraductorListarProximosPartidos CrearTraductorListarProximosPartidos()
        {
            return new TraductorListarProximosPartidos();
        }

        public static TraductorRecibirIdPartido CrearTraductorRecibirIdPartido()
        {
            return new TraductorRecibirIdPartido();
        }
        /// <summary>
        /// Metodo con el cual se instancia un objeto de tipo TraductorCiudad
        /// </summary>
        /// <returns></returns>
        public static TraductorCiudad CrearTraductorCiudad ( )
        {
            return new TraductorCiudad ( );
        }
		public static TraductorCiudad2 CrearTraductorCiudad2()
		{
			return new TraductorCiudad2();
		}

		public static TraductorCiudadNombre CrearTraductorCiudadNombre()
		{
			return new TraductorCiudadNombre();
		}

		public static TraductorCiudadID CrearTraductorCiudadID()
		{
			return new TraductorCiudadID();
		}
       
        public static TraductorMostrarLogrosPartido CrearTraductorMostrarLogrosPartidos()
        {
            return new TraductorMostrarLogrosPartido();
        }
    }
}