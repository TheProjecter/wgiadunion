﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="siteUsers.aspx.cs" Inherits="admin_siteUsers" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<asp:PlaceHolder ID="plhdTitle" runat="server"></asp:PlaceHolder>
<style type="text/css">
    #ulfli{ overflow:hidden;}
    #ulfli li{ list-style:none; float:left; width:237px;}
    #ulfli li span{ display:inline-block; height:24px; line-height:24px;}
    #ulfli li input{ width:149px;}
    #ulfli li span:first-child{ width:65px;}
    .checkall, .checkthis{border:none!important; background:none!important;}
    #tips{ padding:4px 8px;}
    #ulfli li input.redcont{color:red; border-color:red; font-weight:600}
</style>
</head>
<body>
    <form id="form" runat="server">

<!--内容区开始-->
	<div id="container">
	  <!--头部开始-->
      <asp:PlaceHolder ID="plhdHeader" runat="server"></asp:PlaceHolder>
	  <!--头部结束-->
      <!--主内容区容器开始-->
        <div id="wrapper">
            <!--左内容区开始-->
            <div id="content">
       			<div id="rightnow">
                    <h3 class="reallynow">
                        <span>网站主管理</span>
           <asp:LinkButton ID="lbtndel" runat="server" CssClass="pagedelete2" OnClick="deletes" Text="删除" OnClientClick="return confirm('确认删除？');"></asp:LinkButton>
           <a href="javascript:showfloat(1);" class="app_add">新增</a>
           <asp:LinkButton ID="lbtnsearch" runat="server" CssClass="search" Text="查询"></asp:LinkButton>
           <br clear="all" />
                    </h3>
				    <div class="youhave">
                    </div>
			  </div>
			  <br />
              <div id="box">
                	<h3 class="boxtitle">
              
              用户列表——网站主
                	</h3>
                	<asp:GridView ID="gridList" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="userid" AllowPaging="True" OnPreRender="renderview">
                        <PagerTemplate>
                        <div class="pager">
                        Page&nbsp;
                        <asp:ImageButton ID="bfpage" runat="server"  Width="16px" Height="16px" ImageUrl="img/icons/arrow_left_first.gif" CommandName="Page" CommandArgument="First" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex!=0%>" />
                        <asp:ImageButton ID="bppage" runat="server" Width="16px" Height="16px" ImageUrl="img/icons/arrow_left.gif" CommandName="Page" CommandArgument="Prev" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex!=0%>" />
                    	<asp:TextBox ID="txtcurrentPage" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>" Width="20px" MaxLength="3" CssClass="txttopage"></asp:TextBox>
                    	<asp:ImageButton ID="bnpage" runat="server" Width="16px" Height="16px" ImageUrl="img/icons/arrow_right.gif" CommandName="Page" CommandArgument="Next" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1%>" />
                        <asp:ImageButton ID="blpage" runat="server" Width="16px" Height="16px" ImageUrl="img/icons/arrow_right_last.gif" CommandName="Page" CommandArgument="Last" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1%>" />
  of <b><asp:Label id="lblTotalPage" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageCount%>" CssClass="totalpage"></asp:Label></b>
                    pages
                    <asp:Button ID="btngopage" runat="server" Text="go" OnClick="getCustPage" OnClientClick="return ToPage();" />&nbsp|&nbsp;View&nbsp;
                    <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="changepagesize">
                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                        <asp:ListItem Text="15" Value="15"></asp:ListItem>
                        <asp:ListItem Text="20" Value="20"></asp:ListItem>
                        <asp:ListItem Text="30" Value="30"></asp:ListItem>
                        <asp:ListItem Text="50" Value="50"></asp:ListItem>
                    </asp:DropDownList>
                    per&nbsp;page&nbsp;|&nbsp;Total&nbsp;<strong><asp:Label ID="lblTotalRecord" runat="server"></asp:Label></strong>&nbsp;records found
                        </div>
                        </PagerTemplate>
                	<Columns>
                	    <asp:TemplateField ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                	        <HeaderTemplate><input type="checkbox" class="checkall" /></HeaderTemplate>
                	        <ItemTemplate><input type="checkbox" class="checkthis" value='<%# Eval("userid") %>' /></ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
                	    </asp:TemplateField>
                	    <asp:TemplateField HeaderText="序号" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" SortExpression="userid">
                	        <ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
                	    </asp:TemplateField>
                	    <asp:BoundField HeaderText="用户名" DataField="username" SortExpression="username" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="136px"></asp:BoundField>
                        <asp:BoundField HeaderText="姓名" DataField="accountname" SortExpression="accountname" ItemStyle-Width="90px" ItemStyle-HorizontalAlign="Center" />
                	    <asp:BoundField HeaderText="E-mail" DataField="email" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="311px" ></asp:BoundField>
                	    <asp:TemplateField HeaderText="操作" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px">
                	        <ItemTemplate>
                	            <asp:ImageButton ID="btnprofile" runat="server" OnCommand="profile_click" CommandArgument='<%# Eval("userid") %>' ImageUrl="img/icons/user.png" ToolTip="查看详细" Width="16px" Height="16px" />
                	            <asp:ImageButton ID="btnedit" runat="server" OnCommand="edit_click" CommandArgument='<%# Eval("userid") %>' ImageUrl="img/icons/user_edit.png" ToolTip="修改资料" Width="16px" Height="16px" />
                	            <asp:ImageButton ID="btndel" runat="server" CommandName="Delete" ImageUrl="img/icons/user_delete.png" ToolTip="删除" Width="16px" Height="16px" OnClientClick="return confirm('确认删除？');" />
                	        </ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="70px"></ItemStyle>
                	    </asp:TemplateField>
                	</Columns>
                    </asp:GridView>
                    <asp:HiddenField ID="hidselected" runat="server" Value="" />
                    <asp:HiddenField ID="hiduid" runat="server" Value="" />
                    <asp:HiddenField ID="hidcurpage" runat="server" Value="" />

                    <asp:ObjectDataSource ID="ods" runat="server" DeleteMethod="Delete" SelectMethod="GetList" TypeName="wgiAdUnionSystem.BLL.wgi_sitehost">
                        <DeleteParameters>
                            <asp:Parameter Name="userid" Type="Int32" />
                        </DeleteParameters>
                        <SelectParameters>
                            <asp:Parameter DefaultValue="1=1" Name="strWhere" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>

                </div>

            </div>
            <!--左内容区结束-->
            <!--侧面板开始-->
            <asp:PlaceHolder ID="plhdSlide" runat="server"></asp:PlaceHolder>
            <!--侧面板结束-->
      </div>
      <!--浮层开始-->
      <div id="bgopacity"></div>
    <div class="f_outer">
	    <div class="f_bgc">&nbsp;</div>
	    <div class="f_content">
	    <div class="f_title"><span onClick="closepop();"></span></div>
	    <h3></h3>
	    <iframe src="about:blank" frameborder="0" id="userframe"></iframe>
	    </div>
    </div>
      <!--浮层结束-->
      <!--主内容区容器结束-->
      
        <!--脚部开始-->
        <asp:PlaceHolder ID="plhdFooter" runat="server"></asp:PlaceHolder>
        <!--脚部结束-->
