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

        public static ComandoVerificarApuestaVoFExiste CrearComandoVerificarApuestaVoFExiste(Entidad apuesta)
        {
            return new ComandoVerificarApuestaVoFExiste(apuesta);
        }

        public static ComandoVerificarApuestaCantidadExiste CrearComandoVerificarApuestaCantidadExiste(Entidad apuesta)
        {
            return new ComandoVerificarApuestaCantidadExiste(apuesta);
        }

        public static ComandoAgregarApuestaCantidad CrearComandoAgregarApuestaCantidad(Entidad apuesta)
        {
            return new ComandoAgregarApuestaCantidad(apuesta);
        }

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

        public static ComandoVerificarApuestaVoFValida CrearComandoVerificarApuestaVoFValida(Entidad apuesta)
        {
            return new ComandoVerificarApuestaVoFValida(apuesta);
        }

        public static ComandoVerificarApuestaCantidadValida CrearComandoVerificarApuestaCantidadValida(Entidad apuesta)
        {
            return new ComandoVerificarApuestaCantidadValida(apuesta);
        }

        public static ComandoVerificarApuestaJugadorValida CrearComandoVerificarApuestaJugadorValida(Entidad apuesta)
        {
            return new ComandoVerificarApuestaJugadorValida(apuesta);
        }

        public static ComandoVerificarApuestaEquipoValida CrearComandoVerificarApuestaEquipoValida(Entidad apuesta)
        {
            return new ComandoVerificarApuestaEquipoValida(apuesta);
        }


    }
}