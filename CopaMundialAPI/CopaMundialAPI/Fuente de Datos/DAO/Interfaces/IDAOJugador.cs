using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;

namespace CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces
{
    public interface IDAOJugador : IDAO
    {
        /// <summary>
        /// Metodo Insertar,inserta el objeto jugador de tipo jugador enviado por parametro.
        /// </summary>
        /// <param name="jugador">jugador de tipo jugador</param>
        void AgregarJugador ( Jugador jugador );

        /// <summary>
        /// Metodo Modificar, actualiza una jugador enviada por parametro.
        /// </summary>
        /// <param name="jugador">jugador de tipo jugador el cual se desea modificar</param>
        void ModificarJugador (Jugador jugador);

        /// <summary>
        /// Metodo desactivar, desactiva un jugador enviado por parametro.
        /// </summary>
        /// <param name="jugador">jugador de tipo jugador el cual se desea desactivar.</param>
        void DesactivarJugador (Jugador jugador);

        /// <summary>
        /// Metodo activar, activa un jugador enviado por parametro.
        /// </summary>
        /// <param name="jugador">jugador de tipo jugador el cual se desea activar.</param>
        void ActivarJugador(Jugador jugador);

        /// <summary>
        /// Metodo ConsultarJugadorId, consulta un jugador enviado por parametro.
        /// </summary>
        /// <param name="jugador">jugador de tipo jugador el cual se desea consultar.</param>
        /// <returns>jugador asociado al Id colocado por parametro.</returns>
        Jugador ConsultarJugadorId ( Jugador jugador );

        /// <summary>
        /// Metodo ConsultarLista, consulta todos los jugadores del sistema.
        /// </summary>
        /// <param name="jugador">jugador de tipo jugador el cual se desea consultar.</param>
        /// <returns>Lista de jugadores referenciados a la consulta</returns>
        List<Ciudad> ConsultarListaJugadores ( Jugador jugador );

    }
}