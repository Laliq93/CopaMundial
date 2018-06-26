using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Servicios.DTO.Jugadores;
using CopaMundialAPI.Servicios.Fabrica;

namespace CopaMundialAPI.Servicios.Traductores.Jugadores
{
    public class TraductorObtenerJugadores : TraductorGenerico<DTOObtenerJugadores>
    {
        public override DTOObtenerJugadores CrearDto(Entidad entidad)
        {
            Jugador jugador = entidad as Jugador;

            DTOObtenerJugadores dto = FabricaDTO.CrearDTOObtenerJugadores();

            dto.Id = jugador.Id;
            dto.Nombre = jugador.Nombre;
            dto.Apellido = jugador.Apellido;
            dto.FechaNacimiento = jugador.FechaNacimiento;
            dto.LugarNacimiento = jugador.LugarNacimiento;
            dto.Peso = jugador.Peso;
            dto.Altura = jugador.Altura;
            dto.Posicion = jugador.Posicion;
            dto.Numero = jugador.Numero;
            dto.Equipo = jugador.Equipo.Pais;
            dto.Capitan = jugador.Capitan;

            return dto;
        }

        public override Entidad CrearEntidad(DTOObtenerJugadores dto)
        {
            throw new NotImplementedException();
        }

        public override List<DTOObtenerJugadores> CrearListaDto(List<Entidad> entidades)
        {
            List<DTOObtenerJugadores> dtos = new List<DTOObtenerJugadores>();

            foreach (Entidad jugador in entidades)
            {
                dtos.Add(CrearDto(jugador));
            }

            return dtos;
        }

        public override List<Entidad> CrearListaEntidades(List<DTOObtenerJugadores> dtos)
        {
            throw new NotImplementedException();
        }
    }
}