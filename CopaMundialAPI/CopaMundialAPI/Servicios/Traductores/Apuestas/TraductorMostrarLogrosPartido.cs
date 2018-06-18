using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Servicios.DTO.Apuestas;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Servicios.Fabrica;

namespace CopaMundialAPI.Servicios.Traductores.Apuestas
{
    public class TraductorMostrarLogrosPartido : TraductorGenerico<DTOListarLogros, Apuesta>
    {
        public override DTOListarLogros CrearDto(Apuesta entidad)
        {
            DTOListarLogros dto = FabricaDTO.CrearDtoListarLogros();

            //dto.IdLogro = entidad.Logro.Id;
            //dto.Contenido = entidad.Logro.Contenido;

            return dto;
        }

        public override Apuesta CrearEntidad(DTOListarLogros dto)
        {
            throw new NotImplementedException();
        }

        public override List<DTOListarLogros> CrearListaDto(List<Apuesta> entidades)
        {
            List<DTOListarLogros> dtos = new List<DTOListarLogros>();

            foreach (Apuesta apuesta in entidades)
            {
                dtos.Add(CrearDto(apuesta));
            }

            return dtos;
        }

        public override List<Apuesta> CrearListaEntidades(List<DTOListarLogros> dtos)
        {
            throw new NotImplementedException();
        }
    }
}