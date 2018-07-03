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
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>List<Entidad></returns>
        List<Entidad> ObtenerApuestasEnCurso(Entidad usuario);

        /// <summary>
        /// Obtener todas las apuestas finalizadas de un usuairo especifico
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>List<Entidad></returns>
        List<Entidad> ObtenerApuestasFinalizadas(Entidad usuario);

        /// <summary>
        /// Verificar si una apuesta ya se encuentra registrada.
        /// </summary>
        /// <param name="apuesta"></param>
        /// <returns>int</returns>
        int VerificarApuestaExiste(Entidad apuesta);

        /// <summary>
        /// Verificar si una apuesta puede ser editada por el usuario, es decir, el partido 
        /// ligado a la apuesta no haya iniciado.
        /// </summary>
        /// <param name="apuesta"></param>
        /// <returns>int</returns>
        int VerificarApuestaValidaParaEditar(Entidad apuesta);

        /// <summary>
        /// Marcar apuestas como ganadas o perdidas de los logros completados.
        /// </summary>
        void FinalizarApuestas();
    }
}