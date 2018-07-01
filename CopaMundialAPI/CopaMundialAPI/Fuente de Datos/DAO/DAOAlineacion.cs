using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Comun.Excepciones;
using CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces;
using NLog;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Fuente_de_Datos.DAO
{
    public class DAOAlineacion : DAO, IDAOAlineacion
    {
        Logger logger = LogManager.GetLogger("fileLogger");

        public void Actualizar(Entidad entidad)
        {
            if (!(entidad is Alineacion alineacion))
            {
                logger.Error("Casteo invalido de la entidad " + entidad.ToString() + " a Alineacion");
                throw new CasteoInvalidoException("La entidad no es del tipo alineación");
            }

            try
            {
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
            catch (NullReferenceException e)
            {
                logger.Error(e, "DAOAlineacion.Actualizar[" + entidad.ToString() + "] valor nulo");
                throw new DatosInvalidosException("La información enviada no tiene el formato correcto");
            }
            catch (NpgsqlException e)
            {
                logger.Error(e, "DAOAlineacion.Actualizar[" + entidad.ToString() + "] error bd");
                throw new DatabaseException("Error en la comunicación con la base de datos");
            }
            catch (Exception e)
            {
                logger.Error(e, "DAOAlineacion.Actualizar[" + entidad.ToString() + "]");
                throw new ExcepcionPersonalizada();
            }
            finally
            {
                Desconectar();
            }
            
        }

        public void Agregar(Entidad entidad)
        {
            if (!(entidad is Alineacion alineacion))
            {
                logger.Error("Casteo invalido de la entidad " + entidad.ToString() + " a Alineacion");
                throw new CasteoInvalidoException("La entidad no es del tipo alineación");
            }

            try
            {
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
            catch (NullReferenceException e)
            {
                logger.Error(e, "DAOAlineacion.Agregar[" + entidad.ToString() + "] valor nulo");
                throw new DatosInvalidosException("La información enviada no tiene el formato correcto");
            }
            catch (NpgsqlException e)
            {
                logger.Error(e, "DAOAlineacion.Agregar[" + entidad.ToString() + "] error bd");
                throw new DatabaseException("Error en la comunicación con la base de datos");
            }
            catch (Exception e)
            {
                logger.Error(e, "DAOAlineacion.Agregar[" + entidad.ToString() + "]");
                throw new ExcepcionPersonalizada();
            }
            finally
            {
                Desconectar();
            }
        }

        public List<Entidad> ConsultarPorPartido(Entidad entidad)
        {
            if (!(entidad is Alineacion alineacion))
            {
                logger.Error("Casteo invalido de la entidad " + entidad.ToString() + " a Alineacion");
                throw new CasteoInvalidoException("La entidad no es del tipo alineación");
            }

            try
            {
                Conectar();
                StoredProcedure("ConsultarPorPartido(@_idalineacion)");
                AgregarParametro("_idalineacion", alineacion.Id);
                EjecutarReader();
                return ConstruirListaEntidades();
            }
            catch (NullReferenceException e)
            {
                logger.Error(e, "DAOAlineacion.ConsultarPorPartido[" + entidad.ToString() + "] valor nulo");
                throw new DatosInvalidosException("La información enviada no tiene el formato correcto");
            }
            catch (NpgsqlException e)
            {
                logger.Error(e, "DAOAlineacion.ConsultarPorPartido[" + entidad.ToString() + "] error bd");
                throw new DatabaseException("Error en la comunicación con la base de datos");
            }
            catch (Exception e)
            {
                logger.Error(e, "DAOAlineacion.ConsultarPorPartido[" + entidad.ToString() + "]");
                throw new ExcepcionPersonalizada();
            }
            finally
            {
                Desconectar();
            }
                        
        }

        public void Eliminar(Entidad entidad)
        {
            if (!(entidad is Alineacion alineacion))
            {
                logger.Error("Casteo invalido de la entidad " + entidad.ToString() + " a Alineacion");
                throw new CasteoInvalidoException("La entidad no es del tipo alineación");
            }

            try
            {
                Conectar();
                StoredProcedure("EliminarAlineacion(@_idalineacion)");
                AgregarParametro("_idalineacion", alineacion.Id);
                EjecutarQuery();
            }
            catch (NullReferenceException e)
            {
                logger.Error(e, "DAOAlineacion.Eliminar[" + entidad.ToString() + "] valor nulo");
                throw new DatosInvalidosException("La información enviada no tiene el formato correcto");
            }
            catch (NpgsqlException e)
            {
                logger.Error(e, "DAOAlineacion.Eliminar[" + entidad.ToString() + "] error bd");
                throw new DatabaseException("Error en la comunicación con la base de datos");
            }
            catch (Exception e)
            {
                logger.Error(e, "DAOAlineacion.Eliminar[" + entidad.ToString() + "]");
                throw new ExcepcionPersonalizada();
            }
            finally
            {
                Desconectar();
            }
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
                throw new AlineacionNoExisteException("Alineación no encontrada");
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