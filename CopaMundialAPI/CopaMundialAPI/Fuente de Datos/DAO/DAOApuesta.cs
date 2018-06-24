using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;

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

            StoredProcedure("obtenerproximospartidos()");

            EjecutarReader();

            for(int i = 0; i < cantidadRegistros; i++)
            {
                partido = new Partido();
                int idequipo1, idequipo2;

                partido.Id = GetInt(i, 0);
                partido.FechaPartido = GetDateTime(i, 1);
                idequipo1 = GetInt(i, 2);
                idequipo2 = GetInt(i, 3);
                partido.Equipo1 = equiposEstaticos.GetEquipo(idequipo1);
                partido.Equipo2 = equiposEstaticos.GetEquipo(idequipo2);

                partidos.Add(partido);
            }

            return partidos;
        }

        public List<Entidad> ObtenerLogrosVofPartido(Entidad entidad)
        {
            List<Entidad> logrosvof = new List<Entidad>();
            LogroVoF logro;

            StoredProcedure("obtenerlogrosvofpartidos(@idpartido)");

            AgregarParametro("idpartido", entidad.Id);

            EjecutarReader();

            for(int i = 0; i < cantidadRegistros; i++)
            {
                logro = FabricaEntidades.CrearLogroVoF();

                logro.Id = GetInt(i, 0);
                logro.Logro = GetString(i, 1);
                logro.IdTipo = TipoLogro.vof;

                logrosvof.Add(logro);
            }

            return logrosvof;
        }
    }
}