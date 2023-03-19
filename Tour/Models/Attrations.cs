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

        [DisplayName("景點照片1")]
        public string Picture1 { get; set; }
        public string Picdescribe1 { get; set; }
        

        [DisplayName("景點介紹")]
        public string Description { get; set; }

        [DisplayName("電話")]
        public string Tel { get; set; }

        [DisplayName("收費方式")]
        public string Ticketinfo { get; set; }

        [DisplayName("緯度")]
        public float Px { get; set; }
        [DisplayName("經度")]
        public float Py { get; set; }



    }
}