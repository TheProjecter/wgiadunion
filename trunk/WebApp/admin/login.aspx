<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="admin_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <asp:PlaceHolder id="holderheader" runat="server"></asp:PlaceHolder>
    <style type="text/css">
        #header #top-panel{height:auto; margin:90px auto 20px auto;}
        #sitetitle{ background:url(img/icons/comment.gif) no-repeat; padding-left:19px; position:relative; top:-32px;}
        #panel{width:380px; margin:20px auto 160px auto;}
        #logtxt{ color:rgb(41,65,69); margin:0 auto 40px 30px; font-weight:600; font-size:1.2em;}
        table, td, th{ border-width:0px!important;}
        td{height:35px;}
        td:first-child{ text-align:right; padding-right:5px;}
        td input{ margin-bottom:0px!important;}
        #txtUser, #txtPass{ width:165px;}
        #txtCode{width:100px;}
        #checkcode{ margin-left:5px; vertical-align:bottom;}
        .logbtn{ text-align:center;}
    </style>
    
</head>
<body>
    <form id="form" runat="server">
	<div id="container">
    	<div id="header">
        	<h2>广告联盟管理后台</h2>
            <div id="top-panel">
            <span id="sitetitle">Administrator Dashboard</span>
                <div id="panel">
                <div id="logtxt">管理员登录</div>
                    <table>
                                <tr><td>用户名：</td><td><asp:TextBox runat="server" type="text" name="username" id="txtUser" value="" maxlength="20" class="logtxt"></asp:TextBox></td></tr>
							    <tr><td>密码：</td><td><asp:TextBox runat="server" TextMode="Password" ID="txtPass" MaxLength="20" class="logtxt"></asp:TextBox></td></tr>
    							
							    <tr><td>验证码：</td><td><asp:TextBox runat="server" ID="txtCode" MaxLength="4" CssClass="logvcode"></asp:TextBox><img src="/checkcode.aspx?t=1" alt="点此更换图片" class="vcodeimg" onclick="this.src+=1" id="checkcode" /></td></tr>
						    </table>
						   <div class="logbtn"><asp:Button ID="btnsubmit" Text="登&nbsp;录" runat="server" OnClick="btn_login" /></div>
						   <div style="text-align:center; padding-top:8px;"><asp:Label runat="server" ID="lblLoginMessage" ForeColor="Red" Visible="false"></asp:Label></div>
                </div>
          </div>
      </div>
      
      
<asp:PlaceHolder ID="holderfoot" runat="server"></asp:PlaceHolder>

</div>
    </form>
</body>
</html>
