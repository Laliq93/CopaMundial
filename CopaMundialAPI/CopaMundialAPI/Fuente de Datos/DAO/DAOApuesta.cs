using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Comun.Excepciones;

namespace CopaMundialAPI.Fuente_de_Datos.DAO
{
    public class DAOApuesta : DAO
    {
        public void VerificarApuestaExiste(Entidad apuesta)
        {
            Conectar();

            ApuestaVoF apuestavof = apuesta as ApuestaVoF;

            StoredProcedure("verificarapuestaexiste(@idlogro, @idusuario)");

            AgregarParametro("idlogro", apuestavof.Logro.Id);
            AgregarParametro("idusuario", apuestavof.Usuario.Id);

            EjecutarReader();

            int count = GetInt(0, 0);

            if (count > 0)
                throw new ApuestaRepetidaException();
        }

        public List<Entidad> ObtenerProximosPartidos()
        {
            Equipos equiposEstaticos = new Equipos();

            List<Entidad> partidos = new List<Entidad>();

            Partido partido;

            Conectar();

            StoredProcedure("obtenerproximospartidos()");

            EjecutarReader();

            for(int i = 0; i < cantidadRegistros; i++)
            {
                partido = new Partido();
                int idequipo1, idequipo2;

                partido.Id = GetInt(i, 0);
                partido.FechaPartido = GetDateTime(i, 1);
                idequipo1 = GetInt(i, 2);
                idequipo2 = GetInt(i, 3);
                partido.Equipo1 = equiposEstaticos.GetEquipo(idequipo1);
                partido.Equipo2 = equiposEstaticos.GetEquipo(idequipo2);

                partidos.Add(partido);
            }

            return partidos;
        }

        public List<Entidad> ObtenerLogrosVofPartido(Entidad entidad)
        {
            List<Entidad> logrosvof = new List<Entidad>();
            LogroVoF logro;

            Conectar();

            StoredProcedure("obtenerlogrosvofpartido(@idpartido)");

            AgregarParametro("idpartido", entidad.Id);

            EjecutarReader();

            for(int i = 0; i < cantidadRegistros; i++)
            {
                logro = FabricaEntidades.CrearLogroVoF();

                logro.Id = GetInt(i, 0);
                logro.Logro = GetString(i, 1);
                logro.IdTipo = TipoLogro.vof;

                logrosvof.Add(logro);
            }

            return logrosvof;
        }

        public List<Entidad> ObtenerLogrosCantidadPartido(Entidad entidad)
        {
            List<Entidad> logroscantidad = new List<Entidad>();
            LogroCantidad logro;

            Conectar();

            StoredProcedure("obtenerlogroscantidadpartido(@idpartido)");

            AgregarParametro("idpartido", entidad.Id);

            EjecutarReader();

            for (int i = 0; i < cantidadRegistros; i++)
            {
                logro = FabricaEntidades.CrearLogroCantidad();

                logro.Id = GetInt(i, 0);
                logro.Logro = GetString(i, 1);
                logro.IdTipo = TipoLogro.cantidad;

                logroscantidad.Add(logro);
            }

            return logroscantidad;
        }

        public List<Entidad> ObtenerLogrosEquipoPartido(Entidad entidad)
        {
            List<Entidad> logrosequipo = new List<Entidad>();
            LogroEquipo logro;

            Conectar();

            StoredProcedure("obtenerlogrosequipopartido(@idpartido)");

            AgregarParametro("idpartido", entidad.Id);

            EjecutarReader();

            for (int i = 0; i < cantidadRegistros; i++)
            {
                logro = FabricaEntidades.CrearLogroEquipo();

                logro.Id = GetInt(i, 0);
                logro.Logro = GetString(i, 1);
                logro.IdTipo = TipoLogro.equipo;

                logrosequipo.Add(logro);
            }

            return logrosequipo;
        }

        public List<Entidad> ObtenerLogrosJugadorPartido(Entidad entidad)
        {
            List<Entidad> logrosjugador = new List<Entidad>();
            LogroJugador logro;

            Conectar();

            StoredProcedure("obtenerlogrosjugadorpartido(@idpartido)");

            AgregarParametro("idpartido", entidad.Id);

            EjecutarReader();

            for (int i = 0; i < cantidadRegistros; i++)
            {
                logro = FabricaEntidades.CrearLogroJugador();

                logro.Id = GetInt(i, 0);
                logro.Logro = GetString(i, 1);
                logro.IdTipo = TipoLogro.jugador;

                logrosjugador.Add(logro);
            }

            return logrosjugador;
        }
    }
}