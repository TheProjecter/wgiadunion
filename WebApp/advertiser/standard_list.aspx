<%@ Page Language="C#" AutoEventWireup="true" CodeFile="standard_list.aspx.cs" Inherits="advertiser_standard_list"
    Theme="gridlist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="css/css.css" rel="stylesheet" type="text/css" />

    <script src="../Js/ca/WdatePicker.js" type="text/javascript"></script>

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
                                        &nbsp; 截止时间：
                                        <asp:TextBox ID="txtstart" runat="server" Width="70px" onclick=" WdatePicker({ doubleCalendar: true, dateFmt: 'yyyy-MM-dd'})"></asp:TextBox>
                                        <span class="newfont06">至</span>
                                        <asp:TextBox ID="txtend" runat="server" Width="70px" onclick=" WdatePicker({ doubleCalendar: true, dateFmt: 'yyyy-MM-dd'})"></asp:TextBox>
                                        <asp:Button ID="Button1" runat="server" Text="查 询" class="right-button02" OnClick="Button1_Click" /> &nbsp;&nbsp;
                                        <input id="Button2" type="button" value="新 增" onclick="location.href='standard_info.aspx';" class="right-button02"/>
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
                    MouseOverCssClass="OverRow" DataKeyNames="id" Width="100%" AutoGenerateColumns="False"
                    EmptyDataText="没有查询到相关数据！">
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
                          <asp:BoundField DataField="endtime" HeaderText="截止时间" DataFormatString="{0:d}" />
                        <asp:BoundField DataField="payamt" HeaderText="佣金比例" />
                        <asp:BoundField DataField="payintro" HeaderText="佣金说明" />
                          <asp:BoundField DataField="addtime" HeaderText="添加时间" DataFormatString="{0:d}" />
                      
                      
                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                                <img border="0" src="../images/edit.gif" align="absmiddle"/>&nbsp;<a href="standard_info.aspx?id=<%# Eval("id") %>">编辑</a>&nbsp;&nbsp;
                                <img src="../Images/delete.gif" align="absmiddle"/>&nbsp;<asp:LinkButton ID="lbtnDel" runat="server">删除</asp:LinkButton>
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
        SelectMethod="GetPaymentListByCompanyID" TypeName="wgiAdUnionSystem.BLL.wgi_discount">
        <SelectParameters>
            <asp:Parameter Name="compid" Type="Int32" />
            <asp:Parameter Name="beg_date" Type="String" />
            <asp:Parameter Name="end_date" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    </form>
</body>
</html>
