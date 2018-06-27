using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;
using CopaMundialAPI.Fuente_de_Datos.DAO;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Apuestas
{
    public class ComandoObtenerLogrosCantidadPartido : Comando
    {
        private Entidad _partido;
        private List<Entidad> _logroscantidad;
        private DAOApuesta _dao;

        public ComandoObtenerLogrosCantidadPartido(Entidad entidad)
        {
            _partido = entidad;
            _logroscantidad = new List<Entidad>();
            _dao = FabricaDAO.CrearDAOApuesta();
        }

        public override void Ejecutar()
        {
            _logroscantidad = _dao.ObtenerLogrosCantidadPartido(_partido);
        }

        public override Entidad GetEntidad()
        {
            throw new NotImplementedException();
        }

        public override List<Entidad> GetEntidades()
        {
            return _logroscantidad;
        }
    }
}