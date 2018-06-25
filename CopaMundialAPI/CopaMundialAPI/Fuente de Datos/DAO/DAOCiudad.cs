using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces;

namespace CopaMundialAPI.Fuente_de_Datos.DAO
{
    /// <summary>
    /// DAO de la entidad Ciudad. En esta clase se encapsula el acceso a la fuente de datos.
    /// </summary>
    public class DAOCiudad : DAO, IDAOCiudad
    {
        public void Actualizar ( Entidad entidad )
        {
			Ciudad ciudad = entidad as Ciudad;

			Conectar();

			StoredProcedure("updateciudad(@_id,@_nombre,@_poblacion,@_descripcion,@_nombreingles,@_descripcioningles)");

			AgregarParametro("_id", ciudad.Id);
			AgregarParametro("_nombre", ciudad.Nombre);
			AgregarParametro("_poblacion", ciudad.Habitantes);
			AgregarParametro("_descripcion", ciudad.Descripcion);
			AgregarParametro("_nombreingles", ciudad.NombreIngles);
			AgregarParametro("_descripcioningles", ciudad.DescripcionIngles);

			EjecutarQuery();
		}

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

        public Entidad ConsultarCiudadPorId ( Entidad entidad )
        {
			Ciudad ciudad = entidad as Ciudad;
			Conectar();
			StoredProcedure("obtenerciudad(@id)");
			AgregarParametro("id", ciudad.Id);
			EjecutarReader();
			for (int i = 0; i < cantidadRegistros; i++)
			{
				ciudad = FabricaEntidades.CrearCiudad(GetString(i,0),GetInt(i,1),GetString(i,2),GetString(i,3),GetString(i,4));
			}
			return ciudad;
			
		}

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

		public void Eliminar ( Entidad entidad )
        {

			Ciudad ciudad = entidad as Ciudad;
			Conectar();
			StoredProcedure("eliminarciudad(@id)");
			AgregarParametro("id", ciudad.Id);
			EjecutarQuery();
			

		}

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