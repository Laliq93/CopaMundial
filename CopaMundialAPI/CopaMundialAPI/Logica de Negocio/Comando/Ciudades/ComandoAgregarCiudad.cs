using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Ciudades
{
    public class ComandoAgregarCiudad : Comando
    {

        public ComandoAgregarCiudad(Ciudad ciudad)
        {
            Entidad = ciudad;
        }

        public override void Ejecutar()
        {
           
            DAOCiudad dao = FabricaDAO.CrearDAOCiudad();
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