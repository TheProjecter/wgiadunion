<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addSiteUser.aspx.cs" Inherits="admin_addSiteUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <asp:PlaceHolder id="holderheader" runat="server"></asp:PlaceHolder>
    <style type="text/css">
        body{background:none;}
        #box{padding:10px;}
        #box table td{border:none;}
        #box table{border:none!important;}
        #box fieldset table td input{ *width:170px!important;}
    </style>
</head>
<body>
<form id="form" runat="server">
    <div id="box">
        <h3>用户信息</h3>
        <fieldset>
            <legend>个人资料</legend>
    <table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="20%" align="right">
		用户名
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtusername" runat="server" Width="180px" title="6-30位字母/数字/下划线组合"></asp:TextBox><span></span>
	</td></tr>
	<tr>
	<td height="25" width="20%" align="right">
		密码
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtpassword" runat="server" Width="180px" TextMode="Password" title="6-20位字母和数字组合"></asp:TextBox><span></span>
	</td></tr>
	<tr>
	<td height="25" width="20%" align="right">
		重输密码
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtpwd2" runat="server" Width="180px" TextMode="Password" title="请再输一次"></asp:TextBox><span></span>
	</td></tr>
	<tr>
	<td height="25" width="20%" align="right">
		电子邮件
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtemail" runat="server" Width="180px" title="必填"></asp:TextBox><span></span>
	</td></tr>
	<tr>
	<td height="25" width="20%" align="right">
		联系人
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtcontact" runat="server" Width="180px" CssClass="requireTxt" title="必填"></asp:TextBox><span></span>
	</td></tr>
	<tr>
	<td height="25" width="20%" align="right">
		电话
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txttel" runat="server" Width="180px" CssClass="choosefill"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="20%" align="right">
		手机
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtmobile" runat="server" Width="180px" CssClass="choosefill" title="电话、手机至少选填一项"></asp:TextBox><span></span>
	</td></tr>

	<tr>
	<td height="25" width="20%" align="right">
		QQ
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtqq" runat="server" Width="180px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="20%" align="right">
		身份证号码
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtidcard" runat="server" Width="180px" CssClass="requireTxt" title="必填"></asp:TextBox><span></span>
	</td></tr>
	<tr>
	<td height="25" width="20%" align="right">
		通讯地址
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtaddress" runat="server" Width="180px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="20%" align="right">
		邮编
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtzipcode" runat="server" Width="180px"></asp:TextBox>
	</td></tr>
</table>
        </fieldset>
        
        <fieldset>
            <legend>结款账户信息</legend>
            <table cellSpacing="0" cellPadding="0" width="100%" border="0">
	        <tr>
	        <td height="25" width="20%" align="right">
		        开户行
	        ：</td>
	        <td height="25" width="*" align="left">
		        <asp:TextBox id="txtbank" runat="server" Width="180px" CssClass="requireTxt" title="必填"></asp:TextBox><span></span>
	        </td></tr>
	        <tr>
	        <td height="25" width="20%" align="right">
		        支行名
	        ：</td>
	        <td height="25" width="*" align="left">
		        <asp:TextBox id="txtbranch" runat="server" Width="180px" CssClass="requireTxt" title="必填"></asp:TextBox><span></span>
	        </td></tr>
                <tr>
	        <td height="25" width="20%" align="right">
		        账户名
	        ：</td>
	        <td height="25" width="*" align="left">
		        <asp:TextBox id="txtaccountname" runat="server" Width="180px" CssClass="requireTxt" title="必填"></asp:TextBox><span></span>
	        </td></tr>
	        <tr>
	        <td height="25" width="20%" align="right">
		        账号
	        ：</td>
	        <td height="25" width="*" align="left">
		        <asp:TextBox id="txtaccountno" runat="server" Width="180px" CssClass="requireTxt" title="必填"></asp:TextBox><span></span>
	        </td></tr>
        </table>
        </fieldset>
        
        <fieldset>
            <legend>网站信息</legend>
            sites list
        </fieldset>
        <center>
            <asp:Button ID="btnsubmit" runat="server" Text="提交" CommandArgument="add" OnCommand="dosubmit" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btncancel" runat="server" Text="重设" />
        </center>
    </div>
</form>
</body>
<script src="Js/jquery-1.4.min.js" type="text/javascript"></script>
<script type="text/javascript">
    var vali=true;
    var emailreg=/^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
        $(function(){
            $(":input").each(function(){var obj=$(this).next("span"); var txt=$(this).attr("title"); obj.html(txt).addClass("onshow");});
            $(":input").focus(function(){var obj=$(this).next("span"); var txt=$(this).attr("title"); obj.html(txt).removeClass().addClass("onfocus");});
            $("#txtusername").blur(function(){
                var v=$(this).val();
                var obj=$(this).next("span");
                if(regtest(/^[0-9a-zA-Z]+[0-9a-zA-Z_]{5,29}$/,v)){
				    url=encodeURI("/ajaxHandler.aspx?act=checkSitehostUsername&username="+v+"&t="+new Date().getMilliseconds());
				    $.get(url,function(data){
					    if(data==0){obj.html("该用户名已被使用！").removeClass().addClass("onerror");vali=false;}else{obj.removeClass().addClass("oncorrect");}
				    }
			);}
				else{obj.removeClass().html("格式不正确！").addClass("onerror");vali=false;}});
            $("txtpassword").blur(function(){var v=$(this).val();var obj=$(this).next("span");if(!regtest(/^[0-9a-zA-Z]{6,20}$/,v)){obj.html("格式不正确！").removeClass().addClass("onerror");vali=false;}else{obj.removeClass().addClass("oncorrect");}});
            $("txtpwd2").blur(function(){var v=$(this).val();var obj=$(this).next("span");if($("#txtpassword").val()!=v){obj.removeClass().addClass("onerror");obj.html("两次密码输入不一致");vali=false;}else{obj.removeClass().addClass("oncorrect");}});
            $("#txtemail").blur(function(){var v=$(this).val();var obj=$(this).next("span");if(!regtest(emailreg,v)){obj.html("格式不正确！").removeClass().addClass("onerror");vali=false;}else{obj.removeClass().addClass("oncorrect");}});
            $(".requireTxt").blur(function(){var v=$(this).val();var obj=$(this).next("span");if(v==""){obj.removeClass().addClass("onerror");vali=false;}else{obj.removeClass().addClass("oncorrect");}});
            $("#txtmobile").blur(function(){var obj=$(this).next("span");var ctr=0; $(".choosefill").each(function(){if($(this).val()!="") ctr++;});if(!ctr){obj.removeClass().addClass("onerror"); vali=false;}else{obj.removeClass().addClass("oncorrect");}});
        });
        
        function regtest(pattern,data){return pattern.test(data);}
		function checkvali(){vali=true;$(":input").blur(); if(!vali) $(document).scrollTop(100); else if(!$("#cbx_hasread").attr("checked")) alert("请接受合作协议！"); return vali;}
		function showterms(){$(".divterms").slideToggle();};
</script>
</html>
