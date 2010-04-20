<%@ Page Language="C#" MasterPageFile="~/Templet/memberMaster.master" AutoEventWireup="true" CodeFile="notices.aspx.cs" Inherits="member_notices" Title="中商购物|网站联盟|用户中心" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        #noticelist{margin:20px auto 10px 10px; list-style:none;}
        #noticelist li:first-child span{font-weight:800; color:#984f08;}
        #noticelist li{border-bottom:dashed 1px #ca3; padding:4px 0; margin-top:5px;}
        #noticelist li p input{ margin-right:20px;;}
        #noticelist li span{color:#333; display:inline-block;}
        #noticelist span.longtxt{width:500px; overflow:hidden; text-overflow:ellipsis; padding-right:5px; cursor:pointer;}
        #noticelist span.longtxt:hover{text-decoration:underline;}
        #noticelist span.shorttxt{width:120px; text-align:right; float:right; margin-top:7px;}
        li div.noticecont{display:none; padding:5px 10px 5px 40px;}
        li div.noticecont p{ padding:5px; background:#fff6f5;}
        li.unread .longtxt{font-weight:600;}
        #opration{ border:1px solid #EF6F03; padding:2px; width:80px; background:rgb(255,191,137); position:absolute; left:161px; top:23px;#left:173px; cursor:pointer; display:none;z-index:1000;}
        #opration p{ padding:3px 5px;color:#333;/*background:url("../Images/btnbg.gif") repeat-x scroll 0 0 transparent;*/}
        #opration p:hover{background:/*url("../Images/btnbg.gif") repeat-x scroll 0 -23px transparent;*/#f83; color:#eee;}
        #btnop{ display:inline-block; height:17px; line-height:17px; width:40px; position:relative; top:-2px; #top:-1px; padding-left:5px; color:#000!important; cursor:default;}
        .downarr{display:inline-block; width:0px; height:0px; border:4px solid rgb(255,191,137); border-top-color:#000; position:absolute; left:32px; top:8px;}
        #btnop:hover .downarr{border-color:rgb(255,133,43); border-top-color:#000;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<!--内容区样式开始-->
	<div class="conthead"><span>您现在的位置：首页&nbsp;>&nbsp;信息中心&nbsp;>&nbsp;网站公告</span>联盟会员控制面板</div>
	<div class="ctbody_cnt">
		<h3>网站公告</h3>
		<div>
		    <ul id="noticelist">
		        <li><p><span class="shorttxt" style="padding-right:30px;">发布时间</span><input type="checkbox" style="visibility:hidden;" /><span>公告内容</span></p></li>
		        <li class="unread">
		            <p><span class="shorttxt">2010-02-28 17:32:55</span><input type="checkbox" class="checkthis" /><span class="longtxt">关于发放1月份关于发放1月份关于发放1月份佣金的补充通知...</span></p>
		            <div class="noticecont"><p>contcontcontcont<br />contcontdljdoisf<br /></p></div>
		        </li>
		        <li>
		            <p><span class="shorttxt">2010-02-28 17:32:55</span><input type="checkbox" class="checkthis" /><span class="longtxt">关于发放1月份关于发放1月份关于发放1月份佣金的补充通知...</span></p>
		            <div class="noticecont"><p>contcontcontcont<br />contcontdljdoisf<br /></p></div>
		        </li>
		        <li>
		            <p><span class="shorttxt">2010-02-28 17:32:55</span><input type="checkbox" class="checkthis" /><span class="longtxt">关于发放1月份关于发放1月份关于发放1月份佣金的补充通知...</span></p>
		            <div class="noticecont"><p>contcontcontcont<br />contcontdljdoisf<br /></p></div>
		        </li>
		        <li>
		            <p><span class="shorttxt">2010-02-28 17:32:55</span><input type="checkbox" class="checkthis" /><span class="longtxt">关于发放1月份关于发放1月份关于发放1月份佣金的补充通知...</span></p>
		            <div class="noticecont"><p>contcontcontcont<br />contcontdljdoisf<br /></p></div>
		        </li>
		        <li>
		            <p><span class="shorttxt">2010-02-28 17:32:55</span><input type="checkbox" class="checkthis" /><span class="longtxt">关于发放1月份关于发放1月份关于发放1月份佣金的补充通知...</span></p>
		            <div class="noticecont"><p>contcontcontcont<br />contcontdljdoisf<br /></p></div>
		        </li>
		        <li>
		            <p><span class="shorttxt">2010-02-28 17:32:55</span><input type="checkbox" class="checkthis" /><span class="longtxt">关于发放1月份关于发放1月份关于发放1月份佣金的补充通知...</span></p>
		            <div class="noticecont"><p>contcontcontcont<br />contcontdljdoisf<br /></p></div>
		        </li>
		        <li>
		            <p><span class="shorttxt">2010-02-28 17:32:55</span><input type="checkbox" class="checkthis" /><span class="longtxt">关于发放1月份关于发放1月份关于发放1月份佣金的补充通知...</span></p>
		            <div class="noticecont"><p>contcontcontcont<br />contcontdljdoisf<br /></p></div>
		        </li>
		        <li style="position:relative; padding-left:35px;">
		            <input type="button" id="checkall" class="yelbtn" value="全选" />
		            <input type="button" id="revercheck" class="yelbtn" value="反选" />
		            <input type="button" id="uncheckall" class="yelbtn" value="全消" />
		            <span id="btnop" class="yelbtn">操作<span class="downarr"></span></span>
		            <div id="opration">
		                <p>删除</p>
		                <p>标记为未读</p>
		                <p>标记为已读</p>
		            </div>
		        </li>
		    </ul>
        </div>
	</div>
	<!--内容区样式结束-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="jscode" Runat="Server">
    <script type="text/javascript">
        $(function(){
            $(".longtxt").click(function(){var obj=$(this).parent("p").next(".noticecont");$(".noticecont").not(obj).slideUp();obj.slideToggle();});
            $("#checkall").click(function(){$(".checkthis").attr("checked",true)});
            $("#uncheckall").click(function(){$(".checkthis").attr("checked",false);});
            $("#revercheck").click(function(){$(".checkthis").attr("checked",function(){return !($(this).attr("checked"));});});
            $("#btnop").click(function(){$("#opration").slideToggle();});
        });
        
        //function openop(){$("#opration").slideToggle();}
    </script>
</asp:Content>

