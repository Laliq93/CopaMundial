using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;

namespace CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces
{
    public interface IDAOCiudad : IDAO
    {
        Entidad ConsultarCiudadPorId ( Entidad entidad );

		List<Entidad> ConsultarCiudadPorNombre(Entidad entidad);


		List<Entidad> ConsultarCiudadPorNombreIngles(Entidad entidad);

		List<Entidad> ObtenerTodosHabilitados();
	}
}