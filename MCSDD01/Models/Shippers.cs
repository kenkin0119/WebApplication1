using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MCSDD01.Models
{
    public class Shippers
    {
        [Key]
        [DisplayName("運送方式編號")]
        public int ShipID { get; set; }

        [DisplayName("運送方式")]
        [Required(ErrorMessage = "請填寫運送方式")]
        [StringLength(20)]
        public string ShipVia { get; set; }
    }
}