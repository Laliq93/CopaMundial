using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Ciudades
{
    public class ComandoListarCiudades : Comando
    {
        private List<Entidad> _ciudades;

        private IDAOCiudad _dao;

        public ComandoListarCiudades ( )
        {
            _ciudades = new List<Entidad> ( );
            _dao = FabricaDAO.CrearDAOCiudad ( ); 
        }

        public override void Ejecutar ( )
        {
            _ciudades = _dao.ObtenerTodos ( );
        }

        public override Entidad GetEntidad ( )
        {
            throw new NotImplementedException ( );
        }

        public override List<Entidad> GetEntidades ( )
        {
            return _ciudades;
        }
    }
}