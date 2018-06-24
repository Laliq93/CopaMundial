using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;

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
            throw new NotImplementedException ( );
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