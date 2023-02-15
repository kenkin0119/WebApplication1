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
            //一列一列讀 不佔記憶體 但是較慢 要手動connect和close

            SqlDataAdapter adp = new SqlDataAdapter("", conn);
        //用DataSet or DataTable讀取 較快但是佔記憶體 可以用fill自動connect取完資料後自動close

        //使用時機:SqlDataReader:照順序讀or資料數較少 不需要再對資料進行其他動作時
        //        SqlDataAdapter:資料數多 存成ds(DataSet).dt(DataTable)方便進行其他操作


        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        public DataTable TableQuery(string sql,bool a)
        {
            adp.SelectCommand.CommandText = sql;  //指定 Select Command

            if (a == true)
            {
                adp.SelectCommand.CommandType =CommandType.StoredProcedure;
            }

             adp.Fill(ds);  //把取到的DataSet填入DataTable

            if (ds.Tables.Count == 0)
            {
                return dt;
            }

            dt = ds.Tables[0]; //DataSet填好的第一個DataTable存到dt再回傳

            return dt;
        }

        public DataTable TableQuery(string sql, List<SqlParameter> para,bool a)   //多載:同樣方法名稱只要參數不同就OK
        {
            adp.SelectCommand.CommandText = sql;  //指定 Select Command

            if (a == true)
            {
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            }

            foreach (SqlParameter p in para)
            {
                adp.SelectCommand.Parameters.Add(p);
            }

            adp.Fill(ds);  //取到的Table填入DataSet

            if (ds.Tables.Count == 0)
            {
                return dt;
            }

            dt = ds.Tables[0];

            return dt;
        }

        //public DataTable TableQueryBySP(string sql)
        //{
        //    adp.SelectCommand.CommandText = sql;  //指定 Select Command
        //    adp.Fill(ds);  //把取到的Table填入DataSet

        //    dt = ds.Tables[0];

        //    return dt;
        //}

        //public DataTable TableQueryBySP(string sql, List<SqlParameter> para)   //多載:同樣方法名稱只要參數不同就OK
        //{
        //    adp.SelectCommand.CommandText = sql;  //指定 Select Command
        //    adp.SelectCommand.CommandType = CommandType.StoredProcedure; //預設為Text

        //    foreach (SqlParameter p in para)
        //    {
        //        adp.SelectCommand.Parameters.Add(p);
        //    }

        //    adp.Fill(ds);  //取到的Table填入DataSet

        //    dt = ds.Tables[0];

        //    return dt;
        //}

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