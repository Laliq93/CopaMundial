using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces;

namespace CopaMundialAPI.Fuente_de_Datos.DAO
{
    public class DAOApuestaCantidad : DAO, IDAOApuesta
    {
        public void Actualizar(Entidad entidad)
        {
            throw new NotImplementedException();
        }

        public void Agregar(Entidad entidad)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(Entidad entidad)
        {
            throw new NotImplementedException();
        }

        public List<Apuesta> ObtenerApuestasUsuario(Entidad usuario)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}