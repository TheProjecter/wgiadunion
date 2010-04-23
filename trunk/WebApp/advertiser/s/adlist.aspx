<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adlist.aspx.cs" Inherits="advertiser_s_adlist" Theme="gridlist"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="../css/css.css" rel="stylesheet" type="text/css" />
<script src="../../Js/ca/WdatePicker.js" type="text/javascript"></script>
<link href="../css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
  <form id="form1" runat="server">
  <table width="100%" border="0" cellspacing="0" cellpadding="0">
  
  <tr>
    <td height="30">      <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td height="62" background="../images/nav04.gif">
            
		   <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
		    <tr>
			  <td width="21"><img src="../images/ico07.gif" width="20" height="18" /></td>
			  <td>付费类型：
            <asp:DropDownList ID="ddlPayType" runat="server">
            </asp:DropDownList>&nbsp;
		显示类型：<asp:DropDownList ID="ddlDisplayType" runat="server">
      </asp:DropDownList> 截止时间：
                  <asp:TextBox ID="txtstart" runat="server" Width="70px" onclick=" WdatePicker({ doubleCalendar: true,readOnly:true, dateFmt: 'yyyy-MM-dd'})"></asp:TextBox>
<span class="newfont06">至</span>
                  <asp:TextBox ID="txtend" runat="server"  Width="70px" onclick=" WdatePicker({ doubleCalendar: true,readOnly:true, dateFmt: 'yyyy-MM-dd'})"></asp:TextBox>
                  
                 广告描述： <asp:TextBox ID="txtTitle" runat="server" Width="90px" ></asp:TextBox>
                  <asp:Button ID="Button1" runat="server" Text="查 询" class="right-button02" 
                      onclick="Button1_Click"/>
</td>
			  
		    </tr>
          </table></td>
        </tr>
    </table></td></tr>
    </table>
    <br />
    <table align="center" cellpadding="0" cellspacing="0" border="0" style="width:98%"><tr><td>
    
      <Wgi:RichGridView ID="gridList" runat="server" AllowPaging="True" 
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
                <headertemplate>
                    序号
                </headertemplate>
                <itemtemplate>
                    <%# Container.DataItemIndex + 1 %>
                </itemtemplate>

<ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
           
            <asp:BoundField DataField="advtype" HeaderText="显示类型" />
            <asp:BoundField DataField="advname" HeaderText="广告关键字" />
            <asp:BoundField DataField="advstart" HeaderText="开始时间" DataFormatString="{0:d}" />
            <asp:BoundField DataField="advend" HeaderText="截止时间" DataFormatString="{0:d}" />
            <asp:BoundField DataField="advstatus" HeaderText="审核状态" />
            <asp:BoundField DataField="advinvalid" HeaderText="投放状态" />
                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                                <img border="0" src="../../images/edit.gif" align="absmiddle"/>&nbsp;<a href="adnew.aspx?id=<%# Eval("advid") %>">编辑</a>&nbsp;&nbsp;
                                <img src="../../Images/delete.gif" align="absmiddle"/>&nbsp;<asp:LinkButton ID="lbtnDel" runat="server">删除</asp:LinkButton>
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
    </td></tr></table>
                
                    <asp:ObjectDataSource ID="odsData" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAdvListByCompID" 
        TypeName="wgiAdUnionSystem.BLL.wgi_adv">
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
    </form>
</body>
</html>
