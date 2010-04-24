//coding=utf-8
$(function(){
    $("#checkall").click(function(){$(".checkthis").attr("checked",true)});
    $("#uncheckall").click(function(){$(".checkthis").attr("checked",false);});
    $("#revercheck").click(function(){$(".checkthis").attr("checked",function(){return !($(this).attr("checked"));});});
    $("#btnop").click(function(){$("#opration").slideToggle();});
    //读取内容及ajax更改状态
    $(".longtxt").click(function(){
        var li=$(this).parents("li");
        var obj=$(this).parent("p").next(".noticecont");
        var id=$(this).prevAll(":checkbox").val();
        $(".noticecont").not(obj).slideUp();obj.slideToggle();
        var status=obj.attr("status");//标识是否在当前页被阅读过
        if(status==0){//没被阅读过，才ajax请求
            var url="/ajaxHandler.aspx?act=getmsgs&id="+id+"&t="+new Date().getMilliseconds();
            $.get(url,function(data){
                obj.find("p").html(data);
                obj.attr("status",1);
                li.removeClass();
            });
        }
        
    });
});

function nocheck(){
    if($(":checkbox").filter(":checked").length==0){alert("您未选择任何条目"); $("#opration").hide(); return false;}
    else return true;
}