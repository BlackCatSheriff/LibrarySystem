using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Class_Login 的摘要说明
/// 注册类，登录类
/// </summary>
public class Class_Login
{
    public Class_Login()
    {
        //Session ["Vnum"]
        // TODO: 在此处添加构造函数逻辑
        //
    }
    static  public   string str= @"server=DESKTOP-A1L7N2O;Integrated Security=SSPI;database=Library;";

    static public int Operate(string sql )   //返回影响行数 成功  0 插入失败 -1 出错
    {
        try
        {
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            int re = cmd.ExecuteNonQuery();
            if (re != 0)  return re;
            else return 0;
            
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    static  public DataTable SelectT(string sql)  //成功返回数据表，失败返回null
    {
        try
        {
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }


    static  public string SelectHead(string sql)    //成功返回查询出表的左上角元素 失败返回-1
    {
        try
        {
            DataTable dt = SelectT(sql);
            return dt.Rows[0][0].ToString ();
        }
        catch (Exception ex )
        {
            return "-1";
        }
    }
   

    }
 
  













