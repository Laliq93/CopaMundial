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
            throw new NotImplementedException ( );
        }

        public void Agregar ( Entidad entidad )
        {

            Ciudad ciudad = entidad as Ciudad;

            Conectar();

            StoredProcedure("insertarciudad(@ci_nombre,@ci_poblacion,@_descripcion)");

            AgregarParametro("_nombre", ciudad.Nombre);
            AgregarParametro("_capacidad", ciudad.Habitantes);
            AgregarParametro("_descripcion", ciudad.Descripcion);


            EjecutarQuery ( );
        }

        public Ciudad ConsultarCiudadPorId ( Ciudad ciudad )
        {
			
			Conectar();
			StoredProcedure("obtenerciudad(@id)");
			AgregarParametro("id", ciudad.Id);
			EjecutarReader();
			for (int i = 0; i < cantidadRegistros; i++)
			{
				ciudad = FabricaEntidades.CrearCiudad(GetString(i,0),GetInt(i,1),GetString(i,2),GetString(i,3),GetString(i,4));
			}
			return ciudad;
			/*for (int i = 0; i < cantidadRegistros; i++)
			{
				Jugador jugador = FabricaEntidades.CrearJugador();

				jugador.Id = GetInt(i, 0);
				jugador.Nombre = GetString(i, 1);
				jugador.Apellido = GetString(i, 2);
				jugador.FechaNacimiento = GetString(i, 3);
				jugador.LugarNacimiento = GetString(i, 4);
				jugador.Peso = GetDouble(i, 5);
				jugador.Altura = GetDouble(i, 6);
				jugador.Posicion = GetString(i, 7);
				jugador.Numero = GetInt(i, 8);
				jugador.Equipo = GetString(i, 9);
				jugador.Capitan = GetBool(i, 10);

				jugadores.Add(jugador);

			}*/
		}

        public void Eliminar ( Entidad entidad )
        {

            throw new NotImplementedException ( );

        }

        public List<Entidad> ObtenerTodos ( )
        {
            throw new NotImplementedException ( );
        }

    }
}