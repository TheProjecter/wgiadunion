//coding=utf-8
$(function(){
    $(":checkbox").not(".nocheck").attr("checked",true);//解决火狐等记住页面状态的问题，因为下面用的是toggle
    $(".nocheck").each(function(){var v=$(this).val(); $(".col"+v).addClass("hide");}); //把初始没有勾上的项目对应的列隐去
    setTableWidth();
    $(":checkbox").click(function(){
        var obj=$(this);
        var i=$("#fixreport").val()==1?"3":"4";
        if(!(obj.attr("checked"))&&$(":checkbox").filter(":checked").length<i){
            alert("请至少保留"+(i==3?"三":"四")+"列数据显示");
            obj.attr("checked",true);
            return;
        }
        var v=obj.val();
        var d="col"+v;
        $("."+d).toggleClass("hide");
        setTableWidth();
    });
});

function setTableWidth(){
    var thctr=$(":checkbox").filter(":checked").length;
    if(thctr<=5) $(".listtable").css({width:580});
    else if(thctr<=9) $(".listtable").css({width:"100%"});
    else $(".listtable").css({width:thctr*75});
}