using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces;

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

            StoredProcedure("crearapuestavof(@idlogro, @idusuario, @fecha, @apuesta)");

            AgregarParametro("idlogro", apuesta.Logro.Id);
            AgregarParametro("idusuario", apuesta.Usuario.Id);
            AgregarParametro("fecha", apuesta.Fecha);
            AgregarParametro("apuesta", apuesta.Respuesta);

            EjecutarQuery();
        }

        public void Eliminar(Entidad entidad)
        {
            ApuestaVoF apuesta = entidad as ApuestaVoF;

            StoredProcedure("eliminarapuestavof(@idlogro, @idusuario)");

            AgregarParametro("idlogro", apuesta.Logro.Id);
            AgregarParametro("idusuario", apuesta.Usuario.Id);

            EjecutarQuery();
        }

        public List<Apuesta> ObtenerApuestasUsuario(Entidad usuario)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}