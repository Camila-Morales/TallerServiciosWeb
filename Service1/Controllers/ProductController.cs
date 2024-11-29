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
    public class ProductController : ApiController, IProductService
    {
        // CREAR
        [HttpPost]
        public Products Create(Products products)
        {
            var productLogic = new ProductLogic();
            var product = productLogic.Create(products);
            return product;
        }

        // ELIMINAR
        [HttpDelete]
        public bool Delete(int id)
        {
            var productLogic = new ProductLogic();
            var product = productLogic.Delete(id);
            return product;
        }

        // BUSCAR POR ID
        [HttpGet]
        public Products RetrieveByID(int id)
        {
            var productLogic = new ProductLogic();
            var product = productLogic.RetrieveByID(id);
            return product;
        }

        // LISTAR TODOS LOS PRODUCTOS
        [HttpGet]
        public List<Products> ListAll()
        {
            var productLogic = new ProductLogic();
            var products = productLogic.ListAll();
            return products;
        }

        // ACTUALIZAR
        [HttpPut]
        public bool Update(Products products)
        {
            var productLogic = new ProductLogic();
            var updated = productLogic.Update(products);
            return updated;
        }
    }
}
