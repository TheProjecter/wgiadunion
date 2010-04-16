<%@ Page Language="C#" MasterPageFile="~/Templet/memberMaster.master" AutoEventWireup="true" CodeFile="sites.aspx.cs" Inherits="member_sites" Title="中商购物|网站联盟|用户中心" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<!--内容区样式开始-->
	<div class="conthead"><span>您现在的位置：首页&nbsp;>&nbsp;个人设置&nbsp;>&nbsp;网站信息</span>联盟会员控制面板</div>
	<div class="ctbody_cnt">
		<h3>网站信息</h3>
		<div>
		    <asp:GridView ID="gridList" runat="server" DataSourceID="odsData" AutoGenerateColumns="False" EmptyDataText="您尚未添加网站！" RowStyle-Width="100%">
                <Columns>
                    <asp:BoundField DataField="userid" HeaderText="userid" SortExpression="userid" />
                    <asp:BoundField DataField="siteid" HeaderText="siteid" SortExpression="siteid" />
                    <asp:BoundField DataField="sitename" HeaderText="sitename" SortExpression="sitename" />
                    <asp:BoundField DataField="url" HeaderText="url" SortExpression="url" />
                    <asp:BoundField DataField="siteremark" HeaderText="siteremark" SortExpression="siteremark" />
                    <asp:BoundField DataField="ipno" HeaderText="ipno" SortExpression="ipno" />
                    <asp:BoundField DataField="pvno" HeaderText="pvno" SortExpression="pvno" />
                    <asp:BoundField DataField="sitetype" HeaderText="sitetype" SortExpression="sitetype" />
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="odsData" runat="server" TypeName="wgiAdUnionSystem.BLL.wgi_usersite" SelectMethod="getListByUserId">
                <SelectParameters>
                    <asp:Parameter Name="userid" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
	</div>
	<!--内容区样式结束-->
</asp:Content>


<asp:Content ID="jscode1" ContentPlaceHolderID="jscode" runat="server">
</asp:Content>