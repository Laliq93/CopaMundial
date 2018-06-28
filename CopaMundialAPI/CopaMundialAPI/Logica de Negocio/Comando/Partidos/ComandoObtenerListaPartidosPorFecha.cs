using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Partidos
{
    public class ComandoObtenerListaPartidosPorFecha: Comando
    {
        private DateTime _fecha;
        private List<Entidad> _partidos;

        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public List<Entidad> Partidos { get => _partidos; set => _partidos = value; }

        public ComandoObtenerListaPartidosPorFecha(DateTime fecha)
        {
            Fecha = fecha;
        }

        public override void Ejecutar()
        {
            IDAOPartido dao = FabricaDAO.CrearDAOPartido();
            this.Partidos = dao.ObtenerPartidosPosterioresA(Fecha);
        }

        private void CompletarLista()
        {
            Estadios estadios = new Estadios();
            Equipos equipos = new Equipos();

            foreach(Partido partido in Partidos)
            {
                partido.Estadio = estadios.GetEstadio(partido.Estadio.Id);
                partido.Equipo1 = equipos.GetEquipo(partido.Equipo1.Id);
                partido.Equipo2 = equipos.GetEquipo(partido.Equipo2.Id);
            }
        }

        public override Entidad GetEntidad()
        {
            throw new NotImplementedException();
        }

        public override List<Entidad> GetEntidades()
        {
            return Partidos;
        }
    }
}