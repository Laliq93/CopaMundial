using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Logros
{
    public class ComandoAgregarLogroJugador: Comando
    {

        private Entidad _logroJugador;

        public ComandoAgregarLogroJugador(Entidad logroJugador)
        {
            _logroJugador = logroJugador;
        }

        public override void Ejecutar()
        {
            DAOLogroJugador dao = FabricaDAO.CrearDAOLogroJugador();

            dao.Agregar(_logroJugador);
        }

        public override Entidad GetEntidad()
        {
            return _logroJugador;
        }

        public override List<Entidad> GetEntidades()
        {
            throw new NotImplementedException();
        }
    }
}