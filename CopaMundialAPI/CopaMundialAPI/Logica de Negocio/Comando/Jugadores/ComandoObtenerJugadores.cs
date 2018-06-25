using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;

namespace CopaMundialAPI.Logica_de_Negocio.Comando
{
    public class ComandoObtenerJugadores : Comando
    {

        private List<Entidad> _jugadores;

        public ComandoObtenerJugadores()
        {
            _jugadores = new List<Entidad>();
        }

        public override void Ejecutar()
        {
            DAOJugador dao = FabricaDAO.CrearDAOJugador();
            _jugadores = dao.ObtenerJugadores();
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