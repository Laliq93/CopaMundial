using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;


namespace CopaMundialAPI.Logica_de_Negocio.Comando.Apuestas
{
    public class ComandoObtenerApuestasEquipoFinalizadas : Comando
    {
        private Entidad _usuario;
        private List<Entidad> _apuestas;

        public ComandoObtenerApuestasEquipoFinalizadas(Entidad usuario)
        {
            _usuario = usuario;
            _apuestas = new List<Entidad>();
        }

        public override void Ejecutar()
        {
            DAOApuestaEquipo dao = FabricaDAO.CrearDAOApuestaEquipo();

            _apuestas = dao.ObtenerApuestasFinalizadas(_usuario);
            
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