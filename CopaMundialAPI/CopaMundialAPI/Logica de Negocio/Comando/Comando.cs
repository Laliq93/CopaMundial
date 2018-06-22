using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;

namespace CopaMundialAPI.Logica_de_Negocio.Comando
{
    /// <summary>
    /// Superclase Comando
    /// </summary>
    public abstract class Comando
    {
        private Entidad entidad;

        public Entidad Entidad { get => entidad; set => entidad = value; }

        public abstract void Ejecutar ( );

        public abstract Entidad GetEntidad();

        public abstract List<Entidad> GetEntidades();
    }
}