using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Excepciones;
using CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Partidos
{
    public class ComandoValidarMaximoJugadores: Comando
    {
        private List<Entidad> _respuesta;
        private Alineacion _alineacion;

        public ComandoValidarMaximoJugadores(Entidad entidad)
        {
            _alineacion = entidad as Alineacion;
        }

        public override void Ejecutar()
        {
            IDAOAlineacion dao = FabricaDAO.CrearDAOAlineacion();
            try
            {
                _respuesta = dao.ConsultarTitularesPorPartidoYEquipo(_alineacion);
            }
            catch (AlineacionNoExisteException)
            {
                // No hacer nada, no hay capitan
            }

            if (_respuesta != null)
            {
                this.ValidarAlineacion();
            }
            
        }

        private void ValidarAlineacion()
        {
            int _index = _respuesta.FindIndex(e => e.Id == _alineacion.Id);

            if (_respuesta.Count >= 11 && _index == -1 && _alineacion.EsTitular)
            {
                throw new AlineacionMuchosJugadoresException("El equipo solo puede tener 11 titulares");
            }
        }

        public override Entidad GetEntidad()
        {
            throw new NotImplementedException();
        }

        public override List<Entidad> GetEntidades()
        {
            return _respuesta;
        }
    }
}