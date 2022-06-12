using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        public decimal Price { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("ProductbasketItems")]
        public System.Collections.Generic.List<BasketItem> basketItems { get; set; }
    }
}
