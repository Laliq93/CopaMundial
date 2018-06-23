using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Logica_de_Negocio.Comando;
using CopaMundialAPI.Logica_de_Negocio.Comando.Ciudades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Logica_de_Negocio.Fabrica
{
    public static class FabricaComando
    {
        public static ComandoAgregarCiudad CrearComandoAgregarCiudad ( Ciudad ciudad )
        {
            return new ComandoAgregarCiudad ( ciudad );
        }

		public static ComandoObtenerCiudad CrearComandoObtenerCiudad (int id)
		{
			return new ComandoObtenerCiudad(id);
		}

        public static ComandoAgregarApuestaVOF CrearComandoAgregarApuestaVoF(ApuestaVoF apuesta)
        {
            return new ComandoAgregarApuestaVOF(apuesta);
        }

        public static ComandoAgregarJugador CrearComandoAgregarJugador(Jugador jugador)
        {
            return new ComandoAgregarJugador(jugador);
        }

        public static ComandoModificarJugador CrearComandoModificarJugador(Jugador jugador)
        {
            return new ComandoModificarJugador(jugador);
        }

        public static ComandoActivarJugador CrearComandoActivarJugador(Jugador jugador)
        {
            return new ComandoActivarJugador(jugador);
        }

        public static ComandoDesactivarJugador CrearComandoDesactivarJugador(Jugador jugador)
        {
            return new ComandoDesactivarJugador(jugador);
        }

        public static ComandoObtenerJugadores CrearComandoObtenerJugadores(Jugador jugador)
        {
            return new ComandoObtenerJugadores(jugador);
        }

    }
}