using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Partidos
{
    public class ComandoObtenerPartido : Comando
    {
        private Entidad _entidadRespuesta;

        public ComandoObtenerPartido(Partido entidad)
        {
            Entidad = entidad;
        }

        public override void Ejecutar()
        {
            IDAOPartido dao = FabricaDAO.CrearDAOPartido();
            _entidadRespuesta = dao.ObtenerPorId(Entidad);
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