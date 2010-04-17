<%@ Page Language="C#" MasterPageFile="~/Templet/memberMaster.master" AutoEventWireup="true" CodeFile="sites.aspx.cs" Inherits="member_sites" Title="中商购物|网站联盟|用户中心" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="/Css/mem_modify.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<!--内容区样式开始-->
	<div class="conthead"><span>您现在的位置：首页&nbsp;>&nbsp;个人设置&nbsp;>&nbsp;网站信息</span>联盟会员控制面板</div>
	<div class="ctbody_cnt">
		<h3>网站信息</h3>
		<div>
		    <asp:GridView ID="gridList" runat="server" DataSourceID="odsData" AutoGenerateColumns="False" EmptyDataText="您尚未添加网站！" RowStyle-Width="100%" DataKeyNames="siteid" CssClass="listtable">
                <Columns>
                    <asp:BoundField DataField="sitename" HeaderText="网站名称" SortExpression="sitename" />
                    <asp:BoundField DataField="url" HeaderText="网站地址" SortExpression="url" />
                    <asp:BoundField DataField="siteremark" HeaderText="网站说明" SortExpression="siteremark" />
                    <asp:BoundField DataField="ipno" HeaderText="日独立IP" SortExpression="ipno" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="pvno" HeaderText="日均PV" SortExpression="pvno" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="网站类型">
                        <ItemTemplate><%# CommonData.getSiteTypeByValue(Eval("sitetype").ToString()) %></ItemTemplate>
                    </asp:TemplateField>
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