using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;


namespace CopaMundialAPI.Logica_de_Negocio.Comando
{
    public class ComandoActualizarApuestaVoF : Comando<ApuestaVoF>
    {
        private ApuestaVoF _apuesta;

        public ComandoActualizarApuestaVoF(ApuestaVoF apuesta)
        {
            _apuesta = apuesta;
        }

        public override void Ejecutar()
        {
            DAOApuestaVoF dao = FabricaDAO.CrearDAOApuestaVoF();

            dao.Actualizar(_apuesta);
        }

        public override ApuestaVoF GetEntidad()
        {
            throw new NotImplementedException();
        }

        public override List<ApuestaVoF> GetEntidades()
        {
            throw new NotImplementedException();
        }
    }
}