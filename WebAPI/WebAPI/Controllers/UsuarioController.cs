using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models.Usuario;
using WebAPI.Models.DataBase;
using System.Data;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/Usuario")]
    public class UsuarioController : ApiController
    {
        DataBase DataBase = new DataBase();

        // api/Usuario/ObtenerUsuario/?idUsuario=id
        [HttpGet]
        public HttpResponseMessage ObtenerUsuario(int idUsuario)
        {
            try
            {
                if (!DataBase.conectar()) //se abre la conexión con la base de datos
                {
                    DataBase.desconectar();
                    return Request.CreateResponse(HttpStatusCode.NotFound, new HttpError("Error al conectarse con la base de datos"));
                }

                Usuario usuario = GetUsuario(idUsuario);

                if (usuario == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound, new HttpError("El usuario no existe."));

                return Request.CreateResponse(HttpStatusCode.OK, usuario);
            }
            catch (Exception)
            {
                DataBase.desconectar();
                return Request.CreateResponse(HttpStatusCode.NotFound, new HttpError("Error en el servidor."));
            }
           
        }

        // api/Usuario/EditarUsuario/?idUsuario=id&claveUsuario=clave
        [HttpGet]
        public HttpResponseMessage EditarUsuario(int idUsuario, string claveUsuario)
        {
            try
            {
                if (!DataBase.conectar()) //se abre la conexión con la base de datos
                {
                    DataBase.desconectar();
                    return Request.CreateResponse(HttpStatusCode.NotFound, new HttpError("Error al conectarse con la base de datos"));
                }

                bool editado = UpdateUsuario(idUsuario, claveUsuario);

                if (!editado)
                    return Request.CreateResponse(HttpStatusCode.NotFound, new HttpError("El usuario no existe."));

                return Request.CreateResponse(HttpStatusCode.OK, "Usuario editado con éxito.");
            }
            catch (Exception)
            {
                DataBase.desconectar();
                return Request.CreateResponse(HttpStatusCode.NotFound, new HttpError("Error en el servidor."));
            }

        }

        // api/Usuario/EliminarUsuario/?idUsuario=id
        [HttpGet]
        public HttpResponseMessage EliminarUsuario(int idUsuario)
        {
            try
            {
                if (!DataBase.conectar()) //se abre la conexión con la base de datos
                {
                    DataBase.desconectar();
                    return Request.CreateResponse(HttpStatusCode.NotFound, new HttpError("Error al conectarse con la base de datos"));
                }

                bool eliminado = DeleteUsuario(idUsuario);

                if (!eliminado)
                    return Request.CreateResponse(HttpStatusCode.NotFound, new HttpError("El usuario no existe."));

                return Request.CreateResponse(HttpStatusCode.OK, "Usuario eliminado con éxito.");
            }
            catch (Exception)
            {
                DataBase.desconectar();
                return Request.CreateResponse(HttpStatusCode.NotFound, new HttpError("Error en el servidor."));
            }

        }


        // api/Usuario/CrearUsuario/?usuario=prueba&nombre=nombrep&apellido=apellidop&fechaNacimiento=13-12-1990&correo=prueba@hotmail.com&genero=M&password=pepito123
        [HttpGet]
        public HttpResponseMessage CrearUsuario(string usuario, string nombre, string apellido, string fechaNacimiento, string correo, char genero, string password)
        {
            try
            {
                if (!DataBase.conectar()) //se abre la conexión con la base de datos
                {
                    DataBase.desconectar();
                    return Request.CreateResponse(HttpStatusCode.NotFound, new HttpError("Error al conectarse con la base de datos"));
                }

                bool insertado = InsertUsuario(usuario,nombre,apellido,fechaNacimiento,correo,genero,password);

                if (!insertado)
                    return Request.CreateResponse(HttpStatusCode.NotFound, new HttpError("Error al crear el usuario"));

                return Request.CreateResponse(HttpStatusCode.OK, "Usuario creado con éxito.");
            }
            catch (Exception e)
            {
                DataBase.desconectar();
                return Request.CreateResponse(HttpStatusCode.NotFound, new HttpError(e.ToString()));
            }

        }


        private Usuario GetUsuario(int idUsario)
        {
            try
            {
                //Se crea el comando utlizando la función  "crearComando" de la clase DataBase, dentro de la función se generá el objeto NpSqlCommand
                var comando = DataBase.crearComando("SELECT us_id, us_nombre, us_apellido, us_fechanacimiento, us_correo, us_genero, us_nombreusuario, us_password FROM usuario WHERE us_id = :id");
                comando.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer);
                comando.Prepare();
                comando.Parameters[0].Value = idUsario;

                //una vez preparado el comando, al ser un SELECT se usa la función "EjecutarReader", donde guarda los registros en un DataTable y cierra la conexión con la DB.
                var dataTable = DataBase.EjecutarReader();

                if (dataTable == null)
                    return null;

                if (dataTable.Rows.Count < 1)
                    return null;

                Usuario user = new Usuario(Convert.ToInt32(dataTable.Rows[0][0]), dataTable.Rows[0][1].ToString(), dataTable.Rows[0][2].ToString(),
                    DateTime.Parse(dataTable.Rows[0][3].ToString()), dataTable.Rows[0][4].ToString(), Convert.ToChar(dataTable.Rows[0][5]), null, 
                        dataTable.Rows[0][6].ToString(), dataTable.Rows[0][7].ToString(), false);
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        private bool UpdateUsuario(int idUsario, string claveUsuario)
        {
            try
            {
                //Se crea el comando utlizando la función  "crearComando" de la clase DataBase, dentro de la función se generá el objeto NpSqlCommand
                var comando = DataBase.crearComando("UPDATE usuario SET us_password = :clave WHERE us_id = :id");
                comando.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer);
                comando.Parameters.Add("clave", NpgsqlTypes.NpgsqlDbType.Varchar);
                comando.Prepare();
                comando.Parameters[0].Value = idUsario;
                comando.Parameters[1].Value = claveUsuario;

                //una vez preparado el comando, al ser un EDIT se usa la función "EjecutarQuery", donde se actualizan los registros respectivos y devuelve el # de filas afectadas.
                var filasAfectadas = DataBase.EjecutarQuery();

                if (filasAfectadas < 1)
                    return false;

                return true;

            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool DeleteUsuario(int idUsario)
        {
            try
            {
                //Se crea el comando utlizando la función  "crearComando" de la clase DataBase, dentro de la función se generá el objeto NpSqlCommand
                var comando = DataBase.crearComando("DELETE FROM USUARIO WHERE us_id = :id");
                comando.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer);
                comando.Prepare();
                comando.Parameters[0].Value = idUsario;

                //una vez preparado el comando, al ser un DELETE se usa la función "EjecutarQuery", donde se eliminan los registros respectivos y devuelve el # de filas afectadas.
                var filasAfectadas = DataBase.EjecutarQuery();

                if (filasAfectadas < 1)
                    return false;

                return true;

            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool InsertUsuario(string usuario, string nombre, string apellido, string fechaNacimiento, string correo, char genero, string password)
        {
            try
            {
                //Se crea el comando utlizando la función  "crearComando" de la clase DataBase, dentro de la función se generá el objeto NpSqlCommand
                var comando = DataBase.crearComando("INSERT INTO public.usuario( us_id, us_nombreusuario, us_nombre, us_apellido, us_fechanacimiento, us_correo,"
                +" us_genero, us_password, us_foto, us_token, us_passwordTemporal) VALUES(nextVal('seq_usuario'), :usuario, :nombre, :apellido, :fechaNacimiento"
                +", :correo, :genero, :password, null, null, null); ");
                comando.Parameters.Add("usuario", NpgsqlTypes.NpgsqlDbType.Varchar);
                comando.Parameters.Add("nombre", NpgsqlTypes.NpgsqlDbType.Varchar);
                comando.Parameters.Add("apellido", NpgsqlTypes.NpgsqlDbType.Varchar);
                comando.Parameters.Add("fechaNacimiento", NpgsqlTypes.NpgsqlDbType.Date);
                comando.Parameters.Add("correo", NpgsqlTypes.NpgsqlDbType.Varchar);
                comando.Parameters.Add("genero", NpgsqlTypes.NpgsqlDbType.Char);
                comando.Parameters.Add("password", NpgsqlTypes.NpgsqlDbType.Varchar);
                comando.Prepare();
                comando.Parameters[0].Value = usuario;
                comando.Parameters[1].Value = nombre;
                comando.Parameters[2].Value = apellido;
                comando.Parameters[3].Value = Convert.ToDateTime(fechaNacimiento);
                comando.Parameters[4].Value = correo;
                comando.Parameters[5].Value = genero;
                comando.Parameters[6].Value = password;

                //una vez preparado el comando, al ser un INSERT se usa la función "EjecutarQuery", donde se crea el registro y devuelve el número de registros creados.
                var registrosCreados = DataBase.EjecutarQuery();

                if (registrosCreados < 1)
                    return false;

                return true;

            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
