using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NowBorrow : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Succeed_name"] == null)
        {
            Response.Write("<script>window.alert('无法查询！请先登录！');location.href='Login.aspx';</script>");
            return;
        }
        else if(!IsPostBack)
        {
            JumpPage(1);
        }
    }

    protected void rptNowborrow_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if(e.CommandName =="return")
        {
            if (Session["Succeed_name"] == null)
            {
                Response.Write("<script>window.alert('还书失败，请登录！');location.href='Login.aspx';</script>");

            }
            else
            {
                string trid = e.CommandArgument.ToString().Trim();
                string sqlreturn0 = "update  Library .dbo.Repertory  set Rstate =1 ,Ruid=-1 where Rid =" + trid + "";
                int ts = Class_Login.Operate(sqlreturn0);
                if(ts==0 || ts==-1)
                {
                    Response.Write("<script>alert('还书失败！归零出错')</scipt>");
                    return;
                }
                string sqladdone = "update Library .dbo.Books set Blent += 1 where ISBN = (select Risbn from Library.dbo.Repertory where Rid = "+trid+" )";
                ts = Class_Login.Operate(sqladdone);
                if (ts == 0 || ts == -1)
                {
                    Response.Write("<script>alert('还书失败！BOOKS加一出错')</scipt>");
                    return;
                }
                Response.Write("<script>window.alert('还书成功！');location.href='NowBorrow.aspx';</script>");


            }

        }
    }


    protected void JumpPage(int currentPage)
    {
        string sql = "select Rid, Bname from View_usersbooklist where Ruid = (select id from Library.dbo.Users where Username = '" + Session["Succeed_name"].ToString().Trim() + "') and Rstate = 0 order by Rid asc";
        DataTable dt = Class_Login.SelectT(sql);

        PagedDataSource pds = new PagedDataSource();
        pds.AllowPaging = true;
        pds.PageSize = 10;
        pds.DataSource = dt.DefaultView;
        lbTotal.Text = pds.PageCount.ToString();
        pds.CurrentPageIndex = currentPage - 1;
        rptNowborrow.DataSource = pds;
        rptNowborrow.DataBind();


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