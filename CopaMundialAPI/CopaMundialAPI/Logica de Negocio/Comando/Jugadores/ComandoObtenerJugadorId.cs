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

        public ComandoObtenerJugadorId(Entidad jugador)
        {
            Entidad = jugador;
        }

        public override void Ejecutar()
        {
            DAOJugador dao = FabricaDAO.CrearDAOJugador();
            Entidad = dao.ObtenerJugadorId(Entidad);
        }

        public override Entidad GetEntidad()
        {
            return Entidad;
        }

        public override List<Entidad> GetEntidades()
        {
            throw new NotImplementedException();
        }
    }
}