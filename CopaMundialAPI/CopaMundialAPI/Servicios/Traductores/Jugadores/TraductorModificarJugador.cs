using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Servicios.DTO.Jugadores;
using CopaMundialAPI.Servicios.Fabrica;

namespace CopaMundialAPI.Servicios.Traductores.Jugadores
{
    public class TraductorModificarJugador : TraductorGenerico<DTOModificarJugador>
    {
        public override DTOModificarJugador CrearDto(Entidad entidad)
        {
            Jugador jugador = entidad as Jugador;

            DTOModificarJugador dto = FabricaDTO.CrearDTOModificarJugador();

            dto.Id = jugador.Id;
            dto.Nombre = jugador.Nombre;
            dto.Apellido = jugador.Apellido;
            dto.FechaNacimiento = jugador.FechaNacimiento;
            dto.LugarNacimiento = jugador.LugarNacimiento;
            dto.Peso = jugador.Peso;
            dto.Altura = jugador.Altura;
            dto.Posicion = jugador.Posicion;
            dto.Numero = jugador.Numero;
            dto.Capitan = jugador.Capitan;

            return dto;
        }

        public override Entidad CrearEntidad(DTOModificarJugador dto)
        {
            throw new NotImplementedException();
        }

        public override List<DTOModificarJugador> CrearListaDto(List<Entidad> entidades)
        {
            throw new NotImplementedException();
        }

        public override List<Entidad> CrearListaEntidades(List<DTOModificarJugador> dtos)
        {
            throw new NotImplementedException();
        }
    }
}