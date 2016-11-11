<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reader.aspx.cs" Inherits="Reader" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:LinkButton id="lbtninfo" runat ="server" Text ="证件信息" Style ="TEXT-DECORATION: none" OnClick="lbtninfo_Click"></asp:LinkButton>&nbsp&nbsp&nbsp
        <asp:LinkButton ID ="lbtnborrow" runat ="server" Text ="当前借阅" Style ="TEXT-DECORATION: none" OnClick="lbtnborrow_Click"></asp:LinkButton>&nbsp&nbsp&nbsp
        <asp:LinkButton  ID="lbtnhistor" runat ="server" Text ="历史借阅" Style ="TEXT-DECORATION: none" OnClick="lbtnhistor_Click"></asp:LinkButton>&nbsp&nbsp&nbsp
        <asp:LinkButton ID ="lbtneditpwd"  runat ="server" Text ="修改密码" Style ="TEXT-DECORATION: none" OnClick="lbtneditpwd_Click"></asp:LinkButton>&nbsp<br />
        &nbsp&nbsp
    </div>

        <div id="divinfo" runat ="server" visible ="true">
            <table  border ="1">
                <tr >
                    <th >
                        姓名：
                    </th>
                    <th >
                        <asp:Label ID ="lblinfoname" runat ="server" Width ="300px"></asp:Label>
                    </th>&nbsp&nbsp

                     <th >
                        学号：
                    </th>
                    <th >
                        <asp:Label ID ="lblinfoid" runat ="server" Width ="300px"></asp:Label>
                    </th>&nbsp&nbsp


                </tr>

               <tr ></tr>

                <tr >
                   
                        <th>E-mail:</th>
                        <th><asp:Label  ID ="lblinfoemail" runat ="server" Text ="" Width ="300px"></asp:Label>
                    </th>&nbsp&nbsp
                       <th >Phone:</th>
                    <th><asp:Label ID ="lblinfophone" runat ="server" Text ="" Width ="300px"></asp:Label></th>&nbsp&nbsp
                </tr>
                <tr >
                    <th >注册日期：</th>
                    <th ><asp:Label ID ="lblinfodate" runat ="server" Text ="" Width ="300px" ></asp:Label></th>
                </tr>
            </table>
        </div>


        
        <div id="divhistory" runat ="server" visible ="false">
			<h2>历史借阅：</h2>
            <asp:Repeater ID="rptHistory" runat ="server" >
                <HeaderTemplate >
                    <table  border="1">
                        <tr>
                             <th>书号</th>
                             <th>书名</th>
                            
                           
                        </tr>

                    
                </HeaderTemplate>
                <ItemTemplate >
                    <tr>
                        <td> <%# Eval ("Hrid") %></td>
                      <td><%# Eval("Bname") %></td>
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
        
        <div class="content" id ="divNowbor" runat ="server" visible ="false" ><!--主面板的内容放在content内，content为一级版面，不要轻易编辑该层内容-->
         <div id="iframe-wrap1">
        <iframe name="inner1" id="iframe1" runat ="server"  src="" width="100%" height="1000px" >
        </iframe>
        <style>
		
		#iframe-wrap { height: 100%; overflow: visible; position: relative; top: 0; z-index: 0 }
		.tablet-width iframe { height: 960px!important }
		.mobile-width iframe { height: 704px!important }
		.mobile-width-2 iframe { height: 416px!important }
		.mobile-width-3 iframe { height: 256px!important }
		</style>
    </div>
         <!--嵌入外部html-->
         
		</div> <!--一级版面-->







    </form>
</body>
</html>
