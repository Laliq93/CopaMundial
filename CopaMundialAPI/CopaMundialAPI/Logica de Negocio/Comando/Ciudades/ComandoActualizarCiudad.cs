using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Ciudades
{
    public class ComandoActualizarCiudad : Comando
    {
        protected ComandoActualizarCiudad ( Entidad ciudad )
        {
            Entidad = ciudad;
        }

        public override void Ejecutar ( )
        {
            IDAOCiudad dao = FabricaDAO.CrearDAOCiudad ( );
            dao.Actualizar ( Entidad );
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