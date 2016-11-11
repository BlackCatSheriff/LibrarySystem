using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Users : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Succeed_main"] == null)
        {
            Response.Write("<script>window.alert('请登录！');location.href='adminLogin.aspx';</script>");
            return;
        }
        else if(!IsPostBack)
        {
            JumpPage(1);

        }

    }

    protected void rptUsers_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if(e.CommandName == "Reset")
        {
            string sqlReset= "update Library.dbo.Users set Password='F7C3BC1D808E04732ADF679965CCC34C' where id='"+e.CommandArgument .ToString ().Trim ()+"'";

            int result = Class_Login.Operate(sqlReset);
            if (result != 1)
            {
                Response.Write("<script>window.alert('密码重置失败！请重新重置！')</script>");
                return;
            }
            else
            {
                string sqlLid = "select mid from Library.dbo.Manager where Mname='" + Session["Succeed_main"].ToString().Trim() + "'";
                string Lid = Class_Login.SelectHead(sqlLid);
                string sqlAddlog = "insert into  Library.dbo.OperateLog  values('" + Lid + "','" + Session["Succeed_main"].ToString().Trim() + "',Datename(year,GetDate())+'-'+Datename(month,GetDate())+'-'+Datename(day,GetDate())+'-'+DATENAME(WEEKDAY,GETDATE())+'-'+DATENAME(HOUR,GETDATE())+':'+DATENAME(MINUTE,GETDATE())+':'+DATENAME(SECOND,GETDATE()),'重置学号为" + e.CommandArgument.ToString().Trim() + "的学生密码')";
                Class_Login.Operate(sqlAddlog);
                Response.Write("<script>window.alert('密码重置成功！密码为:123456789')</script>");
            }
        }
        else if(e.CommandName == "Delete")
        {
            string sqlSearch = "select Library.dbo.Repertory.Rstate from Repertory where Ruid='" + e.CommandArgument.ToString().Trim() + "' and Rstate=0";
            try
            {
                DataTable dt = Class_Login.SelectT(sqlSearch);
                if(dt.Rows.Count >0)
                {
                    Session["Userid"] = e.CommandArgument.ToString().Trim();
                    Response.Write("<script>window.alert('不能删除此用户！该用户还有未还图书');location.href='UserNotBrrow.aspx';</script>");

                }
                else
                {
                    string sqlDEL = "delete from  Library.dbo.Users  where id='" + e.CommandArgument.ToString().Trim() + "'";
                    if(Class_Login .Operate(sqlDEL)==1)
                    {

                        string sqlLid = "select mid from Library.dbo.Manager where Mname='" + Session["Succeed_main"].ToString().Trim() + "'";
                        string Lid = Class_Login.SelectHead(sqlLid);
                        string sqlAddlog = "insert into  Library.dbo.OperateLog  values('" + Lid + "','" + Session["Succeed_main"].ToString().Trim() + "',Datename(year,GetDate())+'-'+Datename(month,GetDate())+'-'+Datename(day,GetDate())+'-'+DATENAME(WEEKDAY,GETDATE())+'-'+DATENAME(HOUR,GETDATE())+':'+DATENAME(MINUTE,GETDATE())+':'+DATENAME(SECOND,GETDATE()),'删除,学号为" + e.CommandArgument.ToString().Trim() + "的学生')";
                        Class_Login.Operate(sqlAddlog);

                        Response.Write("<script>window.alert('删除成功！');location.href='Users.aspx';</script>");
                    }
                    else
                        Response.Write("<script>window.alert('删除失败，请重试！')</script>");

                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>window.alert('删除失败，请重试！')</script>");
            }
        }

    }

    protected void JumpPage(int currentPage)
    {
        string sqlUsers = "select * from Library.dbo.Users order by id asc ";
        DataTable dt = Class_Login.SelectT(sqlUsers);

        PagedDataSource pds = new PagedDataSource();
        pds.AllowPaging = true;
        pds.PageSize = 10;
        pds.DataSource = dt.DefaultView;
        lbTotal.Text = pds.PageCount.ToString();
        pds.CurrentPageIndex = currentPage - 1;
         rptUsers.DataSource = pds;
        rptUsers.DataBind();


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