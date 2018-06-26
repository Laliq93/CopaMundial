using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Logros
{
    public class ComandoAgregarLogroEquipo: Comando
    {


        private Entidad _logroEquipo;

        public ComandoAgregarLogroEquipo(Entidad logroEquipo)
        {
            _logroEquipo = logroEquipo;
        }

        public override void Ejecutar()
        {
            DAOLogroEquipo dao = FabricaDAO.CrearDAOLogroEquipo();

            dao.Agregar(_logroEquipo);
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