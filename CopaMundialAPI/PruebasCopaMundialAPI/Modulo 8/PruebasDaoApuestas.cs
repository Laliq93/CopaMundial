using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Excepciones;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;
using CopaMundialAPI.Comun.Entidades.Fabrica;

namespace PruebasCopaMundialAPI.Modulo_8
{
    [TestFixture]
    public class PruebasDaoApuestas
    {
        Usuario _apostador;

        LogroVoF _logroVoF;
        LogroCantidad _logroCantidad;
        LogroJugador _logroJugador;
        LogroEquipo _logroEquipo;



        [SetUp]
        public void Init()
        {
            _apostador = FabricaEntidades.CrearUsuarioVacio();
            _apostador.Id = 1;

            _logroVoF = FabricaEntidades.CrearLogroVoF();
            _logroVoF.Id = 4;

            _logroCantidad = FabricaEntidades.CrearLogroCantidad();
            _logroCantidad.Id = 1;

            _logroEquipo = FabricaEntidades.CrearLogroEquipo();
            _logroEquipo.Id = 3;

            _logroJugador = FabricaEntidades.CrearLogroJugador();
            _logroJugador.Id = 2;
        }

        [Test]
        public void AgregarApuestaVoFTest()
        {

        }
    }
}
