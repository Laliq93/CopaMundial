using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Usuarios
{
    public class ComandoObtenerUsuarioNoActivo : Comando
    {
        private List<Entidad> _usuarios;
        private IDAOUsuario _dao;

        public ComandoObtenerUsuarioNoActivo()
        {
            _usuarios = new List<Entidad>();
            _dao = FabricaDAO.CrearDAOUsuario();
        }

        public override void Ejecutar()
        {
            _usuarios = _dao.ObtenerUsuariosNoActivos();
        }

        public override Entidad GetEntidad()
        {
            throw new NotImplementedException();
        }

        public override List<Entidad> GetEntidades()
        {
            return _usuarios;
        }

    }
}