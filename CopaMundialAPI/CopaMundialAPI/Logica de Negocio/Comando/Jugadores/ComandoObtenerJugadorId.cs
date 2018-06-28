using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Jugadores
{
    public class ComandoObtenerJugadorId : Comando
    {
        private Entidad _jugador;

        public ComandoObtenerJugadorId(Entidad jugador)
        {
            Entidad = jugador;
        }

        public override void Ejecutar()
        {
            DAOJugador dao = FabricaDAO.CrearDAOJugador();
            _jugador = dao.ObtenerJugadorId(Entidad);
        }

        public override Entidad GetEntidad()
        {
            return _jugador;
        }

        public override List<Entidad> GetEntidades()
        {
            throw new NotImplementedException();
        }
    }
}