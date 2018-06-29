using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces;
using CopaMundialAPI.Comun.Excepciones;
using Npgsql;

namespace CopaMundialAPI.Fuente_de_Datos.DAO
{
    public class DAOApuestaVoF : DAO, IDAOApuesta
    {
        /// <summary>
        /// Actualiza la información de la apuesta en la base de datos
        /// </summary>
        /// <param name="Entidad">Apuesta</param>
        public void Actualizar(Entidad entidad)
        {
            try
            {
                ApuestaVoF apuesta = entidad as ApuestaVoF;

                Conectar();

                StoredProcedure("editarapuestavof(@idlogro, @idusuario, @apuesta)");

                AgregarParametro("idlogro", apuesta.Logro.Id);
                AgregarParametro("idusuario", apuesta.Usuario.Id);
                AgregarParametro("apuesta", apuesta.Respuesta);

                EjecutarQuery();
            }
            catch(NpgsqlException exc)
            {
                Desconectar();
                throw new BaseDeDatosException(exc, "Error al actualizar la apuesta");
            }

        }

        /// <summary>
        /// Ingresa la informacion de una apuesta nueva en la base de datos
        /// </summary>
        /// <param name="Entidad">Apuesta</param>
        public void Agregar(Entidad entidad)
        {
            ApuestaVoF apuesta = entidad as ApuestaVoF;

            Conectar();

            StoredProcedure("agregarapuestavof(@idlogro, @idusuario, @apuesta)");

            AgregarParametro("idlogro", apuesta.Logro.Id);
            AgregarParametro("idusuario", apuesta.Usuario.Id);
            AgregarParametro("apuesta", apuesta.Respuesta);

            EjecutarQuery();
        }

        /// <summary>
        /// Elimina el registro de la apuesta respectivo.
        /// </summary>
        /// <param name="Entidad">Apuesta</param>
        public void Eliminar(Entidad entidad)
        {
            try
            {
                ApuestaVoF apuesta = entidad as ApuestaVoF;

                Conectar();

                StoredProcedure("eliminarapuesta(@idusuario, @idlogro)");

                AgregarParametro("idusuario", apuesta.Usuario.Id);
                AgregarParametro("idlogro", apuesta.Logro.Id);

                EjecutarQuery();
            }
            catch(NpgsqlException exc)
            {
                Desconectar();
                throw new BaseDeDatosException(exc, "Error al eliminar la apuesta");
            }
        }

        /// <summary>
        /// Marcar apuestas de tipo verdadero/falso como ganadas o perdidas de los logros finalizados.
        /// </summary>
        public void FinalizarApuestas()
        {
            try
            {
                Conectar();

                StoredProcedure("finalizarapuestavof()");

                EjecutarQuery();
            }
            catch (NpgsqlException exc)
            {
                Desconectar();
                throw new BaseDeDatosException(exc, "Error al finalizar apuestas de tipo verdadero o falso");
            }
        }

        /// <summary>
        /// Obtener las apuestas de un usuario en curso. (Partido no iniciado).
        /// </summary>
        /// <param name="Entidad">Usuario</param>
        public List<Entidad> ObtenerApuestasEnCurso(Entidad usuario)
        {
            List<Entidad> apuestasEnCurso = new List<Entidad>();

            ApuestaVoF apuesta;

            LogroVoF logro;

            try
            {
                Usuario apostador = usuario as Usuario;

                Conectar();

                StoredProcedure("obtenerapuestasvofencurso(@idusuario)");

                AgregarParametro("idusuario", usuario.Id);

                EjecutarReader();

                for (int i = 0; i < cantidadRegistros; i++)
                {
                    apuesta = FabricaEntidades.CrearApuestaVoF();

                    logro = FabricaEntidades.CrearLogroVoF();

                    logro.Id = GetInt(i, 0);

                    logro.Logro = GetString(i, 1);

                    apuesta.Respuesta = GetBool(i, 2);

                    apuesta.Estado = GetString(i, 3);

                    apuesta.Fecha = GetDateTime(i, 4);

                    apuesta.Logro = logro;

                    apuesta.Usuario = apostador;

                    apuestasEnCurso.Add(apuesta);

                }

                return apuestasEnCurso;
            }
            catch (InvalidCastException exc)
            {
                throw exc;
            }
            catch(NpgsqlException exc)
            {
                throw new BaseDeDatosException(exc, "Error al obtener apuestas en curso");
            }
            finally
            {
                Desconectar();
            }
        }

