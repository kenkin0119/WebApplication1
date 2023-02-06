using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Razor;

namespace _05CustomValidation.Models
{
    public class Member
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        [RegularExpression("[A-Z][12][0-9]{8}")]
        [CheckIDNumber]
        public string IDNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public class CheckIDNumber : ValidationAttribute
        {
            public CheckIDNumber()
            {
                ErrorMessage = "身份證字號不合法";
            }

            public override bool IsValid(object value)
            {
                string idNumber = value.ToString();
                bool a;

                List<string> list = new List<string> {"A","B","C","D","E","F","G","H","J","K","L","M","N","P","Q","R","S","T","U","V","X","Y","W","Z","I","O"};
                int eng = list.IndexOf(idNumber[0].ToString()) + 10;

                int n1 = eng / 10;
                int n2 = eng % 10;

                int sum = n1 * 1 + n2 * 9;


                for (int i=1 ;i<9 ;i++ )
                {
                    sum += int.Parse(idNumber[i].ToString()) * (9 - i);
                }

                a = 10 - (sum % 10) == int.Parse(idNumber[9].ToString());

                return a;

            }
        }
    }
}