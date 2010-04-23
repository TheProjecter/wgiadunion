<%@ Page Language="C#" MasterPageFile="~/Templet/memberMaster.master" AutoEventWireup="true" CodeFile="notices.aspx.cs" Inherits="member_notices" Title="中商购物|网站联盟|用户中心" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        #noticelist{margin:20px auto 10px 10px; list-style:none;}
        #noticelist li:first-child span{font-weight:800; color:#984f08;}
        #noticelist li{border-bottom:dashed 1px #ca3; padding:4px 0; margin-top:5px;}
        #noticelist li p input{ margin-right:20px;}
        #noticelist li span{color:#333; display:inline-block;}
        #noticelist span.longtxt{width:500px; overflow:hidden; text-overflow:ellipsis; padding-right:5px; cursor:pointer;}
        #noticelist span.longtxt:hover{text-decoration:underline;}
        #noticelist span.shorttxt{width:120px; text-align:right; float:right; margin-top:3px; *margin-top:7px;}
        li div.noticecont{display:none; padding:5px 10px 5px 40px;}
        li div.noticecont p{ padding:5px; background:#fff6f5;}
        li.unread .longtxt{font-weight:600;}
        li .optable td{padding-right:2px;}
        #opration{ border:1px solid #EF6F03; padding:2px; width:80px; background:rgb(255,191,137); position:absolute; left:0; top:20px; display:none;}
        #opration p{ padding:3px 5px;color:#333;}
        #opration p:hover{background:#f83; color:#eee;}
        #btnop{ display:inline-block; height:17px; line-height:17px; width:40px; position:relative; padding-left:5px; color:#000!important; cursor:default;}
        .downarr{display:inline-block; width:0px; height:0px; border:4px solid rgb(255,191,137); border-top-color:#000; position:absolute; left:32px; top:8px;}
        #btnop:hover .downarr{border-color:rgb(255,133,43); border-top-color:#000;}
        #opration p a{ text-decoration:none; color:#111;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<!--内容区样式开始-->
	<div class="conthead"><span>您现在的位置：首页&nbsp;>&nbsp;信息中心&nbsp;>&nbsp;网站公告</span>联盟会员控制面板</div>
	<div class="ctbody_cnt">
		<h3>网站公告</h3>
		<div>
		    <ul id="noticelist">
		        <li><p><span class="shorttxt" style="padding-right:30px;">发布时间</span><input type="checkbox" style="visibility:hidden;" /><span>公告内容</span></p></li>
		        <asp:Repeater ID="rptpager" runat="server">
		        <ItemTemplate>
		        <li <%# base.getClassName(Eval("unread").ToString()) %>>
		                <p><span class="shorttxt"><%#Eval("pubdate") %></span><input type="checkbox" class="checkthis" name="lists" value='<%#Eval("id") %>' /><span class="longtxt"><%#Eval("title") %></span></p>
		                <div class="noticecont"><p><%#Eval("notice") %></p></div>
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
		                        <p><asp:LinkButton ID="lbtndel" runat="server" Text="删除" OnClick="delclick" OnClientClick="if(nocheck()) return confirm('确认删除？');else return false;"></asp:LinkButton></p>
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
    <script type="text/javascript">
        $(function(){
            $(".longtxt").click(function(){var obj=$(this).parent("p").next(".noticecont");$(".noticecont").not(obj).slideUp();obj.slideToggle();});
            $("#checkall").click(function(){$(".checkthis").attr("checked",true)});
            $("#uncheckall").click(function(){$(".checkthis").attr("checked",false);});
            $("#revercheck").click(function(){$(".checkthis").attr("checked",function(){return !($(this).attr("checked"));});});
            $("#btnop").click(function(){$("#opration").slideToggle();});
        });
        
        function nocheck(){
            if($(":checkbox").filter(":checked").length==0){alert("您未选择任何条目"); $("#opration").hide(); return false;}
            else return true;
        }
    </script>
</asp:Content>

