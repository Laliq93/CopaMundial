using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;

namespace CopaMundialAPI.Logica_de_Negocio.Comando
{
    public class ComandoObtenerApuestas : Comando<Apuesta>
    {
        private Entidad _usuario;
        private DAOApuesta _dao;
        private List<Apuesta> _apuestasUsuario;  
        
        public ComandoObtenerApuestas(Entidad usuario)
        {
            _usuario = usuario;
            _dao = FabricaDAO.CrearDAOApuesta();
        }
        public override void Ejecutar()
        {
            _apuestasUsuario = _dao.ObtenerApuestasUsuario(_usuario);
        }

        public override Apuesta GetEntidad()
        {
            throw new NotImplementedException();
        }

        public override List<Apuesta> GetEntidades()
        {           
           return _apuestasUsuario;
        }
    }
}