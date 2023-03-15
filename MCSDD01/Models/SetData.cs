using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MCSDD01.Models
{
    public class SetData
    {
        //1.建立資料庫連線物件
        static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MCSDD01Connection"].ConnectionString);
        //2.建立SQL命令物件
        SqlCommand cmd = new SqlCommand("", conn);

        public void executeSql(string sql)
        {
            cmd.CommandText = sql;

            conn.Open();
            cmd.ExecuteNonQuery();//只有執行sql存值不取值(select)
            cmd.Dispose();//把cmd物件Dispose=>參數清空 下一筆資料才能用相同參數
            conn.Close();
        }

        //設定使用方法時的說明
        /// <summary>
        /// 必須傳入SqlParameter List泛型參數
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="list"></param>
        public void executeSql(string sql, List<SqlParameter> list)
        {
            cmd.CommandText = sql;

            foreach (var p in list)
            {
                cmd.Parameters.Add(p);
            }

            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
        }

        public void executeSqlBySP(string SPName)
        {
            cmd.CommandText = SPName;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            conn.Open();
            cmd.ExecuteNonQuery();//只有執行sql存值不取值(select)
            cmd.Dispose();//把cmd物件Dispose=>參數清空 下一筆資料才能用相同參數
            conn.Close();
        }


        /// <summary>
        /// 必須傳入SqlParameter List泛型參數
        /// </summary>
        /// <param name="SPName"></param>
        /// <param name="list"></param>
        public void executeSqlBySP(string SPName, List<SqlParameter> list)
        {
            cmd.CommandText = SPName;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            foreach (var p in list)
            {
                cmd.Parameters.Add(p);
            }

            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
        }
    }
}