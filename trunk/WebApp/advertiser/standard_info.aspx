﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="standard_info.aspx.cs" Inherits="advertiser_standard_add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" rev="stylesheet" href="css/style.css" type="text/css" media="all" />

    <script src="../Js/jquery-1.4.min.js" type="text/javascript"></script>
    <script src="../Js/formValidator.js" type="text/javascript"></script>    
    <script src="../Js/formValidatorRegex.js" type="text/javascript"></script>
    <script src="../Js/ca/WdatePicker.js" type="text/javascript"></script>
     <script type="text/javascript">
           
             $(document).ready(function() {
                 $.formValidator.initConfig({ formid: "form1", autoSubmit: true, onsuccess: function() {  } });
                 $("#txtpay").formValidator({ onshow: "(必填)", onfocus: "输入支付佣金的比例！", onerror: "支付比例不能为空！" }).inputValidator({ min: 2, onerror: "文字最少为2个字符！", max: 10, onerror: "文字不能超过10个字！" });
                 $("#txtconf").formValidator({ onshow: "(必填)", onfocus: "输入支付佣金的说明！", onerror: "请确认支付佣金不能为空！" }).inputValidator({ min: 5, onerror: "文字最少为5个字符！", max: 30, onerror: "文字不能超过30个字！" });
                 $("#txtbegin").focus(function() { WdatePicker({ doubleCalendar: true,readOnly:true,dateFmt: 'yyyy-MM-dd', minDate: '%y-%M-%d', oncleared: function() { $(this).blur(); }, onpicked: function() { $(this).blur(); } }) }).formValidator({ onshow: "(必选)", onfocus: "请选择佣金支付的有效截止时间", oncorrect: "你输入的日期合法" }).inputValidator({ min: "2000-01-01", max: "2020-01-01", type: "time", onerror: "日期必须在\"2000-01-01\"和\"2020-01-01\"之间" });
                 
             });
     </script>
           
</head>
<body class="ContentBody">
    <form id="form1" runat="server">
    <div class="MainDiv">
<table width="99%" border="0" cellpadding="0" cellspacing="0" class="CContent">
  <tr>
      <th class="tablestyle_title" >佣金支付标准管理</th>
  </tr>
  <tr>
    <td class="CPanel">
		
		<table border="0" cellpadding="0" cellspacing="0" style="width:100%">
		<tr><td align="left">
		
		&nbsp; <asp:Button ID="btnAdd" runat="server" Text="保存" class="right-button02" onclick="btnSave_Click" />
			&nbsp; 
            <input id="Button1" type="button" value="返 回" class="right-button02" onclick="location.href='standard_list.aspx';" />
		</td></tr>

		<TR>
			<TD width="100%">
			   <p>
                   <asp:Label ID="lblmsg" runat="server" style="color:Red"></asp:Label></p>
                   	<fieldset style="height:100%;">
				<legend>佣金标准内容</legend>
				<ul class="adinfo">
				 <li><span class="rowTitle">支付比例：</span><asp:TextBox ID="txtpay" runat="server"></asp:TextBox><span id="txtpayTip"></span></li>
				  <li><span class="rowTitle">佣金说明：</span><asp:TextBox ID="txtconf" runat="server" Width="400px"></asp:TextBox><span id="txtconfTip"></span></li>
				  <li><span class="rowTitle">截止日期：</span><asp:TextBox ID="txtbegin" runat="server"></asp:TextBox><span id="txtbeginTip"></span></li>
				 
				</ul>
				</fieldset>
				<br />
			
			
				</TD>
		</TR>
		
		</TABLE>
	
	
	 </td>
  </tr>
		</TABLE>
	
	
	 </td>
  </tr>
  
  
  
  
  </table>

</div>
   
    </form>
</body>
</html>
