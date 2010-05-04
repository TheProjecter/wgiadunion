<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Finace.aspx.cs" Inherits="admin_Finace" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<asp:PlaceHolder ID="plhdTitle" runat="server"></asp:PlaceHolder>
<style type="text/css">
    #box table td input{ border:none; text-align:center;}
    select{margin:0!important;}
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
                        <span>提现申请</span>
                        <asp:LinkButton ID="lbtnsearch" runat="server" CssClass="search" OnCommand="search_click" Text="查询" OnClientClick="return checksearch();"></asp:LinkButton>
                        <br />
                    </h3>
				    <div class="youhave">				    
				        <ul id="ulfli">
				            <li><span>用户名：</span><asp:TextBox ID="txtusername" runat="server"></asp:TextBox></li>
				            <li><span>E-mail：</span><asp:TextBox ID="txtemail" runat="server"></asp:TextBox></li>
				            <li><span>姓名：</span><asp:TextBox ID="txtname" runat="server"></asp:TextBox></li>
				            <li><span>申请流程：</span><asp:DropDownList ID="ddlapplyflow" runat="server"></asp:DropDownList></li>
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
              <h3 class="boxtitle">申请列表 </h3>
                <div>
                 
<asp:GridView ID="gridList" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" EmptyDataText="没有查询到数据" EmptyDataRowStyle-HorizontalAlign="Center" DataKeyNames="id,status" OnRowDataBound="row_bound" OnRowUpdating="update_status">
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
<EmptyDataRowStyle HorizontalAlign="Center"></EmptyDataRowStyle>
    <Columns>
        <asp:BoundField HeaderText="申请人" DataField="contact" SortExpression="contact" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Center" />
        <asp:BoundField HeaderText="申请金额(元)" DataField="cash" SortExpression="cash" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Center" HtmlEncode="false" DataFormatString="{0:c}" ApplyFormatInEditMode="true" />
        <asp:BoundField HeaderText="申请日期" DataField="applydate" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Center" SortExpression="applydate" />
        <asp:TemplateField HeaderText="申请状态" ItemStyle-Width="25%" ItemStyle-HorizontalAlign="Center" SortExpression="status">
            <ItemTemplate>
                <%# CommonData.getApplyStatusByValue(Eval("status").ToString()) %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:DropDownList ID="ddlstatus" runat="server" DataSource="<%# CommonData.getApplyStatus() %>"></asp:DropDownList>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="操作" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <input type="image" src="img/icons/coins.png" onclick='showfloat(2,<%# Eval("userid") %>);return false;' class="imgbtn" title="查看明细" />
                <input type="image" src="img/icons/user.png" onclick='showfloat(1,<%# Eval("userid") %>);return false;' class="imgbtn" title="查看申请人" />
                <asp:ImageButton ID="lbtndetail" runat="server" ToolTip="编辑" CommandName="Edit" ImageUrl="img/icons/user_edit.png" />
            </ItemTemplate>
            <EditItemTemplate>
                <asp:ImageButton ID="lbtnsave" runat="server" ToolTip="保存" CommandName="Update" ImageUrl="img/icons/page_add.png" />
                <asp:ImageButton ID="lbtncancel" runat="server" ToolTip="取消" CommandName="Cancel" ImageUrl="img/icons/page_white_delete.png" />
            </EditItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<asp:HiddenField ID="hidcurpage" runat="server" />
                    <br />
                    <asp:ObjectDataSource ID="ods" runat="server" SelectMethod="GetList" 
                        TypeName="wgiAdUnionSystem.BLL.wgi_cash" UpdateMethod="UpdateStauts">
                        <UpdateParameters>
                            <asp:Parameter Name="id" Type="Int32" />
                            <asp:Parameter Name="status" Type="Int32" />
                        </UpdateParameters>
                        <SelectParameters>
                            <asp:Parameter DefaultValue="1=1" Name="strWhere" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                 
                </div>
                
                
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
    
    function showfloat(type,userid){
        var uid=userid;
        var url="";
        var title="详细资料";
        var iswider=0;
        switch(type){
            case 1:
                url="addSiteUser.aspx?uid="+uid+"&act=show";
                title="详细资料";
            break;
            case 2:
                url+="orderDetails.aspx?uid="+uid;
                title="查询明细";
                iswider=1;
            break;
            default:
            break;
        }
        $("#userframe").attr("src",url);
        openpop(title,iswider);
    }
    
    
    function checksearch(){
        var obj=$("#tipmsg");
        var sobj=$("#lblsearch");
        if($("#txtusername").val()==""&&$("#txtname").val()==""&&$("#txtemail").val()==""&&$("#ddlapplyflow").val()==""){
            obj.removeClass().addClass("onerror").html("请至少输入一个查询条件");
            sobj.html("");
            return false;
        }
        var e=$("#txtemail").val();
        if(e!="" && !emailreg.test(e)){
            obj.removeClass().addClass("onerror").html("请输入有效email地址");
            sobj.html("");
            return false;
        }
        obj.html("").removeClass();
        return true;
    }
</script>
</html>
