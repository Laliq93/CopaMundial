using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CopaMundialAPI.Comun.Entidades;

namespace CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces
{
    public interface IDAOLogro: IDAO
    {
        /// <summary>
        /// Metodo Obtener Logro por id, se obtiene los datos
        /// de un logro por su id
        /// </summary>
        /// <param name="logro"></param>
        /// <returns></returns>
        Entidad ObtenerLogroPorId(Entidad logro);

        /// <summary>
        /// Metodo para asignarle el resultado a un logro
        /// </summary>
        /// <param name="logro"></param>
        /// <returns></returns>
        void AsignarResultadoLogro(Entidad logro);

        /// <summary>
        /// Metodo para obtener todos los logros que no se han 
        /// asignado un resultado
        /// </summary>
        /// <param name="partido"></param>
        /// <returns></returns>
        List<Entidad> ObtenerLogrosPendientes(Entidad partido);

        /// <summary>
        /// Metodo para obtener todos los logros que posean 
        /// resultados registrados
        /// </summary>
        /// <param name="partido"></param>
        /// <returns></returns>
        List<Entidad> ObtenerLogrosResultados(Entidad partido);
    }
}
