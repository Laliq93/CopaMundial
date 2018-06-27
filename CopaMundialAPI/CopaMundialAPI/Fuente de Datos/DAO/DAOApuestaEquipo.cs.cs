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
            throw new NotImplementedException();
        }

        public void Agregar(Entidad entidad)
        {
            Conectar();

            ApuestaEquipo apuesta = entidad as ApuestaEquipo;

            StoredProcedure("agregarapuestaequipo(@idlogro, @idusuario, @apuesta)");

            AgregarParametro("idlogro", apuesta.Logro.Id);
            AgregarParametro("idusuario", apuesta.Usuario.Id);
            AgregarParametro("apuesta", apuesta.Respuesta.Id);

            EjecutarQuery();
        }

        public void Eliminar(Entidad entidad)
        {
            ApuestaEquipo apuesta = entidad as ApuestaEquipo;

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

        public void VerificarApuestaExiste(Entidad apuesta)
        {
            Conectar();

            ApuestaEquipo apuestaequipo = apuesta as ApuestaEquipo;

            StoredProcedure("verificarapuestaexiste(@idusuario, @idlogro)");

            AgregarParametro("idusuario", apuestaequipo.Usuario.Id);
            AgregarParametro("idlogro", apuestaequipo.Logro.Id);

            EjecutarReader();

            int count = GetInt(0, 0);

            if (count > 0)
                throw new ApuestaRepetidaException();
        }
    
    }
}