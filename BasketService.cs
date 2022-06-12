using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class BasketService : IBasketService
    {
        private readonly Database _database;
        public BasketService(Database database)
        {
            this._database = database;
        }
        public bool Clear()
        {
            User user = (from u in _database.Users
                         select u).First();
            List<BasketItem> listaWszystkich = (List<BasketItem>)(from b in _database.BasketItems
                                                select b);
            bool poprawne = false;
            foreach(var element in listaWszystkich)
            {
                if(element.Id==user.Id)
                {
                    poprawne = true;
                    _database.BasketItems.Remove(element);
                }
                    
            }
            return poprawne;
        }

        public IEnumerable<BasketItem> Delete(int basketItemId)
        {
            BasketItem basketItem = (BasketItem)(from b in _database.BasketItems
                                     where b.Id == basketItemId
                                     select b);

            _database.BasketItems.Remove(basketItem);
            _database.SaveChanges();
            List<BasketItem> lista = new List<BasketItem>
            {
                new BasketItem
                {
                    Id=basketItem.Id,
                    Count=basketItem.Count,
                    User=basketItem.User,
                    Product=basketItem.Product
                }
            };
            return lista;
        }

        public IEnumerable<BasketItem> Get()
        {
            List<BasketItem>? listaPowiazan = new List<BasketItem>();
            List<BasketItem> listaWszystkich = new List<BasketItem>();
            listaWszystkich = (from b in _database.BasketItems
                               select b).ToList();
            User user = (from u in _database.Users
                         select u).First();
            foreach (var element in listaWszystkich)
            {
                if ((user.Id == element.User.Id))
                    listaPowiazan.Add(element);
            }
            _database.SaveChanges();
            return listaPowiazan;
        }

        public IEnumerable<BasketItem> Post(int productId, double count)
        {
            Product ?product = (Product)(from p in _database.Products
                               where p.Id == productId
                               select p);
            User user = (from u in _database.Users
                         select u).First();
            List<BasketItem> basketItemList = new List<BasketItem> 
            { 
                new BasketItem 
                { 
                    Count = count, 
                    User = user, 
                    Product = product 
                }
                
            };
            _database.SaveChanges();
            return basketItemList;
        }

        public IEnumerable<BasketItem> Put(int basketItemId, double count)
        {
            var basketItemkonkretny = _database.BasketItems.Where(b => b.Id == basketItemId).FirstOrDefault<BasketItem>();
            if(basketItemkonkretny!=null)
            {
                basketItemkonkretny.Count = count;
            }
            basketItemkonkretny.SaveChanges();
            List<BasketItem> lista = new List<BasketItem>
            {
                new BasketItem
                {
                    Id=basketItemkonkretny.Id,
                    Count=basketItemkonkretny.Count,
                    User = basketItemkonkretny.User,
                    Product = basketItemkonkretny.Product
                }
            };
            _database.SaveChanges();
            return lista;
        }
    }
}
