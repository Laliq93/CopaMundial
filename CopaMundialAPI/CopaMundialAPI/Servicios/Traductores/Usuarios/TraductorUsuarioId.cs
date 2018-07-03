using System;
using System.Collections.Generic;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Servicios.DTO.Usuario;
using CopaMundialAPI.Comun.Excepciones;
using System.Web;

namespace CopaMundialAPI.Servicios.Traductores.Usuarios
{
    public class TraductorUsuarioId : TraductorGenerico<DTOUsuarioId>
    {
        public override DTOUsuarioId CrearDto(Entidad entidad)
        {
            throw new NotImplementedException();
        }

        public override Entidad CrearEntidad(DTOUsuarioId dto)
        {
            try
            {
                Usuario usuario = FabricaEntidades.CrearUsuarioVacio();

                usuario.Id = dto.IdUsuario;

                return usuario;
            }
            catch (NullReferenceException exc)
            {
                throw new ObjetoNullException(exc, "Ha ocurrido un error al recibir la información del usuario.");
            }
        }

        public override List<DTOUsuarioId> CrearListaDto(List<Entidad> entidades)
        {
            throw new NotImplementedException();
        }

        public override List<Entidad> CrearListaEntidades(List<DTOUsuarioId> dtos)
        {
            throw new NotImplementedException();
        }
    }
}