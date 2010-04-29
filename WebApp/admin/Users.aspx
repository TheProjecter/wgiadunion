<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Users.aspx.cs" Inherits="admin_Users" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<asp:PlaceHolder ID="plhdTitle" runat="server"></asp:PlaceHolder>
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
                        <span>管理员管理</span>
                        <asp:LinkButton ID="lbtncancel" runat="server" OnClick="cancel_click" CssClass="pagedelete" Text="取消" Enabled="false"></asp:LinkButton>
                        <asp:LinkButton ID="lbtnedit" runat="server" CommandArgument="add" CssClass="app_add" OnCommand="save_click" Text="新增" OnClientClick="return checkvali();"></asp:LinkButton>
           <asp:LinkButton ID="lbtnsearch" runat="server" CssClass="search" Text="查询"></asp:LinkButton>
           <br clear="all" />
                    </h3>
				    <div class="youhave">
				        <ul id="ulfli">
				            <li><span>用户名：</span><asp:TextBox ID="txtname" runat="server" ToolTip="6-20位字母/数字组合"></asp:TextBox></li>
				            <li><span>密码：</span><asp:TextBox ID="txtpwd" runat="server" TextMode="Password" ToolTip="6-20位字母/数字组合"></asp:TextBox></li>
				            <li><span>重输密码：</span><asp:TextBox ID="txtpwdre" runat="server" TextMode="Password" ToolTip="请再次入密码"></asp:TextBox></li>
				            <li><span>E-mail：</span><asp:TextBox ID="txtemail" runat="server" ToolTip="请输入有效的邮件地址"></asp:TextBox></li>
				        </ul>
				        <div id="tips"><span style="color:gray; font-weight:600">提示：</span><span id="tipmsg"></span></div>
				        <asp:HiddenField ID="hideditid" runat="server" Value="" />
                    </div>
			  </div>
			  <br />
              <div id="box">
                	<h3 class="boxtitle">
              <asp:LinkButton ID="lbtndel" runat="server" CssClass="pagedelete2" OnClick="deletes" Text="删除" OnClientClick="return filter();"></asp:LinkButton>
              用户列表  
                	</h3>
                	<asp:GridView ID="gridList" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="id" AllowPaging="True" OnPreRender="renderview" EmptyDataText="没有查询到数据" EmptyDataRowStyle-HorizontalAlign="Center">
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
                	        <ItemTemplate><input type="checkbox" class="checkthis" value='<%# Eval("id") %>' /></ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
                	    </asp:TemplateField>
                	    <asp:TemplateField HeaderText="序号" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" SortExpression="id">
                	        <ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate>
                	    </asp:TemplateField>
                	    <asp:BoundField HeaderText="用户名" DataField="username" SortExpression="username" 
                            ItemStyle-HorizontalAlign="Center" ItemStyle-Width="136px" >
                        </asp:BoundField>
                	    <asp:BoundField HeaderText="E-mail" DataField="email" 
                            ItemStyle-HorizontalAlign="Center" ItemStyle-Width="411px" >
                        </asp:BoundField>
                	    <asp:TemplateField HeaderText="操作" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px">
                	        <ItemTemplate>
                	            <asp:ImageButton ID="btnedit" runat="server" OnCommand="edit_click" CommandArgument='<%# Eval("id") %>' ImageUrl="img/icons/user_edit.png" ToolTip="修改资料" Width="16px" Height="16px" />
                	            <asp:ImageButton ID="btndel" runat="server" CommandName="Delete" ImageUrl="img/icons/user_delete.png" ToolTip="删除" Width="16px" Height="16px" OnClientClick='<%# Eval("id", "return con_del({0});") %>' />
                	        </ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
                	    </asp:TemplateField>
                	</Columns>
                    </asp:GridView>
                    <asp:HiddenField ID="hidselected" runat="server" Value="" />
                    <asp:HiddenField ID="hiduid" runat="server" Value="" />
                    <asp:HiddenField ID="hidcurpage" runat="server" Value="" />

                    <asp:ObjectDataSource ID="ods" runat="server" DeleteMethod="Delete" SelectMethod="GetList" TypeName="wgiAdUnionSystem.BLL.wgi_sysuser">
                        <DeleteParameters>
                            <asp:Parameter Name="id" Type="Int32" />
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
      <!--主内容区容器结束-->
      
        <!--脚部开始-->
        <asp:PlaceHolder ID="plhdFooter" runat="server"></asp:PlaceHolder>
        <!--脚部结束-->
