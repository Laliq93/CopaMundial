using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;
using CopaMundialAPI.Fuente_de_Datos.DAO;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Apuestas
{
    public class ComandoObtenerProximosPartidos : Comando
    {

        private List<Entidad> _partidos;
        private DAOApuesta _dao;

        public ComandoObtenerProximosPartidos()
        {
            _partidos = new List<Entidad>();
            _dao = FabricaDAO.CrearDAOApuesta();
        }

        public override void Ejecutar()
        {
            _partidos = _dao.ObtenerProximosPartidos();
        }

        public override Entidad GetEntidad()
        {
            throw new NotImplementedException();
        }

        public override List<Entidad> GetEntidades()
        {
            return _partidos;
        }
    }
}