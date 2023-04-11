using DAL.Interfaces;
using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFact
    {
        public static IRepo<Product, int, Product> ProductData()
        {
            return new ProductRepo();
        }
    }
}
