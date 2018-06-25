using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;

namespace CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces
{
    public interface IDAOApuesta : IDAO
    {

        List<Entidad> ObtenerApuestasEnCurso(Entidad usuario);

        List<Entidad> ObtenerApuestasFinalizadas(Entidad usuario);
    }
}