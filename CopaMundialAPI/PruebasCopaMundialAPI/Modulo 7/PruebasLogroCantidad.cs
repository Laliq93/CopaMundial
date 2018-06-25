﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;
using NUnit.Framework;

namespace PruebasCopaMundialAPI.Modulo_7
{
    [TestFixture]
    public class PruebasLogroCantidad
    {
        private Entidad logro;
        private DAO dao;
        private Entidad respuesta;

        [SetUp]
        public void SetUp()
        {
            dao = FabricaDAO.CrearDAOLogroCantidad();
            dao.StoredProcedure("AsignarLogroPU(500,'PruebaLogroCantidad',1,1)");
            dao.EjecutarQuery();
            dao.Conectar();

        }

        [Test]
        public void PruebaDaoLogroCantidadAgregar()
        {
            LogroCantidad logro = FabricaEntidades.CrearLogroCantidad();
            logro.Id = 500;
            logro.IdTipo = TipoLogro.cantidad;
            logro.Logro = "Logro Prueba Agregar";
            logro.Cantidad = 1;

            ((DAOLogroCantidad)dao).Agregar(logro);
            respuesta = ((DAOLogroCantidad)dao).ObtenerLogroPorId(logro);
            Assert.AreEqual(logro.Id, respuesta.Id);

        }


        [TearDown]
        public void TearDown()
        {
            logro = null;
            dao = null;
            respuesta = null;
            dao.Desconectar();
        }

    }
}