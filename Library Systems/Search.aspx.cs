using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

   


    }
     
    //public DataTable dt = new DataTable();
    protected void btnSubSearch_Click(object sender, EventArgs e)
    {/*
        divTool.Visible = true;
        
        lblKind.Text = dropSearch.SelectedValue+"=";
        lblSearch.Text = txtSearch.Text+" 的结果";
        string leixing = dropSearch.SelectedValue;
        string content = txtSearch.Text.Trim();
        

 
        if (leixing.Trim() == "ISBN")
            leixing = "ISBN";
        else if (leixing.Trim() == "书名")
            leixing = "Bname";
        else if (leixing.Trim() == "作者")
            leixing = "Bauthor";
        else if (leixing.Trim() == "题材")
            leixing = "Bclass";


        string sql = "select ISBN ,Bname , Bcount ,Blent from Books where " + leixing + " like '%" + content + "%' order by Blent desc";
        string sqlisbn = "select ISBN from Books where " + leixing + " like '%" + content + "%'";

        DataTable dt = Class_Login.SelectT(sql);
        */
       
            JumpPage(1);
        
        

        

        //Session["look_isbn"] = Class_Login.SelectHead(sqlisbn);





    }



    protected void rptSearchmain_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Borrow")
        {
            if (Session["Succeed_name"] == null)
            {
                Response.Write("<script>window.alert('借阅失败，请登录！');location.href='Login.aspx';</script>");
           

            }
            else
            {
                string bookname = e.CommandArgument.ToString();
                string sqlisbn = "select ISBN from Library .dbo .Books  where Bname='" + bookname + "'";
                string tisbn = Class_Login.SelectHead(sqlisbn);
                string sqluid = "select id from Library .dbo.Users where Username ='" + Session["Succeed_name"].ToString().Trim() + "'";
                int uid = Convert.ToInt32(Class_Login.SelectHead(sqluid));
                            



                string sqlleft = "select Blent from Library.dbo.Books where ISBN = " + tisbn + "";
                string left = Class_Login.SelectHead(sqlleft);
                if(Convert .ToInt32 ( left)<=0)
                {
                    Response.Write("<script>window.alert('借阅失败，库存为零！')</script>");
                    return;

                }
                else
                {
                    string sqldt = "select Rid from Library.dbo.Repertory where Rstate = 1 and Risbn = "+tisbn+"";
                    string trid = Class_Login.SelectHead(sqldt);

                    string sqlbind = "update Library .dbo.Repertory set Ruid ="+uid +" , Rstate=0 where Rid ="+trid +"";
                    int ts = Class_Login.Operate(sqlbind);
                    if(ts==0 || ts==-1)
                    {
                        Response.Write("<script>window.alert('借阅失败，请重新借阅！绑定失败')</script>");
                        return;
                     
                    }
                    string sqlhistory = "insert into Library.dbo.History values ("+uid +", "+trid +","+tisbn+")";
                    ts = Class_Login.Operate(sqlhistory);
                    if (ts == 0 || ts == -1)
                    {
                        Response.Write("<script>window.alert('借阅失败，请重新借阅！历史失败')</script>");
                        return;
                        
                    }
                    string sqlupdatebook = "update Library.dbo .Books set Blent-=1  where ISBN = "+tisbn +"";

                    ts = Class_Login.Operate(sqlupdatebook );
                    if (ts == 0 || ts == -1)
                    {
                        Response.Write("<script>window.alert('借阅失败，请重新借阅！数据-1失败')</script>");
                        return;
                    }
                    Response.Write("<script>window.alert('借阅成功！请妥善保管图书！');location.href='Search.aspx';</script>");
                    





                }
                
            }



        }
    }


    protected void JumpPage(int currentPage)
    {
        divTool.Visible = true;

        lblKind.Text = dropSearch.SelectedValue + "=";
        lblSearch.Text = txtSearch.Text + " 的结果";
        string leixing = dropSearch.SelectedValue;
        string content = txtSearch.Text.Trim();

        if (leixing.Trim() == "ISBN")
            leixing = "ISBN";
        else if (leixing.Trim() == "书名")
            leixing = "Bname";
        else if (leixing.Trim() == "作者")
            leixing = "Bauthor";
        else if (leixing.Trim() == "题材")
            leixing = "Bclass";

        string sql = "select ISBN ,Bname , Bcount ,Blent from Books where " + leixing + " like '%" + content + "%' order by Blent desc";
        string sqlisbn = "select ISBN from Books where " + leixing + " like '%" + content + "%'";

        DataTable dt = Class_Login.SelectT(sql);
        PagedDataSource pds = new PagedDataSource();
        pds.AllowPaging = true;
        pds.PageSize = 10;
        pds.DataSource = dt.DefaultView;
        lbTotal.Text = pds.PageCount.ToString();
        pds.CurrentPageIndex = currentPage - 1;
        rptSearchmain.DataSource = pds;
        rptSearchmain.DataBind();


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