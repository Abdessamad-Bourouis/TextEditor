﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProductPriceDTO
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string Size { get; set; }
        [Required]
        [Range(1, int.MaxValue,ErrorMessage ="Price must be greater than 1")]
        public double Price { get; set; }
    }
}
