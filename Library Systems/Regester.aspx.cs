using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Regester : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnRegester_Click(object sender, EventArgs e)
    {
        if (Session["Vnum"].ToString() != txtValidator.Text.Trim())
        {
            Response.Write("<script>alert('登录失败，请检查验证码！')</script>");
            return;
        }
        else if (!RegularExpressionValidator_Username.IsValid && !RegularExpressionValidator_Email.IsValid && !RegularExpressionValidator_phone.IsValid && !CompareValidator_Pwd.IsValid)   //是否通过验证控件的判断
        {
            Response.Write("<script>alert('注册失败请正确填写信息！')</script>");
            return;
        }
        else
        {
            if (isUsername(txtUsername.Text.Trim()) != 1)
            {
                Response.Write("<script>alert('注册失败,用户名存在！')</script>");
                return;
            }
            else
            {
                if (Register(txtUsername.Text.Trim(), txtPassword1.Text.Trim(), txtEmail.Text.Trim(), txtPhone.Text.Trim()) != 1)
                {
                    Response.Write("<script>alert('注册失败请正确填写信息！')</script>");
                    return;
                }
                else
                {
                    Session["Succeed_name"] = txtUsername.Text.Trim();      //传递用户名到登录界面
                    Response.Write("<script>window.alert('注册成功！');location.href='Login.aspx';</script>");
                }

            }
        }
        
    }


    protected void imgValidator_Click(object sender, ImageClickEventArgs e)
    {
        this.imgValidator.ImageUrl = "~/ValidatorPage.aspx?" + DateTime.Now.Millisecond.ToString();      //验证码刷新

    }
    public int isUsername(string username)       //验证是否已经存在该用户
    {
        string sql ="select Username from Users where Username ='" + username + "'";
        DataTable dt = new DataTable();
        dt = Class_Login.SelectT(sql);
        if (dt.Rows.Count == 0) return 1;
        else return 0;

    }
    public int Register(string Username, string Password, string Email, string Phone)    //写入到数据库Users
    {
        string sql = "insert into Users values('" + Username + "',upper(substring(sys.fn_sqlvarbasetostr(HashBytes('SHA1', '"+Password+"')), 3, 32)),'" + Email + "','" + Phone + "',str(year(GETDATE()),4)+'-'+str(month(GETDATE()),2)+'-'+str(day(getdate()),2))";
        return Class_Login.Operate(sql);
    }
}