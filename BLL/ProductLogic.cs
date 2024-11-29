using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class ProductLogic
    {
        // METODO PARA CREAR EL PRODUCTO
        public Products Create(Products newProduct)
        {
            Products Result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                // Busca si el nombre del producto existe
                Products res = r.Retrieve<Products>(
                    p => p.ProductName == newProduct.ProductName);

                if (res == null)
                {
                    // No existe, podemos crearlo
                    Result = r.Create(newProduct);
                }
                else
                {
                    // Podriamos lanzar una excepcion para notificar que el producto ya existe
                    // Podriamos incluso crear una capa de Excepciones personalizadas y consumirla desde otras capas
                }
            }
            return Result;
        }

        // BUSQUEDA POR ID
        public Products RetrieveByID(int id)
        {
            Products Result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                Result = r.Retrieve<Products>(p => p.ProductID == id);
            }
            return Result;
        }

        // METODO DE ACTUALIZAR
        public bool Update(Products productToUpdate)
        {
            bool res = false;
            using (var r = RepositoryFactory.CreateRepository())
            {
                // Validar que el nombre del producto NO exista
                Products temp = r.Retrieve<Products>(
                    p => p.ProductName == productToUpdate.ProductName
                    && productToUpdate.ProductID != productToUpdate.ProductID);

                if (temp == null)
                {
                    // No existe
                    res = r.Update(productToUpdate);
                }
                else
                {
                    // Podemos implementar alguna lógica para indicar que no se pudo modificar
                }
            }
            return res;
        }

        // METODO PARA ELIMINAR
        public bool Delete(int ID)
        {
            bool res = false;

            // Buscar el producto para ver si tiene existencias
            var product = RetrieveByID(ID);

            if (product != null)
            {
                // Eliminar el producto
                if (product.UnitsInStock == 0)
                {
                    using (var r = RepositoryFactory.CreateRepository())
                    {
                        res = r.Delete(product);
                    }
                }
                else
                {
                    // Podemos implementar alguna lógica adicional para indicar que no se pudo eliminar el producto
                }
            }
            else
            {
                // Podemos implementar alguna lógica para indicar que el producto no existe
            }

            return res;
        }

        // LISTAR TODOS LOS PRODUCTOS
        public List<Products> ListAll()
        {
            List<Products> result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                result = r.ListAll<Products>();  // Suponiendo que el repositorio tenga este método
            }
            return result;
        }

        // LISTAR TODOS LOS PRODUCTOS POR CATEGORIA
        public List<Products> FilterByCategoryID(int categoryID)
        {
            List<Products> result = null;

            using (var r = RepositoryFactory.CreateRepository())
            {
                result = r.Filter<Products>(
                    p => p.CategoryID == categoryID);
            }
            return result;
        }
    }
}
