using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MCSDD01.Models
{
    public class PayTypes
    {
        [Key]
        [DisplayName("付款方式編號")]
        public int PayTypeID { get; set; }

        [DisplayName("付款方式")]
        [Required(ErrorMessage = "請填寫付款方式")]
        [StringLength(20)]
        public string PayTypeName { get; set; }
    }
}