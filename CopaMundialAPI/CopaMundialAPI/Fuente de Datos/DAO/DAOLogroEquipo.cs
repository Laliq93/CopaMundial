﻿using System;
using System.Collections.Generic;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Comun.Excepciones;
using CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces;

namespace CopaMundialAPI.Fuente_de_Datos.DAO
{
    public class DAOLogroEquipo: DAO, IDAOLogro 
    {


        public void Actualizar(Entidad entidad)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo para agregar un logro por equipo
        /// </summary>
        /// <param name="entidad"></param>
        public void Agregar(Entidad entidad)
        {
            LogroEquipo logro = entidad as LogroEquipo;

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
            LogroEquipo logro = entidad as LogroEquipo;
            Conectar();
            StoredProcedure("ConsultarLogroEquipo(@idLogro)");
            AgregarParametro("idLogro", logro.Id);
            EjecutarReader();
            for (int i = 0; i < cantidadRegistros; i++)
            {
                logro = FabricaEntidades.CrearLogroEquipo();
                logro.Id = GetInt(i, 0);
                logro.IdTipo = TipoLogro.equipo;
                logro.Logro = GetString(i, 2);
                logro.Equipo.Id = GetInt(i, 3);
                logro.Status = GetBool(i, 4);
            }
            if (logro == null)
                throw new LogroNoExisteException(logro.Id, "equipo");
            return logro;
        }

        /// <summary>
        /// Metodo para asignar el resultado de un 
        /// logro por equipo
        /// </summary>
        /// <param name="entidad"></param>
        public void AsignarResultadoLogro(Entidad entidad)
        {

            LogroEquipo logro = entidad as LogroEquipo;

            Conectar();

            StoredProcedure("RegistrarLogroEquipo(@idLogro,@idEquipo)");
            AgregarParametro("idLogro", logro.Id);
            AgregarParametro("idEquipo", logro.Equipo.Id);

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
            List<Entidad> logrosEquipo = new List<Entidad>();
            LogroEquipo logro;

            Conectar();

            StoredProcedure("ConsultarLogrosEquipoPendiente(@idpartido)");

            AgregarParametro("idpartido", partido.Id);

            EjecutarReader();

            for (int i = 0; i < cantidadRegistros; i++)
            {
                logro = FabricaEntidades.CrearLogroEquipo();

                logro.Id = GetInt(i, 0);
                logro.IdTipo = TipoLogro.equipo;
                logro.Logro = GetString(i, 2);


                logrosEquipo.Add(logro);
            }
            if (logrosEquipo.Count == 0)
                throw new LogrosPendientesNoExisteException(partido.Id, "equipo");

            return logrosEquipo;

        }


        /// <summary>
        /// Metodo que obtiene todos los logros de equipo 
        /// que tengan resultado asignado
        /// </summary>
        /// <exception cref="LogrosFinalizadosNoExisteException">Excepcion que 
        /// obtiene cuando el partido no tiene logros de equipo con 
        /// resultado asignado</exception>
        /// <param name="partido"></param>
        /// <returns></returns>
        public List<Entidad> ObtenerLogrosResultados(Entidad partido)
        {
            List<Entidad> logrosEquipo = new List<Entidad>();
            LogroEquipo logro;

            Conectar();

            StoredProcedure("ConsultarLogrosEquipoResultados(@idpartido)");

            AgregarParametro("idpartido", partido.Id);

            EjecutarReader();

            for (int i = 0; i < cantidadRegistros; i++)
            {
                logro = FabricaEntidades.CrearLogroEquipo();

                logro.Id = GetInt(i, 0);
                logro.IdTipo = TipoLogro.equipo;
                logro.Logro = GetString(i, 2);
                logro.Equipo.Id = GetInt(i, 3);
            


                logrosEquipo.Add(logro);
            }
            if (logrosEquipo.Count == 0)
                throw new LogrosFinalizadosNoExisteException(partido.Id, "equipo");

            return logrosEquipo;
        }


        public List<Entidad> ObtenerTodos()
        {
            throw new NotImplementedException();
        }

    }
}