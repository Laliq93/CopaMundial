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
        public void Actualizar(Entidad entidad)
        {
            ApuestaVoF apuesta = entidad as ApuestaVoF;

            StoredProcedure("editarapuestavof(@idlogro, @idusuario, @apuesta)");

            AgregarParametro("idlogro", apuesta.Logro.Id);
            AgregarParametro("idusuario", apuesta.Usuario.Id);
            AgregarParametro("apuesta", apuesta.Respuesta);

            EjecutarQuery();

        }

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

        public void Eliminar(Entidad entidad)
        {
            ApuestaVoF apuesta = entidad as ApuestaVoF;

            StoredProcedure("eliminarapuesta(@idlogro, @idusuario)");

            AgregarParametro("idlogro", apuesta.Logro.Id);
            AgregarParametro("idusuario", apuesta.Usuario.Id);

            EjecutarQuery();
        }

        public List<Entidad> ObtenerApuestasEnCurso(Entidad usuario)
        {
            List<Entidad> apuestasEnCurso = new List<Entidad>();

            ApuestaVoF apuesta;

            LogroVoF logro;

            Usuario apostador = usuario as Usuario;

            Conectar();

            StoredProcedure("obtenerapuestasvofencurso(@idusuario)");

            AgregarParametro("idusuario", usuario.Id);

            EjecutarReader();

            for(int i = 0; i < cantidadRegistros; i++)
            {
                apuesta = FabricaEntidades.CrearApuestaVoF();

                logro = FabricaEntidades.CrearLogroVoF();

                logro.Id = GetInt(i, 0);

                logro.Logro = GetString(i, 1);

                apuesta.Respuesta = GetBool(i, 2);

                apuesta.Estado = GetString(i, 3);

                apuesta.Logro = logro;

                apuesta.Usuario = apostador;

                apuestasEnCurso.Add(apuesta);

            }

            return apuestasEnCurso;
        }

        public List<Entidad> ObtenerApuestasFinalizadas(Entidad usuario)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ObtenerTodos()
        {
            throw new NotImplementedException();
        }

        public void VerificarApuestaExiste(Entidad apuesta)
        {
            Conectar();

            ApuestaVoF apuestavof = apuesta as ApuestaVoF;

            StoredProcedure("verificarapuestaexiste(@idusuario, @idlogro)");

            AgregarParametro("idusuario", apuestavof.Usuario.Id);
            AgregarParametro("idlogro", apuestavof.Logro.Id);

            EjecutarReader();

            int count = GetInt(0, 0);

            if (count > 0)
                throw new ApuestaRepetidaException();
        }
    }
}