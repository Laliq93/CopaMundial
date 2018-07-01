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
        public void Actualizar(Entidad entidad)
        {
            throw new NotImplementedException();
        }

        public void Agregar(Entidad entidad)
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
         
        public void Eliminar(Entidad entidad)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ObtenerTodos()
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ObtenerUsuarios(Entidad entidad)
        {
            Usuario usuario = entidad as Usuario;
            List<Entidad> _usuarios = new List<Entidad>();

            Conectar();

            if (usuario.Activo == true)
                StoredProcedure("ObtenerUsuariosActivos()");
            else
                StoredProcedure("ObtenerUsuariosNoActivos()");

            EjecutarReader();

            for (int i = 0; i < cantidadRegistros; i++)
            {
                _usuarios.Add(FabricaEntidades.CrearConfiguracionUsuario(GetString(i, 0), GetString(i, 1), GetString(i, 2),
                 Convert.ToDateTime(GetString(i, 3)).ToShortDateString(), GetString(i, 4), usuario.Activo));

            }
            return _usuarios;
        }
    }
}