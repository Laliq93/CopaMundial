using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Excepciones;
using CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;
using CopaMundialAPI.Logica_de_Negocio.Fabrica;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Partidos
{
    public class ComandoValidarAlineacion : Comando
    {
        private Comando _comando;

        public ComandoValidarAlineacion(Entidad entidad)
        {
            Entidad = entidad;
        }

        public override void Ejecutar()
        {
            _comando = FabricaComando.CrearComandoValidarCapitan(Entidad);
            _comando.Ejecutar();

            _comando = FabricaComando.CrearComandoValidarMaximoJugadores(Entidad);
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