using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;

namespace CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces
{
    public interface IDAOApuesta
    {
        void AgregarApuesta(Apuesta apuesta);

        void ActualizarApuesta(Apuesta apuesta);

        void EliminarApuesta(Apuesta apuesta);

        List<Apuesta> ObtenerApuestasUsuario(Entidad usuario);


    }
}