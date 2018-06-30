using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Jugadores
{
    public class ComandoObtenerJugadoresActivo : Comando
    {
        private List<Entidad> _jugadores;

        public ComandoObtenerJugadoresActivo()
        {
            _jugadores = new List<Entidad>();
        }

        public override void Ejecutar()
        {
            DAOJugador dao = FabricaDAO.CrearDAOJugador();
            _jugadores = dao.ObtenerJugadoresActivo();
        }

        public override Entidad GetEntidad()
        {
            throw new NotImplementedException();
        }

        public override List<Entidad> GetEntidades()
        {
            return _jugadores;
        }
    }
}