using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Product
    {
        [Key] 
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]  
        public string Description { get; set; }
        public string Color { get; set; }
        public string? ImageUrl { get; set; }
        public bool CustomerFavorites { get; set; }
        public bool Shopfavorites { get; set; }
        public int CategoryId { get; set;}
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public ICollection<ProductPrice> ProductPrices { get; set; }
    }
}
