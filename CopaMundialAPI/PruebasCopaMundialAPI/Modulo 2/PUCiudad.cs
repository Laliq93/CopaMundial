using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;
using CopaMundialAPI.Presentacion.Controllers;
using CopaMundialAPI.Servicios.DTO.Ciudades;
using CopaMundialAPI.Servicios.Fabrica;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasCopaMundialAPI
{

	[TestFixture]
	public class PUCiudad
    {
		private CiudadController controller;
		private Ciudad ciudad;
		private DTOCiudad dto;
		private DAOCiudad dao;


		[SetUp]
		public void SetUp()
		{
			controller = new CiudadController();
			dto = FabricaDTO.CrearDTOCiudad(1, "yonder", 10, "a", "a", "b");
			dao = FabricaDAO.CrearDAOCiudad();
			ciudad = FabricaEntidades.CrearCiudad("prueba", 5, "prueba", "prueba", "prueba");

		}
		[Test]
		public void AgregarCiudad()
		{
			//controller.InsertarCiudad(dto);
			dao.Agregar(ciudad);
			Console.WriteLine(ciudad);
			Ciudad ciudadobtenida = (Ciudad)dao.ObtenerTodos().Last();
				Console.WriteLine(dao.ObtenerTodos().Last());
			ciudadobtenida.Id = 0;
			ciudad.Id = 0;

			String s =ciudadobtenida.ToString();
			String a = ciudad.ToString();

			Assert.AreEqual(ciudad.Nombre, ciudadobtenida.Nombre);
			
			//Assert.AreSame(ciudadobtenida, ciudad);
		}


		[Test]
		public void ObtenerCiudad()
		{
			//dao.Agregar(ciudad);
			//controller.InsertarCiudad(dto);
				dao.Agregar(ciudad);
			Ciudad ciudadobtenida = (Ciudad)dao.ObtenerTodos().Last();
			Console.WriteLine(dao.ObtenerTodos().Last());

			Assert.IsNotNull(ciudadobtenida);
			//Assert.AreSame(ciudadobtenida, ciudad);
		}


		[Test]
		public void ObtenerCiudadPorNombre()
		{
			//dao.Agregar(ciudad);
			//controller.InsertarCiudad(dto);
			dao.Agregar(ciudad);
			Ciudad ciudadobtenida = (Ciudad)dao.ConsultarCiudadPorNombre(ciudad).Last();
			Console.WriteLine(dao.ObtenerTodos().Last());
			
			Assert.IsNotNull(ciudadobtenida);
			//Assert.AreSame(ciudadobtenida, ciudad);
		}

		[Test]
		public void ObtenerCiudadPorId()
		{
			//dao.Agregar(ciudad);
			//controller.InsertarCiudad(dto);
			//Ciudad ciudad = FabricaEntidades.CrearCiudad(24, "prueba", 5, "prueba", "prueba", "prueba");
			Ciudad ciudadobtenida = (Ciudad)dao.ObtenerTodos().Last();

			Ciudad ciudad = new Ciudad(ciudadobtenida.Id);
			//dao.Agregar(ciudad);
			Ciudad city = (Ciudad)dao.ConsultarCiudadPorId(ciudad);
			Console.WriteLine(dao.ObtenerTodos().Last());

			Assert.IsNotNull(city);
			//Assert.AreSame(ciudadobtenida, ciudad);
		}

		[Test]
		public void EliminarCiudad()
		{
			//dao.Agregar(ciudad);
			//controller.InsertarCiudad(dto);
			//Ciudad city = FabricaEntidades.CrearCiudad(24, "prueba", 5, "prueba", "prueba", "prueba");
			Ciudad ciudadobtenida = (Ciudad)dao.ObtenerTodos().Last();

			Ciudad ciudad = new Ciudad(ciudadobtenida.Id);
			//dao.Agregar(ciudad);
			dao.Eliminar(ciudad);
			//Console.WriteLine(dao.ObtenerTodos().Last());
			//dao.Agregar(ciudad);
			Ciudad city = (Ciudad)dao.ConsultarCiudadPorId(ciudad);

			Assert.IsNull(city);
			//Assert.AreSame(ciudadobtenida, ciudad);
		}

		[TearDown]
		public void TeadDown()
		{
			controller = null;
			dto = null;
			dao = null;
		}

    }
}
