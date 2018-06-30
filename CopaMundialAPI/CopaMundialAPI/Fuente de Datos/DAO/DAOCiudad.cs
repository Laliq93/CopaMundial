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


				Ciudad ciudad = (Ciudad)entidad;

                Conectar ( );

                StoredProcedure ( "updateciudad(@_id,@_nombre,@_poblacion,@_descripcion,@_nombreingles,@_descripcioningles,@_habilitado)" );

                AgregarParametro ( "_id", ciudad.Id );
                AgregarParametro ( "_nombre", ciudad.Nombre );
                AgregarParametro ( "_poblacion", ciudad.Habitantes );
                AgregarParametro ( "_descripcion", ciudad.Descripcion );
                AgregarParametro ( "_nombreingles", ciudad.NombreIngles );
                AgregarParametro ( "_descripcioningles", ciudad.DescripcionIngles );
				AgregarParametro("_habilitado", ciudad.Habilitado);

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

            try
            {
                Ciudad ciudad = (Ciudad)entidad ;

                Conectar ( );

                StoredProcedure ( "insertarciudad(@_nombre,@_poblacion,@_descripcion,@_nombreingles,@_descripcioningles)" );

                AgregarParametro ( "_nombre", ciudad.Nombre );
                AgregarParametro ( "_poblacion", ciudad.Habitantes );
                AgregarParametro ( "_descripcion", ciudad.Descripcion );
                AgregarParametro ( "_nombreingles", ciudad.NombreIngles );
                AgregarParametro ( "_descripcioningles", ciudad.DescripcionIngles );

                EjecutarQuery ( );
            }
            catch (NullReferenceException e)
            {
                logger.Error ( e, "Parametros de entrada nulos" );

                throw new ObjetoNullException ( e, "Parametros nulos en: " + GetType ( ).FullName + "." + MethodBase.GetCurrentMethod ( ).Name + ". " + e.Message );
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

                throw new ExcepcionGeneral ( e, DateTime.Now );

            }

            finally
            {
                Desconectar ( );
            }
        }

        /// <summary>
        /// Metodo para consultar una ciudad de tipo entidad dado su ID
        /// </summary>
        /// <param name="entidad">ciudad a consultar</param>
        /// <returns></returns>
        public Entidad ConsultarCiudadPorId ( Entidad entidad )
        {

            try
            {
				Ciudad ciudad = (Ciudad)entidad;
				Conectar ( );
                StoredProcedure ( "getciudad(@id)" );
                AgregarParametro ( "id", ciudad.Id );
                EjecutarReader ( );
				Ciudad ciudadARetornar = null;
                for (int i = 0; i < cantidadRegistros; i++)
                {
                    ciudadARetornar = FabricaEntidades.CrearCiudad(GetInt(i, 0), GetString(i, 1), GetInt(i, 3), GetString(i, 2), GetString(i, 4), GetString(i, 5)) ;
					ciudadARetornar.Habilitado = GetBool(i, 6);
				}
                return ciudadARetornar;
			
            }
            catch (NullReferenceException e)
            {
                logger.Error ( e, "Parametros de entrada nulos" );

                throw new ObjetoNullException ( e, "Parametros nulos en: " + GetType ( ).FullName + "." + MethodBase.GetCurrentMethod ( ).Name + ". " + e.Message );
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

                throw new ExcepcionGeneral ( e, DateTime.Now );

            }

            finally
            {
                Desconectar ( );
            }

        }
		/// <summary>
		/// Metodo para consultar una ciudad de tipo entidad dado su nombre en espanol
		/// </summary>
		/// <param name="entidad">ciudad a consultar</param>
		/// <returns></returns>
		public List<Entidad> ConsultarCiudadPorNombre(Entidad entidad)
		{
            try
            {
				Ciudad ciudad = (Ciudad)entidad;
				List<Entidad> _ciudades = new List<Entidad> ( );
                Conectar ( );
                StoredProcedure ( "getciudadbyname(@nombre)" );
                AgregarParametro ( "nombre", ciudad.Nombre );
                EjecutarReader ( );
                for (int i = 0; i < cantidadRegistros; i++)
                {
					Ciudad city = FabricaEntidades.CrearCiudad(GetInt(i, 0), GetString(i, 1), GetInt(i, 3), GetString(i, 2), GetString(i, 4), GetString(i, 5));
					city.Habilitado = GetBool(i, 6);
					_ciudades.Add(city);
				}
				return _ciudades;
            }
            catch (NullReferenceException e)
            {
                logger.Error ( e, "Parametros de entrada nulos" );

                throw new ObjetoNullException ( e, "Parametros nulos en: " + GetType ( ).FullName + "." + MethodBase.GetCurrentMethod ( ).Name + ". " + e.Message );
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

                throw new ExcepcionGeneral ( e, DateTime.Now );

            }

            finally
            {
                Desconectar ( );
            }
        }

        /// <summary>
        /// Metodo para consultar una ciudad de tipo entidad dado su nombre en espanol
        /// </summary>
        /// <param name="entidad">ciudad a consultar</param>
        /// <returns></returns>
        public List<Entidad> ConsultarCiudadPorNombreIngles(Entidad entidad)
		{
            try
            {
				Ciudad ciudad = (Ciudad)entidad;
				List<Entidad> _ciudades = new List<Entidad> ( );
                Conectar ( );
                StoredProcedure ( "getciudadbynameingles(@nombre)" );
                AgregarParametro ( "nombre", ciudad.Nombre );
                EjecutarReader ( );
                for (int i = 0; i < cantidadRegistros; i++)
                {
					Ciudad city = FabricaEntidades.CrearCiudad(GetInt(i, 0), GetString(i, 1), GetInt(i, 3), GetString(i, 2), GetString(i, 4), GetString(i, 5));
					city.Habilitado = GetBool(i, 6);
					_ciudades.Add(city);
      }
                return _ciudades;
            }
            catch (NullReferenceException e)
            {
                logger.Error ( e, "Parametros de entrada nulos" );

                throw new ObjetoNullException ( e, "Parametros nulos en: " + GetType ( ).FullName + "." + MethodBase.GetCurrentMethod ( ).Name + ". " + e.Message );
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

                throw new ExcepcionGeneral ( e, DateTime.Now );

            }

            finally
            {
                Desconectar ( );
            }
        }

        /// <summary>
        /// Metodo para eliminar una ciudad 
        /// </summary>
        /// <param name="entidad">ciudad a eliminar</param>
        /// <returns></returns>
        public void Eliminar ( Entidad entidad )
        {
            try
            {

				Ciudad ciudad = (Ciudad)entidad;
				Conectar ( );
                StoredProcedure ( "eliminarciudad(@id)" );
                AgregarParametro ( "id", ciudad.Id );
                EjecutarQuery ( );


            }
            catch (NullReferenceException e)
            {
                logger.Error ( e, "Parametros de entrada nulos" );

                throw new ObjetoNullException ( e, "Parametros nulos en: " + GetType ( ).FullName + "." + MethodBase.GetCurrentMethod ( ).Name + ". " + e.Message );
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

                throw new ExcepcionGeneral ( e, DateTime.Now );

            }

            finally
            {
                Desconectar ( );
            }
        }

        /// <summary>
        /// Metodo para obetner todas las ciudades que existen
        /// </summary>
        /// <returns></returns>
        public List<Entidad> ObtenerTodos ( )
        {

            try
            {
                Conectar ( );
                StoredProcedure ( "getallciudad()" );
                EjecutarReader ( );
                List<Entidad> _ciudades = new List<Entidad> ( );
                for (int i = 0; i < cantidadRegistros; i++)
                {
					Ciudad ciudad = FabricaEntidades.CrearCiudad(GetInt(i, 0), GetString(i, 1), GetInt(i, 3), GetString(i, 2), GetString(i, 4), GetString(i, 5));
					ciudad.Habilitado = GetBool(i, 6);
					_ciudades.Add (ciudad );
				
					
				}
                return _ciudades;
            }
            catch (NullReferenceException e)
            {
                logger.Error ( e, "Parametros de entrada nulos" );

                throw new ObjetoNullException ( e, "Parametros nulos en: " + GetType ( ).FullName + "." + MethodBase.GetCurrentMethod ( ).Name + ". " + e.Message );
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

                throw new ExcepcionGeneral ( e, DateTime.Now );

            }

            finally
            {
                Desconectar ( );
            }
        }


		public List<Entidad> ObtenerTodosHabilitados()
		{

			try
			{
				Conectar();
				StoredProcedure("getallciudadtrue()");
				EjecutarReader();
				List<Entidad> _ciudades = new List<Entidad>();
				for (int i = 0; i < cantidadRegistros; i++)
				{
					Ciudad ciudad = FabricaEntidades.CrearCiudad(GetInt(i, 0), GetString(i, 1), GetInt(i, 3), GetString(i, 2), GetString(i, 4), GetString(i, 5));
					ciudad.Habilitado = GetBool(i, 6);
					_ciudades.Add(ciudad);


				}
				return _ciudades;
			}
			catch (NullReferenceException e)
			{
				logger.Error(e, "Parametros de entrada nulos");

				throw new ObjetoNullException(e, "Parametros nulos en: " + GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ". " + e.Message);
			}

			catch (InvalidCastException e)
			{
				logger.Error(e, "Casteo no correcto");

				throw new CasteoNoCorrectoException(e, "Casteo no correcto en: " + GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ". " + e.Message);
			}

			catch (NpgsqlException e)
			{
				logger.Error(e, "Error en la base de datos");

				throw new BaseDeDatosException(e, "Error en la base de datos en: " + GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ". " + e.Message);
			}

			catch (Exception e)
			{
				logger.Error(e, "Error desconocido");

				throw new ExcepcionGeneral(e, DateTime.Now);

			}

			finally
			{
				Desconectar();
			}
		}




	}
}