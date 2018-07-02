using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.EquipoEstatico
{
    public class ComandoObtenerTodosLosEquipos : Comando
    {
        private List<Entidad> _respuesta;

        public override void Ejecutar()
        {
            Equipos estadios = new Equipos();
            _respuesta = estadios.ListaEquipos.Cast<Entidad>().ToList();
        }

        public override Entidad GetEntidad()
        {
            throw new NotImplementedException();
        }

        public override List<Entidad> GetEntidades()
        {
            return _respuesta;
        }
    }
}