<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editor.aspx.cs" Inherits="admin_deleteISBN" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div><h3>编辑图书：</h3><br />
        ISBN：<asp:Label ID ="lblisbn" runat ="server" ></asp:Label><br />
         书名：<asp:TextBox ID="txtName" runat ="server"   MaxLength ="40"></asp:TextBox><br />
         类别：<asp:TextBox ID="txtClass" runat ="server"   MaxLength ="40"></asp:TextBox><br />
         作者：<asp:TextBox ID="txtAuthor" runat ="server"  MaxLength ="40"></asp:TextBox><br />
         内容：<asp:TextBox ID="txtText" runat ="server"   MaxLength ="40"></asp:TextBox><br />
         数量：<asp:TextBox ID="txtCount" runat ="server"  TextMode ="Number" MaxLength ="4"></asp:TextBox>只能增加不能减少<br />
         <asp:Button ID="btnedit" runat ="server" Text ="修改" OnClick="btnedit_Click"  />
    
    </div>
    </form>
</body>
</html>
