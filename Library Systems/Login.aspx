﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
.tables{  
        width:500px;  
        margin:auto;  
        border:1px solid #000000;  
        border-collapse:collapse;  
    }  
.tables th,tr,td{  
        border:1px solid #ffffff;  
    }  
.tables th{ background-color:#ffffff;}  
.tables tr:hover{background-color:#ffffff;}  
        
        .auto-style4 {
            width: 429px;
        }
        </style>




</head>
<body>
    <form id="form1" runat="server">
        <table class="tables">  
        
        &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp  &nbsp &nbsp &nbsp &nbsp&nbsp &nbsp &nbsp&nbsp &nbsp &nbsp&nbsp &nbsp &nbsp&nbsp &nbsp &nbsp&nbsp  <asp:Label ID="lblTitle" runat ="server" Text ="用户登录" Font-Size ="Larger" ForeColor ="Black" Font-Bold ="true" ></asp:Label>
            
        <tr>  
            <td class="auto-style4">用户名：&nbsp&nbsp&nbsp <asp:TextBox ID ="LtxtUsername" runat ="server" MaxLength ="20" BorderStyle="Inset" ></asp:TextBox>  
                <asp:RegularExpressionValidator ID="RegularExpressionValidator_Username" runat="server" ErrorMessage="请输入合法用户名！" ValidationExpression ="^[a-zA-Z]\w{5,17}$" ControlToValidate ="LtxtUsername" ForeColor ="Red" ></asp:RegularExpressionValidator>
                <br />
                <br />
            </td>  
 
        </tr>  
        <tr>  
            <td class="auto-style4">密码：&nbsp&nbsp&nbsp&nbsp <asp:TextBox ID ="LtxtPassword" runat ="server" TextMode ="Password" MaxLength ="15"  ></asp:TextBox><br />
                  <br />
            </td>  
    
        </tr>  
                <tr>  
            <td class="auto-style4">验证码(数字):&nbsp<asp:TextBox ID ="txtValidator" runat ="server"  TextMode ="Number"></asp:TextBox>
                
                <asp:ImageButton ID ="imgbtnLvalid" runat ="server" ImageUrl ="~/ValidatorPage.aspx" OnClick="imgbtnLvalid_Click" />

                
                
                <br />
                <br />
                    </td>  
                    
        </tr>  
              <tr>  
             <td class="auto-style4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="btnLogin" runat="server" Height="28px" Text="登录" Width="85px" OnClick="btnRegester_Click" BorderStyle="Groove" />

                &nbsp;&nbsp;&nbsp; <asp:Button ID="btnJumpToRegister" runat ="server" Text ="注册" Height ="28px" Width ="85px" BorderStyle ="Groove" OnClick="btnJumpToRegister_Click" />


             </td>  
    
        </tr> 
                    </table> 
    
        
        
        
        
        
        
        <div>
    
    </div>
    </form>
</body>
</html>
