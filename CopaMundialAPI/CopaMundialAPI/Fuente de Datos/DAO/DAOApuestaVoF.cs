using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces;
using CopaMundialAPI.Comun.Excepciones;

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
            try
            {
                Conectar();

                ApuestaVoF apuesta = entidad as ApuestaVoF;

                StoredProcedure("agregarapuestavof(@idlogro, @idusuario, @apuesta)");

                AgregarParametro("idlogro", apuesta.Logro.Id);
                AgregarParametro("idusuario", apuesta.Usuario.Id);
                AgregarParametro("apuesta", apuesta.Respuesta);

                EjecutarQuery();
            }
            catch (InvalidCastException exc)
            {
                throw exc;
            }
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
            Usuario apostador = usuario as Usuario;

            List<Entidad> apuestasEnCurso = new List<Entidad>();

            /*StoredProcedure("obtenerapuestasvofencurso(@idusuario)");

            AgregarParametro("idusuario", usuario.Id);

            EjecutarReader();

            for(int i = 0; i < cantidadRegistros; i++)
            {
                ApuestaVoF apuesta = FabricaEntidades.CrearApuestaVoF();

                apuesta.Usuario.Id = usuario.Id;
                apuesta.Logro.Id = GetInt(i, 0);
                apuesta.Logro.Logro = GetString(i, 1);
                apuesta.Respuesta = GetBool(i, 2);
                apuesta.Estado = GetString(i, 3);
                apuesta.Fecha = GetString(i, 4);
                //apuesta.Logro.Partido = GetString(i, 5);

                apuestasEnCurso.Add(apuesta);
     
            }*/

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

    }
}