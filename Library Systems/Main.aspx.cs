using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Main : System.Web.UI.Page
{
    


    protected void Page_Load(object sender, EventArgs e)
    {  
        if (Session["Succeed_name"] != null)
        {
            lblUsername.Visible = true;
            lbnLogin.Text = "注销";
            lblUsername.Text = "欢迎你，" + Session["Succeed_name"].ToString();
            
        }

        else
        {
            lbnLogin.Text = "登录";
            lblUsername.Visible = false;

        }


        }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        divmylib.Visible = false;
        divbooksearch.Visible = true;
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        
    }

    protected void lbnLogin_Click(object sender, EventArgs e)
    {
        if(lbnLogin .Text =="登录")
        {
            lbnLogin.PostBackUrl = "Login.aspx";

        }
        else
        {
            lbnLogin.Text = "登录";
            iframe1.Visible = false;
            lblUsername.Visible = false;
            lblUsername.Text = "";
            lbnLogin.PostBackUrl = "Main.aspx";
            Session.Clear();


        }
    }

    protected void btnReader_Click(object sender, EventArgs e)
    {
        divbooksearch.Visible = false;

        divmylib.Visible = true;
        if (Session["Succeed_name"] == null)
        {
            Response.Write("<script>window.alert('无法查询！请先登录！');location.href='Login.aspx';</script>");
            return;
        }
    }
}