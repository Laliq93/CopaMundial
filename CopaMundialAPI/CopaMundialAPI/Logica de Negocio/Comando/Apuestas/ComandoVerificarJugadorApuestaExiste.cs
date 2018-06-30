using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Excepciones;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Apuestas
{
    public class ComandoVerificarApuestaJugadorExiste : Comando
    {
        DAOApuestaJugador _dao;

        public ComandoVerificarApuestaJugadorExiste(Entidad apuesta)
        {
            Entidad = apuesta;
            _dao = FabricaDAO.CrearDAOApuestaJugador();
        }

        public override void Ejecutar()
        {
            int count = _dao.VerificarApuestaExiste(Entidad);

            if (count > 0)
                throw new ApuestaRepetidaException();
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