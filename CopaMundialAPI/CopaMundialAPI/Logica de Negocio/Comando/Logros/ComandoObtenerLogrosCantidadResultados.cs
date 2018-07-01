using System;
using System.Collections.Generic;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Logros
{
    public class ComandoObtenerLogrosCantidadResultados: Comando
    {
        private Entidad _partido;
        private List<Entidad> _logrosCantidad;
        private DAOLogroCantidad _dao;

        public ComandoObtenerLogrosCantidadResultados(Entidad partido)
        {
            _partido = partido;
            _logrosCantidad = new List<Entidad>();

        }

        public override void Ejecutar()
        {
            _dao = FabricaDAO.CrearDAOLogroCantidad();

            _logrosCantidad = _dao .ObtenerLogrosResultados(_partido);
        }

        public override Entidad GetEntidad()
        {
            throw new NotImplementedException(); ;
        }

        public override List<Entidad> GetEntidades()
        {
            return _logrosCantidad;
        }
    }
}