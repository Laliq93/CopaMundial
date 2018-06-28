using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Comun.Excepciones;
using CopaMundialAPI.Servicios.DTO.Apuestas;
using CopaMundialAPI.Servicios.Fabrica;

namespace CopaMundialAPI.Servicios.Traductores.Apuestas
{
    public class TraductorApuestaJugador : TraductorGenerico<DTOApuestaJugador>
    {
        public override DTOApuestaJugador CrearDto(Entidad entidad)
        {
            DTOApuestaJugador dto = FabricaDTO.CrearDtoApuestaJugador();

            ApuestaJugador apuesta = entidad as ApuestaJugador;

            dto.IdLogro = apuesta.Logro.Id;
            dto.IdUsuario = apuesta.Usuario.Id;
            dto.IdJugador = apuesta.Respuesta.Id;
            dto.NombreJugador = apuesta.Respuesta.Nombre;
            dto.ApellidoJugador = apuesta.Respuesta.Apellido;
            dto.Estado = apuesta.Estado;
            dto.Logro = apuesta.Logro.Logro;
            dto.Fecha = apuesta.Fecha.ToShortDateString();

            return dto;
        }

        public override Entidad CrearEntidad(DTOApuestaJugador dto)
        {
            try
            {
                ApuestaJugador apuesta = FabricaEntidades.CrearApuestaJugador();

                Jugador jugador = FabricaEntidades.CrearJugador();
                Usuario apostador = FabricaEntidades.CrearUsuarioVacio();
                LogroJugador logro = FabricaEntidades.CrearLogroJugador();

                apuesta.Usuario = apostador;
                apuesta.Logro = logro;
                apuesta.Respuesta = jugador;

                apuesta.Logro.Id = dto.IdLogro;
                apuesta.Usuario.Id = dto.IdUsuario;
                apuesta.Respuesta.Id = dto.IdJugador;

                return apuesta;
            }
            catch (NullReferenceException exc)
            {
                throw new ObjetoNullException(exc, "Error al recibir la información de la apuesta");
            }
        }

        public override List<DTOApuestaJugador> CrearListaDto(List<Entidad> entidades)
        {
            List<DTOApuestaJugador> dtos = new List<DTOApuestaJugador>();

            foreach (ApuestaJugador entidad in entidades)
            {
                dtos.Add(CrearDto(entidad));
            }

            return dtos;
        }

        public override List<Entidad> CrearListaEntidades(List<DTOApuestaJugador> dtos)
        {
            throw new NotImplementedException();
        }
    }
}