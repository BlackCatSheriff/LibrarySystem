using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnadminLogin_Click(object sender, EventArgs e)
    {
        if (Logining(txtamdinname.Text.Trim(),txtadminpwd .Text.Trim()) == 0)
        {
            Response.Write("<script>window.alert('登录失败！')</script>");
            return;

        }
        else
        {
            Session["Succeed_main"] = txtamdinname .Text.Trim();
            Response.Write("<script>window.alert('登录成功！');location.href='adminmain.aspx';</script>");
        }

    }
    public int Logining(string Username, string Password)
    {

        string sql = "select Library.dbo.Manager .Mname,  Library.dbo.Manager .Mpassword Password from Library.dbo.Manager where Mname ='" + Username + "' and Mpassword =upper(substring(sys.fn_sqlvarbasetostr(HashBytes('SHA1', '" + Password + "')), 3, 32))";
        DataTable dt = new DataTable();
        dt = Class_Login.SelectT(sql);
        if (dt.Rows.Count != 0) return 1;
        else return 0;
    }

   
}