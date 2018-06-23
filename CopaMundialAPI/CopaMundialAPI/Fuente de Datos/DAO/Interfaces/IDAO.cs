using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CopaMundialAPI.Comun.Entidades;

namespace CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces
{
    public interface IDAO
    {
        void Agregar(Entidad entidad);

        void Actualizar(Entidad entidad);

        void Eliminar(Entidad entidad);

        List<Entidad> ObtenerTodos();
    }
}
