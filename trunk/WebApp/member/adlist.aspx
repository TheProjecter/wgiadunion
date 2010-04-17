<%@ Page Language="C#" MasterPageFile="~/Templet/memberMaster.master" AutoEventWireup="true" CodeFile="adlist.aspx.cs" Inherits="member_adlist" Title="中商购物|网站联盟|用户中心" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="../../Js/ca/WdatePicker.js" type="text/javascript"></script>

    <link href="/Css/mem_modify.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

	<!--内容区样式开始-->
	<div class="conthead"><span>您现在的位置：首页&nbsp;>&nbsp;个人设置&nbsp;>&nbsp;银行信息</span>联盟会员控制面板</div>
	<div class="ctbody_cnt" id="listdiv">
		<h3>推荐广告</h3>
		<div>
		<div id="opdiv">
		<table border="0" cellpadding="0" cellspacing="0" width="100%" style="margin:5px auto;">
		    <tr>
		        <td width="250px">付费类型：<asp:DropDownList ID="ddlPayType" runat="server"></asp:DropDownList></td>
		        <td>显示类型：<asp:DropDownList ID="ddlDisplayType" runat="server"></asp:DropDownList></td>
		    </tr>
		    <tr>
		        <td>截止时间：<asp:TextBox ID="txtstart" runat="server" Width="70px" onclick=" WdatePicker({ doubleCalendar: true,readOnly:true, dateFmt: 'yyyy-MM-dd'})"></asp:TextBox>
<span class="newfont06">至</span>
                  <asp:TextBox ID="txtend" runat="server"  Width="70px" onclick=" WdatePicker({ doubleCalendar: true,readOnly:true, dateFmt: 'yyyy-MM-dd'})"></asp:TextBox> </td>
		        <td>广告描述： <asp:TextBox ID="txtTitle" runat="server" Width="130px" ></asp:TextBox></td>
		    </tr>
		</table>
		    
            <asp:Button ID="Button1" runat="server" Text="查&nbsp;询" class="yelbtn"  onclick="Button1_Click"/>
        </div>
		
      <Wgi:RichGridView ID="gridList" runat="server" AllowPaging="True" CssClass="listtable"
            AllowSorting="True" MouseOverCssClass="OverRow" DataKeyNames="advid"
        Width="100%" AutoGenerateColumns="False" ondatabound="gridList_DataBound" 
            EmptyDataText="没有查询到相关数据！">
                   
                    <CascadeCheckboxes>
                        <Wgi:CascadeCheckbox ChildCheckboxID="item" ParentCheckboxID="all" />
                    </CascadeCheckboxes>
                  
                    <PagerStyle HorizontalAlign="Right" />
                    <CheckedRowCssClass CheckBoxID="item" CssClass="SelectedRow" />
                    
                    <EmptyDataRowStyle ForeColor="Blue" HorizontalAlign="Center" />
                    
                    <Columns>
            <asp:TemplateField ItemStyle-Width="50px">
                <headertemplate>
                    <asp:CheckBox ID="all" runat="server" />
                </headertemplate>
                <itemtemplate>
                    <asp:CheckBox ID="item" runat="server" />
                </itemtemplate>
                <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="50px">
                <headertemplate>序号</headertemplate>
                <itemtemplate><%# Container.DataItemIndex + 1 %></itemtemplate>
                <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
           
            <asp:BoundField DataField="advtype" HeaderText="显示类型" />
            <asp:BoundField DataField="advcont" HeaderText="预览" />
            <asp:BoundField DataField="advname" HeaderText="广告关键字" />
            <asp:BoundField DataField="advstart" HeaderText="开始时间" DataFormatString="{0:d}" />
            <asp:BoundField DataField="advend" HeaderText="截止时间" DataFormatString="{0:d}" />
                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                                <img border="0" alt="" src="../../images/edit.gif" align="absmiddle"/>&nbsp;<a href="javascript:genCode(<%# Eval("advid") %>,<%= base.adhostid %>,<%# Eval("advtype") %>,1)">生成标签</a>
                            </ItemTemplate>
                        </asp:TemplateField>
            </Columns>
             <CustomPagerSettings PagingMode="Webabcd" TextFormat="每页{0}条/共{1}条&nbsp;&nbsp;&nbsp;&nbsp;第{2}页/共{3}页&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" />
        <PagerSettings PageButtonCount="13" FirstPageText="首页" PreviousPageText="上一页"
            NextPageText="下一页" LastPageText="末页" />
                    <SmartSorting AllowMultiSorting="True" AllowSortTip="True" 
                        SortAscImageUrl="~/Images/asc.gif" SortDescImageUrl="~/Images/desc.gif" />
                    <RowStyle HorizontalAlign="Center" />
                </Wgi:RichGridView>
                
                    <asp:ObjectDataSource ID="odsData" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAdvListByCompID" TypeName="wgiAdUnionSystem.BLL.wgi_adv">
                        <SelectParameters>
                            <asp:Parameter Name="compid" Type="Int32" />
                            <asp:Parameter Name="paytype" Type="Int32" />
                            <asp:Parameter Name="display" Type="Int32" />
                            <asp:Parameter Name="beg" Type="String" />
                            <asp:Parameter Name="end" Type="String" />
                            <asp:Parameter Name="title" Type="String" />
                            <asp:Parameter Name="isaudit" Type="Int32" />
                            <asp:Parameter Name="ispublished" Type="Int32" />
                        </SelectParameters>
    </asp:ObjectDataSource>
		</div>
	</div>
	<!--内容区样式结束-->
</asp:Content>


<asp:Content ID="jscode1" ContentPlaceHolderID="jscode" runat="server">
    <script type="text/javascript">
        function genCode(adid,hostid,adtype,paytype){
            location.href="gencode.aspx?id="+adid+"&host="+hostid+"&adtype="+adtype+"&paytype="+paytype;
        }
    </script>
</asp:Content>