using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Servicios.DTO.Jugadores;
using CopaMundialAPI.Servicios.Fabrica;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Comun.Excepciones;

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



            return dto;
        }

        public override Entidad CrearEntidad(DTOJugador dto)
        {

            try
            {
                Jugador jugador = FabricaEntidades.CrearJugador();

                jugador.Nombre = dto.Nombre;
                jugador.Apellido = dto.Apellido;
                jugador.FechaNacimiento = dto.FechaNacimiento;
                jugador.LugarNacimiento = dto.LugarNacimiento;
                jugador.Peso = dto.Peso;
                jugador.Altura = dto.Altura;
                jugador.Posicion = dto.Posicion;
                jugador.Numero = dto.Numero;
                jugador.Equipo.Pais = dto.Equipo;

                return jugador;
            }
            catch (NullReferenceException exc)
            {
                throw new ObjetoNullException(exc, "Error al recibir la información de la apuesta");
            }            
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