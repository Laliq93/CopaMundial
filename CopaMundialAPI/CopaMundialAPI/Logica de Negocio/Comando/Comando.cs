using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;

namespace CopaMundialAPI.Logica_de_Negocio.Comando
{
    public abstract class Comando<Type>
    {
        public abstract void Ejecutar ( );

        public abstract Type GetEntidad();

        public abstract List<Type> GetEntidades();
    }
}