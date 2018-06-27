using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;
using CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Ciudades
{
    public class ComandoEliminarCiudad : Comando
    {
        public ComandoEliminarCiudad ( Entidad ciudad )
        {
            Entidad = ciudad;
        }

        public override void Ejecutar ( )
        {
            try
            {
                IDAOCiudad dao = FabricaDAO.CrearDAOCiudad ( );
                dao.Eliminar ( Entidad );
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public override Entidad GetEntidad ( )
        {
            throw new NotImplementedException ( );
        }

        public override List<Entidad> GetEntidades ( )
        {
            throw new NotImplementedException ( );
        }
    }
}