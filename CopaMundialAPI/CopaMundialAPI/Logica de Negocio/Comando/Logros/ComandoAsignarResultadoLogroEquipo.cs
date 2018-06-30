using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;
using System;
using System.Collections.Generic;


namespace CopaMundialAPI.Logica_de_Negocio.Comando.Logros
{
    public class ComandoAsignarResultadoLogroEquipo: Comando
    {

        private Entidad _logroEquipo;

        public ComandoAsignarResultadoLogroEquipo(Entidad logroEquipo)
        {
            _logroEquipo = logroEquipo;
        }

        public override void Ejecutar()
        {
            DAOLogroEquipo dao = FabricaDAO.CrearDAOLogroEquipo();

            dao.AsignarResultadoLogro(_logroEquipo);
        }

        public override Entidad GetEntidad()
        {
            return _logroEquipo;
        }

        public override List<Entidad> GetEntidades()
        {
            throw new NotImplementedException();
        }

    }
}