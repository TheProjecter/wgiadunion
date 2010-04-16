<%@ Page Language="C#" MasterPageFile="~/Templet/memberMaster.master" AutoEventWireup="true" CodeFile="gencode.aspx.cs" Inherits="member_gencode" Title="中商购物|网站联盟|用户中心" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

	<!--内容区样式开始-->
	<div class="conthead"><span>您现在的位置：首页&nbsp;>&nbsp;广告列表&nbsp;>&nbsp;选择广告</span>联盟会员控制面板</div>
	<div class="ctbody_cnt">
		<h3>生成广告代码</h3>
		<div>
            <div>
                <p>选择网站：<asp:DropDownList ID="ddlsite" runat="server" AutoPostBack="true" OnSelectedIndexChanged="genCode"></asp:DropDownList></p>
                <p>复制下面的代码到网站：</p>
                <asp:TextBox runat="server" ID="txtgcode" TextMode="MultiLine" Columns="70" Rows="6" onclick="this.select();"></asp:TextBox>
                <asp:HiddenField ID="hidadid" runat="server" Value="" />
                <asp:HiddenField ID="hidadhost" runat="server" Value="" />
                <asp:HiddenField ID="hidadtype" runat="server" Value="" />
                <asp:HiddenField ID="hidpaytype" runat="server" Value="" />
                <p>预览:<asp:Label ID="lbltest" runat="server" Text=""></asp:Label></p>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="jscode" Runat="Server">
</asp:Content>

