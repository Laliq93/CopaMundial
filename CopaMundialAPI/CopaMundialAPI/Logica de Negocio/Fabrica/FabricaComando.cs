using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Logica_de_Negocio.Comando.Apuestas;
using CopaMundialAPI.Logica_de_Negocio.Comando.Ciudades;
using CopaMundialAPI.Logica_de_Negocio.Comando.Logros;
using CopaMundialAPI.Logica_de_Negocio.Comando;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Logica_de_Negocio.Fabrica
{
    public static class FabricaComando
    {
        public static ComandoAgregarCiudad CrearComandoAgregarCiudad ( Entidad ciudad )
        {
            return new ComandoAgregarCiudad ( ciudad );
        }

		public static ComandoObtenerCiudad CrearComandoObtenerCiudad (int id)
		{
			return new ComandoObtenerCiudad(id);
		}

		public static ComandoActualizarCiudad CrearComandoActualizarCiudad(Entidad ciudad)
		{
			return new ComandoActualizarCiudad(ciudad);
		}

		public static ComandoEliminarCiudad CrearComandoEliminarCiudad(Entidad ciudad)
		{
			return new ComandoEliminarCiudad(ciudad);
		}

		public static ComandoListarCiudades CrearComandoListarCiudades()
		{
			return new ComandoListarCiudades();
		}
		public static ComandoObtenerCiudadPorNombre CrearComandoObtenerCiudadPorNombre(Entidad ciudad)
		{
			return new ComandoObtenerCiudadPorNombre(ciudad);
		}

        public static ComandoAgregarApuestaVOF CrearComandoAgregarApuestaVoF(Entidad apuesta)
        {
            return new ComandoAgregarApuestaVOF(apuesta);
        }

        public static ComandoObtenerApuestasVoFEnCurso CrearComandoObtenerApuestasVoFEnCurso(Entidad usuario)
        {
            return new ComandoObtenerApuestasVoFEnCurso(usuario);
        }

        public static ComandoAgregarJugador CrearComandoAgregarJugador(Entidad jugador)
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

        public static ComandoObtenerJugadores CrearComandoObtenerJugadores()
        {
            return new ComandoObtenerJugadores();
        }

        public static ComandoObtenerProximosPartidos CrearComandoObtenerProximosPartidos()
        {
            return new ComandoObtenerProximosPartidos();
        }

        public static ComandoObtenerLogrosVofPartido CrearComandoObtenerLogrosVofPartido(Entidad partido)
        {
            return new ComandoObtenerLogrosVofPartido(partido);
        }

        public static ComandoObtenerLogrosCantidadPartido CrearComandoObtenerLogrosCantidadPartido(Entidad partido)
        {
            return new ComandoObtenerLogrosCantidadPartido(partido);
        }

        public static ComandoObtenerLogrosEquipoPartido CrearComandoObtenerLogrosEquipoPartido(Entidad partido)
        {
            return new ComandoObtenerLogrosEquipoPartido(partido);
        }

        public static ComandoObtenerLogrosJugadorPartido CrearComandoObtenerLogrosJugadorPartido(Entidad partido)
        {
            return new ComandoObtenerLogrosJugadorPartido(partido);
        }

        public static ComandoVerificarApuestaExiste CrearComandoVerificarApuestaExiste(Entidad apuesta)
        {
            return new ComandoVerificarApuestaExiste(apuesta);
        }

       public static ComandoAgregarLogroCantidad CrearComandoAgregarLogroCantidad(Entidad logroPartido)
        {
            return new ComandoAgregarLogroCantidad(logroPartido);
        }

        public static ComandoObtenerLogrosCantidadPendientes CrearComandoObtenerLogrosCantidadPendientes(Entidad partido)
        {
            return new ComandoObtenerLogrosCantidadPendientes(partido);
        }

    }
}