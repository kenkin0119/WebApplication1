using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MCSDD01.Models
{
    public class Orders
    {
        [Key]
        [DisplayName("訂單編號")]
        [StringLength(11)]
        public string OrderID { get; set; }

        [DisplayName("訂單建立時間")]
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime OrderDate { get; set; }

        [DisplayName("收件人")]
        [Required(ErrorMessage ="請填寫收件人")]
        [StringLength(40 , ErrorMessage = "收件人姓名長度不可超過40字")]
        public string ShipName { get; set; }

        [DisplayName("收件地址")]
        [Required(ErrorMessage = "請填寫收件地址")]
        [StringLength(100, ErrorMessage = "收件地址長度不可超過100字")]
        public string ShipAddress { get; set; }

        [DisplayName("出貨日")]
        [DataType(DataType.DateTime)]
        public Nullable<DateTime> ShippedDate { get; set; }


        //Forign Key
        public int EmployeeID { get; set; }
        [Required]
        public int MemberID { get; set; }

        public int ShipID { get; set; }
        [Required]
        public int PayTypeID { get; set; }

        //拉關聯
        public virtual Employees Employees { get; set; }
        public virtual Members Members { get; set; }
        public virtual Shippers Shippers { get; set; }
        public virtual PayTypes PayTypes { get; set; }
    }
}