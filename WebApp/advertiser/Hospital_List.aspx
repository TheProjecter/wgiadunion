<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Hospital_List.aspx.cs" EnableEventValidation="true"
    Inherits="SysManage_Hospital_List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="../js/App.js" type="text/javascript"></script>

    <script type="text/javascript" src="../js/dialog/ymPrompt.js"></script>

    <link rel="stylesheet" type="text/css" href="../js/dialog/skin/qq/ymPrompt.css" />
    <link rel="stylesheet" type="text/css" href="../js/contextmenu/menu.css" />

    <script type="text/javascript" src="../js/contextmenu/menu.js"></script>
    
    <script type='text/javascript' src='../js/dragtb/resizable-tables.js'></script>

   

</head>
<body>
    <form id="form1" runat="server">
    <center>
        <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td align="center" style="height: 10px">
                </td>
            </tr>
            <tr>
                <td align="center" class="title">
                    医院列表
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
                &nbsp;<asp:Button ID="btnQurey" CssClass="btn" runat="server" Text=" 查 询 " />
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="gridList" runat="server" AllowPaging="True" OnDataBound="gridList_DataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="全选">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkItem" onclick="this.checked=!this.checked;" runat="server" />
                            </ItemTemplate>
                            <HeaderTemplate>
                                <asp:CheckBox ID="chkAll" runat="server" onclick="CheckAll(this,'gridList');" />
                            </HeaderTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                           <HeaderTemplate>
                              序号
                           </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex+1 %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerTemplate>
                        <table align="right">
                            <tr>
                                <td align="right">
                                    总共<asp:Label ID="lblTotalPage" runat="server" Text="0"></asp:Label>条记录，每<%# ((GridView)Container.Parent.Parent).Rows.Count%>
                                    条/页 ，第<asp:Label ID="lblcurPage" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex+1      %>'></asp:Label>页/共<asp:Label
                                        ID="lblPageCount" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount %>'></asp:Label>页
                                    <asp:LinkButton ID="cmdFirstPage" runat="server" CommandName="Page" CommandArgument="First"
                                        Enabled="<%# ((GridView)Container.Parent.Parent).PageIndex!=0 %>">首页</asp:LinkButton>
                                    <asp:LinkButton ID="cmdPreview" runat="server" CommandArgument="Prev" CommandName="Page"
                                        Enabled="<%# ((GridView)Container.Parent.Parent).PageIndex!=0 %>">上一页</asp:LinkButton>
                                    <asp:LinkButton ID="cmdNext" runat="server" CommandName="Page" CommandArgument="Next"
                                        Enabled="<%# ((GridView)Container.Parent.Parent).PageIndex!=((GridView)Container.Parent.Parent).PageCount-1 %>">下一页</asp:LinkButton>
                                    <asp:LinkButton ID="cmdLastPage" runat="server" CommandArgument="Last" CommandName="Page"
                                        Enabled="<%# ((GridView)Container.Parent.Parent).PageIndex!=((GridView)Container.Parent.Parent).PageCount-1 %>">尾页</asp:LinkButton>
                                    <%--      转<asp:TextBox ID="txtGoPage" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex+1 %>'
       Width="32px"></asp:TextBox>--%>
                                    跳转到<asp:DropDownList ID="ddlPage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPage_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    页
                                </td>
                            </tr>
                        </table>
                    </PagerTemplate>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right">
            </td>
        </tr>
    </table>
    <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <table border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <form action="2_1_add.htm" target="imain">
                        <td width="80" align="center">
                            <input name="Submit2" type="submit" class="btn" value=" 新 增 " />
                        </td>
                        </form>
                        <form>
                        <td width="80" align="center">
                            <input name="Submit2" type="submit" class="btn" value=" 编 辑 " />
                        </td>
                        </form>
                        <td width="80" align="center">
                            <asp:Button ID="btnDel" OnClientClick="return ymPrompt.confirmInfo('确认删除选择的数据？',null,null,'警告提示',function (tp){if(tp=='ok'){__doPostBack('btnDel','');}})"
                                runat="server" Text=" 删 除 " class="btn" OnClick="btnDel_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <asp:ObjectDataSource ID="odsData" runat="server" SelectMethod="getTestData" TypeName="FlowControl">
    </asp:ObjectDataSource>
    </form>
    <div id="cmenu" style="position: absolute; display: none; top: 0px; left: 0px; width: 100px;
        z-index: 10000;">
        <ul>
            <li id="open">打开</li>
            <li id="edit">编辑</li>
            <li id="del" class="disabled">删除</li>
            <li class="separator"></li>
            <li>新建</li>
            <li id="rename">重命名</li>
            <li class="separator"></li>
            <li id="prop">属性</li>
            <li class="separator"></li>
            <li id="fresh">刷新</li>
        </ul>
    </div>

    <script type="text/javascript">

        var cmenu = new contextMenu(
    {
        contextMenuId: "cmenu",
        targetElement: "contextTD"
    },
	 	{
	 	    bindings: {
	 	        'open': function(o) { alert("打开 " + o.id); },
	 	        'edit': function(o) { alert("编辑 " + o.childNodes[0].innerHTML); },
	 	        'del': function(o) { alert("删除 " + o.id); },
	 	        'rename': function(o) { alert("重命名 " + o.id); },
	 	        'prop': function() { alert("查看属性"); },
	 	        'fresh': function() { window.location = window.location; }
	 	    }
	 	}
 	);

        cmenu.buildContextMenu();
    </script>
   <script type="text/javascript">
       function document.onkeydown() {
           var e = event.srcElement;
           if (event.keyCode == 13) {
               document.getElementById("btnQurey").click();
               return false;
           }
       }

       var tb = new ColumnDrag('gridList');
       
    </script>
    <script type="text/javascript">

        function doRow(obj, row) {
            //             var chk = obj.childNodes[0].childNodes[0];
            //    
            //             if (chk.checked) {
            //                 chk.checked = false;
            //                 obj.className = 'table4';
            //             }
            //             else {
            //                 chk.checked = true;
            //                 obj.className = 'table3';
            //             }
        }
        function doCell(obj, row, col) {
            if (col != 0) {
                ymPrompt.alert('您点击第' + row + '的第' + col + '列', null, null, '提示信息', null);
            }
            else {
                var isIE =window.ActiveXObject ? true : false;
                var chk = isIE ? obj.childNodes[0] : obj.childNodes[1];

                if (chk.checked) {
                    chk.checked = false;
                    //obj.className = 'table4';
                }
                else {
                    chk.checked = true;
                    //obj.className = 'table3';
                }
            }
        }
        function selectRow(obj, msg) {
            var item = obj.name.split("$");
            var id = item[item.length - 1];
            var chkid = obj.id.replace(id, '') + "chkItem";


            if (typeof (msg) == 'undefined') {
                document.getElementById(chkid).checked = va;
            }
            else {
                if (obj.value == '') {
                    alert(msg);
                    obj.focus();
                    document.getElementById(chkid).checked = false;
                }
                else {
                    document.getElementById(chkid).checked = true;
                }
            }
        }
    </script>

</body>
</html>
