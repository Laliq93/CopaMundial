using System;
using System.Collections.Generic;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Comun.Excepciones;
using CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces;


namespace CopaMundialAPI.Fuente_de_Datos.DAO
{
    public class DAOLogroVF: DAO, IDAOLogro
    {


        public void Actualizar(Entidad entidad)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo para agregar un logro verdadero o falso
        /// </summary>
        /// <param name="entidad"></param>
        public void Agregar(Entidad entidad)
        {
            LogroVoF logro = entidad as LogroVoF;

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
            LogroVoF logro = entidad as LogroVoF;
            Conectar();
            StoredProcedure("ConsultarLogroVF(@idLogro)");
            AgregarParametro("idLogro", logro.Id);
            EjecutarReader();
            for (int i = 0; i < cantidadRegistros; i++)
            {
                logro = FabricaEntidades.CrearLogroVoF();
                logro.Id = GetInt(i, 0);
                logro.IdTipo = TipoLogro.vof;
                logro.Logro = GetString(i, 2);
                logro.Respuesta = GetBool(i, 3);
                logro.Status = GetBool(i, 4);
            }
            if (logro == null)
                throw new LogroNoExisteException(logro.Id, "vof");
            return logro;
        }

        /// <summary>
        /// Metodo que asigna el resultado de un 
        /// logro VF
        /// </summary>
        /// <param name="entidad"></param>
        public void AsignarResultadoLogro(Entidad entidad)
        {
            
                LogroVoF logro = entidad as LogroVoF;

                Conectar();

                StoredProcedure("RegistrarLogroVoF(@idLogro,@respuesta)");
                AgregarParametro("idLogro", logro.Id);
                AgregarParametro("respuesta", logro.Respuesta);

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
            List<Entidad> logrosVf = new List<Entidad>();
            LogroVoF logro;

            Conectar();

            StoredProcedure("ConsultarLogrosVoFPendiente(@idpartido)");

            AgregarParametro("idpartido", partido.Id);

            EjecutarReader();

            for (int i = 0; i < cantidadRegistros; i++)
            {
                logro = FabricaEntidades.CrearLogroVoF();

                logro.Id = GetInt(i, 0);
                logro.IdTipo = TipoLogro.vof;
                logro.Logro = GetString(i, 2);


                logrosVf.Add(logro);
            }
            if (logrosVf.Count == 0)
                throw new LogrosPendientesNoExisteException(partido.Id, "vf");

            return logrosVf;

        }


        public List<Entidad> ObtenerLogrosResultados(Entidad partido)
        {
            throw new NotImplementedException();
        }


        public List<Entidad> ObtenerTodos()
        {
            throw new NotImplementedException();
        }

    }
}