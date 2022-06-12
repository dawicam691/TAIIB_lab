using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services
{
    public class ProductServiceMemory: IProductService
    {
        List<Product> products = new List<Product>
        {
            new Product
            {
                Description="opis",Id=1,Name="Nazwa",Price=10
            }
        };
        public List<Product> Get()
        {
            return products;
        }
    }
}
