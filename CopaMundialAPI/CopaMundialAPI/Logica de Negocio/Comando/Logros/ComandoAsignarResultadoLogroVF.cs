using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;
using System;
using System.Collections.Generic;


namespace CopaMundialAPI.Logica_de_Negocio.Comando.Logros
{
    public class ComandoAsignarResultadoLogroVF: Comando
    {
        private Entidad _logroVF;

        public ComandoAsignarResultadoLogroVF(Entidad logroVF)
        {
            _logroVF = logroVF;
        }

        public override void Ejecutar()
        {
            DAOLogroVF dao = FabricaDAO.CrearDAOLogroVF();

            dao.AsignarResultadoLogro(_logroVF);
        }

        public override Entidad GetEntidad()
        {
            return _logroVF;
        }

        public override List<Entidad> GetEntidades()
        {
            throw new NotImplementedException();
        }
    }
}