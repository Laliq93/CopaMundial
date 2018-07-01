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
    public class TraductorUsuario : TraductorGenerico<DTOUsuario>
    {
        public override DTOUsuario CrearDto(Entidad entidad)
        {
            DTOUsuario dto = FabricaDTO.CrearDtoUsuario();

            Usuario usuario = entidad as Usuario;

            dto.Id = usuario.Id;
            dto.NombreUsuario = usuario.NombreUsuario;
            dto.Nombre = usuario.Nombre;
            dto.Apellido = usuario.Apellido;
            dto.FechaNacimiento = usuario.FechaNacimiento;
            dto.Correo = usuario.Correo;
            dto.Genero = usuario.Genero;
            dto.Password = usuario.Password;
            dto.FotoPath = usuario.FotoPath;
            dto.EsAdmin = usuario.EsAdmin;
            dto.Activo = usuario.Activo;
            dto.Token = usuario.Token;

            return dto;
        }

        public override Entidad CrearEntidad(DTOUsuario dto)
        {
            try
            {
                Usuario usuario = FabricaEntidades.CrearUsuario(dto.Id, dto.NombreUsuario, dto.Nombre, dto.Apellido, dto.FechaNacimiento,
                    dto.Correo, dto.Genero, dto.Password, dto.FotoPath, dto.EsAdmin, dto.Activo, dto.Token);
                 
                return usuario;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override List<DTOUsuario> CrearListaDto(List<Entidad> entidades)
        {
            try
            {
                List<DTOUsuario> dto = new List<DTOUsuario>();

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

        public override List<Entidad> CrearListaEntidades(List<DTOUsuario> dto)
        {
            try
            {
                List<Entidad> usuarios = new List<Entidad>();

                foreach (DTOUsuario dtousuario in dto)
                {
                    usuarios.Add(CrearEntidad(dtousuario));
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