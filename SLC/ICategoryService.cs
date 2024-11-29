using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace SLC
{
    public interface ICategoryService
    {
        // Crear una nueva categoría
        Categories Create(Categories categories);

        // Eliminar una categoría por ID
        bool Delete(int id);

        // Buscar una categoría por ID
        Categories RetrieveByID(int id);

        // Listar todas las categorías
        List<Categories> ListAll();

        // Actualizar una categoría existente
        bool Update(Categories categories);
    }
}
