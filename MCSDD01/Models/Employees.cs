using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace MCSDD01.Models
{
    public class Employees
    {
        [Key]
        [DisplayName("員工編號")]
        public int EmployeeID { get; set; }

        [DisplayName("員工姓名")]
        [StringLength(40,ErrorMessage ="員工姓名不可超過40字")]
        [Required(ErrorMessage ="請填寫員工姓名")]
        public string EmployeeName { get; set; }

        [DisplayName("建立日期")]          /*{0:MM(月)-dd-yyyy hh:mm(分)}*/
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}", ApplyFormatInEditMode =true)]
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime CreatedDate { get; set; }

        [DisplayName("帳號")]
        [Required(ErrorMessage = "請填寫帳號")]
        [StringLength(20, ErrorMessage ="帳號不可超過20字")]
        //[EmailAddress(ErrorMessage ="信箱格式錯誤")]
        [RegularExpression("[A-Za-z][A-Za-z0-9]{4,19}", ErrorMessage = "帳號請至少設定5碼，第一碼為英文字母")]  //[可以接受的格式]:內容都是"或" {填幾碼(1碼可以省略)} {5,20}:5~20碼
        public string Account { get; set; }

        string password;
        [DisplayName("密碼")]
        [Required(ErrorMessage = "請填寫密碼")]
        [DataType(DataType.Password)]
        //[MinLength(8 ,ErrorMessage ="密碼最少8碼")]
        //[MaxLength(20 ,ErrorMessage ="密碼最多20碼")]
        //[StringLength(20)] //必寫  定義資料庫欄位用
        public string Password 
        {
            get 
            {
                return password;
            }
            set 
            {
                //BR br = new BR(); //鑄造物件 才能使用方法  因為在不同類別 But靜態方法可以依類別使用

                //先把Password收到的Value做雜湊
                password = BR.getHashPassword(value);
            } 
        }

        //field
        //int score;

        //public int Score //屬性封裝
        //{ 
        //    get //取值:讀
        //    {
                
        //        return score; 
        //    } 
        //    set //給值:寫
        //    {
        //        if (value < 0)
        //            score = 0;
        //        else if (value > 100)
        //            score = 100;
        //        else
        //            score = value; 
        //    } 
        //}
    }
}