<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adminLogin.aspx.cs" Inherits="admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <style type="text/css">
h1 {text-align: center}

</style>
</head>
<body style="height: 90px">
    <form id="form1" runat="server">
    <div>
     
           <h1>管理员登录页</h1><br /> 
        <br />

            用户名:<asp:TextBox ID ="txtamdinname" runat ="server" MaxLength="20"></asp:TextBox> 
         <asp:RegularExpressionValidator ID="RegularExpressionValidator_Username" runat="server" ErrorMessage="请输入合法用户名！" ValidationExpression ="^[a-zA-Z]\w{5,17}$" ControlToValidate ="txtamdinname" ForeColor ="Red" ></asp:RegularExpressionValidator><br /><br />

           密码:&nbsp;<asp:TextBox ID ="txtadminpwd" runat ="server" TextMode ="Password" MaxLength="20"></asp:TextBox>  <br /><br />
            <asp:Button ID="btnadminLogin" runat ="server" Text ="登录" OnClick="btnadminLogin_Click" />
        


    </div>
    </form>
</body>
</html>
