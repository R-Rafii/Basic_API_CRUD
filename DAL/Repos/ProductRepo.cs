using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class ProductRepo
    {
        static ShopContext shopContext;
        static ProductRepo() 
        {
           shopContext = new ShopContext();
        }
        
        public static List<Product> Get()
        {
            
            //var products = new List<Product>();
          //  for(int i = 1; i <=12; i++) 
           // {
              //  products.Add(new Product { Id = i, Name = "pro-" + 1 , Price = 10 , Qty = 11 , Cid = 1 });
           //  }
            // return products;
           
            return shopContext.Products.ToList();
        }
        public static Product Get(int id)
        {
            return shopContext.Products.Find(id);
        }
        public static bool Create(Product product)
        {
            shopContext.Products.Add(product);
            return shopContext.SaveChanges() > 0;
        }
        public static bool Update(Product product)
        {
            var expro = shopContext.Products.Find(product.Id);
            shopContext.Entry(expro).CurrentValues.SetValues(product);
            return shopContext.SaveChanges() > 0;
        }
        public static bool Delete(int id)
        {
            var pro = Get(id);
            shopContext.Products.Remove(pro);
            return shopContext.SaveChanges() > 0;
        }
    }
}
