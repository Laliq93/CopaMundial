using System;
using System.Collections.Generic;
using System.Linq;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Servicios.DTO.Usuario;
using CopaMundialAPI.Servicios.Fabrica;
using CopaMundialAPI.Comun.Excepciones;
using System.Web;

namespace CopaMundialAPI.Servicios.Traductores.Usuarios
{
    public class TraductorUsuarioRegistrar : TraductorGenerico<DTOUsuarioRegistrar>
    {
        public override DTOUsuarioRegistrar CrearDto(Entidad entidad)
        {
            throw new NotImplementedException();
        }

        public override Entidad CrearEntidad(DTOUsuarioRegistrar dto)
        {
            try
            {
                Usuario usuario = FabricaEntidades.CrearUsuarioVacio();

                usuario.Id = dto.IdUsuario;
                usuario.NombreUsuario = dto.NombreUsuario;
                usuario.Nombre = dto.Nombre;
                usuario.Apellido = dto.Apellido;
                usuario.FechaNacimiento = dto.FechaNacimiento;
                usuario.Correo = dto.Correo;
                usuario.Genero = dto.Genero;
                usuario.Password = dto.Password;
                usuario.EsAdmin = false;
                usuario.Activo = true;

                return usuario;
            }
            catch (NullReferenceException exc)
            {
                throw new ObjetoNullException(exc, "Ha ocurrido un error al recibir la información del usuario.");
            }
        }

        public override List<DTOUsuarioRegistrar> CrearListaDto(List<Entidad> entidades)
        {
            throw new NotImplementedException();
        }

        public override List<Entidad> CrearListaEntidades(List<DTOUsuarioRegistrar> dtos)
        {
            throw new NotImplementedException();
        }
    }
}