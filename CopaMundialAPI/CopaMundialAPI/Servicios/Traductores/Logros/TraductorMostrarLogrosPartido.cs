using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Servicios.DTO.Logros;
using CopaMundialAPI.Servicios.Fabrica;

namespace CopaMundialAPI.Servicios.Traductores.Logros
{
    public class TraductorMostrarLogrosPartido : TraductorGenerico<DTOMostrarLogrosPartido>
    {
        public override DTOMostrarLogrosPartido CrearDto(Entidad entidad)
        {
            LogroPartido _logro;

            DTOMostrarLogrosPartido _dto;

            try
            {
                _logro = entidad as LogroPartido;
                _dto = FabricaDTO.CrearDTOMostrarLogrosPartido();

                _dto.IdLogro = _logro.Id;
                _dto.Logro = _logro.Logro;

                return _dto;

            }
            catch (InvalidCastException exc)
            {
                throw exc;
            }
        }

        public override Entidad CrearEntidad(DTOMostrarLogrosPartido dto)
        {
            throw new NotImplementedException();
        }

        public override List<DTOMostrarLogrosPartido> CrearListaDto(List<Entidad> entidades)
        {
            List<DTOMostrarLogrosPartido> _dtos = new List<DTOMostrarLogrosPartido>();

            foreach (Entidad logro in entidades)
            {
                _dtos.Add(CrearDto(logro));
            }

            return _dtos;
        }

        public override List<Entidad> CrearListaEntidades(List<DTOMostrarLogrosPartido> dtos)
        {
            throw new NotImplementedException();
        }
    }
}