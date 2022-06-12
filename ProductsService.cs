using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class ProductsService : IProductsService
    {
        private readonly Database _database;
        public ProductsService(Database database)
        {
            this._database = database;
            _database.Products.Add(
                new Product
                {
                    Id = 1,
                    Name = "Produkt 1",
                    Description = "to jest produkt 1",
                    Price = 10

                }
                );
        }
        public bool Delete(int productId)
        {
            _database.Products.Remove(new Product { Id= productId });
            Product product = _database.Products.Find(new Product { Id = productId });
            if (product == null)
                return true;
            return false;
        }

        public PaginatedData<ProductDto> Get(PaginationDto dto)
        {
            PaginatedData<Product> paginatedData=new PaginatedData<Product>();
            List<Product> produkty = _database.Products.ToList();
            paginatedData.Count = produkty.Count();
            produkty.Sort();
            paginatedData.Data = produkty;
            PaginatedData<ProductDto> paginatedDataNowe = new PaginatedData<ProductDto> { Count = paginatedData.Count, Data = paginatedData.Data.Select(x=>
            new ProductDto 
            {
                Id=x.Id, 
                Name=x.Name, 
                Description=x.Description, 
                Price=x.Price
            })};
            return paginatedDataNowe;
        }

        public ProductDto GetById(int id)
        {
            Product product = _database.Products.SingleOrDefault(x => x.Id == id);
            if (product == null)
                return null;
            return new ProductDto
            {
                Id = product.Id,
                Description=product.Description,
                Name=product.Name,
                Price=product.Price
            };
        }

        public ProductDto Post(PostProductDto dto)
        {
            Product product = new Product();
            product.Name = dto.Name;
            product.Price = dto.Price;
            product.Description = dto.Description;
            _database.Products.Add(product);
            _database.SaveChanges();
            return new ProductDto {
                Id=product.Id, 
                Description=product.Description, 
                Name=product.Name, 
                Price=product.Price 
            };
        }

        public ProductDto Put(int productId, PostProductDto dto)
        {
            Product product = (Product)(from p in _database.Products
                                   where p.Id == productId
                                   select p);
            if(product != null)
            {
                product.Id = productId;
                product.Name = dto.Name;
                product.Price = dto.Price;
                product.Description = dto.Description;
            }
            _database.SaveChanges();
            return new ProductDto
            {
                Id = product.Id,
                Description = product.Description,
                Name = product.Name,
                Price = product.Price
            };
        }
    }
}
