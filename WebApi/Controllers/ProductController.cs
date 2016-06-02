using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ProductController : ApiController
    {
        Product[] products = new Product[]
        {
            new Product {Id=1,Name="New",category="Create",price=4 },
            new Product {Id=2,Name="Old",category="Do",price=5M },
            new Product {Id=3,Name="Suceess",category="Try",price=45.9M }
        };
        public IEnumerable<Product> getAllProducts()
        {
            return products;
        }

        public Product getProductById(int id)
        {
            Product product = products.FirstOrDefault(s => s.Id == id);
            if(product==null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return product;
        }

       public IEnumerable<Product> getProductByCategory(string category)
        {
            return products.Where((s) => string.Equals(s.category, category, StringComparison.OrdinalIgnoreCase));
        }
    }
}
