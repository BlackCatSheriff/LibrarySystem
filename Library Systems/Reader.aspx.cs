using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reader : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Succeed_name"] == null)
        {
            Response.Write("<script>window.alert('无法查看！请先登录！');location.href='Login.aspx';</script>");
            return;
        }
        else
        {
            lblinfoname.Text = Session["Succeed_name"].ToString().Trim();
            
             lblinfoid.Text =Class_Login .SelectHead ("select id from Library.dbo.Users where Username = '" + Session["Succeed_name"].ToString().Trim() + "'");
             lblinfoemail.Text=Class_Login .SelectHead ("select Email from Library.dbo.Users where Username = '" + Session["Succeed_name"].ToString().Trim() + "'");
             lblinfophone.Text =Class_Login .SelectHead ("select Phone from Library.dbo.Users where Username = '" + Session["Succeed_name"].ToString().Trim() + "'");
             lblinfodate.Text =Class_Login .SelectHead ("select StartTime from Library.dbo.Users where Username = '" + Session["Succeed_name"].ToString().Trim() + "'");

            if(!IsPostBack)
            {
                JumpPage(1);
            }


        }
       //绑定数据加载进来
    }

    protected void lbtnborrow_Click(object sender, EventArgs e)
    {
        iframe1.Attributes["src"] = " NowBorrow.aspx";

        divNowbor.Visible = true;
        divinfo.Visible = false;
        divhistory.Visible = false;
        

    }

    protected void lbtnhistor_Click(object sender, EventArgs e)
    {
        divhistory.Visible = true;
        divNowbor.Visible = false;
        divinfo.Visible = false;
        

    }

    protected void lbtninfo_Click(object sender, EventArgs e)
    {
        divinfo.Visible = true;
        divNowbor.Visible = false;
        divhistory.Visible = false;
        


    }

    protected void lbtneditpwd_Click(object sender, EventArgs e)
    {
        iframe1.Attributes["src"] = " EditPwd.aspx";
        divhistory.Visible = false;
        divinfo.Visible = false;
        divNowbor.Visible = true ;

    }
    protected void JumpPage(int currentPage)
    {
        string sql = "select Bname,Hrid from View_History where huid=(select id from Library.dbo.Users where Username = '" + Session["Succeed_name"].ToString().Trim() + "') order by Hrid asc";
        DataTable dt = Class_Login.SelectT(sql);

        PagedDataSource pds = new PagedDataSource();
        pds.AllowPaging = true;
        pds.PageSize = 10;
        pds.DataSource = dt.DefaultView;
        lbTotal.Text = pds.PageCount.ToString();
        pds.CurrentPageIndex = currentPage - 1;
        rptHistory.DataSource = pds;
        rptHistory.DataBind();


    }



    protected void btnFirst_Click(object sender, EventArgs e)
    {
        JumpPage(1);
        lbNow.Text = "1";


    }

    protected void btnUp_Click(object sender, EventArgs e)
    {
        if (lbNow.Text == "1")
        {
            JumpPage(1);
            lbNow.Text = "1";
        }
        else
        {
            lbNow.Text = (Convert.ToInt32(lbNow.Text) - 1).ToString();
            JumpPage(Convert.ToInt32(lbNow.Text));
        }

    }

    protected void btnDrow_Click(object sender, EventArgs e)
    {
        if (lbNow.Text == lbTotal.Text)
        {
            JumpPage(1);
            lbNow.Text = "1";
        }
        else
        {
            lbNow.Text = (Convert.ToInt32(lbNow.Text) + 1).ToString();
            JumpPage(Convert.ToInt32(lbNow.Text));
        }

    }

    protected void btnLast_Click(object sender, EventArgs e)
    {
        JumpPage(Convert.ToInt32(lbTotal.Text));
        lbNow.Text = lbTotal.Text;

    }

    protected void btnJump_Click(object sender, EventArgs e)
    {
        if ((Convert.ToInt32(txtJump.Text.Trim()) < 1) || (Convert.ToInt32(txtJump.Text.Trim()) > Convert.ToInt32(lbTotal.Text.Trim())))
        {
            JumpPage(1);
            lbNow.Text = "1";

        }
        else
        {
            JumpPage(Convert.ToInt32(txtJump.Text.Trim()));
            lbNow.Text = txtJump.Text.Trim();

        }

    }
}