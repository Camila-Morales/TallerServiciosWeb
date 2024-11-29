using System.Collections.Generic;
using Entities;

namespace SLC
{
    public interface IProductService
    {
        // Crear un nuevo producto
        Products Create(Products product);

        // Eliminar un producto por ID
        bool Delete(int id);

        // Buscar un producto por ID
        Products RetrieveByID(int id);

        // Listar todos los productos
        List<Products> ListAll();

        // Actualizar un producto existente
        bool Update(Products product);
    }
}
