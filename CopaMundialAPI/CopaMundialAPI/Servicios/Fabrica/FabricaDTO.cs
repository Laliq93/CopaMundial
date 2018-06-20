using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Servicios.DTO.Apuestas;

namespace CopaMundialAPI.Servicios.Fabrica
{
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
    }
}