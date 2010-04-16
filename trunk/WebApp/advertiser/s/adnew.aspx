<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adnew.aspx.cs" Inherits="manage_s_adnew" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
<link rel="stylesheet" rev="stylesheet" href="../css/style.css" type="text/css" media="all" />

    <script src="../../Js/jquery-1.4.min.js" type="text/javascript"></script>
    <script src="../../Js/formValidator.js" type="text/javascript"></script>    
    <script src="../../Js/formValidatorRegex.js" type="text/javascript"></script>
    <script src="../../Js/ca/WdatePicker.js" type="text/javascript"></script>
         <script type="text/javascript">
             var urlRegex = /^((https|http|ftp|rtsp|mms)?:\/\/)?(([0-9a-z_!~\*\'\(\)\.&\=\+$\%-]+: )?[0-9a-z_\!~\*\'\(\)\.&=\+\$\%-]+\@)?(([0-9]{1,3}\.){3}[0-9]{1,3}|([0-9a-z_\!\~\*\'\(\)-]+\.)*([0-9a-z][0-9a-z-]{0,61})?[0-9a-z]\.[a-z]{2,6})(:[0-9]{1,4})?((\/?)|(\/[0-9a-z_\!\~\*\'\(\)\.;\?:@&=\+\$\,\%\#-]+)+\/?)$/;

             $(document).ready(function() {
                 $.formValidator.initConfig({ formid: "form1", autoSubmit: true, onsuccess: function() {  } });
                 $("#txtTilte").formValidator({ onshow: "(必填)", onfocus: "输入显示的广告文字！", onerror: "文字不能为空,请确认！" }).inputValidator({ min: 1, onerror: "文字最少为5个字符！", max: 30, onerror: "文字不能超过30个字！" });
                 $("#txtUrl").formValidator({ onshow: "(必选)", onfocus: "填写广告推广网址，以http://开头！" }).inputValidator({ min: 1, onerror: "请输入广告推广网址！" }).regexValidator({ regexp: urlRegex, onerror: "请输入正确的网址格式！" });
                 $("#txtPicUrl").formValidator({ onshow: "(必选)", onfocus: "填写广告推广网址，以http://开头！" }).inputValidator({ min: 1, onerror: "请输入广告推广网址！" }).regexValidator({ regexp: urlRegex, onerror: "请输入正确的网址格式！" });
                 $("#txtSwfUrl").formValidator({ onshow: "(必选)", onfocus: "填写广告推广网址，以http://开头！" }).inputValidator({ min: 1, onerror: "请输入广告推广网址！" }).regexValidator({ regexp: urlRegex, onerror: "请输入正确的网址格式！" });
                 $("#txtbegin").focus(function() { WdatePicker({ doubleCalendar: true, readOnly: true, dateFmt: 'yyyy-MM-dd', minDate: '%y-%M-%d', oncleared: function() { $(this).blur(); }, onpicked: function() { $(this).blur(); } }) }).formValidator({ onshow: "(必选)", onfocus: "请选择广告开始时间", oncorrect: "你输入的日期合法" }).inputValidator({ min: "2000-01-01", max: "2020-01-01", type: "time", onerror: "日期必须在\"2000-01-01\"和\"2020-01-01\"之间" });
                 $("#txtend").focus(function() { WdatePicker({ doubleCalendar: true, readOnly: true, dateFmt: 'yyyy-MM-dd', minDate: '%y-%M-%d', oncleared: function() { $(this).blur(); }, onpicked: function() { $(this).blur(); } }) }).formValidator({ onshow: "(必选)", onfocus: "请选择广告截止时间", oncorrect: "你输入的日期合法" }).inputValidator({ min: "2000-01-01", max: "2020-01-01", type: "time", onerror: "日期必须在\"2000-01-01\"和\"2020-01-01\"之间" });
                 $("#txtname").formValidator({ onshow: "(必填)", onfocus: "输入广告关键字描述，例如手机！" }).inputValidator({ min: 1, onerror: "关键字描述不能为空！", max: 10, onerror: "描述不能超过10个字！" });

                 $("#txtPicHeight").formValidator({ tipid: "twhTip", onshow: "(必选)", onfocus: "请输入图片高度！" }).inputValidator({ min: 1, onerror: "请输入图片高度！" });
                 $("#txtPicWidth").formValidator({ tipid: "twhTip", onshow: "(必选)", onfocus: "请输入图片宽度！" }).inputValidator({ min: 1, onerror: "请输入图片宽度！" });

                 $("#txtSw").formValidator({ tipid: "whTip", onshow: "(必选)", onfocus: "请输入图片高度！" }).inputValidator({ min: 1, onerror: "请输入图片高度！" });
                 $("#txtSh").formValidator({ tipid: "whTip", onshow: "(必选)", onfocus: "请输入图片宽度！" }).inputValidator({ min: 1, onerror: "请输入图片宽度！" });

                 $("#txtRemotePic").formValidator({ tipid: "fuploadTip", onshow: "(必选)", onfocus: "输入图片来源地址，以http://开头！" }).inputValidator({ min: 1, onerror: "请填写图片来源地址！" }).regexValidator({ regexp: urlRegex, onerror: "请输入正确的网址格式！" });
                 $("#fupload").formValidator({ tipid: "fuploadTip", onshow: "(必填)", onfocus: "选择上传图片的路径！" }).inputValidator({ min: 1, onerror: "请选择上传图片的路径！" });

                 $("#txtRemoteSwf").formValidator({ tipid: "fupladswfTip", onshow: "(必选)", onfocus: "输入FLASH来源地址，以http://开头！" }).inputValidator({ min: 1, onerror: "请填写FLASH来源地址！" }).regexValidator({ regexp: urlRegex, onerror: "请输入正确的网址格式！" });
                 $("#fupladswf").formValidator({ tipid: "fupladswfTip", onshow: "(必填)", onfocus: "选择上传FLASH的路径！" }).inputValidator({ min: 1, onerror: "请选择上传FLASH的路径！" });
             });

             function ajaxPost() {
                  __doPostBack("btnAdd", "");
                // document.getElementById("btnAdd").click();
                 //var f = $("#form1");
                 //$("#btnAdd").click();
                // $.post(f.attr("action"), f.serialize(), function(data) {

                     //alert('aa');
                    
                 //});
              }
              function showInput(val) {
                  var pic = document.getElementById("txtRemotePic");
                  var fup = document.getElementById("fupload");
                  
                  if (val == "1") {
                      
                      pic.style.display = '';
                      fup.style.display = 'none';
               ;
                  }
                  else {
                      pic.style.display = 'none';
                      fup.style.display = '';
                      
                  }
              }
              function showFlashInput(val) {
                  if (val == "1") {
                      document.getElementById("txtRemoteSwf").style.display = '';
                      document.getElementById("fupladswf").style.display = 'none';
                 
                  }
                  else {
                      document.getElementById("txtRemoteSwf").style.display = 'none';
                      document.getElementById("fupladswf").style.display = '';
                  }
              }

              function chkupload() {


                  if (document.getElementById("ddlChange").value == "2") {
                      if (document.getElementById("fupload").vlaue == '') {
                          alert('请选择本地图片！');
                          return false;
                      }
                  }
                  
                  return true;
              }
              

</script>
</head>
<body class="ContentBody">
    <form id="form1" runat="server">
    <div class="MainDiv">
<table width="99%" border="0" cellpadding="0" cellspacing="0" class="CContent">
  <tr>
      <th class="tablestyle_title" >新加投放广告内容</th>
  </tr>
  <tr>
    <td class="CPanel">
		
		<table border="0" cellpadding="0" cellspacing="0" style="width:100%">
		<tr><td align="left">
		选择付费类型：
            <asp:DropDownList ID="ddlPayType" runat="server">
            </asp:DropDownList>&nbsp;
		选择显示类型：<asp:DropDownList ID="ddlDisplayType" runat="server" 
             onselectedindexchanged="ddlDisplayType_SelectedIndexChanged" AutoPostBack="True">
      </asp:DropDownList> <asp:Button ID="btnAdd" runat="server" Text="保存" class="button" 
                onclick="btnAdd_Click" />
			
		</td></tr>

		<TR>
			<TD width="100%">
			   <p>
                   <asp:Label ID="lblmsg" runat="server" style="color:Red"></asp:Label></p>
                   	<fieldset style="height:100%;">
				<legend>广告参数</legend>
				<ul class="adinfo">
				 <li><span class="rowTitle">关键描述：</span><asp:TextBox ID="txtname" runat="server" Width="200px"></asp:TextBox><span id="txtnameTip"></span></li>
				  <li><span class="rowTitle">开始日期：</span><asp:TextBox ID="txtbegin" runat="server"></asp:TextBox><span id="txtbeginTip"></span></li>
				  <li><span class="rowTitle">截止日期：</span><asp:TextBox ID="txtend" runat="server"></asp:TextBox><span id="txtendTip"></span></li>
				 
				</ul>
				</fieldset>
				<br />
				<fieldset style="height:100%;">
				<legend>广告内容</legend>
			
					<asp:MultiView ID="mvAdvertises" runat="server" ActiveViewIndex="0">
        <asp:View ID="viewText" runat="server">
            <ul class="adinfo">
             <li><span class="rowTitle">广告文字：</span><asp:TextBox ID="txtTilte" runat="server" Width="200px"></asp:TextBox><span id="txtTilteTip"></span></li>
             <li><span class="rowTitle">推广地址：</span><asp:TextBox ID="txtUrl" runat="server" Width="400px">http://</asp:TextBox><span id="txtUrlTip"></span></li>
            </ul>
            <p>
                </p>
        </asp:View>
        <asp:View ID="viewPic" runat="server">
            <ul class="adinfo">
             <li><span class="rowTitle">图片来源：</span><asp:DropDownList ID="ddlChange" 
                     runat="server"　onchange="showInput(this.value);">
                  </asp:DropDownList>&nbsp;&nbsp;外部网址一般为您自己网站上的广告图片，如更新内容请保持文件名称一样！
                  
                  </li>
             <li><span class="rowTitle">图片地址：</span><asp:TextBox ID="txtRemotePic" runat="server" Width="400px" Text="http://"></asp:TextBox><asp:FileUpload ID="fupload" runat="server" 
                     Width="400px" style="display:none"/><span id="fuploadTip"></span></li>
             <li><span class="rowTitle">推广地址：</span><asp:TextBox ID="txtPicUrl" runat="server" 
                     Width="400px"  Text="http://"></asp:TextBox><span id="txtPicUrlTip"></span></li>
             <li><span class="rowTitle">图片高：</span><asp:TextBox ID="txtPicHeight" runat="server" Width="40px"></asp:TextBox> px <span>宽：</span><asp:TextBox ID="txtPicWidth" runat="server" Width="40px"></asp:TextBox> px　<span id="twhTip"></span></li>
            </ul>
        </asp:View>
         <asp:View ID="viewFlash" runat="server">
            <ul class="adinfo">
            <li><span class="rowTitle">FLASH来源：</span><asp:DropDownList ID="ddlFlash" runat="server"　onchange="showFlashInput(this.value);">
                  </asp:DropDownList>&nbsp;&nbsp;外部网址一般为您自己网站上的广告图片，如更新内容请保持文件名称一样！
                  
                  </li>
             <li><span class="rowTitle">FLASH地址：</span><asp:TextBox ID="txtRemoteSwf" runat="server" Width="400px"  Text="http://"/><asp:FileUpload ID="fupladswf" runat="server" 
                     Width="400px" style="display:none" /><span id="fupladswfTip"></span></li>
             <li><span class="rowTitle">推广地址：</span><asp:TextBox ID="txtSwfUrl" runat="server" 
                     Width="400px"  Text="http://"></asp:TextBox><span id="txtSwfUrlTip"></span></li>
             <li><span class="rowTitle">FLASH 高：</span><asp:TextBox ID="txtSw" runat="server" Width="40px"></asp:TextBox> px <span>宽：</span><asp:TextBox ID="txtSh" runat="server" Width="40px"></asp:TextBox> px <span id="whTip"></span></li>
            </ul>
        </asp:View>
    </asp:MultiView>
			
			
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
