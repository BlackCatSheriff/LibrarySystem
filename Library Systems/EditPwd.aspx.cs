using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class EditPwd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["Succeed_name"] == null)
        {
            Response.Write("<script>window.alert('请登录！');location.href='Login.aspx';</script>");
            return;

        }
       
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
 


        int t;
        t = ValidPwd(editpwdold.Text.Trim(), Session["Succeed_name"].ToString().Trim());
        if (t==0 || t==-1 )
        {
            Response.Write("<script>window.alert('旧密码不正确，请检查！');location.href='EditPwd.aspx';</script>");
            return;
        }
        else
        {
             t = PwdChange(editpwdnew.Text.Trim(), Session["Succeed_name"].ToString ().Trim ());
            if(t==0 || t==-1)
            {
                Response.Write("<script>window.alert('更改失败！请重新填写！');location.href='EditPwd.aspx';</script>");
                return;

            }
            else
            {
                Response.Write("<script>window.alert('密码更改成功！');location.href='EditPwd.aspx';</script>");
            }



        }

    }


    public int ValidPwd (string Password,string name)
    {

        string sql = "select  id from Users where  Password =upper(substring(sys.fn_sqlvarbasetostr(HashBytes('SHA1', '" + Password + "')), 3, 32)) and  Username= '" + name + "'";
        DataTable dt = new DataTable();
        dt = Class_Login.SelectT(sql);
        if (dt.Rows.Count != 0) return 1;
        else return 0;
    }
    public int PwdChange(string pwd,string name )
    {
        string sql = "update Users set Password = upper(substring(sys.fn_sqlvarbasetostr(HashBytes('SHA1', '" + pwd + "')), 3, 32)) where  Username= '"+name+"'";
        return Class_Login.Operate(sql);


    }
}