using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Comun.Excepciones;
using Npgsql;

namespace CopaMundialAPI.Fuente_de_Datos.DAO
{
    public class DAOUsuario : DAO, IDAOUsuario
    {
        /// <summary>
        /// Actualiza la información del perfil de usuario en la base de datos.
        /// </summary>
        /// <param name="entidad">Usuario</param>
        public void Actualizar(Entidad entidad)
        {
            try
            {
                Usuario usuario = entidad as Usuario;

                Conectar();

                StoredProcedure("editarperfilusuario(@id, @nombre, @apellido, @fechaNacimiento, @genero, @foto)");

                AgregarParametro("id", usuario.Id);
                AgregarParametro("nombre", usuario.Nombre);
                AgregarParametro("apellido", usuario.Apellido);
                AgregarParametro("fechaNacimiento", Convert.ToDateTime(usuario.FechaNacimiento).ToShortDateString());
                AgregarParametro("genero", usuario.Genero.ToString().ToUpper());
                AgregarParametro("foto", usuario.FotoPath);

                EjecutarQuery();
            }
            catch (NpgsqlException exc)
            {
                Desconectar();
                throw new BaseDeDatosException(exc, "Error al modificar al usuario.");
            }
        }

        /// <summary>
        /// Activa/Desactiva la cuenta del usuario, true = activa ; false = desactiva.
        /// </summary>
        public void GestionarCuenta(Entidad entidad)
        {
            try
            {
                Usuario usuario = entidad as Usuario;

                Conectar();

                StoredProcedure("gestionaractivocuentausuario(@id, @activo)");

                AgregarParametro("id", usuario.Id);
                AgregarParametro("activo", usuario.Activo);

                EjecutarQuery();
            }
            catch (NpgsqlException exc)
            {
                Desconectar();
                throw new BaseDeDatosException(exc, "Error al cambiar status del usuario");
            }
        }

        /// <summary>
        /// Actualiza la contraseña del usuario.
        /// </summary>
        /// <param name="entidad">Usuario</param>
        public void EditarPassword(Entidad entidad)
        {
            try
                {
                    Usuario usuario = entidad as Usuario;
                    Conectar();

                    StoredProcedure("cambiarpasswordusuario(@id, @clave)");

                    AgregarParametro("id", usuario.Id);
                    AgregarParametro("clave", usuario.Password);

                    EjecutarQuery();
                }
            catch (NpgsqlException exc)
                {
                    Desconectar();
                    throw new BaseDeDatosException(exc, "Error al modificar la contraseña del usuario");
                }

        }

        /// <summary>
        /// Actualiza el correo del usuario.
        /// </summary>
        /// <param name="entidad">Usuario</param>
        public void EditarCorreo(Entidad entidad)
        {
            try
            {
                Usuario usuario = entidad as Usuario;

                Conectar();

                StoredProcedure("cambiarcorreousuario(@id, @correo)");

                AgregarParametro("id", usuario.Id);
                AgregarParametro("correo", usuario.Correo);

                EjecutarQuery();
            }
            catch (NpgsqlException exc)
            {
                Desconectar();
                throw new BaseDeDatosException(exc, "Error al modificar el correo del usuario");
            }

        }

        /// <summary>
        /// Verifica si el correo ya se encuentra registrado en la base de datos.
        /// </summary>
        /// <param name="entidad">Usuario</param>
        public int VerificarCorreoExiste(Entidad entidad)
        {
            try
            {
                Usuario usuario = entidad as Usuario;

                Conectar();

                StoredProcedure("verificarcorreoexiste(@correo)");

                AgregarParametro("correo", usuario.Correo);

                EjecutarReader();

                int countCorreo = GetInt(0, 0);

                return countCorreo;

            }
            catch (NpgsqlException exc)
            {
                Desconectar();
                throw new BaseDeDatosException(exc, "Error validando que el correo del usuario exista");
            }

        }

        /// <summary>
        /// Verifica si la clave ingresada coincide con la clave actual del usuario.
        /// </summary>
        /// <param name="entidad">Usuario</param>
        public int VerificarClaveUsuario(Entidad entidad)
        {
            try
            {
                Usuario usuario = entidad as Usuario;

                Conectar();

                StoredProcedure("verificarclaveusuario(@clave, @idUsuario)");

                AgregarParametro("clave", usuario.Password.Trim());
                AgregarParametro("idUsuario", usuario.Id);

                EjecutarReader();

                int countClave = GetInt(0, 0);

                return countClave;

            }
            catch (NpgsqlException exc)
            {
                Desconectar();
                throw new BaseDeDatosException(exc, "Error validando la contraseña del usuario");
            }

        }

