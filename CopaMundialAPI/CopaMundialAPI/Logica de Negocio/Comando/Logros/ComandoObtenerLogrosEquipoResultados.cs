using System;
using System.Collections.Generic;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;
namespace CopaMundialAPI.Logica_de_Negocio.Comando.Logros
{
    public class ComandoObtenerLogrosEquipoResultados: Comando
    {

        private Entidad _partido;
        private List<Entidad> _logrosEquipo;
        private DAOLogroEquipo _dao;

        public ComandoObtenerLogrosEquipoResultados(Entidad partido)
        {
            _partido = partido;
            _logrosEquipo = new List<Entidad>();

        }

        public override void Ejecutar()
        {
            _dao = FabricaDAO.CrearDAOLogroEquipo();

            _logrosEquipo = _dao.ObtenerLogrosResultados(_partido);
        }

        public override Entidad GetEntidad()
        {
            throw new NotImplementedException(); ;
        }

        public override List<Entidad> GetEntidades()
        {
            return _logrosEquipo;
        }
    }
}