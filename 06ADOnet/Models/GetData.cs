using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace _06ADOnet.Models
{
    public class GetData
    {
        //1.建立資料庫連線物件 static:可以直接使用
        static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["NorthwindConnection"].ConnectionString);
        //2.建立SQL命令物件
        SqlCommand cmd = new SqlCommand("", conn);
        //3.建立資料讀取物件
        SqlDataReader rd;


        public SqlDataReader LoginQuery(string sql,List<SqlParameter> para)
        {
            cmd.CommandText = sql;

            foreach(SqlParameter p in para)
            {
                cmd.Parameters.Add(p);
            }

            conn.Open();
            try
            {
                rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);//將 CommandText 傳送至 Connection，並使用其中一個 CommandBehavior 值來建置 SqlDataReader。
                                                                        //DataReader關閉的時候，也會自動關閉資料庫的連結（自動關閉 Connection）

                rd.Read();
            }
            catch
            {
                conn.Close();
                return rd;
            }

            return rd;

        }
                
            
    }
}