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
            var data = ProductRepo.Get();
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
            return Convert(ProductRepo.Get(id));
        }
        public static bool Create(ProductDTO product)
        {
            var data = Convert(product);
            return ProductRepo.Create(data);
        }
        public static bool Update(ProductDTO product)
        {
            var data = Convert(product);
            return ProductRepo.Update(data);
        }
        public static bool Delete(int id)
        {
            return ProductRepo.Delete(id);
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
