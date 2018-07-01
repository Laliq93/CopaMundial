using System;
using System.Collections.Generic;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Comun.Excepciones;
using Npgsql;

namespace CopaMundialAPI.Fuente_de_Datos.DAO
{
    public class DAOLogroPartido: DAO
    {
        /// <summary>
        /// Metodo que obtiene los proximos partidos 
        /// a partir de la fecha actual
        /// </summary>
        /// <returns></returns>
        public List<Entidad> ObtenerProximosLogroPartidos()
        {
            try
            {
                Equipos equiposEstaticos = new Equipos();

                List<Entidad> partidos = new List<Entidad>();

                Partido partido;

                Conectar();

                StoredProcedure("ConsultarProximosLogroPartido(@fecha)");

                AgregarParametro("fecha", DateTime.Now);

                EjecutarReader();

                for (int i = 0; i < cantidadRegistros; i++)
                {
                    partido = new Partido();
                    int idequipo1, idequipo2;

                    partido.Id = GetInt(i, 0);
                    partido.FechaInicioPartido = GetDateTime(i, 1);
                    idequipo1 = GetInt(i, 2);
                    idequipo2 = GetInt(i, 3);
                    partido.Equipo1 = equiposEstaticos.GetEquipo(idequipo1);
                    partido.Equipo2 = equiposEstaticos.GetEquipo(idequipo2);

                    partidos.Add(partido);
                }

                return partidos;
            }
            catch (NpgsqlException exc)
            {
                Desconectar();
                throw new BaseDeDatosException(exc, "Error al obtener proximos logros partidos");
            }
            finally
            {
                Desconectar();
            }
        }

        /// <summary>
        /// Metodo que obtiene los proximos partidos 
        /// a partir de la fecha actual
        /// </summary>
        /// <returns></returns>
        public List<Entidad> ObtenerLogroPartidosFinalizados()
        {
            try
            {
                Equipos equiposEstaticos = new Equipos();

                List<Entidad> partidos = new List<Entidad>();

                Partido partido;

                Conectar();

                StoredProcedure("ConsultarLogroPartidoFinalizados(@fecha)");

                AgregarParametro("fecha", DateTime.Now);

                EjecutarReader();

                for (int i = 0; i < cantidadRegistros; i++)
                {
                    partido = new Partido();
                    int idequipo1, idequipo2;

                    partido.Id = GetInt(i, 0);
                    partido.FechaInicioPartido = GetDateTime(i, 1);
                    idequipo1 = GetInt(i, 2);
                    idequipo2 = GetInt(i, 3);
                    partido.Equipo1 = equiposEstaticos.GetEquipo(idequipo1);
                    partido.Equipo2 = equiposEstaticos.GetEquipo(idequipo2);

                    partidos.Add(partido);
                }

                return partidos;
            }
            catch (NpgsqlException exc)
            {
                Desconectar();
                throw new BaseDeDatosException(exc, "Error al obtener proximos logros partidos");
            }
        }


        /// <summary>
        /// Metodo para obtener un partido por su id
        /// </summary>
        /// <exception cref="PartidoNoExisteException"></exception>
        /// <param name="entidad"></param>
        /// <returns></returns>
        public Entidad ObtenerLogroPartidoPorId(Entidad entidad)
        {
            Partido partido = entidad as Partido;
            Equipos equiposEstaticos = new Equipos();
            Conectar();
            StoredProcedure("ConsultarLogroPartidoPorId(@idPartido)");
            AgregarParametro("idPartido", partido.Id);
            EjecutarReader();
            for (int i = 0; i < cantidadRegistros; i++)
            {
                int idequipo1, idequipo2;
                partido.Id = GetInt(i, 0);
                partido.FechaInicioPartido = GetDateTime(i, 1);
                idequipo1 = GetInt(i, 2);
                idequipo2 = GetInt(i, 3);
                partido.Equipo1 = equiposEstaticos.GetEquipo(idequipo1);
                partido.Equipo2 = equiposEstaticos.GetEquipo(idequipo2);

            }
           if (partido == null)
                throw new PartidoNoExisteException("Partido no existe");
            return partido;
        }


    }
}