using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Comun.Excepciones;
using CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Fuente_de_Datos.DAO
{
    public class DAOAlineacion : DAO, IDAOAlineacion
    {
        public void Actualizar(Entidad entidad)
        {
            if (!(entidad is Alineacion alineacion))
            {
                throw new CasteoInvalidoException();
            }

            Conectar();

            StoredProcedure("ModificarAlineacion(@_idalineacion, @_capitan, @_posicion, @_titular, " +
                                                "@_jugador @_equipo, @_partido)");

            AgregarParametro("_idalineacion", alineacion.Id);
            AgregarParametro("_capitan", alineacion.EsCapitan);
            AgregarParametro("_posicion", alineacion.Posicion);
            AgregarParametro("_titular", alineacion.EsTitular);
            AgregarParametro("_jugador", alineacion.Jugador.Id);
            AgregarParametro("_equipo", alineacion.Equipo.Id);
            AgregarParametro("_partido", alineacion.Partido.Id);

            EjecutarQuery();
        }

        public void Agregar(Entidad entidad)
        {
            if (!(entidad is Alineacion alineacion))
            {
                throw new CasteoInvalidoException();
            }

            Conectar();

            StoredProcedure("AgregarAlineacion(@_capitan, @_posicion, @_titular, " +
                                                "@_jugador @_equipo, @_partido)");

            AgregarParametro("_capitan", alineacion.EsCapitan);
            AgregarParametro("_posicion", alineacion.Posicion);
            AgregarParametro("_titular", alineacion.EsTitular);
            AgregarParametro("_jugador", alineacion.Jugador.Id);
            AgregarParametro("_equipo", alineacion.Equipo.Id);
            AgregarParametro("_partido", alineacion.Partido.Id);

            EjecutarQuery();
        }

        public List<Entidad> ConsultarPorPartido(Entidad entidad)
        {
            if (!(entidad is Alineacion alineacion))
            {
                throw new CasteoInvalidoException();
            }

            Conectar();
            StoredProcedure("ConsultarPorPartido(@_idalineacion)");
            AgregarParametro("_idalineacion", alineacion.Id);
            EjecutarReader();

            return ConstruirListaEntidades();
        }

        public void Eliminar(Entidad entidad)
        {
            if (!(entidad is Alineacion alineacion))
            {
                throw new CasteoInvalidoException();
            }

            Conectar();
            StoredProcedure("EliminarAlineacion(@_idalineacion)");
            AgregarParametro("_idalineacion", alineacion.Id);
            EjecutarQuery();
        }

        public List<Entidad> ObtenerTodos()
        {
            throw new NotImplementedException();
        }

        private List<Entidad> ConstruirListaEntidades()
        {
            List<Entidad> _partidos = new List<Entidad>();

            if (cantidadRegistros == 0)
            {
                throw new AlineacionNoExisteException();
            }

            for (int i = 0; i < cantidadRegistros; i++)
            {
                _partidos.Add(this.ConstruirEntidad(i));
            }

            return _partidos;
        }

        private Entidad ConstruirEntidad(int i = 0)
        {
            Jugador jugador = FabricaEntidades.CrearJugador();
            jugador.Id = GetInt(i, 4);

            Equipo equipo = FabricaEntidades.CrearEquipo();
            equipo.Id = GetInt(i, 5);

            Partido partido = FabricaEntidades.CrearPartido();
            partido.Id = GetInt(i, 6);

            Alineacion alineacion = FabricaEntidades.CrearAlineacion(GetInt(i, 0), GetBool(i, 1), GetString(i, 2),
                                                                     GetBool(i, 3), jugador, equipo, partido);

            return partido;
        }

    }
}