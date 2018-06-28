using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Comun.Excepciones;
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
            if (!(entidad is Partido partido))
            {
                throw new CasteoInvalidoException();
            }

            Conectar();

            StoredProcedure("modificarpartido(@_idpartido, @_fechaInicio, @_fechaFin, @_arbitro, @_equipo1, @_equipo2, @_estadio)");

            AgregarParametro("_idpartido", partido.Id);
            AgregarParametro("_fechaInicio", partido.FechaInicioPartido);
            AgregarParametro("_fechaFin", partido.FechaFinPartido);
            AgregarParametro("_arbitro", partido.Arbitro);
            AgregarParametro("_equipo1", partido.Equipo1.Id);
            AgregarParametro("_equipo2", partido.Equipo2.Id);
            AgregarParametro("_estadio", partido.Estadio.Id);
       
            EjecutarQuery ( );
        }

        public void Agregar(Entidad entidad)
        {
            if (!(entidad is Partido partido))
            {
                throw new CasteoInvalidoException();
            }

            Conectar();

            StoredProcedure("agregarpartido(@_fechaInicio, @_fechaFin, @_arbitro, @_equipo1, @_equipo2, @_estadio)");

            AgregarParametro("_fechaInicio", partido.FechaInicioPartido);
            AgregarParametro("_fechaFin", partido.FechaFinPartido);
            AgregarParametro("_arbitro", partido.Arbitro);
            AgregarParametro("_equipo1", partido.Equipo1.Id);
            AgregarParametro("_equipo2", partido.Equipo2.Id);
            AgregarParametro("_estadio", partido.Estadio.Id);

            EjecutarQuery ( );

        }

        public void Eliminar(Entidad entidad)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ObtenerTodos()
        {
            Conectar();
            StoredProcedure("ConsultarPartidos()");
            EjecutarReader();

            return ConstruirListaEntidades();
        }

        public List<Entidad> ObtenerPartidosPosterioresA(DateTime fecha)
        {
            Conectar();
            StoredProcedure("ConsultarPartidosSiguientes(@_fecha)");
            AgregarParametro("_fecha", fecha);
            EjecutarReader();

            return ConstruirListaEntidades();
        }

        public Entidad ObtenerPorId(Entidad entidad)
        {
            if (!(entidad is Partido partido))
            {
                throw new CasteoInvalidoException();
            }

            Conectar();
            StoredProcedure("ConsultarPartido(@_idpartido)");
            AgregarParametro("_idpartido", partido.Id);

            EjecutarReader();

            return ConstruirEntidad();
        }

        private List<Entidad> ConstruirListaEntidades()
        {
            if (cantidadRegistros == 0)
            {
                throw new PartidoNoExisteException();
            }

            List<Entidad> _partidos = new List<Entidad>();

            for (int i = 0; i < cantidadRegistros; i++)
            {
                _partidos.Add(this.ConstruirEntidad(i));
            }

            return _partidos;
        }

        private Entidad ConstruirEntidad(int i = 0)
        {
            Equipo equipo1 = FabricaEntidades.CrearEquipo();
            equipo1.Id = GetInt(i, 4);

            Equipo equipo2 = FabricaEntidades.CrearEquipo();
            equipo1.Id = GetInt(i, 5);

            Estadio estadio = FabricaEntidades.CrearEstadio();
            estadio.Id = GetInt(i, 6);

            Partido partido = FabricaEntidades.CrearPartido(GetInt(i, 0), GetDateTime(i, 1), GetDateTime(i, 2),
                                                            GetString(i, 3), equipo1, equipo2, estadio);

            return partido;
        }

    }
}