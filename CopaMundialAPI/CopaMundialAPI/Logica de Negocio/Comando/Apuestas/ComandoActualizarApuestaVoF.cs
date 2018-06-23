using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;


namespace CopaMundialAPI.Logica_de_Negocio.Comando.Apuestas
{
    public class ComandoActualizarApuestaVoF : Comando
    {
        private Entidad _apuesta;

        public ComandoActualizarApuestaVoF(Entidad apuesta)
        {
            _apuesta = apuesta;
        }

        public override void Ejecutar()
        {
            DAOApuestaVoF dao = FabricaDAO.CrearDAOApuestaVoF();

            dao.Actualizar(_apuesta);
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