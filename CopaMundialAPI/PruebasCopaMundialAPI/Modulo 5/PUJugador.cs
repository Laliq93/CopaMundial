using CopaMundialAPI.Presentacion.Controllers;
using CopaMundialAPI.Servicios.DTO.Jugadores;
using CopaMundialAPI.Servicios.Fabrica;
using NUnit.Framework;
using System;

namespace PruebasCopaMundialAPI.Modulo_5
{
    [TestFixture]
    public class PUJugador
    {
        private JugadorController controlador;

        private DTOJugador jugador;

       // private DTOModificarJugador modificar;

        [SetUp]
        public void SetUp ()
        {
            controlador = new JugadorController();

            jugador = FabricaDTO.CrearDTOJugador();
            jugador.Nombre = "Cristiado";
            jugador.Apellido = "Ronaldo";
            jugador.FechaNacimiento = "02-01-96";
            jugador.LugarNacimiento = "Lisboa";
            jugador.Peso = 90;
            jugador.Altura = 1.85M;
            jugador.Posicion = "DELANTERO";
            jugador.Numero = 7;
            jugador.Equipo = "Portugal";

           /* modificar = FabricaDTO.CrearDTOModificarJugador();
            modificar.Id = 1;
            modificar.Nombre = "modificar";
            modificar.Apellido = "modificar";
            modificar.FechaNacimiento = "02-01-96";
            modificar.LugarNacimiento = "Lisboa";
            modificar.Peso = 90;
            modificar.Altura = 1.85M;
            modificar.Posicion = "DELANTERO";
            modificar.Numero = 7;
            modificar.Capitan = true;*/
        }

        [Test]
        public void TestAgregarJugador ()
        {
            Assert.DoesNotThrow( AgregarJugador );
        }

        public void AgregarJugador ()
        {
            controlador.AgregarJugador(jugador);
        }

        /*[Test]
        public void TestModificarJugador()
        {
            Assert.DoesNotThrow(ModificarJugador);
        }

        public void ModificarJugador()
        {
            controlador.ModificarJugador(modificar);
        }*/

        [TearDown]
        public void TearDown ()
        {
            controlador = null;
            jugador = null;
            //modificar = null;
        }
    }
}
