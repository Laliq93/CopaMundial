using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Comun.Excepciones;
using CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces;

namespace CopaMundialAPI.Fuente_de_Datos.DAO
{
    public class DAOLogroJugador: DAO, IDAOLogro
    {


        public void Actualizar(Entidad entidad)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo para agregar un logro por jugador
        /// </summary>
        /// <param name="entidad"></param>
        public void Agregar(Entidad entidad)
        {
            LogroJugador logro = entidad as LogroJugador;

            Conectar();

            StoredProcedure("AsignarLogro(@logro,@idTipo,@idPartido)");
            AgregarParametro("logro", logro.Logro);
            AgregarParametro("idTipo", (int)logro.IdTipo);
            AgregarParametro("idPartido", logro.Partido.Id);

            EjecutarQuery();
        }

        public void Eliminar(Entidad entidad)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo para obtener logro su id 
        /// </summary>
        /// <param name="entidad"></param>
        /// <exception cref="LogroNoExisteException">Excepcion que indica 
        /// que el logro no existe</exception>
        /// <returns></returns>
        public Entidad ObtenerLogroPorId(Entidad entidad)
        {
            LogroJugador logro = entidad as LogroJugador;
            Jugador jugador;
            Conectar();
            StoredProcedure("ConsultarLogroJugador(@idLogro)");
            AgregarParametro("idLogro", logro.Id);
            EjecutarReader();
            for (int i = 0; i < cantidadRegistros; i++)
            {
                logro = FabricaEntidades.CrearLogroJugador();
                jugador = FabricaEntidades.CrearJugador();
                logro.Jugador = jugador;
                logro.Id = GetInt(i, 0);
                logro.IdTipo = TipoLogro.jugador;
                logro.Logro = GetString(i, 2);
                logro.Jugador.Id = GetInt(i, 3);
                logro.Status = GetBool(i, 4);
            }
            if (logro == null)
                throw new LogroNoExisteException(logro.Id, "jugador");
            return logro;
        }

        /// <summary>
        /// Metodo que asigna el resultado de un logro 
        /// por jugador
        /// </summary>
        /// <param name="entidad"></param>
        public void AsignarResultadoLogro(Entidad entidad)
        {
            LogroJugador logro = entidad as LogroJugador;

            Conectar();

            StoredProcedure("RegistrarLogroJugador(@idLogro,@idJugador)");
            AgregarParametro("idLogro", logro.Id);
            AgregarParametro("idJugador", logro.Jugador.Id);

            EjecutarQuery();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="partido"></param>
        /// <exception cref="LogrosPendientesNoExisteException">Excepcion que 
        /// ocurre cuando un partido no tiene logros pendientes por asignar
        /// resultado</exception>
        /// <returns></returns>
        public List<Entidad> ObtenerLogrosPendientes(Entidad partido)
        {
            List<Entidad> logrosJugador = new List<Entidad>();
            LogroJugador logro;

            Conectar();

            StoredProcedure("ConsultarLogrosJugadorPendiente(@idpartido)");

            AgregarParametro("idpartido", partido.Id);

            EjecutarReader();

            for (int i = 0; i < cantidadRegistros; i++)
            {
                logro = FabricaEntidades.CrearLogroJugador();

                logro.Id = GetInt(i, 0);
                logro.IdTipo = TipoLogro.jugador;
                logro.Logro = GetString(i, 2);


                logrosJugador.Add(logro);
            }
            if (logrosJugador.Count == 0)
                throw new LogrosPendientesNoExisteException(partido.Id, "jugador");

            return logrosJugador;

        }

        /// <summary>
        /// Metodo que obtiene todos los logros de jugador
        /// que tengan resultado asignado
        /// </summary>
        /// <exception cref="LogrosFinalizadosNoExisteException">Retorna esta excepcion
        /// si no existen logros de jugador con resultado asignado</exception>
        /// <param name="partido"></param>
        /// <returns></returns>
        public List<Entidad> ObtenerLogrosResultados(Entidad partido)
        {
            List<Entidad> logrosJugador = new List<Entidad>();
            LogroJugador logro;

            Conectar();

            StoredProcedure("ConsultarLogrosJugadorResultados(@idpartido)");

            AgregarParametro("idpartido", partido.Id);

            EjecutarReader();

            for (int i = 0; i < cantidadRegistros; i++)
            {
                logro = FabricaEntidades.CrearLogroJugador();
                Jugador jugador = FabricaEntidades.CrearJugador();
                logro.Jugador = jugador;
                logro.Id = GetInt(i, 0);
                logro.IdTipo = TipoLogro.jugador;
                logro.Logro = GetString(i, 2);
                logro.Jugador.Id = GetInt(i, 3);


                logrosJugador.Add(logro);
            }
            if (logrosJugador.Count == 0)
                throw new LogrosFinalizadosNoExisteException(partido.Id, "jugador");

            return logrosJugador;
        }


        public List<Entidad> ObtenerTodos()
        {
            throw new NotImplementedException();
        }

    }
}