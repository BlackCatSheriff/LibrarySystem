<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adminre.aspx.cs" Inherits="admin_adminre" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div><h3<>仓库</h3><br />
                   <asp:Repeater ID="rptre" runat ="server" OnItemCommand="rptre_ItemCommand" >
                      <HeaderTemplate >
                          <table  border ="1" >
                              <tr>
                                  <th>ISBN</th>
                                  <th>书号</th>
                                  <th>书名</th>
                                  <th>读者</th>
                                  <th>状态</th>
                                  <th>删除</th>
                                  
                                  
                              </tr>

                          
                      </HeaderTemplate>
                      <ItemTemplate >
                          <tr>
                              <td> <%# Eval ("ISBN") %> </td>
                              <td><%# Eval ("Rid") %> </td>
                              <td><%# Eval("Bname") %></td>
                              <td><%# Eval ("Ruid") %> </td>
                              <td><%# Eval ("Rstate") %> </td>                                                                   
                            
                             <td><asp:LinkButton ID="lbtdelete" runat="server" Text="删除" Style ="TEXT-DECORATION: none" CommandName="Delete" CommandArgument='<%#Eval("Rid") %>' ></asp:LinkButton></td>


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
