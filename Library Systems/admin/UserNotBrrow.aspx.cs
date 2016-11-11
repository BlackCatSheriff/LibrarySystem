using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_UserNotBrrow : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {



        if (Session["Succeed_main"] == null)
        {
            Response.Write("<script>window.alert('请登录！');location.href='adminLogin.aspx';</script>");
            return;
        }
        else if (Session["Userid"] == null)
        {
            Response.Write("<script>window.alert('请重新查看！');location.href='Users.aspx';</script>");
            return;

        }
        else if(!IsPostBack)
        {

            JumpPage(1);


        }
    }

    protected void JumpPage(int currentPage)
    {
        string sqlbooklist = "select Rid,Bname from View_usersbooklist where  Ruid='" + Session["Userid"].ToString().Trim() + "' and Rstate=0 order by Rid asc";
        string sqlusername = "select Username from Library.dbo.Users where id='" + Session["Userid"].ToString().Trim() + "'";
        lblUsername.Text = "用户： " + Class_Login.SelectHead(sqlusername) + "未还数目列表";
        DataTable dt = Class_Login.SelectT(sqlbooklist);

        PagedDataSource pds = new PagedDataSource();
        pds.AllowPaging = true;
        pds.PageSize = 10;
        pds.DataSource = dt.DefaultView;
        lbTotal.Text = pds.PageCount.ToString();
        pds.CurrentPageIndex = currentPage - 1;
         rptUserNorBor.DataSource = pds;
         rptUserNorBor.DataBind();


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