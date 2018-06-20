using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;

namespace CopaMundialAPI.Logica_de_Negocio.Comando
{
    public class ComandoAgregarCiudad : Comando
    {
        private Ciudad _ciudad;

        public ComandoAgregarCiudad(Ciudad ciudad)
        {
            this._ciudad = ciudad;
        }

        public override void Ejecutar()
        {
            DAOCiudad dao = FabricaDAO.CrearDAOCiudad();
            dao.InsertarCiudad(_ciudad);

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