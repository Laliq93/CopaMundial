using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;


namespace CopaMundialAPI.Logica_de_Negocio.Comando.Apuestas
{
    public class ComandoObtenerApuestasVoFEnCurso : Comando
    {
        private List<Entidad> _apuestas;

        public ComandoObtenerApuestasVoFEnCurso(Entidad usuario)
        {
            Entidad = usuario;
            _apuestas = new List<Entidad>();
        }

        public override void Ejecutar()
        {
            DAOApuestaVoF dao = FabricaDAO.CrearDAOApuestaVoF();

            _apuestas = dao.ObtenerApuestasEnCurso(Entidad);
            
        }

        public override Entidad GetEntidad()
        {
            throw new NotImplementedException();
        }

        public override List<Entidad> GetEntidades()
        {
            return _apuestas;
        }
    }
}