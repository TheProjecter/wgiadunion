<%@ Page Language="C#" MasterPageFile="~/Templet/memberMaster.master" AutoEventWireup="true" CodeFile="reports.aspx.cs" Inherits="member_reports" Title="中商购物|网站联盟|用户中心" %>

<%@ Register src="../Controls/report.ascx" tagname="report" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script src="/Js/report.js" type="text/javascript"></script>
    <script src="/Js/ca/WdatePicker.js" type="text/javascript"></script>    

    <link href="/Css/report.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    

	<!--内容区样式开始-->
	<div class="conthead"><span>您现在的位置：首页&nbsp;>&nbsp;查看报表&nbsp;>&nbsp;报表概览</span>联盟会员控制面板</div>
	<div class="ctbody_cnt" id="listdiv">
		<h3>报表概览</h3>
		<div>
		<div id="opdiv">
            <uc1:report ID="report1" runat="server" />
            <asp:Button ID="btnsubmit" runat="server" Text="查询" OnClick="getStatics" CssClass="yelbtn" style="margin-left:250px; margin-top:10px;" />
            <p><span>显示内容：</span>
                <input type="checkbox" checked="checked" name="showitem"  id="cbxshow" value="1" /><label for="cbxshow">露出数</label>
                <input type="checkbox" checked="checked" name="showitem"  id="cbxclick" value="2" /><label for="cbxclick">点击数</label>
                <input type="checkbox" checked="checked" name="showitem"  id="cbxcpsno" value="3" /><label for="cbxcpsno">CPS销售数</label>
                <input type="checkbox" checked="checked" name="showitem"  id="cbxcpsmoney" value="4" /><label for="cbxcpsmoney">CPS销售额</label>
                <input type="checkbox" checked="checked" name="showitem"  id="cbxcps" value="5" /><label for="cbxcps">CPS佣金</label>
                <input type="checkbox" checked="checked" name="showitem"  id="cbxcpano" value="6" /><label for="cbxcpano">CPA引导数</label>
                <input type="checkbox" checked="checked" name="showitem"  id="cbxcpa" value="7" /><label for="cbxcpa">CPA佣金</label>
                <br /><span style="margin-right:54px;">&nbsp;</span>
                <input type="checkbox" checked="checked" name="showitem"  id="cbxcpcno" value="8" /><label for="cbxcpcno">CPC点击数</label>
                <input type="checkbox" checked="checked" name="showitem"  id="cbxcpc" value="9" /><label for="cbxcpc">CPC佣金</label>
                <input type="checkbox" checked="checked" name="showitem"  id="cbxcpnno" value="10" /><label for="cbxcpnno">CPN有效数</label>
                <input type="checkbox" checked="checked" name="showitem"  id="cbxcpn" value="11" /><label for="cbxcpn">CPN佣金</label>
                <input type="checkbox" checked="checked" name="showitem"  id="cbxall" value="12" /><label for="cbxall">全部佣金</label>
                <input type="hidden" value="1" id="fixreport" />
            </p>
        </div>
        <p>&nbsp;</p>
        <asp:DropDownList ID="ddlgroupby" runat="server"><asp:ListItem Value="1" Text="按天统计"></asp:ListItem><asp:ListItem Value="2" Text="按网站统计"></asp:ListItem><asp:ListItem Value="3" Text="按广告主统计"></asp:ListItem></asp:DropDownList>
        <asp:DropDownList ID="ddlyejitype" runat="server"></asp:DropDownList>
        <div id="richdata">
        <table class="listtable" style="margin-left:0;">
            <tr><th>条件</th><th class="col1">露出数</th><th class="col2">点击数</th><th class="col3">CPS销售数</th><th class="col4">CPS销售额</th><th class="col5">CPS佣金</th><th class="col6">CPA引导数</th><th class="col7">CPA佣金</th><th class="col8">CPC点击数</th><th class="col9">CPC佣金</th><th class="col10">CPN有效数</th><th class="col11">CPN佣金</th><th class="col12">全部佣金</th></tr>
            <tr><td></td><td class="col1"></td><td class="col2"></td><td class="col3"></td><td class="col4"></td><td class="col5"></td><td class="col6"></td><td class="col7"></td><td class="col8"></td><td class="col9"></td><td class="col10"></td><td class="col11"></td><td class="col12"></td></tr>
            <tr><td align="center">合计()</td><td class="col1"></td><td class="col2"></td><td class="col3"></td><td class="col4"></td><td class="col5"></td><td class="col6"></td><td class="col7"></td><td class="col8"></td><td class="col9"></td><td class="col10"></td><td class="col11"></td><td class="col12"></td></tr>
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

