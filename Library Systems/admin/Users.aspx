<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Users.aspx.cs" Inherits="admin_Users" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h3>用户列表：</h3><br />
        <asp:Repeater ID="rptUsers" runat ="server" OnItemCommand="rptUsers_ItemCommand"   >
                      <HeaderTemplate >
                          <table border="1">
                              <tr>
                                  <th>ID</th>
                                  <th>名字</th>
                                  <th>E-mail</th>
                                  <th>电话</th>
                                  <th>注册日期</th>
                                  <th>密码重置</th>
                                  <th>删除</th>
                                  
                              </tr>

                          
                      </HeaderTemplate>
                      <ItemTemplate >
                          <tr>
                              
                              <td> <%# Eval ("id") %> </td>
                              <td><%# Eval ("Username") %> </td>
                              <td><%# Eval ("Email") %> </td>    
                              <td><%# Eval ("Phone") %> </td>       
                              <td><%# Eval ("StartTime") %> </td>  
    
                              <td><asp:LinkButton ID="lbtReset2" runat="server" Text="密码重置" Style ="TEXT-DECORATION: none" CommandName="Reset" CommandArgument='<%#Eval("id") %>' ></asp:LinkButton></td>
                             <td><asp:LinkButton ID="lbtDel" runat="server" Text="删除" Style ="TEXT-DECORATION: none" CommandName="Delete" CommandArgument='<%#Eval("id") %>' ></asp:LinkButton></td>


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
