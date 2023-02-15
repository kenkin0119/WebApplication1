using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tour.Models
{
    public class Adminstrators
    {
        [Key]
        [DisplayName("管理員代號")]
        public int AdminID { get; set; }

        [DisplayName("管理員名稱")]
        [StringLength(40, ErrorMessage = "管理員姓名不可超過40字")]
        [Required]
        public string AdminName { get; set; }

        [DisplayName("帳號")]
        [Required(ErrorMessage = "請填寫帳號")]
        [StringLength(20, ErrorMessage = "帳號不可超過20字")]
        [RegularExpression("[A-Za-z][A-Za-z0-9]{4,19}", ErrorMessage = "帳號請至少設定5碼，第一碼為英文字母")]
        public string Account { get; set; }

        string password;
        [DisplayName("密碼")]
        [Required(ErrorMessage = "請填寫密碼")]
        [DataType(DataType.Password)]
        public string Password 
        {
            get
            {
                return password;
            }
            set
            {
                password = BR.getHashPassword(value);
            }
        }
    }
}