using Models;
using System;
using System.Linq;
namespace services
{
    public class ProductService : IProductService
    {
        private readonly Database _database;

        public ProductService(Database database)
        {
            this._database = database;
        }

        public System.Collections.Generic.List<Product> Get()
        {
            return new Database().Products.ToList();
        }
    }
}
