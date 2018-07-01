using System;
using System.Collections.Generic;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;
using CopaMundialAPI.Comun.Excepciones;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Usuarios
{
    public class ComandoVerificarClaveUsuario: Comando
    {
        DAOUsuario _daoUsuario;

        public ComandoVerificarClaveUsuario(Entidad usuario)
        {
            Entidad = usuario;
            _daoUsuario = FabricaDAO.CrearDAOUsuario();
        }

        public override void Ejecutar()
        {
            int ucount = _daoUsuario.VerificarClaveUsuario(Entidad);

            if (ucount < 1)
                throw new ClaveNoCoincideException();
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