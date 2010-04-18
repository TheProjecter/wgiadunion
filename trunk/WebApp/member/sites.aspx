<%@ Page Language="C#" MasterPageFile="~/Templet/memberMaster.master" AutoEventWireup="true" CodeFile="sites.aspx.cs" Inherits="member_sites" Title="中商购物|网站联盟|用户中心" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="/Css/mem_modify.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #opdiv ul{list-style:none;}
        #opdiv li{float:left; height:26px; line-height:26px; width:220px;}
        textarea{ position:absolute; overflow-y:hidden; top:3px;}
        textarea.txtarea01{width:132px; height:16px;}
        textarea.txtarea02{width:190px; height:80px;}
        ul li input{width:130px;}
        ul li span{ display:inline-block; width:80px; text-align:right;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<!--内容区样式开始-->
	<div class="conthead"><span>您现在的位置：首页&nbsp;>&nbsp;个人设置&nbsp;>&nbsp;网站信息</span>联盟会员控制面板</div>
	<div class="ctbody_cnt" id="listdiv">
		<h3>网站信息</h3>
		<div>
		<p class="tabArea"><b>编辑网站</b></p>
		<div id="opdiv">
		    <ul>
		        <li><span>网站名称：</span><asp:TextBox ID="txtsitename" runat="server"></asp:TextBox></li>
		        <li><span>网站地址：</span><asp:TextBox ID="txturl" runat="server"></asp:TextBox></li>
		        <li><span>日独立IP：</span><asp:TextBox ID="txtipno" runat="server"></asp:TextBox></li>
		        <li><span>日均PV：</span><asp:TextBox ID="txtpvno" runat="server"></asp:TextBox></li>
		        <li><span>网站类型：</span><asp:DropDownList ID="ddlsitetype" runat="server"></asp:DropDownList></li>
		        <li style="position:relative;"><span>网站说明：</span><asp:TextBox ID="txtremark" runat="server" TextMode="MultiLine" class="txtarea01"></asp:TextBox></li>
		    </ul>
		    <br clear="all" />
		    <p style="text-align:center;">
		        <asp:Button ID="btnnew" runat="server" Text="新增" CssClass="yelbtn" OnClick="btnnew_s" />
		        <asp:Button ID="btnedit" runat="server" Text="保存" CssClass="yelbtn" OnClick="btnsave" Enabled="false" />
		        <asp:HiddenField ID="hidsiteid" runat="server" Value="" />
		    </p>
		</div>
		<p class="tabArea"><b>网站列表</b></p>
		    <asp:GridView ID="gridList" runat="server" DataSourceID="odsData" AutoGenerateColumns="False" EmptyDataText="您尚未添加网站！" RowStyle-Width="100%" DataKeyNames="siteid" CssClass="listtable" Width="100%" AllowPaging="true" PageSize="10">		   
                <Columns>
                    <asp:BoundField DataField="sitename" HeaderText="网站名称" SortExpression="sitename" ItemStyle-Width="80px" />
                    <asp:BoundField DataField="url" HeaderText="网站地址" SortExpression="url" />
                    <asp:BoundField DataField="siteremark" HeaderText="网站说明" SortExpression="siteremark" />
                    <asp:BoundField DataField="ipno" HeaderText="日独立IP" SortExpression="ipno" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px" />
                    <asp:BoundField DataField="pvno" HeaderText="日均PV" SortExpression="pvno" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px" />
                    <asp:TemplateField HeaderText="网站类型">
                        <ItemTemplate><%# CommonData.getSiteTypeByValue(Eval("sitetype").ToString()) %></ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtnedit" runat="server" Text="编辑" OnCommand="editsite" CommandArgument='<%# Eval("siteid") %>'></asp:LinkButton>&nbsp;
                            <asp:LinkButton ID="lbtndel" runat="server" Text="删除" CommandName="Delete"></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="66px" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="odsData" runat="server" TypeName="wgiAdUnionSystem.BLL.wgi_usersite" SelectMethod="getListByUserId" DeleteMethod="Delete">
                <SelectParameters>
                    <asp:Parameter Name="userid" Type="Int32" />
                </SelectParameters>
                <DeleteParameters>
                    <asp:Parameter Name="siteid" Type="Int32" />
                </DeleteParameters>
            </asp:ObjectDataSource>
        </div>
	</div>
	<!--内容区样式结束-->
</asp:Content>


<asp:Content ID="jscode1" ContentPlaceHolderID="jscode" runat="server">
<script type="text/javascript">
    $(function(){
        $("textarea").focus(function(){$(this).removeClass().addClass("txtarea02");}).blur(function(){$(this).removeClass().addClass("txtarea01");});
    });
</script>
</asp:Content>