using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;

namespace CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces
{
    public interface IDAOCiudad : IDAO
    {
        /// <summary>
        /// Metodo Insertar,inserta el objeto ciudad de tipo Ciudad enviado por parametro.
        /// </summary>
        /// <param name="ciudad">ciudad de tipo Ciudad el cual se desea insertar</param>
        void InsertarCiudad ( Ciudad ciudad );

        /// <summary>
        /// Metodo Modificar, actualiza una Ciudad enviada por parametro.
        /// </summary>
        /// <param name="ciudad">ciudad de tipo Ciudad el cual se desea modificar.</param>
        void ModificarCiudad ( Ciudad ciudad );

        /// <summary>
        /// Metodo Eliminar, elimina una Ciudad enviada por parametro.
        /// </summary>
        /// <param name="ciudad">ciudad de tipo Ciudad el cual se desea Eliminar.</param>
        void EliminarCiudad ( Ciudad ciudad );

        /// <summary>
        /// Metodo ConsultarPorId, consulta una Ciudad enviada por parametro.
        /// </summary>
        /// <param name="ciudad">ciudad de tipo Ciudad el cual se desea consultar.</param>
        /// <returns>Ciudad asociada al Id colocado por parametro.</returns>
        Ciudad ConsultarCiudadPorId ( Ciudad ciudad );

        /// <summary>
        /// Metodo ConsultarLista, consulta todas las ciudades.
        /// </summary>
        /// <param name="ciudad">ciudad de tipo Ciudad el cual se desea consultar.</param>
        /// <returns>Lista de Ciudades referenciadas a la consulta</returns>
        List<Ciudad> ConsultarListaCiudades ( Ciudad ciudad );

    }
}