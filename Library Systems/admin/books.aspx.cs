using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_editbooks : System.Web.UI.Page
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


    protected void rptBooks_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if(e.CommandName == "Delete")
        {
            string isbn = e.CommandArgument.ToString().Trim();
            string sqlISdelete = "select  *  from Library.dbo.Repertory  where Risbn='" + e.CommandArgument.ToString().Trim() + "' and Rstate=0 ";
            string sqlDel = "delete Library.dbo.Books where ISBN='"+isbn+"'";
            DataTable dt = Class_Login.SelectT(sqlISdelete);
            if(dt.Rows .Count >0)
            {
                Response.Write("<script>window.alert('此书不能删除，有用户在阅！')</script>");
                return;
            }
            else
            {
                int i;
                i = Class_Login.Operate(sqlDel);
                if (i != 0 || i != -1)
                {
                    string sqlLid = "select mid from Library.dbo.Manager where Mname='" + Session["Succeed_main"].ToString().Trim() + "'";
                    string Lid = Class_Login.SelectHead(sqlLid);
                    string sqlAddlog = "insert into  Library.dbo.OperateLog  values('" + Lid + "','" + Session["Succeed_main"].ToString().Trim() + "',Datename(year,GetDate())+'-'+Datename(month,GetDate())+'-'+Datename(day,GetDate())+'-'+DATENAME(WEEKDAY,GETDATE())+'-'+DATENAME(HOUR,GETDATE())+':'+DATENAME(MINUTE,GETDATE())+':'+DATENAME(SECOND,GETDATE()),'删除,ISBN为" + isbn + "的图书')";
                    Class_Login.Operate(sqlAddlog);
                    Response.Write("<script>window.alert('删除成功!');location.href='books.aspx'</script>");
                }
                else
                {
                    Response.Write("<script>window.alert('删除失败!数据库删除失败0 -1 ')</script>");
                }


            }

        }
    }
    protected void JumpPage(int currentPage)
    {
        string sqlall = "select * from Library.dbo.Books order by ISBN asc";
        DataTable dt = Class_Login.SelectT(sqlall);

        PagedDataSource pds = new PagedDataSource();
        pds.AllowPaging = true;
        pds.PageSize = 10;
        pds.DataSource = dt.DefaultView;
        lbTotal.Text = pds.PageCount.ToString();
        pds.CurrentPageIndex = currentPage - 1;
        rptBooks.DataSource = pds;
        rptBooks.DataBind();


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