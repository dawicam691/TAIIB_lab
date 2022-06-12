using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BasketItem
    {
        [Key]
        public int Id { get; set; }
        public double Count { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }

}
