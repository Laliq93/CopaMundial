﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;
using CopaMundialAPI.Logica_de_Negocio.Fabrica;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Partidos
{
    public class ComandoCrearAlineacion : Comando
    {
        private Comando _comando;

        public ComandoCrearAlineacion(Entidad entidad)
        {
            Entidad = entidad;
        }

        public override void Ejecutar()
        {
            _comando = FabricaComando.CrearComandoValidarAlineacion(Entidad);
            _comando.Ejecutar();

            IDAOAlineacion dao = FabricaDAO.CrearDAOAlineacion();
            dao.Agregar(Entidad);
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