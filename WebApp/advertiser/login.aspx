<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="syslogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>维格英广告联盟平台V1.0</title>
   <style type="text/css">
<!--
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
}
-->
</style>
<link href="css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        if (top.location != location) {
            top.location.href = "syslogin.aspx";
        }
    </script>
</head>
<body>
 <form id="form1" runat="server">
 <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td height="147" background="images/top02.gif"><img src="images/top03.gif" width="776" height="147" /></td>
  </tr>
</table>
<table width="562" border="0" align="center" cellpadding="0" cellspacing="0" class="right-table03">
  <tr>
    <td width="221"><table width="95%" border="0" cellpadding="0" cellspacing="0" class="login-text01">
      
      <tr>
        <td><table width="100%" border="0" cellpadding="0" cellspacing="0" class="login-text01">
          <tr>
            <td align="center"><img src="images/ico13.gif" width="107" height="97" /></td>
          </tr>
          <tr>
            <td height="40" align="center">&nbsp;</td>
          </tr>
          
        </table></td>
        <td><img src="images/line01.gif" width="5" height="292" /></td>
      </tr>
    </table></td>
    <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="31%" height="35" class="login-text02">用户名称：<br /></td>
        <td width="69%"><input name="textfield" type="text" size="30" runat="server" id="txtUserName"/></td>
      </tr>
      <tr>
        <td height="35" class="login-text02">密　码：<br /></td>
        <td><input name="textfield2" type="password" size="33" runat="server" id="txtPass"/></td>
      </tr>
      <tr>
        <td height="35" class="login-text02">验证图片：<br /></td>
        <td><img src="../checkcode.aspx" id="imgcode" width="109" height="40" /> <a href="javascript:;" onclick="document.getElementById('imgcode').src+='?';" class="login-text03">看不清楚，换张图片</a></td>
      </tr>
      <tr>
        <td height="35" class="login-text02">请输入验证码：</td>
        <td><input name="textfield3" type="text" size="30" id="txtCode" runat="server"/></td>
      </tr>
      <tr>
        <td height="35">&nbsp;</td>
        <td>

            <asp:Button ID="Button1" runat="server" Text="管理登陆" onclick="imgBtn_Click" class="right-button01"/>
          &nbsp;&nbsp; <input name="Submit232" type="reset" class="right-button02" value="重 置" />
        <p> <asp:Label ID="lblmsg" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label></p>
          </td>
      </tr>
    </table></td>
  </tr>
</table>
<table width="100%" align="center" border="0" cellpadding="0" cellspacing="0">
 <tr><td align="center" style="font-size:12px">
   CopyRight &copy 2010 &nbsp; &nbsp;  武汉维格英科技有限公司 &nbsp; &nbsp;  www.wingoi.com &nbsp; &nbsp;  版权所有
 </td></tr>
</table>
    </form>
</body>
</html>
