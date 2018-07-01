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
    public class ComandoObtenerPartido : Comando
    {
        private Partido _entidadRespuesta;
        private Comando _comando;

        public ComandoObtenerPartido(Partido entidad)
        {
            Entidad = entidad;
        }

        public override void Ejecutar()
        {
            IDAOPartido dao = FabricaDAO.CrearDAOPartido();
            _entidadRespuesta = dao.ObtenerPorId(Entidad) as Partido;

            this.CompletarPartido();
        }

        private void CompletarPartido()
        {
            _comando = FabricaComando.CrearComandoObtenerEquipoEstatico(_entidadRespuesta.Equipo1);
            _comando.Ejecutar();
            _entidadRespuesta.Equipo1 = _comando.GetEntidad() as Equipo;

            _comando = FabricaComando.CrearComandoObtenerEquipoEstatico(_entidadRespuesta.Equipo2);
            _comando.Ejecutar();
            _entidadRespuesta.Equipo2 = _comando.GetEntidad() as Equipo;

            _comando = FabricaComando.CrearComandoObtenerEstadioEstatico(_entidadRespuesta.Estadio);
            _comando.Ejecutar();
            _entidadRespuesta.Estadio = _comando.GetEntidad() as Estadio;

            _comando = FabricaComando.CrearComandoAlineacionPorPartido(_entidadRespuesta);
            _comando.Ejecutar();
            _entidadRespuesta.Alineaciones = _comando.GetEntidades().Cast<Alineacion>().ToList();
        }

        public override Entidad GetEntidad()
        {
            return _entidadRespuesta;
        }

        public override List<Entidad> GetEntidades()
        {
            throw new NotImplementedException();
        }
    }
}