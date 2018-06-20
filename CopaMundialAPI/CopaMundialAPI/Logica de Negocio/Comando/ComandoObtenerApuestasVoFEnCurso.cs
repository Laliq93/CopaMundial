using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;


namespace CopaMundialAPI.Logica_de_Negocio.Comando
{
    public class ComandoObtenerApuestasVoFEnCurso : Comando<ApuestaVoF>
    {
        private Usuario _usuario;
        private List<ApuestaVoF> _apuestas;

        public ComandoObtenerApuestasVoFEnCurso(Usuario usuario)
        {
            _usuario = usuario;
            _apuestas = new List<ApuestaVoF>();
        }

        public override void Ejecutar()
        {
            DAOApuestaVoF dao = FabricaDAO.CrearDAOApuestaVoF();

            _apuestas = dao.ObtenerApuestasEnCurso(_usuario).OfType<ApuestaVoF>().ToList();
            
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