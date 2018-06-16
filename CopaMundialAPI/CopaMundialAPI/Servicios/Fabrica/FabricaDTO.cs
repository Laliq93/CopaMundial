using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Servicios.DTO.Apuestas;

namespace CopaMundialAPI.Servicios.Fabrica
{
    public class FabricaDTO
    {
        public static DTOApuesta CrearDtoApuesta()
        {
            return new DTOApuesta();
        }

        public static DTO.Apuestas.DTOListarLogros CrearDtoListarLogros()
        {
            return new DTO.Apuestas.DTOListarLogros();
        }

        public static DTOApuestasUsuario CrearDtoApuestasUsuario()
        {
            return new DTOApuestasUsuario();
        }
    }
}