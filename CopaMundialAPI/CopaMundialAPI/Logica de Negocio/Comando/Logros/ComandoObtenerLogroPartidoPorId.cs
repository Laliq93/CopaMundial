using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Logros
{
    public class ComandoObtenerLogroPartidoPorId: Comando
    {


        private Entidad _partido;
        private List<Entidad> _partidos;
        private DAOLogroPartido _dao;

        public ComandoObtenerLogroPartidoPorId(Entidad partido)
        {
            _partido = partido;
            _partidos = new List<Entidad>();

        }

        public override void Ejecutar()
        {
            _dao = FabricaDAO.CrearDAOLogroPartido();

            _partido = _dao.ObtenerLogroPartidoPorId(_partido);
        }

        public override Entidad GetEntidad()
        {
            return _partido;
        }

        public override List<Entidad> GetEntidades()
        {
            throw new NotImplementedException();
        }
    }
}