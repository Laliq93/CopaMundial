using System;
using System.Collections.Generic;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;
using CopaMundialAPI.Logica_de_Negocio.Fabrica;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Apuestas
{
    public class ComandoAgregarUsuarioAdministrador : Comando
    {
        private Comando _comando;

        public ComandoAgregarUsuarioAdministrador(Entidad usuario)
        {
            Entidad = usuario;
        }

        public override void Ejecutar()
        {

            _comando = FabricaComando.CrearComandoVerificarCorreoExiste(Entidad);

            _comando.Ejecutar();

            DAOUsuario _dao = FabricaDAO.CrearDAOUsuario();

            _dao.Agregar(Entidad);
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