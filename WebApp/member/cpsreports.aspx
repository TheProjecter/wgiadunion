<%@ Page Language="C#" MasterPageFile="~/Templet/memberMaster.master" AutoEventWireup="true" CodeFile="cpsreports.aspx.cs" Inherits="member_cpsreports" Title="中商购物|网站联盟|用户中心" %>

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
		<h3>CPS明细报表</h3>
		<div>
		<div id="opdiv">
            <uc1:report ID="report1" runat="server" />
            <asp:Button ID="btnsubmit" runat="server" Text="查询" OnClick="getStatics" CssClass="yelbtn" style="margin-left:250px; margin-top:10px;" />
            <p><span>显示内容：</span>
                <input type="checkbox" checked="checked" name="showitem"  id="cbx1" value="1" /><label for="cbx1">广告主</label>
                <input type="checkbox" checked="checked" name="showitem"  id="cbx2" value="2" /><label for="cbx2">订货编号</label>
                <input type="checkbox" checked="checked" name="showitem"  id="cbx3" value="3" /><label for="cbx3">时间</label>
                <input type="checkbox" checked="checked" name="showitem"  id="cbx4" value="4" /><label for="cbx4">商品编号</label>
                <input type="checkbox" checked="checked" name="showitem"  id="cbx5" value="5" /><label for="cbx5">分类</label>
                <input type="checkbox" checked="checked" name="showitem"  id="cbx6" value="6" /><label for="cbx6">个数</label>
                <input type="checkbox" checked="checked" name="showitem"  id="cbx7" value="7" /><label for="cbx7">单价</label>
                <input type="checkbox" checked="checked" name="showitem"  id="cbx8" value="8" /><label for="cbx8">销售额</label>
                <br /><span style="margin-right:54px;">&nbsp;</span>
                <input type="checkbox" checked="checked" name="showitem"  id="cbx9" value="9" /><label for="cbx9">佣金</label>
                <input type="checkbox" checked="checked" name="showitem"  id="cbx10" value="10" /><label for="cbx10">业绩状态</label>
                <input type="checkbox" checked="checked" name="showitem"  id="cbx11" value="11" /><label for="cbx11">取消理由</label>
                <input type="checkbox" name="showitem"  id="cbx12" value="12" class="nocheck" /><label for="cbx12">U_ID</label>
                <input type="checkbox" name="showitem"  id="cbx13" value="13" class="nocheck" /><label for="cbx13">广告主会员ID</label>
                <input type="checkbox" checked="checked" name="showitem"  id="cbx14" value="14" /><label for="cbx14">结算时间</label>
            </p>
        </div>
        <p>&nbsp;</p>
        <asp:DropDownList ID="ddlyejitype" runat="server"></asp:DropDownList>
        <div id="richdata">
        <table class="listtable" style="margin-left:0;">
            <tr><th class="col1">广告主</th><th class="col2">订货编号</th><th class="col3">时间</th><th class="col4">商品编号</th><th class="col5">分类</th><th class="col6">个数</th><th class="col7">单价</th><th class="col8">销售额</th><th class="col9">佣金</th><th class="col10">业绩状态</th><th class="col11">取消理由</th><th class="col12">U_ID</th><th class="col13">广告主ID</th><th class="col14">结算时间</th></tr>
            <tr><td class="col1"></td><td class="col2"></td><td class="col3"></td><td class="col4"></td><td class="col5"></td><td class="col6"></td><td class="col7"></td><td class="col8"></td><td class="col9"></td><td class="col10"></td><td class="col11"></td><td class="col12"></td><td class="col13"></td><td class="col14"></td></tr>
            <tr><td align="center" class="col1">合计()</td><td class="col2"></td><td class="col3"></td><td class="col4"></td><td class="col5"></td><td class="col6"></td><td class="col7"></td><td class="col8"></td><td class="col9"></td><td class="col10"></td><td class="col11"></td><td class="col12"></td><td class="col13"></td><td class="col14"></td></tr>
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

