using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Fuente_de_Datos.DAO
{
    public class DAOPartido : DAO, IDAOPartido
    {
        public void Actualizar(Entidad entidad)
        {
            Partido partido = entidad as Partido;

            Conectar();

            StoredProcedure("modificarpartido(@_idpartido,@_horainicio,@_horafin,@_arbitro,@_estatus,@_equipo1,@_equipo2,@_estadio)");

            //AgregarParametro("_idpartido", partido.Id);
            AgregarParametro("_horainicio", partido.FechaInicioPartido);
            AgregarParametro("_horafin", partido.FechaFinPartido);
            AgregarParametro("_arbitro", partido.Arbitro);
            AgregarParametro("_estatus", partido.Estatus);
            AgregarParametro("_equipo1", partido.Equipo1);
            AgregarParametro("_equipo2", partido.Equipo2);
            AgregarParametro("_estadio", partido.Estadio);
       
            EjecutarQuery ( );
        }

        public void Agregar(Entidad entidad)
        {
                
            Partido partido = entidad as Partido;

            Conectar();

            StoredProcedure("agregarpartido(@_horainicio,@_horafin,@_arbitro,@_equipo1,@_equipo2,@_estadio)");

            AgregarParametro("_horainicio", partido.FechaInicioPartido);
            AgregarParametro("_horafin", partido.FechaFinPartido);
            AgregarParametro("_arbitro", partido.Arbitro);
            AgregarParametro("_equipo1", partido.Equipo1);
            AgregarParametro("_equipo2", partido.Equipo2);
            AgregarParametro("_estadio", partido.Estadio);

            EjecutarQuery ( );

        }

        public void Eliminar(Entidad entidad)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ObtenerProximosPartidos()
        {
            Equipos = equiposEstaticos = new Equipos();

            List<Entidad> _partidos = new List<Entidad>();

            Partido partido;

            Conectar();

            StoredProcedure("consultarpartidossiguientes()");

            EjecutarReader();

            for (int i = 0; i < cantidadRegistros; i++)
            {
                partido = FabricaEntidades.CrearPartido();

                int idEquipo1, idEquipo2;

                partido.FechaInicioPartido = GetDateTime(i, 1);
                partido.FechaFinPartido = GetDateTime(i, 2);
                partido.Arbitro = GetString(i, 3);
                idEquipo1 = GetInt(i, 4);
                idEquipo2 = GetInt(i, 5);
                partido.Estadio = GetInt(i, 6);
                partido.Equipo1 = equiposEstaticos.GetEquipo(idEquipo1);
                partido.Equipo2 = equiposEstaticos.GetEquipo(idEquipo2);

                _partidosAdd(partido);
            }

            return _partidos;
        }
    }
}