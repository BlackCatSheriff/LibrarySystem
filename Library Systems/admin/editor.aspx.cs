using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_deleteISBN : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Succeed_main"] == null)
        {
            Response.Write("<script>window.alert('请登录！');location.href='adminLogin.aspx';</script>");
            return;
        }
        if (Request.QueryString["ISBN"] != null)
        {
            string sqlcheckisbn = "select ISBN from Library.dbo.Books where ISBN='" + Request.QueryString["ISBN"].ToString().Trim() + "'";
            DataTable dtcheck = Class_Login.SelectT(sqlcheckisbn);
            if(dtcheck.Rows.Count<1)
            {
                Response.Write("<script>window.alert('页面跳转出错！');location.href='books.aspx';</script>");
                return;


            }
            else if (!IsPostBack)
            {
                lblisbn.Text = Request.QueryString["ISBN"].ToString().Trim();
                string sqlreturncpnt = "select * from Library .dbo.Books where ISBN='" + Request.QueryString["ISBN"].ToString().Trim() + "'";
                DataTable dtss = Class_Login.SelectT(sqlreturncpnt);
                txtName.Text = dtss.Rows[0][1].ToString().Trim();
                txtClass.Text = dtss.Rows[0][2].ToString().Trim();
                txtAuthor.Text = dtss.Rows[0][3].ToString().Trim();
                txtText.Text = dtss.Rows[0][4].ToString().Trim();
                txtCount.Text = dtss.Rows[0][5].ToString().Trim();
            }

          

        }
        else
        {
            btnedit.Enabled = false;

        }
        

    }

    protected void btnedit_Click(object sender, EventArgs e)
    {
 
        
        if (txtName.Text.Trim() == "" || txtClass.Text.Trim() == "" || txtAuthor.Text.Trim() == "" || txtText.Text.Trim() == "" || txtCount.Text.Trim() == "")
        {
            Response.Write("<script>window.alert('请填写完整信息！')</script>");
            return;

        }
        else
        {
           
            string isbn = Request.QueryString["ISBN"].ToString().Trim();
            string sqloldcount = "select Library .dbo.Books.Bcount  from Library.dbo.Books where ISBN=" + isbn + "";
            int oldcount = Convert.ToInt32(Class_Login.SelectHead(sqloldcount));

            string sqlmaxcount = "select Library .dbo.Repertory .Risbn from Library .dbo.Repertory where Risbn ='" + isbn + "' and Rstate =0";//大于状态为0的数量
            string sqlupbooks = "update Library.dbo.Books set  Bname= '" + txtName.Text.Trim() + "', Bclass = '" + txtClass.Text.Trim() + "',Bauthor= '" + txtAuthor.Text.Trim() + "',Btext= '" + txtText.Text.Trim() + "',Bcount ="+ Convert.ToInt32(txtCount.Text.Trim())+",Blent+= "+ (Convert.ToInt32(txtCount.Text.Trim())-oldcount)+" where ISBN='"+isbn+"'";

            //string sqlAutoRid = "declare @i int declare @j int declare @s char(10) set @i=(select max(rid) from library.dbo.repertory  where risbn='" + isbn + "')+1 set @s='" + isbn + "' set @j=0 while @j<" + (Convert.ToInt32(txtCount.Text.Trim()) - oldcount) + " begin  insert into library.dbo.repertory  values(@i,@s,-1,1)  set @j=@j+1  end";
            string sqlmaxrid = "select max(Rid) from Library.dbo.repertory  where Risbn=" + isbn + "";
            string tmaxrid = Class_Login.SelectHead(sqlmaxrid);

            int maxrid = Convert.ToInt32(tmaxrid);


            DataTable dt = Class_Login.SelectT(sqlmaxcount);
           
            int mincount = dt.Rows.Count;
            if (Convert.ToInt32(txtCount.Text.Trim()) < mincount)
            {
                Response.Write("<script>window.alert('数量不能少于当前读者已借阅本书的数量！')</script>");
                return;

            }
            else
            {
                //更新books表

                int i;
                i = Class_Login.Operate(sqlupbooks);
                if (i != 0 || i != -1)
                {
                    //自动添加到仓库

                    //int jd = Class_Login.Operate(sqlAutoRid);
                    //if (jd == 0 || jd == -1)
                    //{
                    //    Response.Write("<script>window.alert('仓库增加失败！')</script>");

                    //   return;
                    //}

                    string sqlinsert = "";
                    for (int j = 0; j < Convert.ToInt32(txtCount.Text.Trim())-oldcount; j++)
                    { 
                        sqlinsert = "insert into library.dbo.repertory  values(" + (++maxrid) + "," + isbn + ",-1,1) ";
                        if (Class_Login.Operate(sqlinsert) != 1)
                        {
                            
                            Response.Write("<script>window.alert('增加失败！')</script>");
                            return;

                        }

                    }






                    //添加完毕

                    string sqlLid = "select mid from Library.dbo.Manager where Mname='" + Session["Succeed_main"].ToString().Trim() + "'";
                    string Lid = Class_Login.SelectHead(sqlLid);
                    string sqlAddlog = "insert into  Library.dbo.OperateLog  values('" + Lid + "','" + Session["Succeed_main"].ToString().Trim() + "',Datename(year,GetDate())+'-'+Datename(month,GetDate())+'-'+Datename(day,GetDate())+'-'+DATENAME(WEEKDAY,GETDATE())+'-'+DATENAME(HOUR,GETDATE())+':'+DATENAME(MINUTE,GETDATE())+':'+DATENAME(SECOND,GETDATE()),'增加图书,ISBN=" + isbn + ",书号:" + tmaxrid + " 到" + maxrid.ToString() + "的图书')";
                    Class_Login.Operate(sqlAddlog);



                    Response.Write("<script>window.alert('修改成功!')</script>");
                }
                else
                {
                    Response.Write("<script>window.alert('修改失败!books数据库更新失败 ')</script>");
                }



            }
        }

    }
}