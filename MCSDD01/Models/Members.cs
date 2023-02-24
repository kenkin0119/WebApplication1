using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MCSDD01.Models
{
    public class Members
    {
        [Key]
        [DisplayName("會員編號")]
        public int MemberID { get; set; }

        [DisplayName("會員名稱")]
        [Required(ErrorMessage = "請填寫會員名稱")]
        [StringLength(40 ,ErrorMessage ="會員名稱不可超過40字")]
        public string MemberName { get; set; }

        [DisplayName("會員照片")]
        public string MemberPhotoFile { get; set; }

        [DisplayName("生日")]
        [Required(ErrorMessage = "請填寫生日")]             //應用時間格式到編輯模式
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime MemberBirthday { get; set; }

        [DisplayName("帳號")]
        [Required(ErrorMessage = "請填寫帳號")]
        [StringLength(20, ErrorMessage = "帳號不可超過20字")]
        [RegularExpression("[A-Za-z][A-Za-z0-9]{4,19}", ErrorMessage = "帳號請至少設定5碼，第一碼為英文字母")]
        public string Account { get; set; }

        string password;
        [DisplayName("密碼")]
        [Required(ErrorMessage = "請填寫密碼")]
        [DataType(DataType.Password)]
        //[MinLength(8, ErrorMessage = "密碼最少8碼")]
        //[MaxLength(20, ErrorMessage = "密碼最多20碼")]
        //[StringLength(20)]
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

        [DisplayName("加入日期")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }
    }
}