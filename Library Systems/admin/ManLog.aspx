<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManLog.aspx.cs" Inherits="admin_ManLog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div><h3>操作记录：</h3><br />

        <asp:Repeater ID="rptLog" runat ="server" OnItemCommand="rptLog_ItemCommand"   >
                      <HeaderTemplate >
                          <table  border ="1" >
                              <tr>
                                  <th>工号</th>
                                  <th>姓名</th>
                                  <th>操作时间</th>
                                  <th>事件</th>
                                  <th>删除</th>
                                  
                                  
                              </tr>

                          
                      </HeaderTemplate>
                      <ItemTemplate >
                          <tr>
                              <td> <%# Eval ("Lid") %> </td>
                              <td><%# Eval ("Lname") %> </td>
                              <td><%# Eval ("Ltime") %> </td>
                              <td><%# Eval ("Levents") %> </td>                                                                   
                            
                             <td><asp:LinkButton ID="lbtdelete" runat="server" Text="删除" Style ="TEXT-DECORATION: none" CommandName="Delete" CommandArgument='<%#Eval("Ltime") %>' ></asp:LinkButton></td>


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
