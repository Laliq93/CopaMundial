using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;
using CopaMundialAPI.Logica_de_Negocio.Fabrica;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Apuestas
{
    public class ComandoAgregarUsuario : Comando
    {
        //private Comando _comando;

        public ComandoAgregarUsuario(Entidad usuario)
        {
            Entidad = usuario;
        }

        public override void Ejecutar()
        {

            //faltan verificaciones
            DAOUsuario dao = FabricaDAO.CrearDAOUsuario();

            dao.AgregarNuevo(Entidad);
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