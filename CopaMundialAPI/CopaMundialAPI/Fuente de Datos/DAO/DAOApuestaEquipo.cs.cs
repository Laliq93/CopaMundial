using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Comun.Excepciones;
using CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces;
using Npgsql;

namespace CopaMundialAPI.Fuente_de_Datos.DAO
{
    public class DAOApuestaEquipo : DAO, IDAOApuesta
    {
        public void Actualizar(Entidad entidad)
        {
            ApuestaEquipo apuesta = entidad as ApuestaEquipo;

            Conectar();

            StoredProcedure("editarapuestaequipo(@idlogro, @idusuario, @apuesta)");

            AgregarParametro("idlogro", apuesta.Logro.Id);
            AgregarParametro("idusuario", apuesta.Usuario.Id);
            AgregarParametro("apuesta", apuesta.Respuesta.Id);

            EjecutarQuery();
        }

        public void Agregar(Entidad entidad)
        {
            ApuestaEquipo apuesta = entidad as ApuestaEquipo;

            Conectar();

            StoredProcedure("agregarapuestaequipo(@idlogro, @idusuario, @apuesta)");

            AgregarParametro("idlogro", apuesta.Logro.Id);
            AgregarParametro("idusuario", apuesta.Usuario.Id);
            AgregarParametro("apuesta", apuesta.Respuesta.Id);

            EjecutarQuery();
        }

        public void Eliminar(Entidad entidad)
        {
            ApuestaEquipo apuesta = entidad as ApuestaEquipo;

            Conectar();

            StoredProcedure("eliminarapuesta(@idusuario, @idlogro)");

            AgregarParametro("idusuario", apuesta.Usuario.Id);
            AgregarParametro("idlogro", apuesta.Logro.Id);

            EjecutarQuery();
        }

        public List<Entidad> ObtenerApuestasEnCurso(Entidad usuario)
        {
            List<Entidad> apuestasEnCurso = new List<Entidad>();

            ApuestaEquipo apuesta;

            LogroEquipo logro;

            Equipos listaequipos = new Equipos();

            Equipo equipo;

            try
            {
                Usuario apostador = usuario as Usuario;

                Conectar();

                StoredProcedure("obtenerapuestasequipoencurso(@idusuario)");

                AgregarParametro("idusuario", usuario.Id);

                EjecutarReader();

                for (int i = 0; i < cantidadRegistros; i++)
                {
                    apuesta = FabricaEntidades.CrearApuestaEquipo();

                    logro = FabricaEntidades.CrearLogroEquipo();

                    logro.Id = GetInt(i, 0);

                    logro.Logro = GetString(i, 1);

                    equipo = listaequipos.GetEquipo(GetInt(i, 2));

                    apuesta.Estado = GetString(i, 3);

                    apuesta.Fecha = GetDateTime(i, 4);

                    apuesta.Logro = logro;

                    apuesta.Respuesta = equipo;

                    apuesta.Usuario = apostador;

                    apuestasEnCurso.Add(apuesta);

                }


                return apuestasEnCurso;

            }
            catch (InvalidCastException exc)
            {
                Desconectar();
                throw exc;
            }
        }

        public List<Entidad> ObtenerApuestasFinalizadas(Entidad usuario)
        {
            List<Entidad> apuestasFinalizadas = new List<Entidad>();

            ApuestaEquipo apuesta;

            LogroEquipo logro;

            Equipos listaequipos = new Equipos();

            Equipo equipo;

            try
            {
                Usuario apostador = usuario as Usuario;

                Conectar();

                StoredProcedure("obtenerapuestasequipoencurso(@idusuario)");

                AgregarParametro("idusuario", usuario.Id);

                EjecutarReader();

                for (int i = 0; i < cantidadRegistros; i++)
                {
                    apuesta = FabricaEntidades.CrearApuestaEquipo();

                    logro = FabricaEntidades.CrearLogroEquipo();

                    logro.Id = GetInt(i, 0);

                    logro.Logro = GetString(i, 1);

                    equipo = listaequipos.GetEquipo(GetInt(i, 2));

                    apuesta.Estado = GetString(i, 3);

                    apuesta.Fecha = GetDateTime(i, 4);

                    apuesta.Logro = logro;

                    apuesta.Respuesta = equipo;

                    apuesta.Usuario = apostador;

                    apuestasFinalizadas.Add(apuesta);

                }


                return apuestasFinalizadas;

            }
            catch (InvalidCastException exc)
            {
                Desconectar();
                throw exc;
            }
        }

        public List<Entidad> ObtenerTodos()
        {
            throw new NotImplementedException();
        }

        public int VerificarApuestaExiste(Entidad apuesta)
        {
            ApuestaEquipo apuestaequipo = apuesta as ApuestaEquipo;

            Conectar();

            StoredProcedure("verificarapuestaexiste(@idusuario, @idlogro)");

            AgregarParametro("idusuario", apuestaequipo.Usuario.Id);
            AgregarParametro("idlogro", apuestaequipo.Logro.Id);

            EjecutarReader();

            int count = GetInt(0, 0);

            return count;
        }


        public int VerificarApuestaValidaParaEditar(Entidad apuesta)
        {
            ApuestaEquipo apuestaequipo = apuesta as ApuestaEquipo;

            Conectar();

            StoredProcedure("verificarapuestavalida(@idusuario, @idlogro)");


            AgregarParametro("idusuario", apuestaequipo.Usuario.Id);
            AgregarParametro("idlogro", apuestaequipo.Logro.Id);

            EjecutarReader();

            int count = GetInt(0, 0);

            return count;
        }
    }
}