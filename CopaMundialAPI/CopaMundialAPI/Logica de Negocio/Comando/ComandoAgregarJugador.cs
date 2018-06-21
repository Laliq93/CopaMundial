using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;
using CopaMundialAPI.Fuente_de_Datos.DAO;

namespace CopaMundialAPI.Logica_de_Negocio.Comando
{
    public class ComandoAgregarJugador : Comando
    {
        private Jugador _jugador;

        public ComandoAgregarJugador(Jugador jugador)
        {
            _jugador = jugador;
        }

        public override void Ejecutar()
        {
            DAOJugador dao = FabricaDAO.CrearDAOJugador();
            dao.AgregarJugador(_jugador);
            
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