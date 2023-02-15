using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Tour.Models
{
    public class Comments
    {
        [Key]
        [DisplayName("景點編號")]
        [Column(Order = 1)]  //複合主鍵用!!!
        public int AttrationID { get; set; }

        [Key]
        [DisplayName("會員編號")]
        [Column(Order = 2)]
        public int MemberID { get; set; }

        [DisplayName("評論內容")]
        [StringLength(300)]
        [Required]
        public string Contents { get; set; }

        [DisplayName("照片")]
        public string Photos { get; set; }

        [DisplayName("建立日期")]          /*{0:MM(月)-dd-yyyy hh:mm(分)}*/
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime DateTime { get; set; }

        [StringLength(20)]
        public string HashTag { get; set; }

        [DisplayName("評分")]
        [RegularExpression("[0-5]{1}")]
        [Required]
        public int Rate { get; set; }




        //拉關聯

        public virtual Attrations Attrations { get; set; }
        public virtual Members Members { get; set; }
    }
}