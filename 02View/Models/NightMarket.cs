using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _02View.Models
{
    public class NightMarket
    {
        [DisplayName("夜市編號")]
        public string Id { set; get; }

        [DisplayName("夜市名稱")]
        public string Name { set; get; }

        [DisplayName("夜市地址")]
        public string Address { set; get; }
    }
}