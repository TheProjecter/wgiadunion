<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Notice.aspx.cs" Inherits="admin_Notice" %>

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
                        <span>公告管理</span>
           <asp:LinkButton ID="lbtndel" runat="server" CssClass="pagedelete2" OnClick="deletes" Text="删除" OnClientClick="return dels();"></asp:LinkButton>
           <asp:LinkButton ID="lbtnsearch" runat="server" CssClass="search" Text="查询" OnClick="searchResault" OnClientClick="return checksearch();"></asp:LinkButton>
           <a href="javascript:showfloat(1);" class="app_add">发布公告</a>
           <br clear="all" />
                    </h3>
				    <div class="youhave">
				        <ul id="ulfli">
				            <li><span>标题：</span><asp:TextBox ID="txttitle" runat="server"></asp:TextBox></li>
				            <li style="width:310px;"><span>发布时间：</span><asp:TextBox ID="txtstart" runat="server" Width="95px" Height="16px" CssClass="Wdate" onclick=" WdatePicker({ doubleCalendar: true,readOnly:true, dateFmt: 'yyyy-MM-dd'})"></asp:TextBox>
<span>至</span>
                  <asp:TextBox ID="txtend" runat="server"  Width="95px" Height="16px" CssClass="Wdate" onclick=" WdatePicker({ doubleCalendar: true,readOnly:true, dateFmt: 'yyyy-MM-dd',minDate:'#F{$dp.$D(\'txtstart\')}'})"></asp:TextBox></li>
				            <li style="width:170px;"><span>接收人：</span><asp:DropDownList runat="server" ID="ddlobjtype"></asp:DropDownList></li>
				        </ul>
				        <div id="tips"><span style="color:gray; font-weight:600">提示：</span><span id="tipmsg"></span>
				            <asp:Label ID="lblsearch" runat="server"></asp:Label>
				            <asp:LinkButton ID="lbtnclear" Visible="false" runat="server" Text="清除" CssClass="folder_table" style="padding-left:20px; text-decoration:none;" OnClick="clearsearch"></asp:LinkButton>
				        </div>
				        <asp:HiddenField ID="hidquery" runat="server" />
                    </div>
			  </div>
			  <br />
              <div id="box">
                	<h3 class="boxtitle">
              
              公告列表
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
                	        <ItemTemplate><input type="checkbox" class="checkthis" value='<%# Eval("id") %>' name="ids" /></ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
                	    </asp:TemplateField>
                	    <asp:TemplateField HeaderText="序号" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" SortExpression="userid">
                	        <ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
                	    </asp:TemplateField>
                	    <asp:BoundField HeaderText="标题" DataField="title" SortExpression="titile" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="311px"></asp:BoundField>
                        <asp:BoundField HeaderText="发布时间" DataField="pubdate" SortExpression="pubdate" ItemStyle-Width="130px" ItemStyle-HorizontalAlign="Center" />
                	    <asp:TemplateField HeaderText="接收人" ItemStyle-Width="96px" ItemStyle-HorizontalAlign="Center" SortExpression="objtype">
                	        <ItemTemplate>
                	            <%# CommonData.getUsertypeByValue(Eval("objtype").ToString()) %>&nbsp;
                	        </ItemTemplate>
                	    </asp:TemplateField>
                	    <asp:TemplateField HeaderText="操作" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px">
                	        <ItemTemplate>
                	            <%--<input type="image" src="img/icons/page_white_link.png" title="预览" class="imgbtn" onclick='showfloat(3,<%# Eval("id") %>); return false' />--%>
                	            <input type="image" src="img/icons/page_white_edit.png" title="编辑" class="imgbtn" onclick='showfloat(2,<%# Eval("id") %>); return false;' />
                	            <asp:ImageButton ID="btndel" runat="server" CommandName="Delete" ImageUrl="img/icons/page_white_delete.png" ToolTip="删除" Width="16px" Height="16px" OnClientClick="return confirm('确认删除？');" />
                	        </ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="70px"></ItemStyle>
                	    </asp:TemplateField>
                	</Columns>
                    </asp:GridView>
                    <asp:HiddenField ID="hiduid" runat="server" Value="" />
                    <asp:HiddenField ID="hidcurpage" runat="server" Value="" />

                    <asp:ObjectDataSource ID="ods" runat="server" DeleteMethod="Delete" SelectMethod="getList" TypeName="wgiAdUnionSystem.BLL.wgi_notice">
                        <DeleteParameters>
                            <asp:Parameter Name="id" Type="Int32" />
                        </DeleteParameters>
                        <SelectParameters>
                            <asp:Parameter Name="strWhere" Type="String" />
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

<script src="../Js/ca/WdatePicker.js" type="text/javascript"></script>
<script src="js/drag.js" type="text/javascript"></script>
<script type="text/javascript">
    var emailreg=/^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
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
    @uid:the userid for edit/show, but no need for create(default by 0)
    */
    function showfloat(type,noticeid){
        var nid=noticeid||0;
        var url="ArticalPage.aspx?t="+new Date().getMilliseconds()+"&noticeid="+nid+"&act=";
        var title="";
        switch(type){
            case 1:
                url+="add";
                title="发布公告";
            break;
            case 2:
                url+="edit";
                title="编辑公告";
            break;
            default:
                url+="show";
                title="预览公告";
            break;
        }
        $("#userframe").attr("src",url);
        openpop(title,1);
    }
    
    function checksearch(){
        var obj=$("#tipmsg");
        var sobj=$("#lblsearch");
        if($("#txttitle").val()==""&&$("#txtstart").val()==""&&$("#txtend").val()==""&&$("#ddlobjtype").val()=="-1"){
            obj.removeClass().addClass("onerror").html("请至少输入一个查询条件，查询所有请直接清除");
            sobj.html("");
            return false;
        }
        obj.html("").removeClass();
        return true;
    }
    
    function dels(){
        if($(".checkthis:checked").length==0){
            alert("请选择需要删除的条目");
            return false;
        }
        return confirm("确认删除？");
    }
    
    
</script>

</html>
