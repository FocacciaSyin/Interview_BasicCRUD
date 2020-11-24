using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview_BasicCRUD.Dto
{
    public class ProductForUpdateDto
    {
        [Required(ErrorMessage = "產品名稱不可為空值")]
        [MaxLength(100)]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "產品描述不可為空值")]
        [MaxLength(1000)]
        public string Description { get; set; }
        public decimal OriginalPrice { get; set; }
        public double? DiscountPrice { get; set; }
    }
}
