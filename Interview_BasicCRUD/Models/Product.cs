using System;
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
        public string Price { get; set; }
        public int? Type { get; set; }

        #region 資料新增更正相關資訊
        public DateTime DB_CRDAT { get; set; }
        public string DB_CRUSR { get; set; }
        public DateTime? DB_UPDAT { get; set; }
        public string DB_TRUSR { get; set; }
        #endregion


    }
}
