<%@ Page Language="C#" MasterPageFile="~/Templet/memberMaster.master" AutoEventWireup="true" CodeFile="sites.aspx.cs" Inherits="member_sites" Title="中商购物|网站联盟|用户中心" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="/Css/mem_modify.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #opdiv ul{list-style:none;}
        #opdiv li{float:left; height:26px; line-height:26px; width:230px;}
        textarea{ position:absolute; overflow-y:hidden; top:3px; font-size:12px; line-height:16px;}
        textarea.txtarea01{width:132px; height:16px;}
        textarea.txtarea02{width:190px; height:80px;}
        ul li input{width:130px;}
        ul li span:first-child{ display:inline-block; width:80px; text-align:right;}
        li span.almsg{ color:Red; display:none;}
        th a{ color:#984F08; text-decoration:underline;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<!--内容区样式开始-->
	<div class="conthead"><span>您现在的位置：首页&nbsp;>&nbsp;个人设置&nbsp;>&nbsp;网站信息</span>联盟会员控制面板</div>
	<div class="ctbody_cnt" id="listdiv">
		<h3>网站信息</h3>
		<div>
		<p class="tabArea"><span>编辑网站</span></p>
		<div id="opdiv">
		    <ul>
		        <li><span>网站名称：</span><asp:TextBox ID="txtsitename" runat="server" CssClass="requiredfield"></asp:TextBox><span class="almsg">&nbsp;*</span></li>
		        <li><span>网站地址：</span><asp:TextBox ID="txturl" runat="server" CssClass="requiredfield"></asp:TextBox><span class="almsg">&nbsp;*</span></li>
		        <li><span>日独立IP：</span><asp:TextBox ID="txtipno" runat="server"></asp:TextBox></li>
		        <li><span>日均PV：</span><asp:TextBox ID="txtpvno" runat="server"></asp:TextBox></li>
		        <li><span>网站类型：</span><asp:DropDownList ID="ddlsitetype" runat="server"></asp:DropDownList></li>
		        <li style="position:relative;"><span>网站说明：</span><asp:TextBox ID="txtremark" runat="server" TextMode="MultiLine" class="txtarea01"></asp:TextBox></li>
		    </ul>
		    <br clear="all" />
		    <asp:Label runat="server" ID="lblmsg" Text="[提示：日独立IP和日均PV请填入有效数字，留空和非数字均会被置零，其余各项必填]" style="color:Gray; margin:10px 20px;"></asp:Label>
		    <p style="text-align:center; margin-top:10px;">
		        <asp:Button ID="btnnew" runat="server" Text="新增" CssClass="yelbtn" OnClick="btnnew_s" OnClientClick="return checkPageVali();" />
		        <asp:Button ID="btnedit" runat="server" Text="保存" CssClass="yelbtn" OnClick="btnsave" Enabled="false" OnClientClick="return checkPageVali();" />
		        <asp:Button ID="btnreset" runat="server" Text="取消" CssClass="yelbtn" OnClick="reset_click" Enabled="false" />
		        <asp:HiddenField ID="hidsiteid" runat="server" Value="" />
		    </p>
		</div>
		<p class="tabArea"><span>网站列表</span></p>
		    <asp:GridView ID="gridList" runat="server" DataSourceID="odsData" AutoGenerateColumns="False" EmptyDataText="您尚未添加网站！" RowStyle-Width="100%" DataKeyNames="siteid" CssClass="listtable" Width="100%" AllowPaging="true" PageSize="10" AllowSorting="true">		   
                <Columns>
                    <asp:BoundField DataField="sitename" HeaderText="网站名称" SortExpression="sitename" ItemStyle-Width="80px" />
                    <asp:BoundField DataField="url" HeaderText="网站地址" />
                    <asp:TemplateField HeaderText="网站说明">
                        <ItemStyle Width="120px" />
                        <ItemTemplate>
                            <%# Helper.HelperString.cutString(Eval("siteremark").ToString(),30) %>
                        </ItemTemplate>
                    </asp:TemplateField>
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
    var vali=true;
    $(function(){
        $("textarea").focus(function(){$(this).removeClass().addClass("txtarea02");}).blur(function(){$(this).removeClass().addClass("txtarea01");});
        $(".requiredfield").blur(function(){var obj=$(this); if(obj.val()==""){obj.next("span").show(); vali=false;}});
    });
    
    function checkPageVali(){vali=true; $(".requiredfield").blur(); return vali;}
</script>
</asp:Content>