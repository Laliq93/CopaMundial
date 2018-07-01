using System;
using System.Collections.Generic;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Usuarios
{
    public class ComandoObtenerUsuarioDatos : Comando
    {
        public ComandoObtenerUsuarioDatos(Entidad usuario)
        {
            Entidad = usuario;
        }

        public override void Ejecutar()
        {
            IDAOUsuario dao = FabricaDAO.CrearDAOUsuario();
            dao.GetUsuario(Entidad);
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