using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;
using CopaMundialAPI.Fuente_de_Datos.DAO;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Apuestas
{
    public class ComandoObtenerLogrosEquipoPartido : Comando
    {
        private Entidad _partido;
        private List<Entidad> _logrosequipo;
        private DAOApuesta _dao;

        public ComandoObtenerLogrosEquipoPartido(Entidad entidad)
        {
            _partido = entidad;
            _logrosequipo = new List<Entidad>();
            _dao = FabricaDAO.CrearDAOApuesta();
        }

        public override void Ejecutar()
        {
            _logrosequipo = _dao.ObtenerLogrosEquipoPartido(_partido);
        }

        public override Entidad GetEntidad()
        {
            throw new NotImplementedException();
        }

        public override List<Entidad> GetEntidades()
        {
            return _logrosequipo;
        }
    }
}