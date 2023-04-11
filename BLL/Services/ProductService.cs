using DAL;
using System;
using DAL.Models;
using DAL.Repos;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs;

namespace BLL.Services
{
    public class ProductService
    {
        public static List<ProductDTO> Get()
        {
            var data = DataAccessFact.ProductData().Get();
           // var data = ProductRepo.Get();
            return Convert(data);
        }
       /*
        public static List<ProductDTO> Get10()
        {
            var data = (from e in ProductRepo.Get()
                        where e.Id < 11
                        select e).ToList();
            return Convert(data);
        }
       */
        public static ProductDTO Get(int id)
        {
            return Convert(DataAccessFact.ProductData().Get(id));
        }
        public static bool Create(ProductDTO product)
        {
            var data = Convert(product);
            var res = DataAccessFact.ProductData().Insert(data);

            if (res != null) return true;
            return false;
        }
        public static bool Update(ProductDTO product)
        {
            var data = Convert(product);
            var res =  DataAccessFact.ProductData().Update(data);

            if (res != null) return true;
            return false;
        }
        public static bool Delete(int id)
        {
            return DataAccessFact.ProductData().Delete(id);
        }

        
        static List<ProductDTO> Convert(List<Product> products)
        {
            var data = new List<ProductDTO>();
            foreach (var pro in products)
            {
                data.Add(new ProductDTO()
                {
                    Id = pro.Id,
                    Name = pro.Name,
                    Price= pro.Price,
                    Qty= pro.Qty,
                    Cid=pro.Cid,
                });
            }
            return data;

        }

        
        static Product Convert(ProductDTO pro)
        {
            return new Product()
            {
                Id = pro.Id,
                Name = pro.Name,
                Price = pro.Price,
                Qty = pro.Qty,
                Cid = pro.Cid,
            };
        }
        static ProductDTO Convert(Product pro)
        {
            return new ProductDTO()
            {
                Id = pro.Id,
                Name = pro.Name,
                Price = pro.Price,
                Qty = pro.Qty,
                Cid = pro.Cid,
            };
        }
    }
}
