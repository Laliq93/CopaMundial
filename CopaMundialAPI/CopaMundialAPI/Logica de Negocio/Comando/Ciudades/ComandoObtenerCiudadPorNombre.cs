using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Ciudades
{
	public class ComandoObtenerCiudadPorNombre :Comando
	{

		private List<Entidad> ciudad;
        /// <summary>
        /// Constructor de la clase 
        /// </summary>
        /// <param name="ciudad">Instancia ciudad que se desea insertar</param>
        public ComandoObtenerCiudadPorNombre(Entidad ciudad)
		{
			Entidad = ciudad;
		}

		public override void Ejecutar()
		{
			try
			{
				IDAOCiudad dao = FabricaDAO.CrearDAOCiudad();
				this.ciudad =dao.ConsultarCiudadPorNombre(Entidad);
			}
			catch (Exception e)
			{
				throw e;
			}



		}

		public override Entidad GetEntidad()
		{
			return Entidad;
		}

		public override List<Entidad> GetEntidades()
		{
			return this.ciudad;
		}
	}
}
