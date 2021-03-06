﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Interview_BasicCRUD.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
        public decimal OriginalPrice { get; set; }
        public double? DiscountPrice { get; set; }

        [Required]
        public DateTime DB_CRDAT { get; set; }

        public DateTime? DB_TRDAT { get; set; }
    }
}
