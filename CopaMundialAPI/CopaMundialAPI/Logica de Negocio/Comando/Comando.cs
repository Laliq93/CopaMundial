using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;

namespace CopaMundialAPI.Logica_de_Negocio.Comando
{
    public abstract class Comando
    {
        public abstract void Ejecutar ( );

        public abstract Entidad GetEntidad();

        public abstract List<Entidad> GetEntidades();
    }
}