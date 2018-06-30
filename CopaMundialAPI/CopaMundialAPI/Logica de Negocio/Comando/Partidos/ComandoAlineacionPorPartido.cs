using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Excepciones;
using CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;
using CopaMundialAPI.Logica_de_Negocio.Fabrica;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Partidos
{
    public class ComandoAlineacionPorPartido : Comando
    {
        private List<Entidad> _alineaciones;

        public ComandoAlineacionPorPartido(Entidad entidad)
        {
            Entidad = entidad;
        }

        public override void Ejecutar()
        {
            IDAOAlineacion dao = FabricaDAO.CrearDAOAlineacion();

            _alineaciones = dao.ConsultarPorPartido(Entidad);

            CompletarLista();
        }

        private void CompletarLista()
        {
            foreach(Alineacion alineacion in _alineaciones)
            {
                Comando comandoJugador = FabricaComando.CrearComandoObtenerJugadorId(alineacion.Jugador);
                comandoJugador.Ejecutar();
                
                alineacion.Jugador = comandoJugador.GetEntidad() as Jugador;
            }
        }

        public override Entidad GetEntidad()
        {
            throw new NotImplementedException();
        }

        public override List<Entidad> GetEntidades()
        {
            return _alineaciones;
        }
    }
}