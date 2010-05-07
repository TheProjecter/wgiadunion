<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pydemo.aspx.cs" Inherits="pydemo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>

    <script src="Js/jquery-1.4.min.js" type="text/javascript"></script>
    <style type="text/css">
        *{margin:0; padding:0;}
        body{font-size:12px;}
        #searchwrap{position:relative;}
        #txtsearch{border:1px gray solid; width:400px; height:24px; line-height:24px;}
        #tips{ border:1px gray solid; width:400px; position:absolute; top:46px; left:0; display:none;}
        #tips p{ line-height:20px; *background:#fff; padding:1px 3px; cursor:default;}
        #tips p.highlight{ background:#22f; color:#eee;}
    </style>
</head>
<body>
<form id="form1" runat="server">
<%--<a href="http://localhost:13679/click/click.aspx?shopid=1&adid=30&siteid=4&userid=1&paytype=1&adtype=1" target="_blank">adfdasf</a><img src='http://localhost:13679/click/showCtr.aspx?shopid=1&adid=30&siteid=4&userid=1&paytype=1&adtype=1' alt='' style='display:none;' />
<br />
<a href="http://localhost:13679/click/click.aspx?shopid=1&adid=33&siteid=16&userid=12&paytype=1&adtype=2" target="_blank"><img src="http://img.alimama.cn/adbrand/adboard/picture/2010-04-13/112970490001100413200239.gif" alt="" style="border:none; width:300px; height:250px" /></a><img src='http://localhost:13679/click/showCtr.aspx?shopid=1&adid=33&siteid=16&userid=12&paytype=1&adtype=2' alt='' style='display:none;' />--%>
<asp:Button ID="btnpy" runat="server" OnClick="py" Text="生成用户" />
<asp:Repeater ID="gv" runat="server"><ItemTemplate><%# Eval("name") %>:<%# Eval("value") %></ItemTemplate><SeparatorTemplate>&nbsp;|&nbsp;</SeparatorTemplate></asp:Repeater>
<div id="searchwrap" style="margin-left:400px;">
    <input type="radio" name="type" id="getpy" value="1" />生成拼音
    <input type="radio" name="type" id="getchar" value="2" checked="checked" />智能提示
    <input type="hidden" id="hidlastquery" value="" />
    <br />
    <input type="text" id="txtsearch" autocomplete="off" />
    <div id="tips">
    </div>
    <div class="a01" style="background:red; color:#fff; font-size:2em; padding:20px 10px; width:120px; position:absolute; top:20; left:-380px; cursor:default; font-weight:800">animation</div>
</div>
<div id="test"></div>
</form>
</body>
<script type="text/javascript" src="/Js/jquery.easing.1.3.js"></script>
<script type="text/javascript">
    $(function(){
    $(".a01").live("click",function(){$(this).animate({top:400,left:200},4000,"easeOutBounce").removeClass().addClass("a02");});
    $(".a02").live("click",function(){$(this).animate({top:20,left:-380},4000,"easeOutBounce").removeClass().addClass("a01");});
        //$("*").keyup(function(event){$("#test").html(event.keyCode);});
        //40=down,38=up,8=backspace, 37=left, 39=right, 32=space, 13=enter
        //a-z:65-90, 0-1:48-57, ;';'=186,"'"=222
        var nohide=false;//标识智能提示是否隐藏
        $("#hidlastquery").val("");
        $("#tips p").live("mouseover",function(){
            $(".highlight").removeClass("highlight");
            $(this).addClass("highlight");
            nohide=true;
        });
        $("#tips p").live("mouseout",function(){
            $(this).removeClass("highlight");
            nohide=false;
        });
        $("#tips p").live("click",function(){
            var v=$(this).html();
            $("#txtsearch").val(v);
            nohide=false;
            $("#tips").hide();
        });
        $("#txtsearch").keydown(function(event){
            var k=event.keyCode;
            if($("#tips").is(":hidden")){
                if(k==40){ getSuggest($("#txtsearch")); return;}
                else return;
            }
            //todo:加上向下键的时候强制ajax请求
            if(k==40){
                var o=$(".highlight");
                var v;
                if(o.length==0){
                    v=$("#tips p:first").addClass("highlight").html();
                }else{
                    v=o.eq(0).removeClass("highlight").next("p").addClass("highlight").html();
                    if(v==null){
                        v=$("#tips p:first").addClass("highlight").html();
                    }
                }
                $("#txtsearch").val(v);
            }else if(k==38){
                var o=$(".highlight");
                var v;
                if(o.length==0){
                    v=$("#tips p:last").addClass("highlight").html();
                }else{
                    v=o.filter(":last").removeClass("highlight").prev("p").addClass("highlight").html();
                    if(v==null){
                        v=$("#tips p:last").addClass("highlight").html();
                    }
                }
                $("#txtsearch").val(v);
            }else{}
            
        });
        $("#txtsearch").bind("keyup",function(event){
            var k=event.keyCode;
            if((k>=65&&k<=90)||k==8||k==32||(k>=48&&k<=57)||k==186||k==222){
                getSuggest(this);
            };
        });
        $("#txtsearch").blur(function(){ if(!nohide) $("#tips").hide();});
    });
   //m=setInterval("getSuggest($('#txtsearch'))",200)
   
    function getSuggest(o,k){
        var obj=$(o);
        var v=obj.val();
        var last=$("#hidlastquery");
        v=v.replace(/[;', ]/g,"");
        if(v!=""){
            var t=$("#tips");
            if(v==last.val()){
                if(t.children("p").length>0){ t.show(); return;}
                else return;
            }
            last.val(v);
            var url="";
            if($(":radio:checked").val()==1)
                url="login.aspx?act=getpy&v="+v+"&t="+new Date().getMilliseconds();
            else
                url="login.aspx?act=ajaxpy&v="+v+"&t="+new Date().getMilliseconds();
            $.get(encodeURI(url),function(data){
                if(data!=""){
                    var names=data.split(',');
                    var l=names.length;
                    t.empty();
                    for(var i=0; i<l; i++){
                        t.append("<p>"+names[i]+"</p>");
                    }
                    t.show();
                }else{
                    t.hide();
                }
            });
        }else{$("#tips").hide();}
    }
</script>
</html>
