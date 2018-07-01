using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.EstadioEstatico
{
    public class ComandoObtenerEstadioEstatico : Comando
    {
        private Entidad _respuesta;

        public ComandoObtenerEstadioEstatico(Entidad entidad)
        {
            Entidad = entidad;
        }

        public override void Ejecutar()
        {
            Estadios estadios = new Estadios();
            _respuesta = estadios.GetEstadio(Entidad.Id);
        }

        public override Entidad GetEntidad()
        {
            return _respuesta;
        }

        public override List<Entidad> GetEntidades()
        {
            throw new NotImplementedException();
        }
    }
}