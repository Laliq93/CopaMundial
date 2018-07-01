using System;
using System.Collections.Generic;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Usuarios
{
    public class ComandoObtenerUsuarioDatos : Comando
    {
        private Usuario _usuarioDatos;

        public ComandoObtenerUsuarioDatos(Entidad usuario)
        {
            Entidad = usuario;
        }

        public override void Ejecutar()
        {
            IDAOUsuario dao = FabricaDAO.CrearDAOUsuario();
            _usuarioDatos = dao.GetUsuario(Entidad);
        }

        public override Entidad GetEntidad()
        {
            return _usuarioDatos;
        }

        public override List<Entidad> GetEntidades()
        {
            throw new NotImplementedException();
        }

    }
}