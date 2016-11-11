using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_addbook : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Succeed_main"] == null)
        {
            Response.Write("<script>window.alert('请登录！');location.href='adminLogin.aspx';</script>");
            return;
        }

    }

    protected void btnADD_Click(object sender, EventArgs e)
    {
        if(txtISBN .Text .Trim ()=="" || txtName .Text .Trim ()=="" || txtClass .Text .Trim ()=="" || txtAuthor .Text .Trim ()=="" || txtText .Text .Trim ()=="" || txtCount .Text .Trim ()=="" || Convert .ToInt32 ( txtCount.Text.Trim())<=0)
        {
            Response.Write("<script>window.alert('请填写完整信息！')</script>");
            return;

        }
        else
        { 
        string sqlCheckISBN = "select Library.dbo.Books.ISBN from Library.dbo.Books where ISBN='" + txtISBN.Text.Trim() + "'";
            DataTable dt = Class_Login.SelectT(sqlCheckISBN);
            int cc  = dt.Rows.Count;

        if(cc!=0)
        {

            Response.Write("<script>window.alert('图书已存在，请点击修改！')</script>");
            return;

        }
        else
        {
            string sqlAddtoBooks = "insert into   Library.dbo.Books values('"+txtISBN .Text .Trim ()+"','"+txtName.Text .Trim ()+"','"+txtClass .Text .Trim ()+"','"+txtAuthor .Text .Trim ()+"','"+txtText .Text.Trim ()+"',"+Convert .ToInt32(txtCount .Text .Trim ())+ "," + Convert.ToInt32(txtCount.Text.Trim()) + ")";
               // string sqlAutoRid = "declare @i int declare @j int declare @s char(10) set @i=(select max(rid) from library.dbo.repertory  where risbn='" + txtISBN.Text.Trim() + "')+1 set @s='" + txtISBN.Text.Trim() + "' set @j=0 while @j<" + Convert.ToInt32(txtCount.Text.Trim()) + " begin  insert into library.dbo.repertory  values(@i,@s,-1,1)  set @j=@j+1  end";





                string sqlDel = "delete Library.dbo.Books where ISBN='"+txtISBN .Text.Trim ()+"'";





                int pd = Class_Login.Operate(sqlAddtoBooks);
                if(pd==0 || pd==-1)
                {
                    Response.Write("<script>window.alert('增加失败！')</script>");
                    return;
                }
                else
                {
                    ////开始自动添加仓库编号
                    //int jd = Class_Login.Operate(sqlAutoRid);
                    //if (jd == 0 || jd == -1)
                    //{
                    //    Response.Write("<script>window.alert('增加失败！')</script>");

                    //  Class_Login.Operate(sqlDel);   //删除books的记录

                    //    return;
                    //}

                    ////自动添加完毕

                    //循环增加数据开始
                    //string sqlmaxrid = "select max(Rid) from Library.dbo.repertory  where Risbn=" + txtISBN.Text.Trim() + "";
                    //int maxrid = Convert.ToInt32(Class_Login.SelectHead(sqlmaxrid));
                    int maxrid = Convert.ToInt32(txtISBN.Text.Trim() + "0001");
                    string sqlinsert = "";
                    for (int i = 0; i < Convert.ToInt32(txtCount.Text.Trim()); i++)
                    {
                        sqlinsert = "insert into library.dbo.repertory  values(" + (maxrid++) + "," + txtISBN.Text.Trim() + ",-1,1) ";
                       if( Class_Login.Operate(sqlinsert)!=1)
                        {
                            Class_Login.Operate(sqlDel);   //删除books的记录
                            Response.Write("<script>window.alert('增加失败！')</script>");
                            return;                           

                        }

                    }
                    string sqlLid = "select mid from Library.dbo.Manager where Mname='" + Session["Succeed_main"].ToString().Trim() + "'";
                    string Lid = Class_Login.SelectHead(sqlLid);
                    string sqlAddlog = "insert into  Library.dbo.OperateLog  values('" + Lid + "','" + Session["Succeed_main"].ToString().Trim() + "',Datename(year,GetDate())+'-'+Datename(month,GetDate())+'-'+Datename(day,GetDate())+'-'+DATENAME(WEEKDAY,GETDATE())+'-'+DATENAME(HOUR,GETDATE())+':'+DATENAME(MINUTE,GETDATE())+':'+DATENAME(SECOND,GETDATE()),'添加图书,ISBN=" + txtISBN.Text.Trim() + ",书号:" + txtISBN.Text.Trim() + "0001 到"+ (maxrid-1).ToString () + "的图书')";
                    Class_Login.Operate(sqlAddlog);

                    Response.Write("<script>window.alert('增加成功！')</script>");


                    //循环增加结束


                }
        }
        }

    }
}