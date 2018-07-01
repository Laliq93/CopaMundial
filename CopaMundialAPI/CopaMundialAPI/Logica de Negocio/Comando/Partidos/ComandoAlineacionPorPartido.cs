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
        private Comando _comando;

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
                _comando = FabricaComando.CrearComandoObtenerJugadorId(alineacion.Jugador);
                _comando.Ejecutar();
                alineacion.Jugador = _comando.GetEntidad() as Jugador;

                _comando = FabricaComando.CrearComandoObtenerEquipoEstatico(alineacion.Equipo);
                _comando.Ejecutar();
                alineacion.Equipo = _comando.GetEntidad() as Equipo;

                _comando = FabricaComando.CrearComandoObtenerPartido(alineacion.Partido);
                _comando.Ejecutar();
                alineacion.Partido = _comando.GetEntidad() as Partido;
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