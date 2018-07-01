using System;
using System.Collections.Generic;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Usuarios
{
    public class ComandoObtenerUsuarioNoActivo : Comando
    {
        public ComandoObtenerUsuarioNoActivo(Entidad usuario)
        {
            Entidad = usuario;
        }

        public override void Ejecutar()
        {
            DAOUsuario dao = FabricaDAO.CrearDAOUsuario();
            dao.ObtenerUsuariosNoActivos(Entidad);
        }

        public override Entidad GetEntidad()
        {
            throw new NotImplementedException();
        }

        public override List<Entidad> GetEntidades()
        {
            throw new NotImplementedException();
        }

    }
}