<%@ Page Language="C#" AutoEventWireup="true" CodeFile="books.aspx.cs" Inherits="admin_editbooks" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div><h3>书单</h3><br />
    
        <asp:Repeater ID="rptBooks" runat ="server" OnItemCommand="rptBooks_ItemCommand"  >
                      <HeaderTemplate >
                          <table border="1">
                              <tr>
                                  <th>ISBN</th>
                                  <th>书名</th>
                                  <th>类别</th>
                                  <th>作者</th>
                                  <th>内容</th>
                                  <th>数量</th>
                                  <th>剩余</th>
                                  <th>修改</th>
                                  <th>删除</th>
                                  
                                  
                              </tr>

                          
                      </HeaderTemplate>
                      <ItemTemplate >
                          <tr>
                              <td> <%# Eval ("ISBN") %> </td>
                              <td> <%# Eval ("Bname") %> </td>
                              <td> <%# Eval ("Bclass") %> </td>
                              <td> <%# Eval ("Bauthor") %> </td>
                              <td> <%# Eval ("Btext") %> </td>
                              <td><%# Eval ("Bcount") %> </td>
                              <td><%# Eval ("Blent") %> </td>                                                                   
                             <td><asp:LinkButton ID ="lbtedit" runat ="server" Text ="修改" Style ="TEXT-DECORATION: none" PostBackUrl ='<%# "editor.aspx?isbn="+Eval("ISBN") %>'></asp:LinkButton></td>
                             <td><asp:LinkButton ID="lbtDel" runat="server" Text="删除" Style ="TEXT-DECORATION: none" CommandName="Delete" CommandArgument='<%#Eval("ISBN") %>' ></asp:LinkButton></td>


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
