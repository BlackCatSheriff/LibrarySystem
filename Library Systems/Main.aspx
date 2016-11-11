<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Main" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div >
         <img alt="中国海洋大学图书馆书目检索系统" src="\img\haeder.png" />
        <table >
            
               
          
          <tr>
                <th >
                    <asp:Label ID ="lblUsername" runat ="server" Visible ="False" Width="300px" ></asp:Label>
                </th>
              
                <th >
                   
                    <asp:LinkButton  ID="lbnLogin" runat ="server" Text ="" Style ="TEXT-DECORATION: none"  OnClick="lbnLogin_Click"></asp:LinkButton>
                </th>
              
            </tr>

        </table>

    </div>
        <div >
            <table >
                <tr>
                    <th>
                         <asp:Button ID ="btnSearch" runat = "server" Text="书目检索" Font-Size="Large" Font-Bold="True" ForeColor="blue"  OnClick="btnSearch_Click"  />

                    </th>
                    <th ></th><th ></th><th ></th><th ></th><th ></th>
                            <th>
                         <asp:Button ID ="btnReader" runat = "server" Text="我的图书馆" Font-Size="Large" Font-Bold="True" ForeColor="blue" OnClick="btnReader_Click"  />

                    </th>
                   
                </tr>
            </table>
        </div>

  		<div class="content" id ="divbooksearch" runat ="server" visible ="true" ><!--主面板的内容放在content内，content为一级版面，不要轻易编辑该层内容-->
         <div id="iframe-wrap">
        <iframe name="inner1" id="iframe" runat ="server"  src="Search.aspx" width="100%" height="1000px" >
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

       
         <div class="content" id ="divmylib" runat ="server" visible ="false" ><!--主面板的内容放在content内，content为一级版面，不要轻易编辑该层内容-->
         <div id="iframe-wrap1">
        <iframe name="inner1" id="iframe1" runat ="server"  src="Reader.aspx" width="100%" height="1000px" >
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
