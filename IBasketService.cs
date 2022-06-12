using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public interface IBasketService
    {
        public IEnumerable<BasketItem> Get();
        public IEnumerable<BasketItem> Post(int productId, double count);
        public IEnumerable<BasketItem> Put(int basketItemId, double count);
        public IEnumerable<BasketItem> Delete(int basketItemId);
        public bool Clear();

    }
}
