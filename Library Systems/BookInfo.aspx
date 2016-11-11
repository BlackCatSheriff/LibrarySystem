<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BookInfo.aspx.cs" Inherits="BookInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <!--数据绑定-->

                       <asp:Repeater ID="rptbookinfo" runat ="server" >
                      <HeaderTemplate >
                          <table border ="1" >
                              <tr>
                                  <th>ISBN</th>
                                  <th>书名</th>
                                  <th>分类</th>
                                  <th>作者</th>
                                  <th>内容简介</th>
                                  <th>馆藏</th>
                                  <th>可借</th>
                                  
                                  
                              </tr>

                          
                      </HeaderTemplate>
                      <ItemTemplate >
                          <tr>
                              <td><%# Eval ("ISBN") %> </td><!--判断传值的正确性-->
                              <td><%# Eval ("Bname") %> </td>
                              <td><%# Eval ("Bclass") %> </td>
                              <td><%# Eval ("Bauthor") %> </td>
                              <td><%# Eval ("Btext") %> </td>
                              <td><%# Eval ("Bcount") %> </td>
                              <td><%# Eval ("Blent") %> </td>
                          </tr>

                          
                      </ItemTemplate>
                      <FooterTemplate >
                          </table>
                      </FooterTemplate>
                  </asp:Repeater>





    </div>
    </form>
</body>
</html>
