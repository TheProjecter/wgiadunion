<%@ Page Language="C#" MasterPageFile="~/Templet/memberMaster.master" AutoEventWireup="true" CodeFile="cpcreports.aspx.cs" Inherits="member_cpcreports" Title="中商购物|网站联盟|用户中心" %>

<%@ Register src="../Controls/report.ascx" tagname="report" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script src="/Js/report.js" type="text/javascript"></script>
    <script src="/Js/ca/WdatePicker.js" type="text/javascript"></script>    

    <link href="/Css/report.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    

	<!--内容区样式开始-->
	<div class="conthead"><span>您现在的位置：首页&nbsp;>&nbsp;查看报表&nbsp;>&nbsp;报表明细</span>联盟会员控制面板</div>
	<div class="ctbody_cnt" id="listdiv">
		<h3>CPC明细报表</h3>
		<div>
		<div id="opdiv">
            <uc1:report ID="report1" runat="server" />
            <asp:Button ID="btnsubmit" runat="server" Text="查询" OnClick="getStatics" CssClass="yelbtn" style="margin-left:250px; margin-top:10px;" />
            <p><span>显示内容：</span>
                <input type="checkbox" checked="checked" name="showitem"  id="cbx1" value="1" /><label for="cbx1">广告主</label>
                <input type="checkbox" checked="checked" name="showitem"  id="cbx2" value="2" /><label for="cbx2">时间</label>
                <input type="checkbox" checked="checked" name="showitem"  id="cbx3" value="3" /><label for="cbx3">点击数</label>
                <input type="checkbox" checked="checked" name="showitem"  id="cbx4" value="4" /><label for="cbx4">单次点击价格</label>
                <input type="checkbox" checked="checked" name="showitem"  id="cbx5" value="5" /><label for="cbx5">佣金</label>
                <input type="checkbox" checked="checked" name="showitem"  id="cbx6" value="6" /><label for="cbx6">业绩状态</label>
                <input type="checkbox" checked="checked" name="showitem"  id="cbx7" value="7" /><label for="cbx7">结算时间</label>
            </p>
        </div>
        <p>&nbsp;</p>
        <asp:DropDownList ID="ddlstatustype" runat="server"><asp:ListItem Value="0" Text="选择状态"></asp:ListItem><asp:ListItem Value="1" Text="正常"></asp:ListItem><asp:ListItem Value="2" Text="不正常"></asp:ListItem></asp:DropDownList>
        <div id="richdata">
        <table class="listtable" style="margin-left:0;">
            <tr><th class="col1">广告主</th><th class="col2">时间</th><th class="col3">点击数</th><th class="col4">单次点击价格</th><th class="col5">佣金</th><th class="col6">U_ID</th><th class="col7">结算时间</th></tr>
            <tr><td class="col1"></td><td class="col2"></td><td class="col3"></td><td class="col4"></td><td class="col5"></td><td class="col6"></td><td class="col7"></td></tr>
            <tr><td align="center" class="col1">合计()</td><td class="col2"></td><td class="col3"></td><td class="col4"></td><td class="col5"></td><td class="col6"></td><td class="col7"></tr>
        </table>
        <!--[if IE 7]>
         <p>&nbsp;</p><p>&nbsp;</p>
        <![endif]-->
        
        </div>

		</div>
	</div>
	<!--内容区样式结束-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="jscode" Runat="Server">

</asp:Content>

