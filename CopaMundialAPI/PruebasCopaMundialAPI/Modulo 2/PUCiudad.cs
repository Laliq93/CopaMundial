using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Comun.Excepciones;
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
using CopaMundialAPI.Servicios.Traductores.Ciudades;
using CopaMundialAPI.Servicios.Traductores;
using CopaMundialAPI.Servicios.Traductores.Fabrica;


namespace PruebasCopaMundialAPI
{

	[TestFixture]
	public class PUCiudad
    {
		
		private Ciudad ciudad;
		private DTOCiudad dto;
		private DAOCiudad dao;


		[SetUp]
		public void SetUp()
		{
			
			dto = FabricaDTO.CrearDTOCiudad(1, "yonder", 10, "a", "a", "b");
			dao = FabricaDAO.CrearDAOCiudad();
			ciudad = FabricaEntidades.CrearCiudad("prueba", 5, "prueba", "prueba", "prueba");

		}
		[Test]
		public void AgregarCiudad()
		{
			
			dao.Agregar(ciudad);
			Ciudad ciudadobtenida = (Ciudad)dao.ObtenerTodos().Last();	
			ciudadobtenida.Id = 0;
			ciudad.Id = 0;

			String s =ciudadobtenida.ToString();
			String a = ciudad.ToString();

			Assert.AreEqual(ciudad.Nombre, ciudadobtenida.Nombre);
			
		}


		[Test]
		public void ObtenerCiudad()
		{
			
			dao.Agregar(ciudad);
			Ciudad ciudadobtenida = (Ciudad)dao.ObtenerTodos().Last();
			Console.WriteLine(dao.ObtenerTodos().Last());

			Assert.IsNotNull(ciudadobtenida);
			
		}


		[Test]
		public void ObtenerCiudadPorNombre()
		{
			dao.Agregar(ciudad);
			Ciudad ciudadobtenida = (Ciudad)dao.ConsultarCiudadPorNombre(ciudad).Last();
			Console.WriteLine(dao.ObtenerTodos().Last());
			
			Assert.IsNotNull(ciudadobtenida);
			
		}

