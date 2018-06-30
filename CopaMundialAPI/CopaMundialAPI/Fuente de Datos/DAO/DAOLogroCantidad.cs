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
    public class DAOLogroCantidad: DAO, IDAOLogro
    {
        public void Actualizar(Entidad entidad)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo para agregar un logro por cantidad
        /// </summary>
        /// <param name="entidad"></param>
        public void Agregar(Entidad entidad)
        {
            LogroCantidad logro = entidad as LogroCantidad;

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
            LogroCantidad logro = entidad as LogroCantidad;
            Conectar();
            StoredProcedure("ConsultarLogroCantidad(@idLogro)");
            AgregarParametro("idLogro", logro.Id);
            EjecutarReader();
            for (int i = 0; i < cantidadRegistros; i++)
            {
                logro = FabricaEntidades.CrearLogroCantidad();

                logro.Id = GetInt(i, 0);
                logro.IdTipo = TipoLogro.cantidad;
                logro.Logro = GetString(i, 2);
                logro.Cantidad = GetInt(i, 3);
                logro.Status = GetBool(i, 4);
            }
            if (logro == null)
                throw new LogroNoExisteException(logro.Id, "cantidad");
            return logro;
        }

        /// <summary>
        /// Metodo que asigna un el resultado  de un 
        /// logroCantidad
        /// </summary>
        /// <param name="entidad"></param>
        public void AsignarResultadoLogro(Entidad entidad)
        {
            
                LogroCantidad logro = entidad as LogroCantidad;

                Conectar();

                StoredProcedure("RegistrarLogroCantidad(@idLogro,@cantidad)");
                AgregarParametro("idLogro", logro.Id);
                AgregarParametro("cantidad", (int)logro.Cantidad);

                EjecutarQuery();
            
        }

        /// <summary>
        /// Metodo para obtener todos los logros
        /// pendientes por asignar un resultado de un partido
        /// </summary>
        /// <param name="partido"></param>
        /// <exception cref="LogrosPendientesNoExisteException">Excepcion que 
        /// ocurre cuando un partido no tiene logros pendientes por asignar
        /// resultado</exception>
        /// <returns></returns>
        public List<Entidad> ObtenerLogrosPendientes(Entidad partido)
        {
            List<Entidad> logroscantidad = new List<Entidad>();
            LogroCantidad logro;

            Conectar();

            StoredProcedure("ConsultarLogrosCantidadPendiente(@idpartido)");

            AgregarParametro("idpartido", partido.Id);

            EjecutarReader();

            for (int i = 0; i < cantidadRegistros; i++)
            {
                logro = FabricaEntidades.CrearLogroCantidad();

                logro.Id = GetInt(i, 0);
                logro.IdTipo = TipoLogro.cantidad;
                logro.Logro = GetString(i, 2);
                

                logroscantidad.Add(logro);
            }
            if (logroscantidad.Count ==0 )
                throw new LogrosPendientesNoExisteException(partido.Id,"cantidad");

            return logroscantidad;
           
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