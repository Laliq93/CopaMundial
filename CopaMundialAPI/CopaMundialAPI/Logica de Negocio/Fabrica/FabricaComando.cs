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

        public static ComandoModificarJugador CrearComandoModificarJugador(Entidad jugador)
        {
            return new ComandoModificarJugador(jugador);
        }

        public static ComandoActivarJugador CrearComandoActivarJugador(Entidad jugador)
        {
            return new ComandoActivarJugador(jugador);
        }

        public static ComandoDesactivarJugador CrearComandoDesactivarJugador(Entidad jugador)
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

        /// <exception cref="ApuestaRepetidaException"></exception>
        public static ComandoVerificarApuestaVoFExiste CrearComandoVerificarApuestaVoFExiste(Entidad apuesta)
        {
            return new ComandoVerificarApuestaVoFExiste(apuesta);
        }

        /// <exception cref="ApuestaRepetidaException"></exception>
        public static ComandoVerificarApuestaCantidadExiste CrearComandoVerificarApuestaCantidadExiste(Entidad apuesta)
        {
            return new ComandoVerificarApuestaCantidadExiste(apuesta);
        }

        public static ComandoAgregarApuestaCantidad CrearComandoAgregarApuestaCantidad(Entidad apuesta)
        {
            return new ComandoAgregarApuestaCantidad(apuesta);
        }

        /// <exception cref="ApuestaRepetidaException"></exception>
        public static ComandoVerificarApuestaJugadorExiste CrearComandoVerificaApuestaJugadorExiste(Entidad apuesta)
        {
            return new ComandoVerificarApuestaJugadorExiste(apuesta);
        }

        public static ComandoAgregarApuestaJugador CrearComandoAgregarApuestaJugador(Entidad apuesta)
        {
            return new ComandoAgregarApuestaJugador(apuesta);
        }

        public static ComandoAgregarApuestaEquipo CrearComandoAgregarApuestaEquipo(Entidad apuesta)
        {
            return new ComandoAgregarApuestaEquipo(apuesta);
        }

        /// <exception cref="ApuestaRepetidaException"></exception>
        public static ComandoVerificarApuestaEquipoExiste CrearComandoVerificaApuestaEquipoExiste(Entidad apuesta)
        {
            return new ComandoVerificarApuestaEquipoExiste(apuesta);
        }

       public static ComandoAgregarLogroCantidad CrearComandoAgregarLogroCantidad(Entidad logroPartido)
        {
            return new ComandoAgregarLogroCantidad(logroPartido);
        }

        public static ComandoObtenerLogrosCantidadPendientes CrearComandoObtenerLogrosCantidadPendientes(Entidad partido)
        {
            return new ComandoObtenerLogrosCantidadPendientes(partido);
        }

        public static ComandoAgregarLogroJugador CrearComandoAgregarLogroJugador(Entidad logroPartido)
        {
            return new ComandoAgregarLogroJugador(logroPartido);
        }

        public static ComandoObtenerLogrosJugadorPendientes CrearComandoObtenerLogrosJugadorPendientes(Entidad partido)
        {
            return new ComandoObtenerLogrosJugadorPendientes(partido);
        }

        public static ComandoAgregarLogroEquipo CrearComandoAgregarLogroEquipo(Entidad logroPartido)
        {
            return new ComandoAgregarLogroEquipo(logroPartido);
        }

        public static ComandoObtenerLogrosEquipoPendientes CrearComandoObtenerLogrosEquipoPendientes(Entidad partido)
        {
            return new ComandoObtenerLogrosEquipoPendientes(partido);
        }

        public static ComandoAgregarLogroVF CrearComandoAgregarLogroVF(Entidad partido)
        {
            return new ComandoAgregarLogroVF(partido);
        }

        public static ComandoObtenerLogrosVFPendientes CrearComandoObtenerLogrosVFPendientes(Entidad partido)
        {
            return new ComandoObtenerLogrosVFPendientes(partido);
        }
        public static ComandoObtenerApuestasCantidadEnCurso CrearComandoObtenerApuestasCantidadEnCurso(Entidad usuario)
        {
            return new ComandoObtenerApuestasCantidadEnCurso(usuario);
        }

        public static ComandoObtenerApuestasJugadorEnCurso CrearComandoObtenerApuestasJugadorEnCurso(Entidad usuario)
        {
            return new ComandoObtenerApuestasJugadorEnCurso(usuario);
        }

        public static ComandoObtenerApuestasEquipoEnCurso CrearComandoObtenerApuestasEquipoEnCurso(Entidad usuario)
        {
            return new ComandoObtenerApuestasEquipoEnCurso(usuario);
        }

        /// <exception cref="ApuestaInvalidaException"></exception>
        public static ComandoVerificarApuestaVoFValida CrearComandoVerificarApuestaVoFValida(Entidad apuesta)
        {
            return new ComandoVerificarApuestaVoFValida(apuesta);
        }

        /// <exception cref="ApuestaInvalidaException"></exception>
        public static ComandoVerificarApuestaCantidadValida CrearComandoVerificarApuestaCantidadValida(Entidad apuesta)
        {
            return new ComandoVerificarApuestaCantidadValida(apuesta);
        }

        /// <exception cref="ApuestaInvalidaException"></exception>
        public static ComandoVerificarApuestaJugadorValida CrearComandoVerificarApuestaJugadorValida(Entidad apuesta)
        {
            return new ComandoVerificarApuestaJugadorValida(apuesta);
        }

        /// <exception cref="ApuestaInvalidaException"></exception>
        public static ComandoVerificarApuestaEquipoValida CrearComandoVerificarApuestaEquipoValida(Entidad apuesta)
        {
            return new ComandoVerificarApuestaEquipoValida(apuesta);
        }

        public static ComandoActualizarApuestaVoF CrearComandoActualizarApuestaVoF(Entidad apuesta)
        {
            return new ComandoActualizarApuestaVoF(apuesta);
        }

        public static ComandoActualizarApuestaCantidad CrearComandoActualizarApuestaCantidad(Entidad apuesta)
        {
            return new ComandoActualizarApuestaCantidad(apuesta);
        }

        public static ComandoActualizarApuestaJugador CrearComandoActualizarApuestaJugador(Entidad apuesta)
        {
            return new ComandoActualizarApuestaJugador(apuesta);
        }

        public static ComandoActualizarApuestaEquipo CrearComandoActualizarApuestaEquipo(Entidad apuesta)
        {
            return new ComandoActualizarApuestaEquipo(apuesta);
        }

        public static ComandoEliminarApuestaVOF CrearComandoEliminarApuestaVoF(Entidad apuesta)
        {
            return new ComandoEliminarApuestaVOF(apuesta);
        }

        public static ComandoEliminarApuestaCantidad CrearComandoEliminarApuestaCantidad(Entidad apuesta)
        {
            return new ComandoEliminarApuestaCantidad(apuesta);
        }

        public static ComandoEliminarApuestaJugador CrearComandoEliminarApuestaJugador(Entidad apuesta)
        {
            return new ComandoEliminarApuestaJugador(apuesta);
        }

        public static ComandoEliminarApuestaEquipo CrearComandoEliminarApuestaEquipo(Entidad apuesta)
        {
            return new ComandoEliminarApuestaEquipo(apuesta);
        }

        public static ComandoObtenerApuestasVoFFinalizadas CrearComandoObtenerApuestasVoFFinalizadas(Entidad usuario)
        {
            return new ComandoObtenerApuestasVoFFinalizadas(usuario);
        }

        public static ComandoObtenerApuestasCantidadFinalizadas CrearComandoObtenerApuestasCantidadFinalizadas(Entidad usuario)
        {
            return new ComandoObtenerApuestasCantidadFinalizadas(usuario);
        }

        public static ComandoObtenerApuestasJugadorFinalizadas CrearComandoObtenerApuestasJugadorFinalizadas(Entidad usuario)
        {
            return new ComandoObtenerApuestasJugadorFinalizadas(usuario);
        }

        public static ComandoObtenerApuestasEquipoFinalizadas CrearComandoObtenerApuestasEquipoFinalizadas(Entidad usuario)
        {
            return new ComandoObtenerApuestasEquipoFinalizadas(usuario);
        }
    }
}