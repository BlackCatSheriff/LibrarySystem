<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table  border ="1">
        <tr>
            <th >
                类型：<asp:DropDownList ID="dropSearch"  runat="server" >
                    <asp:ListItem  Selected ="True"  >ISBN</asp:ListItem>
                    <asp:ListItem >书名</asp:ListItem>
                    <asp:ListItem >作者</asp:ListItem>
                    <asp:ListItem >题材</asp:ListItem>
                   </asp:DropDownList>&nbsp
                <asp:TextBox ID ="txtSearch" runat ="server"  MaxLength ="20" ></asp:TextBox>&nbsp&nbsp&nbsp
                <asp:Button ID ="btnSubSearch" runat ="server"  Text ="检索" OnClick="btnSubSearch_Click" />
            </th>

        </tr>

    </table>
    </div>


       <div>

          <table >
              <tr>
                  <th>
                      <asp:Label id="lblKind" runat ="server" Text =""></asp:Label> <asp:Label ID ="lblSearch" runat ="server" Text =""></asp:Label>
                  </th>
              </tr>
              <!--开始查询结果绑定 -->
              <tr>
                  <asp:Repeater ID="rptSearchmain" runat ="server" OnItemCommand="rptSearchmain_ItemCommand" >
                      <HeaderTemplate >
                          <table border="1">
                              <tr>
                                  <th>书名</th>
                                  
                                  <th>馆藏</th>
                                  <th>可借</th>
                                  <th>查看</th>
                                  <th>借阅</th>
                                  
                                  
                              </tr>

                          
                      </HeaderTemplate>
                      <ItemTemplate >
                          <tr>
                              
                              <td> <%# Eval ("Bname") %> </td>
                              <td><%# Eval ("Bcount") %> </td>
                              <td><%# Eval ("Blent") %> </td>                                                                   
                              <td><a  href="BookInfo.aspx?bid=<%#Eval("ISBN") %>">查看</a></td>
                             <td><asp:LinkButton ID="lbtBorrow" runat="server" Text="借阅" Style ="TEXT-DECORATION: none" CommandName="Borrow" CommandArgument='<%#Eval("Bname") %>' ></asp:LinkButton></td>


                          </tr>

                          
                      </ItemTemplate>
                      <FooterTemplate >
                          </table>
                      </FooterTemplate>
                  </asp:Repeater>



              </tr>
              <!--绑定结束-->
      

          </table>
     
         
       </div>
        <div  id ="divTool" runat ="server"  visible ="false">


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
