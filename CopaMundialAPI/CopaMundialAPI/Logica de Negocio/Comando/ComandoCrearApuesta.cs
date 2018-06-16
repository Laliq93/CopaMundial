using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;

namespace CopaMundialAPI.Logica_de_Negocio.Comando
{
    public class ComandoCrearApuesta : Comando<Apuesta>
    {
        private DAOApuesta _dao;

        private Apuesta _apuesta;

        public ComandoCrearApuesta(Apuesta apuesta)
        {
            _apuesta = apuesta;
            _dao = FabricaDAO.CrearDAOApuesta();
        }

        public override void Ejecutar()
        {
            _dao.AgregarApuesta(_apuesta);
        }

        public override Apuesta GetEntidad()
        {
            throw new NotImplementedException();
        }

        public override List<Apuesta> GetEntidades()
        {
            throw new NotImplementedException();
        }
    }
}