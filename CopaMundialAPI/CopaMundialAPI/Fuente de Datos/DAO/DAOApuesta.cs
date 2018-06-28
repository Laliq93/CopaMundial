using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Comun.Excepciones;

namespace CopaMundialAPI.Fuente_de_Datos.DAO
{
    public class DAOApuesta : DAO
    {
        public List<Entidad> ObtenerProximosPartidos()
        {
            Equipos equiposEstaticos = new Equipos();

            List<Entidad> partidos = new List<Entidad>();

            Partido partido;

            Conectar();

            StoredProcedure("obtenerproximospartidos(@fecha)");

            AgregarParametro("fecha", DateTime.Now);

            EjecutarReader();

            for(int i = 0; i < cantidadRegistros; i++)
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

    }
}