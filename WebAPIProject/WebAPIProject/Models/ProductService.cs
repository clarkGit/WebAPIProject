using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIProject.Models
{
    public class ProductService : IProductService
    {
        List<Product> products = new List<Product>();
        int pro_id = 1;
        public ProductService()
        {
            Add(new Product { Id = 1, Name = "iphone6", Category = "iphone", Price = 1200 });
        }
        public IEnumerable<Product> GetAll()
        {
            return products;
        }

        public Product Get(int id)
        {
            return products.FirstOrDefault(s => s.Id == id);
        }

        public Product Add(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("");
            }
            product.Id = pro_id++;
            products.Add(product);
            return product;
        }

        public bool update(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("");
            }
            int index = products.FindIndex(p => p.Id == product.Id);
            if (index == -1)
            {
                return false; 
            }
            products.RemoveAt(index);
            products.Add(product);
            return true;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}