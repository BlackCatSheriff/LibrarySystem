using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class adminmain : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Succeed_main"] == null)
        {
            lbnLogin.Text = "登录";
            lblUsername.Visible = false;
            Response.Write("<script>window.alert('请登录！');location.href='adminLogin.aspx';</script>");
            return;
        }



     else
        {
            if (Session["Succeed_main"].ToString().Trim() == "ILIBowner")
            {
                btnLog.Visible = true;
                lblUsername.Visible = true;
                lbnLogin.Text = "注销";
                lblUsername.Text = "欢迎你，" + Session["Succeed_main"].ToString();
            }
            else
            {
                lblUsername.Visible = true;
                lbnLogin.Text = "注销";
                lblUsername.Text = "欢迎你，" + Session["Succeed_main"].ToString();
            }
        }

    


    }


    protected void btncheckre_Click(object sender, EventArgs e)
    {

        iframe.Attributes["src"] = " adminre.aspx";
        divmain.Visible = true;


    }

    protected void btnaddbooks_Click(object sender, EventArgs e)
    {
        iframe.Attributes["src"] = " addbook.aspx";
        divmain.Visible = true;

    }

    protected void btnedit_Click(object sender, EventArgs e)
    {
        iframe.Attributes["src"] = " books.aspx";
        divmain.Visible = true;

    }

    protected void lbnLogin_Click(object sender, EventArgs e)
    {


   
        if (lbnLogin.Text == "登录")
        {
            lbnLogin.PostBackUrl = "adminLogin.aspx";

        }
        else
        {
            lbnLogin.Text = "登录";
            
            lblUsername.Visible = false;
            lblUsername.Text = "";
            lbnLogin.PostBackUrl = "adminmain.aspx";
            Session.Clear();


        }
    

}

    protected void btnUsers_Click(object sender, EventArgs e)
    {
        iframe.Attributes["src"] = "Users.aspx";
        divmain.Visible = true;
    }

    protected void btnLog_Click(object sender, EventArgs e)
    {
        iframe.Attributes["src"] = "ManLog.aspx";
        divmain.Visible = true;

    }
}
    
