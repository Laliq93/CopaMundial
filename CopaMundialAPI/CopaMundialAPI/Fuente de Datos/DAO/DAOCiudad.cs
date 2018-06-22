using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces;

namespace CopaMundialAPI.Fuente_de_Datos.DAO
{
    /// <summary>
    /// DAO de la entidad Ciudad. En esta clase se encapsula el acceso a la fuente de datos.
    /// </summary>
    public class DAOCiudad : DAO, IDAOCiudad
    {
        public void Actualizar(Entidad entidad)
        {
            throw new NotImplementedException();
        }

        public void Agregar(Entidad entidad)
        {
            Ciudad ciudad = entidad as Ciudad;

            Conectar();

            StoredProcedure("insertarciudad(@ci_nombre,@ci_poblacion,@_descripcion,@_imagen)");

            AgregarParametro("_nombre", ciudad.Nombre);
            AgregarParametro("_capacidad", ciudad.Habitantes);
            AgregarParametro("_descripcion", ciudad.Descripcion);
			AgregarParametro("_imagen", ciudad.Imagen);

            EjecutarQuery();
        }

        public Ciudad ConsultarCiudadPorId(Ciudad ciudad)
        {
            throw new NotImplementedException();
        }

        public List<Ciudad> ConsultarListaCiudades(Ciudad ciudad)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(Entidad entidad)
        {
            throw new NotImplementedException();
        }

        public void EliminarCiudad(Ciudad ciudad)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo InsertarCiudad , inserta objeto de tipo Ciudad en la base de datos
        /// </summary>
        /// <param name="objeto">Ciudad que se desea insertar</param>
        public void InsertarCiudad(Ciudad ciudad)
        {
            Conectar();
			StoredProcedure("insertarciudad(@ci_nombre,@ci_poblacion,@_descripcion,@_imagen)");

			AgregarParametro("ci_nombre", ciudad.Nombre);
			AgregarParametro("ci_poblacion", ciudad.Habitantes);
			AgregarParametro("_descripcion", ciudad.Descripcion);
			AgregarParametro("_imagen", ciudad.Imagen);
			EjecutarQuery();
        }

        public void ModificarCiudad(Ciudad ciudad)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}