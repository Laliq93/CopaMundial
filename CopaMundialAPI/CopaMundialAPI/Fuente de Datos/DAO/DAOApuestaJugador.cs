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
    public class DAOApuestaJugador : DAO, IDAOApuesta
    {
        public void Actualizar(Entidad entidad)
        {
            ApuestaJugador apuesta = entidad as ApuestaJugador;

            StoredProcedure("editarapuestajugador(@idlogro, @idusuario, @apuesta)");

            AgregarParametro("idlogro", apuesta.Logro.Id);
            AgregarParametro("idusuario", apuesta.Usuario.Id);
            AgregarParametro("apuesta", apuesta.Respuesta.Id);

            EjecutarQuery();
        }

        public void Agregar(Entidad entidad)
        {
            Conectar();

            ApuestaJugador apuesta = entidad as ApuestaJugador;

            StoredProcedure("agregarapuestajugador(@idlogro, @idusuario, @apuesta)");

            AgregarParametro("idlogro", apuesta.Logro.Id);
            AgregarParametro("idusuario", apuesta.Usuario.Id);
            AgregarParametro("apuesta", apuesta.Respuesta.Id);

            EjecutarQuery();
        }

        public void Eliminar(Entidad entidad)
        {
            ApuestaJugador apuesta = entidad as ApuestaJugador;

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

            ApuestaJugador apuestajugador = apuesta as ApuestaJugador;

            StoredProcedure("verificarapuestaexiste(@idusuario, @idlogro)");

            AgregarParametro("idusuario", apuestajugador.Usuario.Id);
            AgregarParametro("idlogro", apuestajugador.Logro.Id);

            EjecutarReader();

            int count = GetInt(0, 0);

            if (count > 0)
                throw new ApuestaRepetidaException();
        }
    
    }
}