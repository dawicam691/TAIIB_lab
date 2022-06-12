using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Login { get; set; }
        [Required, MinLength(10), MaxLength(100)]
        public string Password { get; set; }
        [Required, MaxLength(40)]
        public string Name { get; set; }
        [Required, MaxLength(60)]
        public string Surname { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("UserbasketItems")]
        public List<BasketItem> basketItems { get;set;}
    }
}
