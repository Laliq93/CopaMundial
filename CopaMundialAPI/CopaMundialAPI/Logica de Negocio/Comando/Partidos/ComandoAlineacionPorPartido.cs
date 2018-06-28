using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Excepciones;
using CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Partidos
{
    public class ComandoAlineacionPorPartido : Comando
    {
        private List<Entidad> _alineaciones;

        public ComandoAlineacionPorPartido(Alineacion entidad)
        {
            Entidad = entidad;
        }

        public override void Ejecutar()
        {
            IDAOAlineacion dao = FabricaDAO.CrearDAOAlineacion();

            _alineaciones = dao.ConsultarPorPartido(Entidad);
        }

        private void CompletarLista()
        {
            IDAOJugador daoJugador = FabricaDAO.CrearDAOJugador();
            foreach(Alineacion alineacion in _alineaciones)
            {
                if (!(daoJugador.ObtenerJugadorId(alineacion.Jugador) is Jugador _jugador))
                {
                    throw new CasteoInvalidoException();
                }

                alineacion.Jugador = _jugador;
            }
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