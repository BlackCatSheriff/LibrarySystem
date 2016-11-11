using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_adminre : System.Web.UI.Page
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

    protected void rptre_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if(e.CommandName == "Delete")
        {
            string sqldelstate = "select  Library.dbo.Repertory.Rstate  from Library.dbo.Repertory  where Rid='"+e.CommandArgument .ToString ().Trim() +"' ";
            string sqldel = "delete from Library.dbo.Repertory  where Rid='" + e.CommandArgument.ToString().Trim().ToString().Trim() + "'";
            string sqloldcount = "select Library .dbo.Books.Bcount from Library .dbo.Books where ISBN =(select Library .dbo.Repertory.Risbn from Library .dbo.Repertory where rid='" + e.CommandArgument.ToString().Trim() + "') ";
            string sqloldlent= "select Library .dbo.Books.Blent from Library .dbo.Books where ISBN =(select Library .dbo.Repertory.Risbn from Library .dbo.Repertory where rid='" + e.CommandArgument.ToString().Trim() + "') ";
            int oldcount = Convert .ToInt32 (Class_Login.SelectHead(sqloldcount));
            int oldlent = Convert.ToInt32(Class_Login.SelectHead(sqloldlent));
             string sqlBooksupdata = "update Library .dbo.Books set Bcount ="+(oldcount-1)+" ,Blent="+(oldlent-1)+" where ISBN =(select Library .dbo.Repertory.Risbn from Library .dbo.Repertory where rid='"+ e.CommandArgument.ToString().Trim() + "')";
           // string sqlBooksupdata = "update Library .dbo.Books set Bcount + = -1 ,Blent + = - 1 where ISBN =(select Library .dbo.Repertory.Risbn from Library .dbo.Repertory where rid='" + e.CommandArgument.ToString().Trim() + "')";

            if ( Convert.ToInt32(Class_Login.SelectHead(sqldelstate))==1)
            {
                int i;
                i = Class_Login.Operate(sqlBooksupdata); 
                if (i != 0 || i!=-1)
                {
                    Class_Login.Operate(sqldel);
                    string sqlLid = "select mid from Library.dbo.Manager where Mname='"+ Session["Succeed_main"].ToString ().Trim ()+ "'";
                    string Lid = Class_Login. SelectHead(sqlLid);
                    string sqlAddlog = "insert into  Library.dbo.OperateLog  values('" + Lid + "','" + Session["Succeed_main"].ToString().Trim() + "',Datename(year,GetDate())+'-'+Datename(month,GetDate())+'-'+Datename(day,GetDate())+'-'+DATENAME(WEEKDAY,GETDATE())+'-'+DATENAME(HOUR,GETDATE())+':'+DATENAME(MINUTE,GETDATE())+':'+DATENAME(SECOND,GETDATE()),'删除,书号" + e.CommandArgument.ToString().Trim() + "的图书')";
                    Class_Login.Operate(sqlAddlog);
                    Response.Write("<script>window.alert('删除成功!');location.href='adminre.aspx';</script>");

                }
                else
                {
                    Response.Write("<script>window.alert('删除失败!数据库删除失败0 -1 ')</script>");
                }

            }
            else
            {
                Response.Write("<script>window.alert('删除失败!state=0')</script>");
            }
          

        }

    }
    protected  void JumpPage(int currentPage)
    {
        string sqlre = "select ISBN,Rid,Bname,Ruid ,Rstate from  View_usersbooklist order by Rid asc";
        DataTable dt = Class_Login.SelectT(sqlre);

        PagedDataSource pds = new PagedDataSource();
        pds.AllowPaging = true;
        pds.PageSize = 10;
        pds.DataSource = dt.DefaultView;
        lbTotal.Text = pds.PageCount.ToString();
        pds.CurrentPageIndex = currentPage -1;
        rptre.DataSource = pds;
        rptre.DataBind();


    }



    protected void btnFirst_Click(object sender, EventArgs e)
    {
        JumpPage(1);
        lbNow.Text ="1";


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
            lbNow.Text = (Convert.ToInt32(lbNow.Text) - 1).ToString ();
            JumpPage(Convert.ToInt32(lbNow.Text));
        }

    }

    protected void btnDrow_Click(object sender, EventArgs e)
    {
        if (lbNow.Text == lbTotal.Text )
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
        if((Convert.ToInt32( txtJump.Text.Trim ()) < 1) || ( Convert.ToInt32(txtJump.Text.Trim())>Convert.ToInt32(lbTotal.Text .Trim ())))
         {    
            JumpPage(1);
            lbNow.Text = "1";

        }
        else
        {
            JumpPage(Convert.ToInt32(txtJump.Text.Trim()));
            lbNow.Text = txtJump.Text.Trim ();

        }

    }
}