		[Test]
		public void ObtenerCiudadPorId()
		{
			Ciudad ciudadobtenida = (Ciudad)dao.ObtenerTodos().Last();

			Ciudad ciudad = new Ciudad(ciudadobtenida.Id);
			Ciudad city = (Ciudad)dao.ConsultarCiudadPorId(ciudad);
			

			Assert.IsNotNull(city);
			
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

		[Test]
		public void TestAgregarCiudadException()
		{
			
			Assert.Catch<ObjetoNullException>(AgregarCiudadException);
		}

		
		public void AgregarCiudadException()
		{
			Ciudad city = null;
			dao.Agregar(city);
			
		}

		[Test]
		public void TestAgregarCiudadCastException()
		{
			
			Assert.Catch<CasteoNoCorrectoException>(AgregarCiudadCastException);
		}


		public void AgregarCiudadCastException()
		{
			Usuario jugador = new Usuario();
			dao.Agregar(jugador);

		}


		[Test]
		public void TestEliminarCiudadException()
		{

			Assert.Catch<ObjetoNullException>(AgregarCiudadException);
		}


		public void EliminarCiudadException()
		{
			Ciudad city = null;
			dao.Eliminar(city);

		}

		[Test]
		public void TestConsultarCiudadException()
		{

			Assert.Catch<ObjetoNullException>(AgregarCiudadException);
		}


		public void ConsultarCiudadException()
		{
			Ciudad city = null;
			dao.ConsultarCiudadPorId(city);

		}

		[Test]
		public void TestConsultarCiudadPorNombreException()
		{

			Assert.Catch<ObjetoNullException>(AgregarCiudadException);
		}


		public void ConsultarCiudadPorNombreException()
		{
			Ciudad city = null;
			dao.ConsultarCiudadPorNombre(city);

		}

		[Test]
		public void TestConsultarCiudadPorNombreInglesException()
		{

			Assert.Catch<ObjetoNullException>(AgregarCiudadException);
		}


		public void ConsultarCiudadPorNombreInglesException()
		{
			Ciudad city = null;
			dao.ConsultarCiudadPorNombreIngles(city);

		}

		[Test]
		public void TestEliminarCiudadCastException()
		{

			Assert.Catch<CasteoNoCorrectoException>(EliminarCiudadCastException);
		}


		public void EliminarCiudadCastException()
		{
			Usuario jugador = new Usuario();
			dao.Eliminar(jugador);

		}

		[Test]
		public void TestConsultarCiudadCastException()
		{

			Assert.Catch<CasteoNoCorrectoException>(ConsultarCiudadCastException);
		}


		public void ConsultarCiudadCastException()
		{
			Usuario jugador = new Usuario();
			dao.ConsultarCiudadPorId(jugador);

		}

		[Test]
		public void TestConsultarCiudadPorNombreCastException()
		{

			Assert.Catch<CasteoNoCorrectoException>(ConsultarCiudadPorNombreCastException);
		}


		public void ConsultarCiudadPorNombreCastException()
		{
			Usuario jugador = new Usuario();
			dao.ConsultarCiudadPorNombre(jugador);

		}

		[Test]
		public void TestConsultarCiudadPorNombreInglesCastException()
		{

			Assert.Catch<CasteoNoCorrectoException>(ConsultarCiudadPorNombreInglesCastException);
		}


		public void ConsultarCiudadPorNombreInglesCastException()
		{
			Usuario jugador = new Usuario();
			dao.ConsultarCiudadPorNombreIngles(jugador);

		}
		[Test]
		public void TestModificarCiudad()
		{
			dao.Agregar(ciudad);
			Ciudad ciudadobtenida = (Ciudad)dao.ObtenerTodos().Last();
			Ciudad ciudadamodificar = new Ciudad(ciudadobtenida.Id,"nombremodificado",5,"descripcionmodificada","NombreEnModificado","DescripcionEnModificado");
			dao.Actualizar(ciudadamodificar);
			Ciudad ciudad1 = (Ciudad)dao.ObtenerTodos().Last();
			
			
			Assert.AreEqual(ciudad1.Nombre, ciudadamodificar.Nombre);
		}

        [Test]
        public void TestTraducirDTOCiudadaCiudad ( )
        {
            Ciudad ciudadEsperada = FabricaEntidades.CrearCiudad ( 1, "nombremodificado", 5, "descripcionmodificada", "NombreEnModificado", "DescripcionEnModificado" );

            Ciudad ciudad = null;

            DTOCiudad dto = FabricaDTO.CrearDTOCiudad ( 1, "nombremodificado", 5, "descripcionmodificada", "NombreEnModificado", "DescripcionEnModificado" );

            TraductorCiudad traductor = FabricaTraductor.CrearTraductorCiudad ( );

            ciudad=traductor.CrearEntidad ( dto ) as Ciudad;

            Assert.AreEqual ( ciudad.Id,ciudadEsperada.Id );
            Assert.AreEqual ( ciudad.Nombre, ciudadEsperada.Nombre );
            Assert.AreEqual ( ciudad.Habitantes, ciudadEsperada.Habitantes );
            Assert.AreEqual ( ciudad.Habilitado, ciudadEsperada.Habilitado );
            Assert.AreEqual ( ciudad.NombreIngles, ciudadEsperada.NombreIngles );
            Assert.AreEqual ( ciudad.DescripcionIngles, ciudadEsperada.DescripcionIngles );

        }

        [Test]
        public void TestTraducirCiudadaDTOCiudad ( )
        {
            DTOCiudad dtoEsperado = FabricaDTO.CrearDTOCiudad ( 1, "nombremodificado", 5, "descripcionmodificada", "NombreEnModificado", "DescripcionEnModificado" );

            DTOCiudad dto = null;

            Ciudad ciudad = FabricaEntidades.CrearCiudad ( 1, "nombremodificado", 5, "descripcionmodificada", "NombreEnModificado", "DescripcionEnModificado" );

            TraductorCiudad traductor = FabricaTraductor.CrearTraductorCiudad ( );

            Entidad entidad = ciudad as Ciudad;

            dto = traductor.CrearDto ( entidad ) ;

            Assert.AreEqual ( dto.Id, dtoEsperado.Id );
            Assert.AreEqual ( dto.Nombre, dtoEsperado.Nombre );
            Assert.AreEqual ( dto.Habitantes, dtoEsperado.Habitantes );
            Assert.AreEqual ( dto.Habilitado, dtoEsperado.Habilitado );
            Assert.AreEqual ( dto.NombreIngles, dtoEsperado.NombreIngles );
            Assert.AreEqual ( dto.DescripcionIngles, dtoEsperado.DescripcionIngles );

        }

        [Test]
        public void TestTraducirCiudadaDTOCiudadNombre ( )
        {
            DTOCiudadNombre dtoEsperado = FabricaDTO.CrearDTOCiudadNombre ( "nombremodificado");

            DTOCiudadNombre dto = null;

            Ciudad ciudad = FabricaEntidades.CrearCiudad ("nombremodificado", 5, "descripcionmodificada", "NombreEnModificado", "DescripcionEnModificado" );

            TraductorCiudadNombre traductor = FabricaTraductor.CrearTraductorCiudadNombre ( );

            Entidad entidad = ciudad as Ciudad;

            dto = traductor.CrearDto ( entidad );

            Assert.AreEqual ( dto.Nombre, dtoEsperado.Nombre );


        }

        [Test]
        public void TestTraducirDTOCiudadNombreaCiudad ( )
        {
            DTOCiudadNombre dtoEsperado = FabricaDTO.CrearDTOCiudadNombre ("nombremodificado");

            DTOCiudadNombre dto = null;

            Ciudad ciudad = FabricaEntidades.CrearCiudad ( 1, "nombremodificado", 5, "descripcionmodificada", "NombreEnModificado", "DescripcionEnModificado" );

            TraductorCiudadNombre traductor = FabricaTraductor.CrearTraductorCiudadNombre ( );

            Entidad entidad = ciudad as Ciudad;

            dto = traductor.CrearDto ( entidad );

            Assert.AreEqual ( dto.Nombre, dtoEsperado.Nombre );

        }

        [Test]
        public void TestTraducirCiudadaDTOCiudadID ( )
        {
            DTOCiudadID dtoEsperado = FabricaDTO.CrearDTOCiudadId ( 1 );

            DTOCiudadID dto = null;

            Ciudad ciudad = FabricaEntidades.CrearCiudad (1, "nombremodificado", 5, "descripcionmodificada", "NombreEnModificado", "DescripcionEnModificado" );

            TraductorCiudadID traductor = FabricaTraductor.CrearTraductorCiudadID ( );

            Entidad entidad = ciudad as Ciudad;

            dto = traductor.CrearDto ( entidad );

            Assert.AreEqual ( dto.Id, dtoEsperado.Id );


        }
        

        [Test]
        public void TestTraducirDTOCiudadIDaCiudad ( )
        {
            DTOCiudadID dtoEsperado = FabricaDTO.CrearDTOCiudadId ( 1 );

            DTOCiudadID dto = null;

            Ciudad ciudad = FabricaEntidades.CrearCiudad ( 1, "nombremodificado", 5, "descripcionmodificada", "NombreEnModificado", "DescripcionEnModificado" );

            TraductorCiudadID traductor = FabricaTraductor.CrearTraductorCiudadID ( );

            Entidad entidad = ciudad as Ciudad;

            dto = traductor.CrearDto ( entidad );

            Assert.AreEqual ( dto.Id, dtoEsperado.Id );



        }


        [TearDown]
		public void TeadDown()
		{
			
			dto = null;
			dao = null;
		}

    }
}
