<%@ Page Language="C#" AutoEventWireup="true" CodeFile="orderDetails.aspx.cs" Inherits="admin_orderDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <asp:PlaceHolder id="holderheader" runat="server"></asp:PlaceHolder>
    <link href="css/float.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #box table{margin:0;}
    </style>
</head>
<body>
<form id="form" runat="server">
    <asp:HiddenField ID="hiduid" runat="server" />
    <div id="box">
     <div id="rightnow">
        <h3 class="reallynow">佣金明细</h3>
        <div class="youhave">
            <div id="tips">
                用户申请的佣金为：<asp:Label ID="lblapplyamt" runat="server" ForeColor="Red"></asp:Label>元，查询有效佣金为：
                <asp:Label ID="lblfigureamt" runat="server" ForeColor="Red"></asp:Label>元
                <asp:Label ID="lbladv" runat="server">把交易记录按照广告主不同发到各广告主要求确认？</asp:Label>
                <br />
                <asp:Label ID="lbltime" runat="server"></asp:Label>
            </div>
        </div>
     </div>
     <br />   
    <div style="width:inherit; overflow-x:auto; *overflow-y:hidden; position:relative;">
        <asp:GridView ID="gridList" runat="server" AllowPaging="True" AllowSorting="True" DataSourceID="ods" EmptyDataText="没有记录">
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
        </asp:GridView>
    <asp:HiddenField ID="hidcurpage" runat="server" />
    <asp:HiddenField ID="hidpagecounter" runat="server" />
        <!--[if IE 7]>
        <p>&nbsp;</p>
        <![endif]-->
    </div>
            
            
    </div> 
    <asp:ObjectDataSource ID="ods" runat="server" SelectMethod="GetListFromView" TypeName="wgiAdUnionSystem.BLL.wgi_orders">
        <SelectParameters>
            <asp:Parameter DefaultValue="view_orders" Name="viewname" Type="String" />
            <asp:Parameter DefaultValue="1=1" Name="strWhere" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</form>
</body>
<script type="text/javascript">
    $(function(){
        $(window).scroll(function(){
            var obj=$("#fixth");
            var h=obj.css("height");
            var sh=$(document).scrollTop(); 
            if(sh>105){
                obj.css({top:sh-126,display:"block"});//$(document).scrollTop()-36});
            }
            else
                $("#fixth").css({top:1,display:"none"});
        });
        
        if(window.screen.availHeight>document.body.clientHeight){
            $("table").parent("div").css({position:"relative"});
            var otr=$("th").parent("tr");
            otr.clone().attr("id","fixth").prependTo("table").css({position:"absolute",top:1,display:"none"})
        }
        
        var t=0.00;
        $("tr").each(function(){
            t+=Number($(this).find("td").eq(11).html());
        });
        $("#lblfigureamt").html(t);
    });
</script>
</html>
