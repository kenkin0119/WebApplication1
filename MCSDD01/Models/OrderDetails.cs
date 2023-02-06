using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MCSDD01.Models
{
    public class OrderDetails
    {
        [Key]
        [DisplayName("訂單編號")]
        [Column(Order =1)]    /*複合主鍵用  Order:排列順序*/
        public string OrderID { get; set; }

        [Key]
        [DisplayName("產品編號")]
        [Column(Order = 2)]
        public string ProductID { get; set; }

        [DisplayName("售價")]
        [Required]
        [Range(0,short.MaxValue,ErrorMessage ="商品售價不可小於0")]
        public short UnitPrice { get; set; }

        [DisplayName("訂購數量")]
        [Required(ErrorMessage ="請填寫訂購數量")]
        [Range(1, short.MaxValue, ErrorMessage = "商品數量不可小於0")]
        public short Quantity { get; set; }

        //拉關聯
        public virtual Orders Orders { get; set; }
        public virtual Products Products { get; set; }
    }
}