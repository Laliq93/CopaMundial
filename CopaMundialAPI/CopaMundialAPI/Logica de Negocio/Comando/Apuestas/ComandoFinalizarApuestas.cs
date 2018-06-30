using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Logica_de_Negocio.Fabrica;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Apuestas
{
    public class ComandoFinalizarApuestas : Comando
    {
        Comando _comando;

        public override void Ejecutar()
        {
            _comando = FabricaComando.CrearComandoFinalizarApuestasCantidad();
            _comando.Ejecutar();

            _comando = FabricaComando.CrearComandoFinalizarApuestasVoF();
            _comando.Ejecutar();

            _comando = FabricaComando.CrearComandoFinalizarApuestasJugador();
            _comando.Ejecutar();

            _comando = FabricaComando.CrearComandoFinalizarApuestasEquipo();
            _comando.Ejecutar();
        }

        public override Entidad GetEntidad()
        {
            throw new NotImplementedException();
        }

        public override List<Entidad> GetEntidades()
        {
            throw new NotImplementedException();
        }
    }
}