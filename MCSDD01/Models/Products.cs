using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MCSDD01.Models
{
    public class Products
    {
        [Key]
        [DisplayName("產品編號")]
        [Required(ErrorMessage ="請填寫產品編號")]
        [RegularExpression("[A-F][0-9]{5}")]
        [StringLength(6)]
        public string ProductID { get; set; }

        [DisplayName("產品名稱")]
        [Required(ErrorMessage = "請填寫產品名稱")]
        [StringLength(40 ,ErrorMessage ="商品名稱最多40字")]
        public string ProductName { get; set; }

        [DisplayName("訂價")]
        [Required(ErrorMessage = "請填寫訂價")]
        [Range(0, short.MaxValue,ErrorMessage ="單價不可小於0")]
                                        //0:C0 貨幣ex:$50  0:C1 $50.0
        [DisplayFormat(DataFormatString ="{0:C0}" ,ApplyFormatInEditMode = true)]                        
        public short UnitPrice { get; set; }

        [DisplayName("庫存量")]
        [Required(ErrorMessage = "請填寫庫存量")]
        [Range(0, short.MaxValue, ErrorMessage = "庫存量不可小於0")]
        public short UnitsInStock { get; set; }

        [DisplayName("產品描述")]
        [Required(ErrorMessage = "請填寫產品描述")]
        [StringLength (1000 ,ErrorMessage = "產品描述不可超過1000字")]
        public string Description { get; set; }

        [DisplayName("產品照片")]
        [Required(ErrorMessage = "請上傳產品照片")]
        public byte[] PhotoFile { get; set; }

        [StringLength(10)]
        [Required]
        public string ImageMimeType { get; set; }

        [DisplayName("已下架")]
        [DefaultValue(false)]
        [Required]
        public bool Discontinued { get; set; }

        [DisplayName("建立日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime CreatedDate { get; set; }
    }
}