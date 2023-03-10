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
        [StringLength(6)]
        [RegularExpression("[A-F][0-9]{5}")]
        public string ProductID { get; set; }

        [DisplayName("產品名稱")]
        [StringLength(150, ErrorMessage = "產品名稱不可超過150字")]
        [Required(ErrorMessage = "請填寫產品名稱")]
        public string ProductName { get; set; }

        [DisplayName("產品圖片")]
        [Required(ErrorMessage = "請上傳商品圖片")]
        public byte[] PhotoFile { get; set; }

        [DisplayName("圖片類型")]
        [StringLength(10)]
        [Required]
        public string ImageMimeType { get; set; }

        [DisplayName("單價")]
        [Required(ErrorMessage = "請填寫單價")]
        [Range(0, short.MaxValue, ErrorMessage = "單價不可小於0")]
        [DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
                                        //C0:取到整數 C1:小數一位
        public short UnitPrice { get; set; }

        [DisplayName("產品描述")]
        [Required(ErrorMessage = "請填寫產品描述")]
        [StringLength(1000, ErrorMessage = "產品描述不可超過1000字")]
        public string Description { get; set; }

        [DisplayName("庫存量")]
        [Range(0, short.MaxValue, ErrorMessage = "請輸入在預設範圍")]
        [Required(ErrorMessage = "請填寫庫存量")]
        public short UnitsInStock { get; set; }

        [DisplayName("下架否")]
        [DefaultValue(false)]
        public bool Discontinued { get; set; }

        [DisplayName("建立日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime CreatedDate { get; set; }
    }
}