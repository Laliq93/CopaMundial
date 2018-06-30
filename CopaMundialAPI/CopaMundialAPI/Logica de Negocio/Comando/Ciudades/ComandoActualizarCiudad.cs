using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;
using NLog;
using System.Reflection;
using CopaMundialAPI.Comun.Excepciones;
using Npgsql;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Ciudades
{
    /// <summary>
    /// Comando que se encarga de actualizar una ciudad de tipo Entidad
    /// </summary>
    public class ComandoActualizarCiudad : Comando
    {
        Logger logger = LogManager.GetLogger ( "fileLogger" );//logger 

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="ciudad">ciudad a actualizar</param>
        public ComandoActualizarCiudad ( Entidad ciudad )
        {
            Entidad = ciudad;
        }

        /// <summary>
        /// Metodo que ejecuta la accion del comando
        /// </summary>
        public override void Ejecutar ( )
        {
            try
            {
                IDAOCiudad dao = FabricaDAO.CrearDAOCiudad ( );
                dao.Actualizar ( Entidad );
            }

            catch (NpgsqlException e)
            {
                logger.Error ( e, "Error en la base de datos" );

                throw new BaseDeDatosException ( e, "Error en la base de datos en: " + GetType ( ).FullName + "." + MethodBase.GetCurrentMethod ( ).Name + ". " + e.Message );
            }

            catch (Exception e)
            {
                logger.Error ( e, "Error desconocido" );

                throw new ExcepcionGeneral ( e, DateTime.Now );

            }
        }

        /// <summary>
        /// Metodo que retorna una instancia de tipo Entidad de la respuesta del metodo ejecutar().
        /// </summary>
        /// <returns>Una instacia de tipo Entidad</returns>
        /// <exception cref="System.NotImplementedException">Metodo No implementado</exception>
        public override Entidad GetEntidad ( )
        {
            throw new NotImplementedException ( );
        }

        /// <summary>
        /// Metodo que retorna una lista de tipo Entidad de la respuesta del metodo ejecutar().
        /// </summary>
        /// <returns>Una lista de tipo Entidad</returns>
        /// <exception cref="System.NotImplementedException">Metodo No implementado</exception>
        public override List<Entidad> GetEntidades ( )
        {
            throw new NotImplementedException ( );
        }
    }
}