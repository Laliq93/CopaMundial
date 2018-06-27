using System;
using System.Collections.Generic;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Logros
{
    public class ComandoObtenerLogrosJugadorPendientes: Comando
    {

        private Entidad _partido;
        private List<Entidad> _logrosJugador;
        private DAOLogroJugador _dao;

        public ComandoObtenerLogrosJugadorPendientes(Entidad partido)
        {
            _partido = partido;
            _logrosJugador = new List<Entidad>();

        }

        public override void Ejecutar()
        {
            _dao = FabricaDAO.CrearDAOLogroJugador();

            _logrosJugador = _dao.ObtenerLogrosPendientes(_partido);
        }

        public override Entidad GetEntidad()
        {
            throw new NotImplementedException(); ;
        }

        public override List<Entidad> GetEntidades()
        {
            return _logrosJugador;
        }
    }
}