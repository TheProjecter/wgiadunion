<%@ Page Language="C#" MasterPageFile="~/Templet/memberMaster.master" AutoEventWireup="true" CodeFile="account.aspx.cs" Inherits="member_account" Title="中商购物|网站联盟|用户中心" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="/Css/mem_modify.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<!--内容区样式开始-->
	<div class="conthead"><span>您现在的位置：首页&nbsp;>&nbsp;个人设置&nbsp;>&nbsp;账号信息</span>联盟会员控制面板</div>
	<div class="ctbody_cnt">
		<h3>账号信息</h3>
		<div>
<p class="tabArea"><span>状态信息</span></p>
<table border="0" cellpadding="0" cellspacing="0" align="center" class="prof_detail">

	<tr>
	    <td height="25" width="100px" align="right">账号状态：</td>
	    <td height="25" width="180px" align="left"><asp:Label Text="" id="txtstatus" runat="server"></asp:Label></td>
	    <td height="25" width="100px" align="right">&nbsp;</td>
	    <td height="25" width="120px" align="left">&nbsp;</td>
	</tr>
	
	<tr>
	    <td height="25" align="right">注册日期：</td>
	    <td height="25" align="left"><asp:Label id="txtregdate" name="Text1" runat="server" Text=""></asp:Label></td>
	    <td height="25" align="right">注册IP：</td>
	    <td height="25" align="left"><asp:Label Text="" id="txtregip" runat="server"></asp:Label></td>
	</tr>
	<tr>
	    <td height="25" align="right">上次登录日期：</td>
	    <td height="25" align="left"><asp:Label id="txtlastdate" type="text" size="10" name="Text1" runat="server" Text=""></asp:Label></td>
	    <td height="25" align="right">上次登录IP：</td>
	    <td height="25" align="left"><asp:Label id="txtlastip" runat="server" Text=""></asp:Label></td>
	</tr>
</table>
<br />
<p class="tabArea"><span>个人资料</span></p>
<table cellspacing="0" cellpadding="0" width="100%" border="0">
	
	<tr>
	<td height="25" width="30%" align="right">
		联系人
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtcontact" runat="server" Width="200px" MaxLength="30" CssClass="requireTxt"></asp:TextBox><span title="必填"></span>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		电子邮件
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtemail" runat="server" Width="200px" MaxLength="100"></asp:TextBox><span title="必填"></span>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		电话
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txttel" runat="server" Width="200px" MaxLength="30" CssClass="choosefill"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		手机
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtmobile" runat="server" Width="200px" MaxLength="50" CssClass="choosefill"></asp:TextBox><span title="电话、手机至少选填一项"></span>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		QQ
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtqq" runat="server" Width="200px" MaxLength="25"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		身份证号码
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtidcard" runat="server" Width="200px" MaxLength="50" CssClass="requireTxt"></asp:TextBox><span title="必填"></span>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		通讯地址
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtaddress" runat="server" Width="200px" MaxLength="150"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right" max="20">
		邮编
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtzipcode" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" colspan="2"><div align="center">
		<asp:Button ID="btnUpdate" runat="server" Text="提交" OnClick="btnUpdate_Click" OnClientClick="return checkvali();" CssClass="yelbtn" />
	</div></td></tr>
	
</table>
</div>
	</div>
	<!--内容区样式结束-->
</asp:Content>



<asp:Content ID="jscode1" ContentPlaceHolderID="jscode" runat="server">
<script type="text/javascript">
    var vali=true;
    var emailreg=/^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
        $(function(){
            $(":input").each(function(){var obj=$(this).next("span"); var txt=obj.attr("title"); obj.html(txt).addClass("onshow");});
            $(":input").focus(function(){var obj=$(this).next("span"); var oldtext=obj.attr("title"); obj.html(oldtext).removeClass().addClass("onfocus");});
            $("#ctl00_ContentPlaceHolder1_txtemail").blur(function(){var v=$(this).val();var obj=$(this).next("span");if(!regtest(emailreg,v)){obj.html("格式不正确！").removeClass().addClass("onerror");vali=false;}else{obj.removeClass().addClass("oncorrect");}});
            $(".requireTxt").blur(function(){var v=$(this).val();var obj=$(this).next("span");if(v==""){obj.removeClass().addClass("onerror");vali=false;}else{obj.removeClass().addClass("oncorrect");}});
            $("#ctl00_ContentPlaceHolder1_txtmobile").blur(function(){var obj=$(this).next("span");var ctr=0; $(".choosefill").each(function(){if($(this).val()!="") ctr++;});if(!ctr){obj.removeClass().addClass("onerror"); vali=false;}else{obj.removeClass().addClass("oncorrect");}});
        });
        
        function regtest(pattern,data){return pattern.test(data);}
		function checkvali(){vali=true;$(":input").blur(); return vali;}
</script>
</asp:Content>