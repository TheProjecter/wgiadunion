<%@ Page Language="C#" AutoEventWireup="true" CodeFile="left.aspx.cs" Inherits="advertiser_left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
<!--
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
	background-image: url(images/left.gif);
}
-->
</style>
<link href="css/css.css" rel="stylesheet" type="text/css" />
<SCRIPT language=JavaScript>
function tupian(idt){
    var nametu="xiaotu"+idt;
    var tp = document.getElementById(nametu);
    tp.src="images/ico05.gif";//图片ico04为白色的正方形
	
	for(var i=1;i<30;i++)
	{
	  
	  var nametu2="xiaotu"+i;
	  if(i!=idt*1)
	  {
	    var tp2=document.getElementById('xiaotu'+i);
		if(tp2!=undefined)
	    {tp2.src="images/ico06.gif";}//图片ico06为蓝色的正方形
	  }
	}
}

function list(idstr){
	var name1="subtree"+idstr;
	var name2 = "img" + idstr;
	var objectobj=document.getElementById(name1);
	var imgobj = document.getElementById(name2);
		
	//alert(imgobj);
	
	if(objectobj.style.display=="none"){
		for(i=1;i<10;i++){
			var name3="img"+i;
			var name="subtree"+i;
			var o = document.getElementById(name);
			if(o!=undefined){
				o.style.display="none";
				var image = document.getElementById(name3);
				//alert(image);
				image.src="images/ico04.gif";
			}
		}
		objectobj.style.display="";
		imgobj.src="images/ico03.gif";
	}
	else{
		objectobj.style.display="none";
		imgobj.src="images/ico04.gif";
	}
}

</SCRIPT>

