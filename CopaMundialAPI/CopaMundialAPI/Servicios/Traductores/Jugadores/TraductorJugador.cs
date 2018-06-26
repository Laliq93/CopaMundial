using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Servicios.DTO.Jugadores;
using CopaMundialAPI.Servicios.Fabrica;

namespace CopaMundialAPI.Servicios.Traductores.Jugadores
{
    public class TraductorJugador : TraductorGenerico<DTOJugador>
    {
        public override DTOJugador CrearDto(Entidad entidad)
        {
            DTOJugador dto = FabricaDTO.CrearDTOJugador();

            Jugador jugador = entidad as Jugador;

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
            dto.Activo = jugador.Activo;



            return dto;
        }

        public override Entidad CrearEntidad(DTOJugador dto)
        {
            throw new NotImplementedException();
        }

        public override List<DTOJugador> CrearListaDto(List<Entidad> entidades)
        {
            throw new NotImplementedException();
        }

        public override List<Entidad> CrearListaEntidades(List<DTOJugador> dtos)
        {
            throw new NotImplementedException();
        }
    }
}