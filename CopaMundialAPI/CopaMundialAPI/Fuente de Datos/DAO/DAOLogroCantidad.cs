using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
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
            
            return logro;
        }

      
        public void AsignarResultadoLogro(Entidad logro)
        {
            throw new NotImplementedException();
        }

     
        public List<Entidad> ObtenerLogrosPendientes(Entidad partido)
        {
            throw new NotImplementedException();
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