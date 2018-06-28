using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;


namespace CopaMundialAPI.Logica_de_Negocio.Comando.Apuestas
{
    public class ComandoEliminarApuestaCantidad : Comando
    {
        private Entidad _apuesta;

        public ComandoEliminarApuestaCantidad(Entidad apuesta)
        {
            _apuesta = apuesta;
        }

        public override void Ejecutar()
        {
            DAOApuestaCantidad dao = FabricaDAO.CrearDAOApuestaCantidad();

            dao.Eliminar(_apuesta);
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