using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace Tour.Models
{
    public class BR
    {
         //static:靜態方法 無須鑄造物件 可通過類別使用方法
            public static string getHashPassword(string pw) //雜湊
            {
                byte[] hashValue;
                string result = "";

                System.Text.UnicodeEncoding ue = new System.Text.UnicodeEncoding();

                byte[] pwBytes = ue.GetBytes(pw); //把密碼轉2進制

                SHA256 shHash = SHA256.Create();  //鑄造雜湊物件
                hashValue = shHash.ComputeHash(pwBytes); //將轉為2進制的密碼進行雜湊

                foreach (byte b in hashValue)  //將陣列轉回字串
                {
                    result += b.ToString();
                }
                return result;
            }
        }
}