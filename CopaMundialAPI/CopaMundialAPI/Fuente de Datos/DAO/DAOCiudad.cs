using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces;
using CopaMundialAPI.Comun.Excepciones;
using System.Reflection;
using NLog;
using Npgsql;

namespace CopaMundialAPI.Fuente_de_Datos.DAO
{
    /// <summary>
    /// DAO de la entidad Ciudad. En esta clase se encapsula el acceso a la fuente de datos.
    /// </summary>
    public class DAOCiudad : DAO, IDAOCiudad
    {
        Logger logger = LogManager.GetLogger ( "fileLogger" );

        /// <summary>
        /// Metodo para actualizar una ciudad
        /// </summary>
        /// <param name="entidad">ciudad a actualizar</param>
        public void Actualizar ( Entidad entidad )
        {
            try
            {

                Exception e = new Exception ( );
                //throw e;

                Ciudad ciudad = entidad as Ciudad;

                Conectar ( );

                StoredProcedure ( "updateciudad(@_id,@_nombre,@_poblacion,@_descripcion,@_nombreingles,@_descripcioningles)" );

                AgregarParametro ( "_id", ciudad.Id );
                AgregarParametro ( "_nombre", ciudad.Nombre );
                AgregarParametro ( "_poblacion", ciudad.Habitantes );
                AgregarParametro ( "_descripcion", ciudad.Descripcion );
                AgregarParametro ( "_nombreingles", ciudad.NombreIngles );
                AgregarParametro ( "_descripcioningles", ciudad.DescripcionIngles );

                EjecutarQuery ( );


            }
            catch (NullReferenceException e)
            {
                logger.Error (e,"Parametros de entrada nulos");

                throw new ObjetoNullException(e,"Parametros nulos en: " + GetType ( ).FullName + "." + MethodBase.GetCurrentMethod ( ).Name + ". " + e.Message );
            }

            catch (InvalidCastException e)
            {
                logger.Error ( e, "Casteo no correcto" );

                throw new CasteoNoCorrectoException ( e, "Casteo no correcto en: " + GetType ( ).FullName + "." + MethodBase.GetCurrentMethod ( ).Name + ". " + e.Message );
            }

            catch (NpgsqlException e)
            {
                logger.Error ( e, "Error en la base de datos" );

                throw new BaseDeDatosException ( e, "Error en la base de datos en: " + GetType ( ).FullName + "." + MethodBase.GetCurrentMethod ( ).Name + ". " + e.Message );
            }

            catch (Exception e)
            {
                logger.Error ( e, "Error desconocido" );

                throw new ExcepcionGeneral ( e,DateTime.Now);

            }

            finally
            {
                Desconectar ( );
            }
		}


        /// <summary>
        /// Metodo par agregar una ciudad de tipo Entidad
        /// </summary>
        /// <param name="entidad">ciudad a agregar</param>
        public void Agregar ( Entidad entidad )
        {

            Ciudad ciudad = entidad as Ciudad;

            Conectar();

            StoredProcedure("insertarciudad(@_nombre,@_poblacion,@_descripcion,@_nombreingles,@_descripcioningles)");

            AgregarParametro("_nombre", ciudad.Nombre);
            AgregarParametro("_poblacion", ciudad.Habitantes);
            AgregarParametro("_descripcion", ciudad.Descripcion);
			AgregarParametro("_nombreingles", ciudad.NombreIngles);
			AgregarParametro("_descripcioningles", ciudad.DescripcionIngles);

            EjecutarQuery ( );
        }

        /// <summary>
        /// Metodo para consultar una ciudad de tipo entidad dado su ID
        /// </summary>
        /// <param name="entidad">ciudad a consultar</param>
        /// <returns></returns>
        public Entidad ConsultarCiudadPorId ( Entidad entidad )
        {
			Ciudad ciudad = entidad as Ciudad;
			Conectar();
			StoredProcedure("getciudad(@id)");
			AgregarParametro("id", ciudad.Id);
			EjecutarReader();
			Ciudad ciudadARetornar = null;
			for (int i = 0; i < cantidadRegistros; i++)
			{
				ciudadARetornar = FabricaEntidades.CrearCiudad(GetInt(i,0),GetString(i,1),GetInt(i,3),GetString(i,2),GetString(i,4),GetString(i,5));
			}
			return ciudadARetornar;
			
		}

        /// <summary>
        /// Metodo para consultar una ciudad de tipo entidad dado su nombre en espanol
        /// </summary>
        /// <param name="entidad">ciudad a consultar</param>
        /// <returns></returns>
		public List<Entidad> ConsultarCiudadPorNombre(Entidad entidad)
		{
			Ciudad ciudad = entidad as Ciudad;
			List<Entidad> _ciudades = new List<Entidad>();
			Conectar();
			StoredProcedure("getciudadbyname(@nombre)");
			AgregarParametro("nombre", ciudad.Nombre);
			EjecutarReader();
			for (int i = 0; i < cantidadRegistros; i++)
			{
				_ciudades.Add(FabricaEntidades.CrearCiudad(GetInt(i,0),GetString(i, 1), GetInt(i, 3), GetString(i, 2), GetString(i, 4), GetString(i, 5)));
			}
			return _ciudades;
		}

        /// <summary>
        /// Metodo para consultar una ciudad de tipo entidad dado su nombre en espanol
        /// </summary>
        /// <param name="entidad">ciudad a consultar</param>
        /// <returns></returns>
        public List<Entidad> ConsultarCiudadPorNombreIngles(Entidad entidad)
		{
			Ciudad ciudad = entidad as Ciudad;
			List<Entidad> _ciudades = new List<Entidad>();
			Conectar();
			StoredProcedure("getciudadbynameingles(@nombre)");
			AgregarParametro("nombre", ciudad.Nombre);
			EjecutarReader();
			for (int i = 0; i < cantidadRegistros; i++)
			{
				_ciudades.Add(FabricaEntidades.CrearCiudad(GetString(i, 0), GetInt(i, 1), GetString(i, 2), GetString(i, 3), GetString(i, 4)));
			}
			return _ciudades;
		}

        /// <summary>
        /// Metodo para eliminar una ciudad 
        /// </summary>
        /// <param name="entidad">ciudad a eliminar</param>
        /// <returns></returns>
        public void Eliminar ( Entidad entidad )
        {

			Ciudad ciudad = entidad as Ciudad;
			Conectar();
			StoredProcedure("eliminarciudad(@id)");
			AgregarParametro("id", ciudad.Id);
			EjecutarQuery();
			

		}

        /// <summary>
        /// Metodo para obetner todas las ciudades que existen
        /// </summary>
        /// <returns></returns>
        public List<Entidad> ObtenerTodos ( )
        {

			Conectar();
			StoredProcedure("getallciudad()");
			EjecutarReader();
			List<Entidad> _ciudades = new List<Entidad>();
			for (int i = 0; i < cantidadRegistros; i++)
			{
				_ciudades.Add(FabricaEntidades.CrearCiudad(GetInt(i,0),GetString(i, 1), GetInt(i, 3), GetString(i, 2), GetString(i, 4), GetString(i, 5)));
			}
			return _ciudades;
		}

    }
}