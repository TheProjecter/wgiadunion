<%@ Page Language="C#" AutoEventWireup="true" CodeFile="User_List.aspx.cs" EnableViewState="false" Inherits="SysManage_User_List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <script type="text/javascript" src="../js/dialog/ymPrompt.js"></script>

    <link rel="stylesheet" type="text/css" href="../js/dialog/skin/qq/ymPrompt.css" />
      <script type='text/javascript' src='../js/dragtb/resizable-tables.js'></script>
</head>
<body>
       <form id="form1" runat="server">
       <asp:ScriptManager ID="ScriptManager1" runat="server">
       </asp:ScriptManager>
       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
       <ContentTemplate>
         <center>
        <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td align="center" style="height: 10px">
                </td>
            </tr>
            <tr>
                <td align="center" class="title">
                    用户列表
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </center>
    <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="30" align="left">
                部门名称
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                &nbsp;<asp:Button ID="btnQurey" CssClass="btn" runat="server" Text=" 查 询 " />           <input name="Submit2" type="submit" class="btn" value=" 新 增 " />
                        
                        
                            <input name="Submit2" type="submit" class="btn" value=" 编 辑 " />
                      
                            <input ID="btnDel" type="button" runat="server" onclick="ymPrompt.confirmInfo('确认删除选择的数据？',null,null,'警告提示',function (tp){if(tp=='ok'){document.getElementById('hidact').value='del',__doPostBack('btnDel','');}})"
                                value=" 删 除 " class="btn" />                 
          <asp:Button ID="btnExcel" runat="server" Text="导出为Excel" CommandName="ExportExcel"
            OnCommand="btn_Command" class="btn"/>
        <asp:Button ID="btnWord" runat="server" Text="导出为Word" CommandName="ExportWord" CssClass="btn" OnCommand="btn_Command" />
        <asp:Button ID="btnText" runat="server" Text="导出为Text" CommandName="ExportText" CssClass="btn" OnCommand="btn_Command" />
                
            </td>
        </tr>
        <tr>
            <td align="center">
                <Wgi:RichGridView ID="gridList" runat="server" AllowPaging="True" 
                    AllowSorting="True" DataSourceID="odsData" MouseOverCssClass="OverRow" DataKeyNames="name"
        Width="100%" ContextMenuCssClass="RightMenu" AutoGenerateColumns="False" 
                    ondatabound="gridList_DataBound" MergeCells="2" 
                    onrowcommand="gridList_RowCommand">
                   
                    <CascadeCheckboxes>
                        <Wgi:CascadeCheckbox ChildCheckboxID="item" ParentCheckboxID="all" />
                    </CascadeCheckboxes>
                    <ContextMenus>
                        <Wgi:ContextMenu BoundCommandName="RightMenuClick" Text="点击行事件" />
                         <Wgi:ContextMenu Text="webabcd" NavigateUrl="http://webabcd.cnblogs.com" Target="_blank"/>
                        <Wgi:ContextMenu Text="<hr/>" />
                        <Wgi:ContextMenu Text="<span onclick=confirm('确认刷新当前页')>刷新</span>" NavigateUrl="#" />
                        <Wgi:ContextMenu Text="<span onclick=cmenu('胡说八道')>单元格</span>" NavigateUrl="#" />
                    </ContextMenus>
                    <PagerStyle HorizontalAlign="Right" />
                    <CheckedRowCssClass CheckBoxID="item" CssClass="SelectedRow" />
                    
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
           
            
            <asp:BoundField DataField="group" HeaderText="分组" SortExpression="group" />
            <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id" />
            <asp:BoundField DataField="name" HeaderText="名称" SortExpression="name" />
            <asp:BoundField DataField="age" HeaderText="年龄" SortExpression="age" />
            <asp:BoundField DataField="salary" HeaderText="薪水" SortExpression="salary" />
            <asp:ButtonField CommandName="RightMenuClick" Visible="false" />
            </Columns>
             <CustomPagerSettings PagingMode="Webabcd" TextFormat="每页{0}条/共{1}条&nbsp;&nbsp;&nbsp;&nbsp;第{2}页/共{3}页&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" />
        <PagerSettings PageButtonCount="13" FirstPageText="首页" PreviousPageText="上一页"
            NextPageText="下一页" LastPageText="末页" />
                    <SmartSorting AllowMultiSorting="True" AllowSortTip="True" 
                        SortAscImageUrl="~/Images/asc.gif" SortDescImageUrl="~/Images/desc.gif" />
                    <RowStyle HorizontalAlign="Center" />
                </Wgi:RichGridView>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:HiddenField ID="hidact" runat="server" /> <asp:HiddenField ID="hidparams" runat="server" />
            </td>
        </tr>
    </table>
       </ContentTemplate>
       </asp:UpdatePanel>
  
   
    <asp:ObjectDataSource ID="odsData" runat="server" SelectMethod="Get" 
            TypeName="TestData" OldValuesParameterFormatString="original_{0}">
    </asp:ObjectDataSource>
       <script type="text/javascript">


           var tb = new ColumnDrag('gridList');

           function cmenu(obj, param) {
              
               ymPrompt.alert('您要做什么事？'+param, null, null, '提示信息', null);
           }
           function doCell(obj, row, col) {
               if (col != 0) {
                   //ymPrompt.alert('您点击第' + row + '的第' + col + '列', null, null, '提示信息', null);
                   document.getElementById("hidact").value = "docell";
                   document.getElementById("hidparams").value = row + ":" + col;
                   __doPostBack('btnDel', '');
               }
               else {
                  
               }
           }
           function doRow(obj, row) {
           }
           function document.onkeydown() {
               var e = event.srcElement;
               if (event.keyCode == 13) {
                   document.getElementById("btnQurey").click();
                   return false;
               }
           }
    </script>
    </form>
 
</body>
</html>
