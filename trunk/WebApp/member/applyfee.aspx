<%@ Page Language="C#" MasterPageFile="~/Templet/memberMaster.master" AutoEventWireup="true" CodeFile="applyfee.aspx.cs" Inherits="member_applyfee" Title="中商购物|网站联盟|用户中心" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="/Css/mem_modify.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #opdiv .oplist{ margin:15px 20px;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<!--内容区样式开始-->
	<div class="conthead"><span>您现在的位置：首页&nbsp;>&nbsp;财务管理&nbsp;>&nbsp;申请佣金</span>联盟会员控制面板</div>
	<div class="ctbody_cnt" id="listdiv">
		<h3>申请佣金</h3>
		<div>
		<p class="tabArea"><span>佣金信息</span></p>
		<div id="opdiv">
		   <p class="oplist">您可申请支付的佣金是：&nbsp;<asp:Label ID="lblmoney" runat="server" style="color:Red; font-weight:600"></asp:Label>&nbsp;元</p>
		   <p class="oplist"><asp:Label ID="lblapply" runat="server" Visible="false">您的佣金不到100元不可以申请</asp:Label><asp:Button ID="btnapply" runat="server" CssClass="yelbtn" Text="申请" Visible="false" OnClick="applyclick" /></p>
		   
		</div>
		<p class="tabArea"><span>佣金概览</span></p>
		<center><span>请选择查询的年份：</span><asp:DropDownList ID="ddlyear" runat="server"></asp:DropDownList>&nbsp;&nbsp;<a href="feelist.aspx">查看详细</a></center><p>&nbsp;</p>
		    <table class="listtable">
		        <tr><th>日期</th><th>产生</th><th>支付</th><th>余额</th></tr>
		        <tr><td>2010年1月</td><td>50.00</td><td>0.00</td><td>50.00</td></tr>
		        <tr><td>2010年4月</td><td>2.50</td><td>0.00</td><td>2.50</td></tr>
		        <tr><td>2010年5月</td><td>10.00</td><td>0.00</td><td>10.00</td></tr>
		        <tr><td>合计</td><td>62.50元</td><td>0元</td><td>62.50元</td></tr>
		    </table>
		    
		<p class="tabArea"><span>申领详情</span></p>
		    <table class="listtable">
		        <tr><th>申请日期</th><th>支付日期</th><th>开户名</th><th>银行名称</th><th>银行账号</th><th>申请金额</th></tr>
		        <tr><td>2010/3/5</td><td>2010/4/22</td><td>张三</td><td>中国工商银行</td><td>3429857432853021</td><td>120.00元</td></tr>
		    </table>
		
        </div>
	</div>
	<!--内容区样式结束-->

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="jscode" Runat="Server">
</asp:Content>

