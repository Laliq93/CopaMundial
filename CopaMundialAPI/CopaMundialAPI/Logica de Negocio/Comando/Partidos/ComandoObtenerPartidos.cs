using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;
using CopaMundialAPI.Logica_de_Negocio.Fabrica;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Partidos
{
    public class ComandoObtenerPartidos : Comando
    {
        private List<Entidad> _entidadRespuesta;
        private Comando _comando;

        public override void Ejecutar()
        {
            IDAOPartido dao = FabricaDAO.CrearDAOPartido();
            _entidadRespuesta = dao.ObtenerTodos();

            CompletarPartido();
        }

        private void CompletarPartido()
        {
            foreach (Partido partido in _entidadRespuesta)
            {
                _comando = FabricaComando.CrearComandoObtenerEquipoEstatico(partido.Equipo1);
                _comando.Ejecutar();
                partido.Equipo1 = _comando.GetEntidad() as Equipo;

                _comando = FabricaComando.CrearComandoObtenerEquipoEstatico(partido.Equipo2);
                _comando.Ejecutar();
                partido.Equipo2 = _comando.GetEntidad() as Equipo;

                _comando = FabricaComando.CrearComandoObtenerEstadioEstatico(partido.Estadio);
                _comando.Ejecutar();
                partido.Estadio = _comando.GetEntidad() as Estadio;
            }
        }

        public override Entidad GetEntidad()
        {
            throw new NotImplementedException();
        }

        public override List<Entidad> GetEntidades()
        {
            return _entidadRespuesta;
        }
    }
}