using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;

namespace CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces
{
    public interface IDAOApuesta : IDAO
    {
        /// <summary>
        /// Obtener todas las apuestas en curso de un usuario especifico.
        /// resultados registrados
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        List<Entidad> ObtenerApuestasEnCurso(Entidad usuario);

        /// <summary>
        /// Obtener todas las apuestas finalizadas de un usuairo especifico
        /// resultados registrados
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        List<Entidad> ObtenerApuestasFinalizadas(Entidad usuario);

        /// <summary>
        /// Verificar si una apuesta ya se encuentra registrada.
        /// resultados registrados
        /// </summary>
        /// <param name="apuesta"></param>
        /// <returns></returns>
        void VerificarApuestaExiste(Entidad apuesta);
    }
}