using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;


namespace CopaMundialAPI.Logica_de_Negocio.Comando.Apuestas
{
    public class ComandoObtenerApuestasCantidadEnCurso : Comando
    {
        private Entidad _usuario;
        private List<Entidad> _apuestas;

        public ComandoObtenerApuestasCantidadEnCurso(Entidad usuario)
        {
            _usuario = usuario;
            _apuestas = new List<Entidad>();
        }

        public override void Ejecutar()
        {
            DAOApuestaCantidad dao = FabricaDAO.CrearDAOApuestaCantidad();

            _apuestas = dao.ObtenerApuestasEnCurso(_usuario);
            
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