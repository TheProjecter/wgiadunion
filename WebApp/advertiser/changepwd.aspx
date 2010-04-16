<%@ Page Language="C#" AutoEventWireup="true" CodeFile="changepwd.aspx.cs" Inherits="advertiser_passwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" rev="stylesheet" href="css/style.css" type="text/css" media="all" />

    <script src="../Js/jquery-1.4.min.js" type="text/javascript"></script>
    <script src="../Js/formValidator.js" type="text/javascript"></script>    
    <script src="../Js/formValidatorRegex.js" type="text/javascript"></script>
     <script type="text/javascript">
           
             $(document).ready(function() {
                 $.formValidator.initConfig({ formid: "form1", autoSubmit: true, onsuccess: function() {  } });
                 $("#txtopwd").formValidator({ onshow: "(必填)", onfocus: "输入登录帐号的原来密码！", onerror: "登录帐号的原来密码不能为空！" }).inputValidator({ min: 5, onerror: "密码最少为5个字符！", max: 15, onerror: "密码不能超过15个字！" });
                 $("#txtnpwd").formValidator({ onshow: "(必填)", onfocus: "输入您要更改的登录密码！", onerror: "请输入您要更改的登录密码！" }).inputValidator({ min: 5, onerror: "密码最少为5个字符！", max: 15, onerror: "密码不能超过15个字！" });
               
                 
             });
     </script>
           
</head>
<body class="ContentBody">
    <form id="form1" runat="server">
    <div class="MainDiv">
<table width="99%" border="0" cellpadding="0" cellspacing="0" class="CContent">
  <tr>
      <th class="tablestyle_title" >登录用户帐号管理</th>
  </tr>
  <tr>
    <td class="CPanel">
		
		<table border="0" cellpadding="0" cellspacing="0" style="width:100%">
		<tr><td align="left">
		
		&nbsp; <asp:Button ID="btnAdd" runat="server" Text="保存" class="right-button02" onclick="btnSave_Click" />
			&nbsp;&nbsp;
		</td></tr>

		<TR>
			<TD width="100%">
			   <p>
                   <asp:Label ID="lblmsg" runat="server" style="color:Red"></asp:Label></p>
                   	<fieldset style="height:100%;">
				<legend>修改登录密码</legend>
				<ul class="adinfo">
				 <li><span class="rowTitle">输入用户原密码：</span><asp:TextBox ID="txtopwd" runat="server"></asp:TextBox><span id="txtopwdTip"></span></li>
				  <li><span class="rowTitle">输入修改的密码：</span><asp:TextBox ID="txtnpwd" runat="server"></asp:TextBox><span id="txtnpwdTip"></span></li>
				  <li><span class="rowTitle">确认修改的密码：</span><asp:TextBox ID="txtcpwd" runat="server"></asp:TextBox><span id="txtcpwdTip"></span></li>
				 
				</ul>
				</fieldset>
				
			
				</TD>
		</TR>
		
		</TABLE>
	
	
	 </td>
  </tr>
		</TABLE>
	
	
	 </td>
  </tr>
  
  
  
  
  </table>

</div>
   
    </form>
</body>
</html>
