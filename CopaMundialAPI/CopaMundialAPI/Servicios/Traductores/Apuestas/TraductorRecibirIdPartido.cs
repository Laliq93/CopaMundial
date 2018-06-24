using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Servicios.DTO.Apuestas;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Comun.Excepciones;

namespace CopaMundialAPI.Servicios.Traductores.Apuestas
{
    public class TraductorRecibirIdPartido : TraductorGenerico<DTORecibirIdPartido>
    {
        public override DTORecibirIdPartido CrearDto(Entidad entidad)
        {
            throw new NotImplementedException();
        }

        public override Entidad CrearEntidad(DTORecibirIdPartido dto)
        {
            try
            {
                Partido partido = new Partido();

                partido.Id = dto.IdPartido;

                return partido;
            }
            catch (NullReferenceException exc)
            {
                throw new ObjetoNullException(exc, "Ha ocurrido un error al recibir la información del partido");
            }
        }

        public override List<DTORecibirIdPartido> CrearListaDto(List<Entidad> entidades)
        {
            throw new NotImplementedException();
        }

        public override List<Entidad> CrearListaEntidades(List<DTORecibirIdPartido> dtos)
        {
            throw new NotImplementedException();
        }
    }
}