using CopaMundialAPI.Comun.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces
{
    public interface IDAOPartido: IDAO
    {
        List<Entidad> ObtenerPartidosPosterioresA(DateTime fecha);

        Entidad ObtenerPorId(Entidad entidad);
    }
}