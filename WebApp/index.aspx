<%@ Page Language="C#" MasterPageFile="~/Templet/indexMaster.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" Title="中商购物|网站联盟|首页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        $(function(){$("#navi li").eq(5).addClass("curtab");});
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<!--内容区圆角样式-->
	<div id="rca_body">
		<div class="btop">&nbsp;</div>
		<div class="bmid">content</div>
		<div class="bbot">&nbsp;</div>
	</div>
	<!--内容区圆角样式结束-->
	<div id="rca_body">
		<div class="btop">&nbsp;</div>
		<div class="bmid">content</div>
		<div class="bbot">&nbsp;</div>
	</div>
	<div id="rca_body">
		<div class="btop">&nbsp;</div>
		<div class="bmid">content</div>
		<div class="bbot">&nbsp;</div>
	</div>
</asp:Content>

