using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Logros
{
    public class ComandoObtenerLogrosVFPendientes: Comando
    {


        private Entidad _partido;
        private List<Entidad> _logrosVF;
        private DAOLogroVF _dao;

        public ComandoObtenerLogrosVFPendientes(Entidad partido)
        {
            _partido = partido;
            _logrosVF = new List<Entidad>();

        }

        public override void Ejecutar()
        {
            _dao = FabricaDAO.CrearDAOLogroVF();

            _logrosVF = _dao.ObtenerLogrosPendientes(_partido);
        }

        public override Entidad GetEntidad()
        {
            throw new NotImplementedException(); ;
        }

        public override List<Entidad> GetEntidades()
        {
            return _logrosVF;
        }
    }
}