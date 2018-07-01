using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.EquipoEstatico
{
    public class ComandoObtenerEquipoEstatico : Comando
    {
        private Entidad _respuesta;

        public ComandoObtenerEquipoEstatico(Entidad entidad)
        {
            Entidad = entidad;
        }
        public override void Ejecutar()
        {
            Equipos equipos = new Equipos();
            _respuesta = equipos.GetEquipo(Entidad.Id);
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