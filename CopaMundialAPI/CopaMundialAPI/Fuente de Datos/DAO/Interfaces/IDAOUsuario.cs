using CopaMundialAPI.Comun.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces
{
    public interface IDAOUsuario: IDAO
    {
        /// <summary>
        /// Obtener todos los usuarios activos o inactivos
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>List<Entidad></returns>
        List<Entidad> ObtenerUsuarios(Entidad usuario);

    }
}