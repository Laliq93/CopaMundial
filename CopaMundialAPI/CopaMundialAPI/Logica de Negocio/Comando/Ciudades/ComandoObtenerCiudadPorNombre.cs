using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NLog;
using System.Reflection;
using CopaMundialAPI.Comun.Excepciones;
using Npgsql;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Ciudades
{
    /// <summary>
    /// Comando que se encarga de obtener una ciudad de tipo Entidad segun su nombre
    /// </summary>
    public class ComandoObtenerCiudadPorNombre :Comando
	{

		private List<Entidad> ciudad; //Lista de ciudades
        Logger logger = LogManager.GetLogger ( "fileLogger" );//logger 

        /// <summary>
        /// Constructor de la clase 
        /// </summary>
        /// <param name="ciudad">Instancia ciudad que se desea obtener</param>
        public ComandoObtenerCiudadPorNombre (Entidad ciudad)
		{
			Entidad = ciudad;
		}

        /// <summary>
        /// Metodo que ejecuta la accion del comando
        /// </summary>
        public override void Ejecutar()
		{
			try
			{
				IDAOCiudad dao = FabricaDAO.CrearDAOCiudad();
				this.ciudad =dao.ConsultarCiudadPorNombre(Entidad);
			}

            catch (NpgsqlException e)
            {
                logger.Error ( e, e.Message );

                throw new BaseDeDatosException ( e, "Error en la base de datos en: " + GetType ( ).FullName + "." + MethodBase.GetCurrentMethod ( ).Name + ". " + e.Message );
            }

            catch (Exception e)
            {
                logger.Error ( e, e.Message );

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
        public override List<Entidad> GetEntidades()
		{
			return this.ciudad;
		}
	}
}
