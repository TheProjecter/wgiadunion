<%@ Page Language="C#" AutoEventWireup="true" CodeFile="order_chk.aspx.cs" Inherits="advertiser_order_chk" Theme="gridlist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <script src="../../Js/ca/WdatePicker.js" type="text/javascript"></script>
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
                                        <img src="../images/ico07.gif" width="20" height="18" />
                                    </td>
                                    <td>
                                        精确订单号：<asp:TextBox ID="txtorderno" runat="server" style="width:80px"></asp:TextBox>&nbsp;&nbsp;购买人：<asp:TextBox ID="txtbuyer" runat="server" style="width:80px"></asp:TextBox> 
                                        订单时间： <asp:TextBox ID="txtstart" runat="server" Width="70px" onclick=" WdatePicker({ doubleCalendar: true,readOnly:true, dateFmt: 'yyyy-MM-dd'})"></asp:TextBox>
<span class="newfont06">至</span>
                  <asp:TextBox ID="txtend" runat="server"  Width="70px" onclick=" WdatePicker({ doubleCalendar: true,readOnly:true, dateFmt: 'yyyy-MM-dd'})"></asp:TextBox>
                                        &nbsp;&nbsp;<asp:Button ID="Button1" runat="server" Text="查 询" class="right-button02"
                                            OnClick="Button1_Click" />
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
                    MouseOverCssClass="OverRow" DataKeyNames="orderid" Width="100%" AutoGenerateColumns="False"
                    EmptyDataText="没有查询到相关数据！" OnDataBound="gridList_DataBound" 
                    onrowcommand="gridList_RowCommand">
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
                        <asp:BoundField DataField="ordertime" HeaderText="订单时间" DataFormatString="{0:G}" />
                        <asp:BoundField DataField="orderno" HeaderText="订单编号" />
                        <asp:BoundField DataField="consumer" HeaderText="购买人" />
                        <asp:BoundField DataField="username" HeaderText="联盟会员" />
                        <asp:BoundField DataField="orderamt" HeaderText="订单金额" />
                        <asp:BoundField DataField="payamt" HeaderText="需付佣金" />
                        
                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                            <img border="0" src="../images/ok.gif" align="absmiddle" />&nbsp;<asp:LinkButton
                                ID="lbtnOK" runat="server" Text="核对有效" OnClientClick="return confirm('确认此订单有效吗？');" CommandArgument='<%# Eval("orderid") %>' CommandName="doValid"></asp:LinkButton>
                                <img border="0" src="../images/stop.gif" align="absmiddle" />&nbsp;&nbsp;<asp:LinkButton
                                ID="lbtnNo" runat="server" Text="核对无效" OnClientClick="return confirm('确认此订单无效吗？请务必填写无效的理由！');" CommandArgument='<%# Eval("orderid") %>' CommandName="doInvalid"></asp:LinkButton>
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
                <asp:Panel ID="Panel1" runat="server" Visible="false">
                 <p>请填写无效的理由，一旦保存将无法更改： </p><asp:TextBox ID="txtReason" runat="server" 
                        Width="400px" Height="50px" 
                        TextMode="MultiLine" ValidationGroup="reason"></asp:TextBox> 
                    <asp:Button ID="btnReason" runat="server" Text="保 存" 
                        onclick="btnReason_Click" ValidationGroup="reason" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtReason" Display="Dynamic" ErrorMessage="必须填写无效订单的理由！" 
                        ValidationGroup="reason"></asp:RequiredFieldValidator>
                </asp:Panel> 
            </td>
        </tr>
    </table>
    <asp:ObjectDataSource ID="odsData" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetAdvOrderList" TypeName="wgiAdUnionSystem.BLL.wgi_order">
        <SelectParameters>
            <asp:Parameter Name="compid" Type="Int32" />
            <asp:Parameter Name="status" Type="Int32" />
            <asp:Parameter Name="member" Type="String" />
            <asp:Parameter Name="orderno" Type="String" />
            <asp:Parameter Name="buyer" Type="String" />
            <asp:Parameter Name="sdate" Type="String" />
            <asp:Parameter Name="edate" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    </form>
</body>
</html>
