using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Servicios.DTO.Apuestas;
using CopaMundialAPI.Comun.Entidades.Fabrica;

namespace CopaMundialAPI.Servicios.Traductores.Apuestas
{
    public class TraductorCrearApuesta : TraductorGenerico<DTOApuesta, Apuesta>
    {
        public override DTOApuesta CrearDto(Apuesta entidad)
        {
            throw new NotImplementedException();
        }

        public override Apuesta CrearEntidad(DTOApuesta dto)
        {
            //Apuesta apuesta = FabricaEntidades.CrearApuesta();

            //apuesta.Usuario.Id = dto.IdUsuario;
            //apuesta.Logro.Id = dto.IdLogro;
            //apuesta.Contenido = dto.Contenido;
            //apuesta.Fecha = DateTime.Now;

            //return apuesta;

            return null;
        }

        public override List<DTOApuesta> CrearListaDto(List<Apuesta> entidades)
        {
            throw new NotImplementedException();
        }

        public override List<Apuesta> CrearListaEntidades(List<DTOApuesta> dtos)
        {
            throw new NotImplementedException();
        }
    }
}