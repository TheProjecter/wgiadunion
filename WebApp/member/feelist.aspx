<%@ Page Language="C#" MasterPageFile="~/Templet/memberMaster.master" AutoEventWireup="true" CodeFile="feelist.aspx.cs" Inherits="member_feelist" Title="中商购物|网站联盟|用户中心" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Css/mem_modify.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<!--内容区样式开始-->
	<div class="conthead"><span>您现在的位置：首页&nbsp;>&nbsp;财务管理&nbsp;>&nbsp;佣金明细</span>联盟会员控制面板</div>
	<div class="ctbody_cnt" id="listdiv">
		<h3>佣金明细</h3>
		<div>
		
		    <div style="text-align:right; margin-top:20px;">
		        请选择要查询的日期：
		        <asp:DropDownList ID="ddlyear" runat="server"></asp:DropDownList>&nbsp;年
		        <asp:DropDownList ID="ddlmonth" runat="server"></asp:DropDownList>&nbsp;月
		    </div>
		             <table class="listtable" width="100%">
                    <tr>
                        <th>日期</th><th>明细</th><th>广告主</th><th>详细内容</th><th>产生</th><th>支付</th><th>余额</th>
                    </tr>
                    <tr>
                        <td align="middle">合计()</td><td></td><td></td><td></td><td>0.00</td><td>0.00</td><td>88.20</td>
                    </tr>
                </table>
		
		
			
        </div>
	</div>
	<!--内容区样式结束-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="jscode" Runat="Server">
</asp:Content>

