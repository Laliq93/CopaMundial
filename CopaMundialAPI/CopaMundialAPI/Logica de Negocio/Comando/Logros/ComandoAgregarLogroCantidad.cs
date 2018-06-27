using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Logros
{
    public class ComandoAgregarLogroCantidad: Comando
    {
        private Entidad _logroCantidad;

        public ComandoAgregarLogroCantidad(Entidad logroCantidad)
        {
            _logroCantidad = logroCantidad;
        }

        public override void Ejecutar()
        {
            DAOLogroCantidad dao = FabricaDAO.CrearDAOLogroCantidad();

            dao.Agregar(_logroCantidad);
        }

        public override Entidad GetEntidad()
        {
            return _logroCantidad;
        }

        public override List<Entidad> GetEntidades()
        {
            throw new NotImplementedException();
        }
    }
}
