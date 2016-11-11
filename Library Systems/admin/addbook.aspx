<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addbook.aspx.cs" Inherits="admin_addbook" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        添加图书<br />
        ISBN：<asp:TextBox ID="txtISBN" runat ="server"  TextMode ="Number" MaxLength ="4"></asp:TextBox><br />
         书名：<asp:TextBox ID="txtName" runat ="server"   MaxLength ="40"></asp:TextBox><br />
         类别：<asp:TextBox ID="txtClass" runat ="server"   MaxLength ="40"></asp:TextBox><br />
         作者：<asp:TextBox ID="txtAuthor" runat ="server"  MaxLength ="40"></asp:TextBox><br />
         内容：<asp:TextBox ID="txtText" runat ="server"   MaxLength ="40"></asp:TextBox><br />
         数量：<asp:TextBox ID="txtCount" runat ="server"  TextMode ="Number" MaxLength ="4"></asp:TextBox><br />
         <asp:Button ID="btnADD" runat ="server" Text ="添加" OnClick="btnADD_Click" />


    
    </div>
    </form>
</body>
</html>
