using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Ciudades
{
    /// <summary>
    /// Comando que se encarga de agregar una ciudad de tipo Entidad
    /// </summary>
    public class ComandoAgregarCiudad : Comando
    {
        /// <summary>
        /// Constructor de la clase 
        /// </summary>
        /// <param name="ciudad">Instancia ciudad que se desea insertar</param>
        public ComandoAgregarCiudad(Entidad ciudad)
        {
            Entidad = ciudad;
        }

        public override void Ejecutar()
        {
            try
            {
                IDAOCiudad dao = FabricaDAO.CrearDAOCiudad ( );
                dao.Agregar ( Entidad );
            }
            catch(Exception e)
            {
                throw e;
            }
           


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