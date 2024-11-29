using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Entities;
using SLC;

namespace Service.Controllers
{
    public class CategoryController : ApiController, ICategoryService
    {
        // CREAR
        [HttpPost]
        public Categories Create(Categories category)
        {
            var categoryLogic = new CategoryLogic();
            var createdCategory = categoryLogic.Create(category);
            return createdCategory;
        }

        // ELIMINAR
        [HttpDelete]
        public bool Delete(int id)
        {
            var categoryLogic = new CategoryLogic();
            var result = categoryLogic.Delete(id);
            return result;
        }

        // BUSCAR POR ID
        [HttpGet]
        public Categories RetrieveByID(int id)
        {
            var categoryLogic = new CategoryLogic();
            var category = categoryLogic.RetrieveByID(id);
            return category;
        }

        // LISTAR TODAS LAS CATEGORÍAS
        [HttpGet]
        public List<Categories> ListAll()
        {
            var categoryLogic = new CategoryLogic();
            var categories = categoryLogic.FilterByName(""); // Sin filtro para listar todas
            return categories;
        }

        // ACTUALIZAR
        [HttpPut]
        public bool Update(Categories category)
        {
            var categoryLogic = new CategoryLogic();
            var result = categoryLogic.Update(category);
            return result;
        }
    }
}
