﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Excepciones;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Apuestas
{
    public class ComandoVerificarApuestaEquipoExiste : Comando
    {
        IDAOApuesta _dao;

        public ComandoVerificarApuestaEquipoExiste(Entidad apuesta)
        {
            Entidad = apuesta;
            _dao = FabricaDAO.CrearDAOApuestaEquipo();
        }

        public override void Ejecutar()
        {
            int count = _dao.VerificarApuestaExiste(Entidad);

            if (count > 0)
                throw new ApuestaRepetidaException();
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