</div>
<!--内容区结束-->
    </form>
</body>
<script type="text/javascript">
    var vali=true;
    var emailreg=/^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
    var obj=$("#tipmsg");
    $(function(){
        //check input
        $("#ulfli :input").focus(function(){var thisobj=$(this);var oldtext=$(this).attr("title"); obj.html(oldtext).removeClass().addClass("onfocus");});
        $("#txtname").blur(function(){
                var v=$(this).val();
                var thisobj=$(this);
                if(regtest(/^[0-9a-zA-Z]+[0-9a-zA-Z_]{5,29}$/,v)){
				    url=encodeURI("/ajaxHandler.aspx?act=checkAdminUsername&username="+v+"&t="+new Date().getMilliseconds());
				    $.get(url,function(data){
					    if(data==0){obj.html("该用户名已被使用！").removeClass().addClass("onerror");vali=false;addRedBorder(thisobj);}else{obj.html("输入正确").removeClass().addClass("oncorrect");removeRed(thisobj);}
				    }
			);}
				else{obj.removeClass().html("用户名格式不正确！").addClass("onerror");vali=false;addRedBorder(thisobj);}});
            $("#txtpwd").blur(function(){var thisobj=$(this);var v=$(this).val();if(!regtest(/^[0-9a-zA-Z]{6,20}$/,v)){obj.html("密码格式不正确！").removeClass().addClass("onerror");vali=false;addRedBorder(thisobj);}else{obj.html("输入正确").removeClass().addClass("oncorrect");removeRed(thisobj);}});
            $("#txtpwdre").blur(function(){var thisobj=$(this);var v=$(this).val();if($("#txtpwd").val()!=v){obj.removeClass().addClass("onerror");obj.html("两次密码输入不一致");vali=false;addRedBorder(thisobj);}else{obj.html("输入正确").removeClass().addClass("oncorrect");removeRed(thisobj);}});
            $("#txtemail").blur(function(){var thisobj=$(this);var v=$(this).val();if(!regtest(emailreg,v)){obj.html("邮箱格式不正确！").removeClass().addClass("onerror");vali=false;addRedBorder(thisobj);}else{obj.html("输入正确").removeClass().addClass("oncorrect");removeRed(thisobj);}});
        
        
        //全选
        $(".checkall").click(function(){$(".checkthis").attr("checked",$(this).attr("checked"));});
        $(".checkthis").click(function(){$(".checkall").attr("checked",$(".checkthis").length==$(".checkthis").filter(":checked").length);});
    });
    //删除单个用户前的确认
    function con_del(id){
        if(id==$("#hiduid").val()){
            alert("您不能删除自己的账号！");
            return false;
        }
        return confirm("确认删除？");
    }
    
    
    function regtest(pattern,data){return pattern.test(data);}
    function checkvali(){vali=true;$("#ulfli :input").blur(); if(!vali) obj.removeClass().addClass("onerror").html("请检查红框部分，输入正确的数据");  return vali;}
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
    
    
    //删除前过滤掉操作者本人的ID
    function filter(){
        var l=$(".checkthis:checked").length;
        if(l==0){ alert("请选择需要删除的用户！"); return false;}
        var uid=$("#hiduid").val();
        if(l==1 && $(".checkthis:checked").val()==uid){alert("您不能删除自己的账号！"); return false;}
        var obj=$(".checkthis[value="+uid+"]");
        var ids=$(":checkbox").filter(":checked").not(obj).map(function(){return $(this).val();}).get().join(",");
        $("#hidselected").val(ids);
        return confirm("确认删除？");
    }
    
</script>

</html>
