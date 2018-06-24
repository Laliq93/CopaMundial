using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces;

namespace CopaMundialAPI.Fuente_de_Datos.DAO
{
    public class DAOApuestaCantidad : DAO, IDAOApuesta
    {
        public void Actualizar(Entidad entidad)
        {
            ApuestaCantidad apuesta = entidad as ApuestaCantidad;

            StoredProcedure("editarapuestacantidad(@idlogro, @idusuario, @apuesta)");

            AgregarParametro("idlogro", apuesta.Logro.Id);
            AgregarParametro("idusuario", apuesta.Usuario.Id);
            AgregarParametro("apuesta", apuesta.Respuesta);

            EjecutarQuery();
        }

        public void Agregar(Entidad entidad)
        {
            ApuestaCantidad apuesta = entidad as ApuestaCantidad;

            StoredProcedure("crearapuestacantidad(@idlogro, @idusuario, @fecha, @apuesta)");

            AgregarParametro("idlogro", apuesta.Logro.Id);
            AgregarParametro("idusuario", apuesta.Usuario.Id);
            AgregarParametro("fecha", apuesta.Fecha);
            AgregarParametro("apuesta", apuesta.Respuesta);

            EjecutarQuery();
        }

        public void Eliminar(Entidad entidad)
        {
            ApuestaCantidad apuesta = entidad as ApuestaCantidad;

            StoredProcedure("eliminarapuesta(@idlogro, @idusuario)");

            AgregarParametro("idlogro", apuesta.Logro.Id);
            AgregarParametro("idusuario", apuesta.Usuario.Id);

            EjecutarQuery();
        }

        public List<Entidad> ObtenerApuestasEnCurso(Entidad usuario)
        {
            throw new NotImplementedException();
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