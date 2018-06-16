using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces;

namespace CopaMundialAPI.Fuente_de_Datos.DAO
{
    public class DAOApuesta : DAO, IDAOApuesta
    {
        public void ActualizarApuesta(Apuesta apuesta)
        {
            throw new NotImplementedException();
        }

        public void AgregarApuesta(Apuesta apuesta)
        {
            Conectar();

            StoredProcedure("CrearApuestaUsuario(@idUsuario, @idLogro, @Contenido, @Fecha)");

            //AgregarParametro("idUsuario", apuesta.Usuario.Id);
            //AgregarParametro("idLogro", apuesta.Logro.Id);
            AgregarParametro("Contenido", apuesta.Contenido);
            AgregarParametro("Fecha", apuesta.Fecha);

            EjecutarQuery();

        }

        public void EliminarApuesta(Apuesta apuesta)
        {
            throw new NotImplementedException();
        }

        public List<Apuesta> ObtenerApuestasUsuario(Entidad usuario)
        {
            List<Apuesta> apuestas = new List<Apuesta>();

            Apuesta apuesta;

            Conectar();

            StoredProcedure("ObtenerApuestasUsuario(@usuarioId)");
            AgregarParametro("usuario", usuario.Id);

            EjecutarReader();

            for(int i = 0; i < cantidadRegistros; i++)
            {
                apuesta = new Apuesta();

                //apuesta.Usuario.Id = usuario.Id;
                //apuesta.Logro.Id = GetInt(i,0);
                apuesta.Contenido = GetString(i, 1);
                apuesta.Resultado = GetString(i, 2);
                apuesta.Fecha = GetDateTime(i, 3);

                apuestas.Add(apuesta);
            }

            return apuestas;

        }
    }
}