        /// <summary>
        /// Obtener las apuestas finalizadas de un usuario.
        /// </summary>
        /// <param name="Entidad">Usuario</param>
        public List<Entidad> ObtenerApuestasFinalizadas(Entidad usuario)
        {
            List<Entidad> apuestasFinalizadas = new List<Entidad>();

            ApuestaVoF apuesta;

            LogroVoF logro;

            try
            {
                Usuario apostador = usuario as Usuario;

                Conectar();

                StoredProcedure("obtenerapuestasvoffinalizadas(@idusuario)");

                AgregarParametro("idusuario", usuario.Id);

                EjecutarReader();

                for (int i = 0; i < cantidadRegistros; i++)
                {
                    apuesta = FabricaEntidades.CrearApuestaVoF();

                    logro = FabricaEntidades.CrearLogroVoF();

                    logro.Id = GetInt(i, 0);

                    logro.Logro = GetString(i, 1);

                    apuesta.Respuesta = GetBool(i, 2);

                    apuesta.Estado = GetString(i, 3);

                    apuesta.Fecha = GetDateTime(i, 4);

                    apuesta.Logro = logro;

                    apuesta.Usuario = apostador;

                    apuestasFinalizadas.Add(apuesta);

                }

                return apuestasFinalizadas;
            }
            catch (InvalidCastException exc)
            {
                throw exc;
            }
            catch(NpgsqlException exc)
            {
                throw new BaseDeDatosException(exc, "Error al obtener apuestas finalizadas");
            }
            finally
            {
                Desconectar();
            }
        }

        public List<Entidad> ObtenerTodos()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Verifica si la apuesta ya se encuentra registrada en la base de datos
        /// </summary>
        /// <param name="Entidad">Apuesta</param>
        public int VerificarApuestaExiste(Entidad apuesta)
        {
            try
            {
                ApuestaVoF apuestavof = apuesta as ApuestaVoF;

                Conectar();

                StoredProcedure("verificarapuestaexiste(@idusuario, @idlogro)");

                AgregarParametro("idusuario", apuestavof.Usuario.Id);
                AgregarParametro("idlogro", apuestavof.Logro.Id);

                EjecutarReader();

                int count = GetInt(0, 0);


                return count;
            }
            catch (NpgsqlException exc)
            {
                Desconectar();
                throw new BaseDeDatosException(exc, "Error al validar si la apuesta existe");
            }
        }

        /// <summary>
        /// Verifica si la apuesta es valida para ser editada, es decir, si el partido no ha iniciado.
        /// </summary>
        /// <param name="Entidad">Apuesta</param>
        public int VerificarApuestaValidaParaEditar(Entidad apuesta)
        {
            try
            {
                ApuestaVoF apuestavof = apuesta as ApuestaVoF;

                Conectar();

                StoredProcedure("verificarapuestavalida(@idusuario, @idlogro)");


                AgregarParametro("idusuario", apuestavof.Usuario.Id);
                AgregarParametro("idlogro", apuestavof.Logro.Id);

                EjecutarReader();

                int count = GetInt(0, 0);

                return count;
            }
            catch(NpgsqlException exc)
            {
                Desconectar();
                throw new BaseDeDatosException(exc, "Error al verificar si la apuesta es valida para ser modificada");
            }
        }
    }
}