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
    public class ComandoValidarCapitan : Comando
    {
        private Entidad _respuesta;
        public ComandoValidarCapitan(Entidad entidad)
        {
            Entidad = entidad;
        }

        public override void Ejecutar()
        {
            IDAOAlineacion dao = FabricaDAO.CrearDAOAlineacion();
            try
            {
                _respuesta = dao.ConsultarCapitanPorPartidoYEquipo(Entidad);
            }
            catch (AlineacionNoExisteException)
            {
                // No hacer nada, no hay capitan
            }

            this.ValidarCapitania();
           
        }

        private void ValidarCapitania()
        {
            if (_respuesta != null && _respuesta.Id != Entidad.Id)
            {
                throw new AlineacionMasDeUnCapitanException("Solo se permite un capitan por equipo");
            }
        }

        public override Entidad GetEntidad()
        {
            return _respuesta;
        }

        public override List<Entidad> GetEntidades()
        {
            throw new NotImplementedException();
        }
    }
}