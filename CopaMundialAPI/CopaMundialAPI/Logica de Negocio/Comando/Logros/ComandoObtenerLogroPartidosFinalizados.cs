﻿using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Logros
{
    public class ComandoObtenerLogroPartidosFinalizados: Comando
    {

        private List<Entidad> _partidos;
        private DAOLogroPartido _dao;

        public ComandoObtenerLogroPartidosFinalizados()
        {
            _partidos = new List<Entidad>();
            _dao = FabricaDAO.CrearDAOLogroPartido();
        }

        public override void Ejecutar()
        {
            _partidos = _dao.ObtenerLogroPartidosFinalizados();
        }

        public override Entidad GetEntidad()
        {
            throw new NotImplementedException();
        }

        public override List<Entidad> GetEntidades()
        {
            return _partidos;
        }
    }
}
