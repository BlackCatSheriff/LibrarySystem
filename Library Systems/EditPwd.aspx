<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditPwd.aspx.cs" Inherits="EditPwd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
  <h2>密码修改：</h2><br />
      
        <br />
        旧密码：<asp:TextBox id="editpwdold" runat ="server"  Text ="" MaxLength1="15" TextMode="Password" ></asp:TextBox>
        <br />
        新密码：<asp:TextBox  ID="editpwdnew" runat ="server"  Text =""  MaxLength ="15" TextMode="Password"> </asp:TextBox>
        &nbsp<br />
        &nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID ="btnsubmit" runat ="server" Text ="提交" OnClick="btnsubmit_Click" />
    
    </div>
    </form>
</body>
</html>