</head>
<body>
    <form id="form1" runat="server">
  <table width="198" border="0" cellpadding="0" cellspacing="0" class="left-table01">
  <tr>
    <TD>
		<table width="100%" border="0" cellpadding="0" cellspacing="0">
		  <tr>
			<td width="207" height="55" background="images/nav01.gif">
				<table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
				  <tr>
					<td width="25%" rowspan="2"><img src="images/ico02.gif" width="35" height="35" /></td>
					<td width="75%" height="22" class="left-font01">您好，<span class="left-font02">king</span></td>
				  </tr>
				  <tr>
					<td height="22" class="left-font01">
						[&nbsp;<a href="#" target="_top" class="left-font01">退出</a>&nbsp;]</td>
				  </tr>
				</table>
			</td>
		  </tr>
		</table>
		
 <!-- 管理系统开始 -->
      <table width="100%" border="0" cellpadding="0" cellspacing="0" class="left-table03">
          <tr>
            <td height="29"><table width="85%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                  <td width="8%"><img name="img5" id="img5" src="images/ico04.gif" width="8" height="11" /></td>
                  <td width="92%"><a href="javascript:" target="mainFrame" class="left-font03" onClick="list('5');">基本参数设置</a></td>
                </tr>
            </table></td>
          </tr>
      </table>

	  <table id="subtree5" style="DISPLAY: none" width="80%" border="0" align="center" cellpadding="0" cellspacing="0" class="left-table02">
        <tr>
          <td width="9%" height="20"><img id="xiaotu13" src="images/ico06.gif" width="8" height="12" /></td>
          <td width="91%"><a href="baseinfo.aspx" target="mainFrame" class="left-font03" onClick="tupian('13');">基本资料信息</a></td>
        </tr>
        <tr>
          <td height="20"><img id="xiaotu14" src="images/ico06.gif" width="8" height="12" /></td>
          <td><a href="adparam.aspx" target="mainFrame" class="left-font03" onClick="tupian('14');">广告参数设置</a></td>
        </tr>
       
      </table>
	  <!-- 管理系统结束-->


		<!--  任务系统开始    -->
		<TABLE width="100%" border="0" cellpadding="0" cellspacing="0" class="left-table03">
          <tr>
            <td height="29">
				<table width="85%" border="0" align="center" cellpadding="0" cellspacing="0">
					<tr>
						<td width="8%"><img name="img8" id="img8" src="images/ico04.gif" width="8" height="11" /></td>
						<td width="92%">
								<a href="javascript:" target="mainFrame" class="left-font03" onClick="list('8');" >广告投放管理</a></td>
					</tr>
				</table>
			</td>
          </tr>		  
        </TABLE>
		<table id="subtree8" style="DISPLAY: none" width="80%" border="0" align="center" cellpadding="0" 
				cellspacing="0" class="left-table02">
				 <tr>
          <td height="20"><img id="xiaotu22" src="images/ico06.gif" width="8" height="12" /></td>
          <td><a href="standard_list.aspx" target="mainFrame" class="left-font03" onClick="tupian('22');">拥金提成管理</a></td>
        </tr>
				<tr>
				  <td width="9%" height="20" ><img id="xiaotu20" src="images/ico06.gif" width="8" height="12" /></td>
				  <td width="91%"><a href="s/adnew.aspx" target="mainFrame" class="left-font03" onClick="tupian('20');">新增投放广告</a></td>
				</tr>
				<tr>
				  <td width="9%" height="21" ><img id="xiaotu21" src="images/ico06.gif" width="8" height="12" /></td>
				  <td width="91%"><a href="s/adlist.aspx" target="mainFrame" class="left-font03" onClick="tupian('21');">查询投放广告</a></td>
				</tr>
      </table>
		<!--  任务系统结束    -->

		 <!--  客户系统开始    -->
	  <table width="100%" border="0" cellpadding="0" cellspacing="0" class="left-table03">
          <tr>
            <td height="29"><table width="85%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                  <td width="8%" height="12"><img name="img2" id="img2" src="images/ico04.gif" width="8" height="11" /></td>
                  <td width="92%"><a href="javascript:" target="mainFrame" class="left-font03" onClick="list('2');" >投放网站管理</a></td>
                </tr>
            </table></td>
          </tr>
      </table>
	  
	  <table id="subtree2" style="DISPLAY: none" width="80%" border="0" align="center" cellpadding="0" cellspacing="0" class="left-table02">
        
		<tr>
          <td width="9%" height="20" ><img id="xiaotu7" src="images/ico06.gif" width="8" height="12" /></td>
          <td width="91%"><a href="siteaudit.aspx" target="mainFrame" class="left-font03" onClick="tupian('7');">已申请网站管理</a></td>
        </tr>
        
      </table>
 <!--  考勤系统开始    -->
	   <table width="100%" border="0" cellpadding="0" cellspacing="0" class="left-table03">
          <tr>
            <td height="29"><table width="85%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                  <td width="8%" height="12"><img name="img4" id="img4" src="images/ico04.gif" width="8" height="11" /></td>
                  <td width="92%"><a href="javascript:" target="mainFrame" class="left-font03" onClick="list('4');" >广告统计分析</a></td>
                </tr>
            </table></td>
          </tr>
      </table>
	  
	  <table id="subtree4" style="DISPLAY: none" width="80%" border="0" align="center" cellpadding="0" cellspacing="0" class="left-table02">
		<tr>
          <td width="9%" height="20" ><img id="xiaotu11" src="images/ico06.gif" width="8" height="12" /></td>
          <td width="91%"><a href="listGongZiType.htm" target="mainFrame" class="left-font03" onClick="tupian('11');">跟踪数据统计</a></td>
        </tr>
	  	<tr>
          <td width="9%" height="20" ><img id="xiaotu12" src="images/ico06.gif" width="8" height="12" /></td>
          <td width="91%"><a href="listMonthYuanGongGongZi.htm" target="mainFrame" class="left-font03" onClick="tupian('12');">广告数据分析</a></td>
        </tr>
      </table>

      <!--  考勤系统结束    -->

	  <!--  客户系统结束    -->
        <TABLE width="100%" border="0" cellpadding="0" cellspacing="0" class="left-table03">
          <tr>
            <td height="29">
				<table width="85%" border="0" align="center" cellpadding="0" cellspacing="0">
					<tr>
						<td width="8%"><img name="img1" id="img1" src="images/ico04.gif" width="8" height="11" /></td>
						<td width="92%">
								<a href="javascript:" target="mainFrame" class="left-font03" onClick="list('1');" >订单销售管理</a></td>
					</tr>
				</table>
			</td>
          </tr>		  
        </TABLE>
		<table id="subtree1" style="DISPLAY: none" width="80%" border="0" align="center" cellpadding="0" 
				cellspacing="0" class="left-table02">
				
				<tr>
				  <td width="9%" height="20" ><img id="xiaotu1" src="images/ico06.gif" width="8" height="12" /></td>
				  <td width="91%"><a href="order_chk.aspx" target="mainFrame" class="left-font03" onClick="tupian('1');">核对成交订单</a></td>
				</tr>
					<tr>
				  <td height="20" ><img id="Img10" src="images/ico06.gif" width="8" height="12" /></td>
				  <td width="91%"><a href="order_invalid.aspx" target="mainFrame" class="left-font03" onClick="tupian('14');">查看无效订单</a></td>
				</tr>
				<tr>
				  <td height="20" ><img id="xiaotu14" src="images/ico06.gif" width="8" height="12" /></td>
				  <td width="91%"><a href="order_valid.aspx" target="mainFrame" class="left-font03" onClick="tupian('14');">查询有效订单</a></td>
				</tr>
				
	
      </table>
		<!--  项目系统结束    -->
		  <!--  人员系统开始    -->
	  <table width="100%" border="0" cellpadding="0" cellspacing="0" class="left-table03">
          <tr>
            <td height="29"><table width="85%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                  <td width="8%" height="12"><img name="img3" id="img3" src="images/ico04.gif" width="8" height="11" /></td>
                  <td width="92%"><a href="javascript:" target="mainFrame" class="left-font03" onClick="list('3');" >财务佣金管理</a></td>
                </tr>
            </table></td>
          </tr>
      </table>
	  
	  <table id="subtree3" style="DISPLAY: none" width="80%" border="0" align="center" cellpadding="0" cellspacing="0" class="left-table02">
        <tr>
          <td width="9%" height="20" ><img id="xiaotu8" src="images/ico06.gif" width="8" height="12" /></td>
          <td width="91%"><a href="listyuangong.html" target="mainFrame" class="left-font03" onClick="tupian('8');">待支付的佣金管理</a></td>
        </tr>
		<tr>
          <td height="20" ><img id="xiaotu9" src="images/ico06.gif" width="8" height="12" /></td>
          <td width="91%"><a href="listzhiwu.htm" target="mainFrame" class="left-font03" onClick="tupian('9');">佣金支付结算报表</a></td>
        </tr>
		<tr>
          <td height="20" ><img id="xiaotu10" src="images/ico06.gif" width="8" height="12" /></td>
          <td width="91%"><a href="listzhiwu.htm" target="mainFrame" class="left-font03" onClick="tupian('10');">在线充值管理</a></td>
        </tr>
      </table>
	
	  <!--  人员系统结束    -->
		<!--  消息系统开始    -->
		<TABLE width="100%" border="0" cellpadding="0" cellspacing="0" class="left-table03">
          <tr>
            <td height="29">
				<table width="85%" border="0" align="center" cellpadding="0" cellspacing="0">
					<tr>
						<td width="8%"><img name="img7" id="img7" src="images/ico04.gif" width="8" height="11" /></td>
						<td width="92%">
								<a href="javascript:" target="mainFrame" class="left-font03" onClick="list('7');" >消息信箱管理</a></td>
					</tr>
				</table>
			</td>
          </tr>		  
        </TABLE>
		<table id="subtree7" style="DISPLAY: none" width="80%" border="0" align="center" cellpadding="0" 
				cellspacing="0" class="left-table02">
				<tr>
				  <td width="9%" height="20" ><img id="xiaotu17" src="images/ico06.gif" width="8" height="12" /></td>
				  <td width="91%">
						<a href="sendxiaoxi.htm" target="mainFrame" class="left-font03" onClick="tupian('17');">发送信息</a></td>
				</tr>
				<tr>
				  <td width="9%" height="20" ><img id="xiaotu18" src="images/ico06.gif" width="8" height="12" /></td>
				  <td width="91%">
					<a href="listtakexiaoxi.htm" target="mainFrame" class="left-font03" onClick="tupian('18');">收件信息查看</a></td>
				</tr>
				<tr>
				  <td width="9%" height="20" ><img id="xiaotu19" src="images/ico06.gif" width="8" height="12" /></td>
				  <td width="91%">
						<a href="listsendxiaoxi.htm" target="mainFrame" class="left-font03" onClick="tupian('19');">发件信息查看
							</a></td>
				</tr>
				<tr>
				  <td width="9%" height="20" ><img id="xiaotu24" src="images/ico06.gif" width="8" height="12" /></td>
				  <td width="91%">
						<a href="listxiaoxi.htm" target="mainFrame" class="left-font03" onClick="tupian('24');">消息信息列表
							</a></td>
				</tr>
      </table>
		<!--  消息系统结束    -->




	 <!--个人信息管理开始-->

		<TABLE width="100%" border="0" cellpadding="0" cellspacing="0" class="left-table03">
          <tr>
            <td height="29">
				<table width="85%" border="0" align="center" cellpadding="0" cellspacing="0">
					<tr>
						<td width="8%"><img name="img9" id="img9" src="images/ico04.gif" width="8" height="11" /></td>
						<td width="92%">
								<a href="javascript:" target="mainFrame" class="left-font03" onClick="list('9');" >登录帐号管理</a></td>
					</tr>
				</table>
			</td>
          </tr>		  
        </TABLE>

		<table id="subtree9" style="DISPLAY: none" width="80%" border="0" align="center" cellpadding="0" 
				cellspacing="0" class="left-table02">
				<tr>
				  <td width="9%" height="23" ><img id="xiaotu23" src="images/ico06.gif" width="8" height="12" /></td>
				  <td width="91%"><a href="changepwd.aspx" target="mainFrame" class="left-font03" 
						onClick="tupian('23');">修改用户密码</a></td>
				</tr>
				<tr>
				  <td height="22" ><img id="xiaotu22" src="images/ico06.gif" width="8" height="12" /></td>
				  <td width="91%"><a href="listgerenxinxi.htm" target="mainFrame" class="left-font03" 
						onClick="tupian('22');">用户操作日志</a></td>
				</tr>
				
      </table>
		<!--  个人信息结束    -->
		
		 <!-- 系统帮助开始 -->
      <table width="100%" border="0" cellpadding="0" cellspacing="0" class="left-table03">
        <tr>
          <td height="29"><table width="85%" border="0" align="center" cellpadding="0" cellspacing="0">
              <tr>
                <td width="8%"><img name="img6" id="img6" src="images/ico04.gif" width="8" height="11" /></td>
                <td width="92%"><a href="mode.html" target="mainFrame" class="left-font03" onClick="list('6');">系统帮助中心</a></td>
              </tr>
          </table></td>
        </tr>
      </table>
	  <table id="subtree6" style="DISPLAY: none" width="80%" border="0" align="center" cellpadding="0" cellspacing="0" class="left-table02">
        <tr>
          <td width="9%" height="20"><img id="xiaotu15" src="images/ico06.gif" width="8" height="12" /></td>
          <td width="91%"><a href="mode.html" target="mainFrame" class="left-font03" onClick="tupian('15');">用户操作手册</a></td>
        </tr>
      
      </table>
	 <!-- 系统帮助结束-->

	  </TD>
  </tr>
  
</table>
    </form>
</body>
</html>
