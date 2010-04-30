<%@ Page Language="C#" MasterPageFile="~/Templet/memberMaster.master" AutoEventWireup="true" CodeFile="applyfee.aspx.cs" Inherits="member_applyfee" Title="中商购物|网站联盟|用户中心" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="/Css/mem_modify.css" rel="stylesheet" type="text/css" />
    <link href="/Css/step.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #opdiv .oplist{ margin:15px 20px;}
        #opdiv li span{ font-size:12px}
        #opdiv .step01 li{ width:150px;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<!--内容区样式开始-->
	<div class="conthead"><span>您现在的位置：首页&nbsp;>&nbsp;财务管理&nbsp;>&nbsp;申请佣金</span>联盟会员控制面板</div>
	<div class="ctbody_cnt" id="listdiv">
		<h3>申请佣金</h3>
		<div>
		<p class="tabArea"><span>佣金信息</span></p>
		<div id="opdiv">
		   <p class="oplist">您可申请支付的佣金是：&nbsp;<asp:Label ID="lblmoney" runat="server" style="color:Red; font-weight:600"></asp:Label>&nbsp;元</p>
		   <p class="oplist"><asp:Label ID="lblapply" runat="server" Visible="false"></asp:Label>
		       <asp:Button ID="btnapply" runat="server" CssClass="yelbtn" Text="申请" Visible="false" OnClick="applyclick" />
		       <asp:TextBox ID="txtapplyamount" runat="server" Columns="7" MaxLength="9" Text="100.00" style="text-align:right;" Visible="false"></asp:TextBox>
		      <asp:Label ID="lblfixtxt" runat="server" Text="元&nbsp;&nbsp;附言：" Visible="false"></asp:Label>
		       <asp:TextBox ID="txtapplyremark" runat="server" style="width:300px;" Visible="false"></asp:TextBox>
		    </p>
		    <div class="oplist">
		        <asp:HiddenField ID="hidstep" runat="server" />
		        流程图示：
		        <br /><br />
		        <ul class="step step01">
		            <li step="-1"><span>佣金不到申请条件</span></li>
		            <li step="0"><span>请提交佣金申请</span></li>
		            <li step="1"><span>请按<a href="applyinfo.aspx">资料格式</a>递交资料</span></li>
		            <li step="2" class="last"><span>已收到资料，请耐心等待审核</span></li>
		        </ul>
		        <!-- [if IE 6]>
		        <br clear="all" />
		        <![endif] -->
		        <ul class="step">
		            <li step="3"><span>审核通过，等待打款</span></li>
		            <li step="4" class="last"><span>佣金已经支付，请查询账户</span></li>
		        </ul>
		        <!-- [if IE 6]>
		        <br clear="all" />
		        <![endif] -->
		        <ul class="step">
		            <li step="5" class="last"><span>审核未通过</span></li>
		        </ul>
		        <!-- [if IE 6]>
		        <br clear="all" />
		        <![endif] -->
		    </div>
		   
		</div>
		<p class="tabArea"><span>佣金概览</span></p>
		<center><span>请选择查询的年份：</span><asp:DropDownList ID="ddlyear" runat="server"></asp:DropDownList>&nbsp;&nbsp;<a href="feelist.aspx">查看详细</a></center><p>&nbsp;</p>
		    <table class="listtable">
		        <tr><th>日期</th><th>产生</th><th>支付</th><th>余额</th></tr>
		        <tr><td>2010年1月</td><td>50.00</td><td>0.00</td><td>50.00</td></tr>
		        <tr><td>2010年4月</td><td>2.50</td><td>0.00</td><td>2.50</td></tr>
		        <tr><td>2010年5月</td><td>10.00</td><td>0.00</td><td>10.00</td></tr>
		        <tr><td>合计</td><td>62.50元</td><td>0元</td><td>62.50元</td></tr>
		    </table>
		    
		<p class="tabArea"><span>申领详情</span></p>
		    <table class="listtable">
		        <tr><th>申请日期</th><th>支付日期</th><th>开户名</th><th>银行名称</th><th>银行账号</th><th>申请金额</th></tr>
		        <tr><td>2010/3/5</td><td>2010/4/22</td><td>张三</td><td>中国工商银行</td><td>3429857432853021</td><td>120.00元</td></tr>
		    </table>
		
        </div>
	</div>
	<!--内容区样式结束-->

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="jscode" Runat="Server">
<script type="text/javascript">
    $(function(){
        var step=$("#ctl00_ContentPlaceHolder1_hidstep").val();
        var obj=$("li:[step='"+step+"']");
        if(step==2||step==4||step==5){
            obj.addClass("last-current");
        }else{
            obj.addClass("current");
        }
    });
</script>
</asp:Content>

