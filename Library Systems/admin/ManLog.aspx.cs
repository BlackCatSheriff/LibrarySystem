using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_ManLog : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["Succeed_main"] == null) || (Session["Succeed_main"].ToString().Trim() != "ILIBowner"))
        {
            Response.Write("<script>window.alert('请登录！');location.href='adminLogin.aspx';</script>");
            return;
        }
        else if(!IsPostBack)
        {
            JumpPage(1);



        }

    }

    protected void rptLog_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        
        if(e.CommandName== "Delete")
        {
            string sqldel = "delete from Library.dbo.OperateLog  where Ltime='" + e.CommandArgument.ToString().Trim() + "'";
            if(Class_Login .Operate(sqldel)==1)
            {
                Response.Write("<script>window.alert('删除成功！');location.href='ManLog.aspx';</script>");

            }
           else
                Response.Write("<script>window.alert('删除失败,请重试！');location.href='ManLog.aspx';</script>");

        }


    }


    protected void JumpPage(int currentPage)
    {
        string sqlLog = "select * from Library.dbo.OperateLog order by Ltime desc";
        DataTable dt = Class_Login.SelectT(sqlLog);

        PagedDataSource pds = new PagedDataSource();
        pds.AllowPaging = true;
        pds.PageSize = 10;
        pds.DataSource = dt.DefaultView;
        lbTotal.Text = pds.PageCount.ToString();
        pds.CurrentPageIndex = currentPage - 1;
        rptLog.DataSource = pds;
        rptLog.DataBind();


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