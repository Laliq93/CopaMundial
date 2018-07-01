using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Partidos
{
    public class ComandoCrearPartido : Comando
    {
        public ComandoCrearPartido(Entidad entidad)
        {
            Entidad = entidad;
        }

        public override void Ejecutar()
        {
            IDAOPartido dao = FabricaDAO.CrearDAOPartido();
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