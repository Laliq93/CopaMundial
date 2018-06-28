using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Excepciones;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Apuestas
{
    public class ComandoVerificarApuestaCantidadValida : Comando
    {
        DAOApuestaCantidad _dao;
        Entidad _apuesta;

        public ComandoVerificarApuestaCantidadValida(Entidad apuesta)
        {
            _apuesta = apuesta;
            _dao = FabricaDAO.CrearDAOApuestaCantidad();
        }

        public override void Ejecutar()
        {
            int count = _dao.VerificarApuestaValidaParaEditar(_apuesta);

            if (count < 1)
                throw new ApuestaInvalidaException();
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