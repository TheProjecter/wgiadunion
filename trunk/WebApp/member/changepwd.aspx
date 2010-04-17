<%@ Page Language="C#" MasterPageFile="~/Templet/memberMaster.master" AutoEventWireup="true" CodeFile="changepwd.aspx.cs" Inherits="member_changepwd" Title="中商购物|网站联盟|用户中心" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="/Css/mem_modify.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<!--内容区样式开始-->
	<div class="conthead"><span>您现在的位置：首页&nbsp;>&nbsp;个人设置&nbsp;>&nbsp;更改密码</span>联盟会员控制面板</div>
	<div class="ctbody_cnt">
		<h3>更改密码</h3>
		<div class="pwddiv">
            <table>
                <tr><td>原密码：</td><td width="290"><asp:TextBox ID="txtold" runat="server" MaxLength="20" TextMode="Password"></asp:TextBox><span class="onshow">请输入原始密码</span></td></tr>
                <tr><td>新密码：</td><td><asp:TextBox ID="txtnew" runat="server" MaxLength="20" TextMode="Password"></asp:TextBox><span class="onshow">6-20位字母/数字</span></td></tr>
                <tr><td>新密码：</td><td><asp:TextBox ID="txtnew2" runat="server" MaxLength="20" TextMode="Password"></asp:TextBox><span class="onshow">请重输上面的密码</span></td></tr>
                <tr><td>&nbsp;</td><td><asp:Button ID="btnsubmit" runat="server" Text="确定" OnClick="submit_click" CssClass="yelbtn" OnClientClick="return checkvali();" />&nbsp;&nbsp;
                    <input type="reset" value="重置" class="yelbtn" />
                </td></tr>
            </table>
        </div>
	</div>
	<!--内容区样式结束-->
</asp:Content>

<asp:Content ID="jscode1" ContentPlaceHolderID="jscode" runat="server">
    <script type="text/javascript">
    var vali=true;
        $(function(){
            $(":password").focus(function(){$(this).next("span").removeClass().addClass("onfocus");});
            $("#ctl00_ContentPlaceHolder1_txtold").blur(function(){var v=$(this).val();var obj=$(this).next("span");
				url=encodeURI("/ajaxHandler.aspx?act=checkpwd&userid=1&pwd="+v+"&t="+new Date().getMilliseconds());
				$.get(url,function(data){
					if(data==0){obj.removeClass().addClass("onerror");vali=false;}else{obj.removeClass().addClass("oncorrect");}
				}
			);});
            $("#ctl00_ContentPlaceHolder1_txtnew").blur(function(){var v=$(this).val();var obj=$(this).next("span");if(!regtest(/^[0-9a-zA-Z]{6,20}$/,v)){obj.removeClass().addClass("onerror");vali=false;}else{obj.removeClass().addClass("oncorrect");}});
            $("#ctl00_ContentPlaceHolder1_txtnew2").blur(function(){var v=$(this).val();var obj=$(this).next("span");if($("#ctl00_ContentPlaceHolder1_txtnew").val()!=v){obj.removeClass().addClass("onerror");obj.html("两次密码输入不一致");vali=false;}else{obj.removeClass().addClass("oncorrect");obj.html("请重输上面的密码");}});
        });
        function regtest(pattern,data){return pattern.test(data);}
		function checkvali(){vali=true;$(":input").blur(); return vali;}
    </script>
</asp:Content>