<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NowBorrow.aspx.cs" Inherits="NowBorrow" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <h2>当前节借阅：</h2><br />
        
     <!--数据绑定-->

        <asp:Repeater ID="rptNowborrow" runat ="server" OnItemCommand="rptNowborrow_ItemCommand" >
            <HeaderTemplate >
                <table border ="1" >
                    <tr>
                        
                        <th>书号</th>
                        <th>书名</th>
                        <th>还书</th>
                        
                    </tr>
            </HeaderTemplate>
            <ItemTemplate >
               
                <tr>
                    
                    <td><%# Eval ("Rid") %></td>
                    <td><%# Eval("Bname") %></td>
                    <td><asp:LinkButton ID="lbtreturn" runat="server" Text="还书" Style ="TEXT-DECORATION: none" CommandName="return" CommandArgument='<%#Eval("Rid") %>' ></asp:LinkButton></td>

                </tr> 

            </ItemTemplate>
            <FooterTemplate >
                </table>
            </FooterTemplate>
        </asp:Repeater>
                <asp:Button ID="btnFirst" runat="server" Text="首页" OnClick="btnFirst_Click" />
              <asp:Button ID="btnUp" runat="server" Text="上一页" OnClick="btnUp_Click" />
        <asp:Button ID="btnDrow" runat="server" Text="下一页"  OnClick="btnDrow_Click"/>
        
        <asp:Button ID="btnLast" runat="server" Text="尾页"  OnClick="btnLast_Click"/>
        页次：<asp:Label ID="lbNow" runat="server" Text="1"></asp:Label>
        /<asp:Label ID="lbTotal" runat="server" Text="1"></asp:Label>

        转<asp:TextBox ID="txtJump" Text="1" runat="server" Width="30px" TextMode="Number"></asp:TextBox>
        <asp:Button ID="btnJump" runat="server" Text="Go"  OnClick="btnJump_Click"/>  






    
    </div>
    </form>
</body>
</html>
