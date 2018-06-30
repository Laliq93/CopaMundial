using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Excepciones;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;
using NLog;
using Npgsql;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Ciudades
{
    /// <summary>
    /// Comando que se encarga de obtener una ciudad de tipo Entidad segun su id
    /// </summary>
    public class ComandoObtenerCiudad : Comando
	{
		private int _id;//id de la ciudad
        Logger logger = LogManager.GetLogger ( "fileLogger" );//logger 


        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="id">id de la ciudad a obtener</param>
        public ComandoObtenerCiudad (int id)
		{
			_id = id;
		}

        /// <summary>
        /// Metodo que ejecuta la accion del comando
        /// </summary>
        public override void Ejecutar()
		{
            try
            {
                DAOCiudad dao = FabricaDAO.CrearDAOCiudad ( );
                //dao.ConsultarCiudadPorId()
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
        public override Entidad GetEntidad()
		{
			return Entidad;
		}

        /// <summary>
        /// Metodo que retorna una lista de tipo Entidad de la respuesta del metodo ejecutar().
        /// </summary>
        /// <returns>Una lista de tipo Entidad</returns>
        /// <exception cref="System.NotImplementedException">Metodo No implementado</exception>
        public override List<Entidad> GetEntidades()
		{
			throw new NotImplementedException();
		}
	}
}