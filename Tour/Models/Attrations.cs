using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tour.Models
{
    public class Attrations
    {
        [Key]
        [DisplayName("景點編號")]
        public int AttrationID { get; set; }

        [DisplayName("景點名稱")]
        [StringLength(40)]
        [Required]
        public string AttrationName { get; set; }

        [DisplayName("地址")]
        [StringLength(100)]
        [Required]
        public string Address { get; set; }

        [DisplayName("景點照片")]
        public string AttrationPhotos { get; set; }

    }
}