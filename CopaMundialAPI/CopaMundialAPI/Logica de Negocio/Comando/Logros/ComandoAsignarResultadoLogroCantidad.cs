using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Logros
{
    public class ComandoAsignarResultadoLogroCantidad: Comando
    {
        private Entidad _logroCantidad;

        public ComandoAsignarResultadoLogroCantidad(Entidad logroCantidad)
        {
            _logroCantidad = logroCantidad;
        }

        public override void Ejecutar()
        {
            DAOLogroCantidad dao = FabricaDAO.CrearDAOLogroCantidad();

            dao.AsignarResultadoLogro(_logroCantidad);
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