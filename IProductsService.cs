using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public interface IProductsService
    {
        public PaginatedData<ProductDto> Get(PaginationDto dto);

        public ProductDto GetById(int id);
        public ProductDto Put(int productId, PostProductDto dto);
        public ProductDto Post(PostProductDto dto);
        public bool Delete(int productId);

    }
}
