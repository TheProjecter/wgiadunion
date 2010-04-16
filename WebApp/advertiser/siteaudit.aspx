<%@ Page Language="C#" AutoEventWireup="true" CodeFile="siteaudit.aspx.cs" Inherits="advertiser_siteaudit" Theme="gridlist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="css/css.css" rel="stylesheet" type="text/css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td height="30">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td height="62" class="sh_leftbg">
                            <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="21">
                                        <img src="images/ico07.gif" width="20" height="18" />
                                    </td>
                                    <td>
                                        网站名称：<asp:TextBox ID="txtname" runat="server"></asp:TextBox>&nbsp;
                                        审核状态：<asp:DropDownList ID="ddlAudit" runat="server">
                                        </asp:DropDownList>
                                        &nbsp;&nbsp;<asp:Button ID="Button1" runat="server" Text="查 询" class="right-button02" OnClick="Button1_Click" />
                                        &nbsp;&nbsp;<asp:Button ID="Button2" runat="server" Text="通 过" 
                                            class="right-button02" onclick="Button2_Click"/>
                                        &nbsp;&nbsp;<asp:Button ID="Button3" runat="server" Text="拒 绝"  
                                            class="right-button02" onclick="Button3_Click"/>
                                        
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <br />
    <table align="center" cellpadding="0" cellspacing="0" border="0" style="width: 98%">
        <tr>
            <td>
                <Wgi:RichGridView ID="gridList" runat="server" AllowPaging="True" AllowSorting="True"
                    MouseOverCssClass="OverRow" DataKeyNames="auid" Width="100%" AutoGenerateColumns="False"
                    EmptyDataText="没有查询到相关数据！" ondatabound="gridList_DataBound">
                    <CascadeCheckboxes>
                        <Wgi:CascadeCheckbox ChildCheckboxID="item" ParentCheckboxID="all" />
                    </CascadeCheckboxes>
                    <PagerStyle HorizontalAlign="Right" />
                    <CheckedRowCssClass CheckBoxID="item" CssClass="SelectedRow" />
                    <EmptyDataRowStyle ForeColor="Blue" HorizontalAlign="Center" />
                    <Columns>
                        <asp:TemplateField ItemStyle-Width="50px">
                            <HeaderTemplate>
                                <asp:CheckBox ID="all" runat="server" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="item" runat="server" />
                            </ItemTemplate>
                            <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="50px">
                            <HeaderTemplate>
                                序号
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                         <asp:BoundField DataField="catename" HeaderText="网站分类" />
                        <asp:BoundField DataField="sitename" HeaderText="网站名称" /> 
                        <asp:BoundField DataField="url" HeaderText="网站网址" />
                       
                        <asp:BoundField DataField="applytime" HeaderText="申请时间" DataFormatString="{0:d}" />
                        <asp:BoundField DataField="status" HeaderText="审核状态" />
                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                                <img border="0" src="../images/edit.gif" align="absmiddle" />&nbsp;<a href="site_info.aspx?id=<%# Eval("siteid") %>">查看详细</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <CustomPagerSettings PagingMode="Webabcd" TextFormat="每页{0}条/共{1}条&nbsp;&nbsp;&nbsp;&nbsp;第{2}页/共{3}页&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" />
                    <PagerSettings PageButtonCount="13" FirstPageText="首页" PreviousPageText="上一页" NextPageText="下一页"
                        LastPageText="末页" />
                    <SmartSorting AllowMultiSorting="True" AllowSortTip="True" SortAscImageUrl="~/Images/asc.gif"
                        SortDescImageUrl="~/Images/desc.gif" />
                    <RowStyle HorizontalAlign="Center" />
                </Wgi:RichGridView>
            </td>
        </tr>
    </table>
    <asp:ObjectDataSource ID="odsData" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetWebSiteWithAdvList" TypeName="wgiAdUnionSystem.BLL.wgi_adhost_usersite">
        <SelectParameters>
            <asp:Parameter Name="compid" Type="Int32" />
            <asp:Parameter Name="status" Type="Int32" />
             <asp:Parameter Name="sitename" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    </form>
</body>
</html>
