using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Servicios.DTO.Apuestas;
using CopaMundialAPI.Servicios.DTO.Ciudades;
using CopaMundialAPI.Servicios.DTO.Jugadores;


using CopaMundialAPI.Servicios.DTO.Partidos;

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
        public static DTOCiudad CrearDTOCiudad (string nombre, int habitantes, string descripcion, string nombreIngles, string descripcionIngles)
        {
            return new DTOCiudad (nombre,habitantes,descripcion,nombreIngles,descripcionIngles);
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

        public static DTOListarProximosPartidos CrearDTOListarProximosPartidos()
        {
            return new DTOListarProximosPartidos();
        }

        public static DTOJugador CrearDTOJugador()
        {
            return new DTOJugador();
        }
    }
}