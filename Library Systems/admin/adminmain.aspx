<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adminmain.aspx.cs" Inherits="adminmain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <style type="text/css">
h1 {text-align: center}

</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div><h1 >中国海洋大学图书系统后台</h1></div>
                    <asp:Label ID ="lblUsername" runat ="server" Visible ="False" Width="300px" ></asp:Label>
                   
                    <asp:LinkButton  ID="lbnLogin" runat ="server" Text ="" Style ="TEXT-DECORATION: none"  OnClick="lbnLogin_Click"></asp:LinkButton>
        <br /><br />

    
                <asp:Button ID="btncheckre" runat ="server" Text ="查看仓库" OnClick="btncheckre_Click" />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
        <asp:Button ID="btnaddbooks" runat ="server" Text ="增加图书" OnClick="btnaddbooks_Click" />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
        <asp:Button ID="btnedit" runat ="server" Text ="修改、删除图书" OnClick="btnedit_Click"  />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
        <asp:Button ID ="btnUsers" runat ="server" Text ="用户" OnClick="btnUsers_Click" />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
        <asp:Button ID="btnLog" runat ="server" Text ="操作记录" Visible="false"  OnClick="btnLog_Click"/>
        <br />

      
    
    </div>



              <div class="content" id ="divmain" runat ="server" visible ="false" ><!--主面板的内容放在content内，content为一级版面，不要轻易编辑该层内容-->
         <div id="iframe-wrap1">
        <iframe name="inner1" id="iframe" runat ="server"  src="" width="100%" height="1000px" >
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
