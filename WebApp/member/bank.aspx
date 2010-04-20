<%@ Page Language="C#" MasterPageFile="~/Templet/memberMaster.master" AutoEventWireup="true" CodeFile="bank.aspx.cs" Inherits="member_bank" Title="中商购物|网站联盟|用户中心" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="/Css/mem_modify.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<!--内容区样式开始-->
	<div class="conthead"><span>您现在的位置：首页&nbsp;>&nbsp;个人设置&nbsp;>&nbsp;银行信息</span>联盟会员控制面板</div>
	<div class="ctbody_cnt">
		<h3>银行信息</h3>
		<div class="pwddiv">
	<!--内容区样式结束-->
<table cellspacing="0" cellpadding="0" width="100%" border="0" style="margin-top:15px;">
	<tr>
	    <td height="25" width="30%" align="right">银行账户名：</td>
	    <td height="25" width="*" align="left"><asp:TextBox id="txtaccountname" runat="server" Width="200px" MaxLength="50" CssClass="requireTxt"></asp:TextBox><span title="必填"></span></td>
	</tr>
	<tr>
	    <td height="25" width="30%" align="right">账号：</td>
	    <td height="25" width="*" align="left"><asp:TextBox id="txtaccountno" runat="server" Width="200px" MaxLength="50" CssClass="requireTxt"></asp:TextBox><span title="必填"></span></td>
	</tr>
	<tr>
	    <td height="25" width="30%" align="right">开户行：</td>
	    <td height="25" width="*" align="left"><asp:TextBox id="txtbank" runat="server" Width="200px" MaxLength="50" CssClass="requireTxt"></asp:TextBox><span title="必填"></span></td>
	</tr>
	<tr>
	    <td height="25" width="30%" align="right">开户支行/分行：</td>
	    <td height="25" width="*" align="left"><asp:TextBox id="txtbranch" runat="server" Width="200px" MaxLength="50" CssClass="requireTxt"></asp:TextBox><span title="必填"></span></td>
	</tr>
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
        $(function(){
            $(":input").each(function(){var obj=$(this).next("span"); var txt=obj.attr("title"); obj.html(txt).addClass("onshow");});
            $(":input").focus(function(){var obj=$(this).next("span"); var oldtext=obj.attr("title"); obj.html(oldtext).removeClass().addClass("onfocus");});
            $(".requireTxt").blur(function(){var v=$(this).val();var obj=$(this).next("span");if(v==""){obj.removeClass().addClass("onerror");vali=false;}else{obj.removeClass().addClass("oncorrect");}});
            
        });
        
        
		function checkvali(){vali=true;$(":input").blur(); return vali;}
        
</script>
</asp:Content>