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

        /// <summary>
        /// Verifica si el correo ya se encuentra registrado en la base de datos.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>int</returns>
        int VerificarCorreoExiste(Entidad usuario);

        /// <summary>
        /// Verifica si la clave ingresada coincide con la clave actual del usuario.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>int</returns>
        int VerificarClaveUsuario(Entidad usuario);

        /// <summary>
        /// Activar/Desactivar la cuenta del usuario, true = activa ; false = desactiva.
        /// </summary>
        void GestionarCuenta(Entidad usuario);

        /// <summary>
        /// modifica solo la contraseña del usuario
        /// </summary>
        void EditarPassword(Entidad usuario);

        /// <summary>el correo del usuario
        /// </summary>
        void EditarCorreo(Entidad usuario);

        /// <summary>eExtrae la información usuario de la base de datos ingresado por su id.
        /// </summary>
        Usuario GetUsuario(Entidad usuario);
    }
}