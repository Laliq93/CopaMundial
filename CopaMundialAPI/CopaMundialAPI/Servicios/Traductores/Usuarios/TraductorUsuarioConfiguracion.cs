using System;
using System.Collections.Generic;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Servicios.DTO.Usuario;
using CopaMundialAPI.Comun.Excepciones;
using CopaMundialAPI.Servicios.Fabrica;
using System.Web;

namespace CopaMundialAPI.Servicios.Traductores.Usuarios
{
    public class TraductorUsuarioConfiguracion : TraductorGenerico<DTOUsuarioConfiguracion>
    {
        public override DTOUsuarioConfiguracion CrearDto(Entidad entidad)
        {
            DTOUsuarioConfiguracion dto = FabricaDTO.CrearDtoUsuarioConfiguracion();

            Usuario usuario = entidad as Usuario;

            dto.Id = usuario.Id;
            dto.NombreUsuario = usuario.NombreUsuario;
            dto.Nombre = usuario.Nombre;
            dto.Apellido = usuario.Apellido;
            dto.FechaNacimiento = usuario.FechaNacimiento;
            dto.Correo = usuario.Correo;
            dto.Activo = usuario.Activo;

            return dto;
        }

        public override Entidad CrearEntidad(DTOUsuarioConfiguracion dto)
        {
            try
            {
                Usuario usuario = FabricaEntidades.CrearConfiguracionUsuario(dto.Id, dto.NombreUsuario, dto.Nombre, dto.Apellido, dto.FechaNacimiento,
                    dto.Correo, dto.Activo);

                return usuario;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override List<DTOUsuarioConfiguracion> CrearListaDto(List<Entidad> entidades)
        {
            try
            {
                List<DTOUsuarioConfiguracion> dto = new List<DTOUsuarioConfiguracion>();

                foreach (Entidad usuario in entidades)
                {
                    dto.Add(CrearDto(usuario));
                }

                return dto;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override List<Entidad> CrearListaEntidades(List<DTOUsuarioConfiguracion> dto)
        {
            try
            {
                List<Entidad> usuarios = new List<Entidad>();

                foreach (DTOUsuarioConfiguracion dtousuarioconfiguracion in dto)
                {
                    usuarios.Add(CrearEntidad(dtousuarioconfiguracion));
                }

                return usuarios;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}