        /// <summary>
        /// Ingresa un nuevo usuario administrador en la base de datos.
        /// </summary>
        /// <param name="entidad">Usuario</param>
        public void Agregar(Entidad entidad)
        {
            try
            {
                Usuario usuario = entidad as Usuario;

                Conectar();

                StoredProcedure("crearusuarioadministrador(@nombreU, @nombre, @apellido, @fechaNacimiento, @correo, @genero, @clave)");

                AgregarParametro("nombreU", usuario.NombreUsuario);
                AgregarParametro("nombre", usuario.Nombre);
                AgregarParametro("apellido", usuario.Apellido);
                AgregarParametro("fechaNacimiento", usuario.FechaNacimiento);
                AgregarParametro("correo", usuario.Correo);
                AgregarParametro("genero", usuario.Genero.ToString().ToUpper());
                AgregarParametro("clave", usuario.Password);

                EjecutarQuery();
            }
            catch (NpgsqlException exc)
            {
                Desconectar();
                throw new BaseDeDatosException(exc, "Error insertando usuario como administrador");
            }

        }

        /// <summary>
        /// Extrae la información usuario de la base de datos ingresado por su id.
        /// </summary>
        /// <param name="entidad">Usuario</param>
        public Usuario GetUsuario(Entidad entidad)
        {
            try
            {
                Usuario usuario = entidad as Usuario;
                Conectar();

                StoredProcedure("ObtenerUsuario(@id)");

                AgregarParametro("id", usuario.Id);

                EjecutarReader();

                usuario = FabricaEntidades.CrearUsuario(usuario.Id, GetString(0, 0), GetString(0, 1), GetString(0, 2), Convert.ToDateTime(GetString(0, 3)).ToShortDateString(),
                    GetString(0, 4), GetChar(0, 5), GetString(0, 6), GetString(0, 7), GetBool(0, 8), GetBool(0, 9), "");

                return usuario;
            }
            catch (NpgsqlException exc)
            {
                Desconectar();
                throw new BaseDeDatosException(exc, "Error al obtener el usuario");
            }
        }


        public void Eliminar(Entidad entidad)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Devuelve los usuarios (no administradores) activos/no activos registrados en la base de datos. true = activos; false = no activos.
        /// </summary>
        /// <param name="entidad">Usuario</param>
        public List<Entidad> ObtenerUsuariosActivos(Entidad entidad)
        {
            Usuario usuario = entidad as Usuario;
            List<Entidad> usuarios = new List<Entidad>();

            Conectar();
            
            StoredProcedure("ObtenerUsuariosActivos()");
 
            EjecutarReader();

            for (int i = 0; i < cantidadRegistros; i++)
            {
                usuarios.Add(FabricaEntidades.CrearConfiguracionUsuario(GetInt(i, 0), GetString(i, 1), GetString(i, 2), GetString(i, 3),
                 Convert.ToDateTime(GetString(i, 4)).ToShortDateString(), GetString(i, 5), usuario.Activo));

            }
            return usuarios;
        }

        /// <summary>
        /// Devuelve los usuarios (no administradores) no activos registrados en la base de datos
        /// </summary>
        /// <param name="entidad">Usuario</param>
        public List<Entidad> ObtenerUsuariosNoActivos(Entidad entidad)
        {
            Usuario usuario = entidad as Usuario;
            List<Entidad> usuarios = new List<Entidad>();

            Conectar();

            StoredProcedure("ObtenerUsuariosNoActivos()");

            EjecutarReader();

            for (int i = 0; i < cantidadRegistros; i++)
            {
                usuarios.Add(FabricaEntidades.CrearConfiguracionUsuario(GetInt(i, 0), GetString(i, 1), GetString(i, 2), GetString(i, 3),
                 Convert.ToDateTime(GetString(i, 4)).ToShortDateString(), GetString(i, 5), usuario.Activo));

            }
            return usuarios;
        }

        public List<Entidad> ObtenerTodos()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Ingresa un nuevo usuario administrador en la base de datos.
        /// </summary>
        /// <param name="entidad">Usuario</param>
        public void AgregarNuevo(Entidad entidad)
        {
            try
            {
                Usuario usuario = entidad as Usuario;

                Conectar();

                StoredProcedure("agregarusuario(@nombreusuario, @nombre, @apellido , @fechanacimiento, @correo, @genero, @password)");

                AgregarParametro("nombreusuario", usuario.NombreUsuario);
                AgregarParametro("nombre", usuario.Nombre);
                AgregarParametro("apellido", usuario.Apellido);
                AgregarParametro("fechanacimiento", usuario.FechaNacimiento );
                AgregarParametro("correo", usuario.Correo);
                AgregarParametro("genero", usuario.Genero.ToString().ToUpper());
                AgregarParametro("password", usuario.Password);

                System.Diagnostics.Debug.WriteLine(usuario.NombreUsuario + " " + usuario.FechaNacimiento);

                EjecutarReader();
            }
            catch (NpgsqlException exc)
            {
                System.Diagnostics.Debug.WriteLine("exception:"+exc.ToString());
                throw new BaseDeDatosException(exc, "Error al agregar el usuario");
            }
            finally
            {
                Desconectar();
            }

        }
    }
}