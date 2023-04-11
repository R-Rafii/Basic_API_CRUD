using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ProductRepo : Repo, IRepo<Product, int, Product>
    {

        // ********************** 

        /*
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
        */
        public bool Delete(int id)
        {
            var pro = Get(id);
            db.Products.Remove(pro);
            return db.SaveChanges() > 0;
        }

        public List<Product> Get()
        {
            // throw new NotImplementedException();

            //  return shopContext.Products.ToList();

            return db.Products.ToList();
        }

        public Product Get(int id)
        {
            return db.Products.Find(id);
        }

        public Product Insert(Product obj)
        {
            db.Products.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public Product Update(Product obj)
        {
            var expro = db.Products.Find(obj.Id);
            db.Entry(expro).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
