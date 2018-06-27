using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Ciudades
{
	public class ComandoObtenerCiudad : Comando
	{
		private int _id;

		public ComandoObtenerCiudad(int id)
		{
			_id = id;
		}

		public override void Ejecutar()
		{			
			DAOCiudad dao = FabricaDAO.CrearDAOCiudad();
			//dao.ConsultarCiudadPorId()
			
		}

		public override Entidad GetEntidad()
		{
			return Entidad;
		}

		public override List<Entidad> GetEntidades()
		{
			throw new NotImplementedException();
		}
	}
}