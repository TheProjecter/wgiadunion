<%@ Page Language="C#" MasterPageFile="~/Templet/memberMaster.master" AutoEventWireup="true" CodeFile="notices.aspx.cs" Inherits="member_notices" Title="中商购物|网站联盟|用户中心" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Css/notice.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<!--内容区样式开始-->
	<div class="conthead"><span>您现在的位置：首页&nbsp;>&nbsp;信息中心&nbsp;>&nbsp;网站公告</span>联盟会员控制面板</div>
	<div class="ctbody_cnt">
		<h3>网站公告</h3>
		<div>
		    <ul id="noticelist">
		        <li><p><span class="shorttxt" style="padding-right:30px;">发布时间</span><input type="checkbox" style="visibility:hidden;" /><span>标题</span></p></li>
		        <asp:Repeater ID="rptpager" runat="server">
		        <ItemTemplate>
		        <li <%# base.getClassName(Eval("readed").ToString()) %>>
		                <p><span class="shorttxt"><%# Convert.ToDateTime(Eval("pubdate")).ToString("yyyy-MM-dd HH:mm:ss") %></span><input type="checkbox" class="checkthis" name="lists" value='<%#Eval("id") %>' /><span class="longtxt" uid="<%# base.userid %>"><%#Eval("title") %></span></p>
		                <div class="noticecont" status="0"><p><img src="/Images/loading.gif" alt="" style="margin-left:200px;" /></p></div>
		            </li>		        
		        </ItemTemplate>
		        </asp:Repeater>
		        <li style="padding-left:35px;">
		            <table class="optable"><tr>
		                <td><input type="button" id="checkall" class="yelbtn" value="全选" /></td>
		                <td><input type="button" id="revercheck" class="yelbtn" value="反选" /></td>
		                <td><input type="button" id="uncheckall" class="yelbtn" value="取消" /></td>
		                <td><div style="position:relative; padding:0;"><span id="btnop" class="yelbtn">操作<span class="downarr"></span></span>
		                    <div id="opration">
		                        <p><asp:LinkButton ID="lbtndel" runat="server" Text="删除" OnClick="delclick" OnClientClick="if(nocheck()){if(confirm('确认删除？')) return ture; else{$('#opration').hide(); return false;}}else return false;"></asp:LinkButton></p>
		                        <p><asp:LinkButton ID="lbtnread" runat="server" Text="标记为已读" OnClick="markread" OnClientClick="return nocheck();"></asp:LinkButton></p>
		                        <p><asp:LinkButton ID="lbtnunread" runat="server" Text="标记为未读" OnClick="markunread" OnClientClick="return nocheck();"></asp:LinkButton></p>
		                    </div></div>
		                </td>		            
		            </tr></table>
		        </li>
		    </ul>
		    <asp:Literal ID="lblpager" runat="server"></asp:Literal>
        </div>
	</div>
	<!--内容区样式结束-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="jscode" Runat="Server">

    <script src="../Js/jquery.easing.1.3.js" type="text/javascript"></script>
    <script src="/Js/notice.js" type="text/javascript"></script>
</asp:Content>

