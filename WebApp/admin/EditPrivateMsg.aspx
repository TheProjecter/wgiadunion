<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditPrivateMsg.aspx.cs" Inherits="admin_EditPrivateMsg" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <asp:PlaceHolder id="holderheader" runat="server"></asp:PlaceHolder>
    <link href="css/float.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form" runat="server">
    <div id="box"> 
    <div>
    <p>
        <b>公告标题：</b><asp:TextBox ID="txttitle" runat="server" MaxLength="100" Columns="50"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
        <b>接收人：</b><asp:Label ID="lblusername" runat="server"></asp:Label>
        <asp:Button ID="btnsubmit" runat="server" Text="提&nbsp;&nbsp;交" OnClick="sub_click" OnClientClick="return checkVali();" style="margin-left:20px;" />
    </p>
    <p><b>公告内容：</b><span id="lblmsg" style="margin-left:150px; color:Red; font-weight:600;"></span></p>
    <textarea id="txtcontent" name="txtcontent" style="width:730px;height:255px;" runat="server" cols="50" rows="8"></textarea>
    <asp:HiddenField ID="hidnid" runat="server" />
    </div>
            
            
    </div> 
</form>
</body>
<script type="text/javascript" charset="utf-8" src="/js/kindeditor342/kindeditor.js"></script>
<script type="text/javascript">  
  KE.show({id : 'txtcontent',resizeMode:0,skinType:"default",autoOnsubmitMode:false});
</script>
<script type="text/javascript">
    function checkVali(){
        var obj=$("#lblmsg");
        KE.util.setData("txtcontent");
        if($.trim($("#txtcontent").val())==""){
            obj.html("错误：内容不能为空");
            return false;
        }
        if($.trim($("#txttitle").val())==""){
            obj.html("错误：标题不能为空");
            return false;
        }
        return true;
    }
</script>
</html>
