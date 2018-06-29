using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;
using CopaMundialAPI.Logica_de_Negocio.Fabrica;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Apuestas
{
    public class ComandoAgregarApuestaJugador : Comando
    {
        private Entidad _apuesta;
        private Comando _comando;

        public ComandoAgregarApuestaJugador(Entidad apuesta)
        {
            _apuesta = apuesta;
        }

        public override void Ejecutar()
        {
            _comando = FabricaComando.CrearComandoVerificaApuestaJugadorExiste(_apuesta);

            _comando.Ejecutar();

            DAOApuestaJugador dao = FabricaDAO.CrearDAOApuestaJugador();

            dao.Agregar(_apuesta);
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