</div>
<!--内容区结束-->
    </form>
</body>
<script src="js/drag.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function(){
        //全选
        $(".checkall").click(function(){$(".checkthis").attr("checked",$(this).attr("checked"));});
        $(".checkthis").click(function(){$(".checkall").attr("checked",$(".checkthis").length==$(".checkthis").filter(":checked").length);});
    });
   
    function addRedBorder(obj){$(obj).addClass("redcont");}
    function removeRed(obj){$(obj).removeClass("redcont");}
    
    function ToPage(){
        var totalPage=Number($(".totalpage").eq(0).html());
        var topage=Number($(".txttopage").eq(0).val());
        if(topage>totalPage){
            alert("超出页码范围");
            return false;
        }
        else if(topage==$("#hidcurpage").val()) return false;
        else return true;
    }
    
    /*
    @type:1:add,2:edit,3,show profile
    */
    function showfloat(type){
        var url="addSiteUser.aspx?uid="+$("#hiduid").val()+"&act=";
        var title="";
        switch(type){
            case 1:
                url+="add";
                title="添加用户";
            break;
            case 2:
                url+="edit";
                title="编辑用户";
            break;
            default:
                url+="show";
                title="详细资料";
            break;
        }
        $("#userframe").attr("src",url);
        openpop(title);
    }
    
    
</script>

</html>
