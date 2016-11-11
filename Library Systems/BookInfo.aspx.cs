using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BookInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         
        if (Request .QueryString ["bid"] == null) 
            {
            Response.Write("<script>window.alert('请重新查看！');location.href='Main.aspx';</script>");
            return;

        }
        else
        {
            string bookisbn  = Request.QueryString["bid"].ToString().Trim();

            string sqlcheckisbn = "select ISBN from Library.dbo.Books where ISBN='" + bookisbn + "'";    //处理？传值被更改
            DataTable dtcheck = Class_Login.SelectT(sqlcheckisbn);
            if (dtcheck.Rows.Count < 1)
            {
                Response.Write("<script>window.alert('页面跳转出错！');location.href='books.aspx';</script>");
                return;


            }




            string sqljudgename = "select * from Library.dbo.Books where ISBN='" + bookisbn + "'";
                DataTable dt = Class_Login.SelectT(sqljudgename);
                rptbookinfo.DataSource = dt;
                rptbookinfo.DataBind();


            
        }
 



    }
}