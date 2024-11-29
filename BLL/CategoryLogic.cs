using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class CategoryLogic
    {
        // MÉTODO PARA CREAR UNA CATEGORÍA
        public Categories Create(Categories newCategory)
        {
            Categories result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                // Busca si el nombre de la categoría existe
                Categories res =
                    r.Retrieve<Categories>(
                        c => c.CategoryName == newCategory.CategoryName);

                if (res == null)
                {
                    // No existe, podemos crearla
                    result = r.Create(newCategory);
                }
                else
                {
                    // Podríamos lanzar una excepción para notificar que la categoría ya existe
                }
            }
            return result;
        }

        // BÚSQUEDA POR ID
        public Categories RetrieveByID(int id)
        {
            Categories result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                result = r.Retrieve<Categories>(c => c.CategoryID == id);
            }
            return result;
        }

        // MÉTODO PARA ACTUALIZAR
        public bool Update(Categories categoryToUpdate)
        {
            bool res = false;
            using (var r = RepositoryFactory.CreateRepository())
            {
                // Validar que el nombre de la categoría NO exista
                Categories temp =
                    r.Retrieve<Categories>(
                        c => c.CategoryName == categoryToUpdate.CategoryName
                        && c.CategoryID != categoryToUpdate.CategoryID);

                if (temp == null)
                {
                    // No existe
                    res = r.Update(categoryToUpdate);
                }
                else
                {
                    // Podríamos implementar alguna lógica para indicar que no se pudo modificar
                }
            }
            return res;
        }

        // MÉTODO PARA ELIMINAR
        public bool Delete(int id)
        {
            bool res = false;

            // Buscar la categoría por ID
            var category = RetrieveByID(id);

            if (category != null)
            {
                // Validar si tiene dependencias antes de eliminarla
                using (var r = RepositoryFactory.CreateRepository())
                {
                    res = r.Delete(category);
                }
            }
            else
            {
                // Podríamos implementar lógica para indicar que la categoría no existe
            }

            return res;
        }

        // LISTAR TODAS LAS CATEGORÍAS POR NOMBRE
        public List<Categories> FilterByName(string categoryName)
        {
            List<Categories> result = null;

            using (var r = RepositoryFactory.CreateRepository())
            {
                result = r.Filter<Categories>(
                    c => c.CategoryName.Contains(categoryName));
            }
            return result;
        }

        public List<Categories> ListAll()
        {
            List<Categories> result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                result = r.ListAll<Categories>();  // Suponiendo que el repositorio tenga este método
            }
            return result;
        }

    }
}
