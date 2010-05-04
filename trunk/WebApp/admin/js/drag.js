//coding=utf-8;
$(function(){
    var ox;
    var oy;
    var flag=false;
    var setWidth=false;
    $("*").mousemove(function(e){
	    if(flag==true){
	        var finalx,finaly,bodyx,bodyy; 
	        finalx=e.clientX-ox>0?e.clientX-ox:0;
	        finaly=e.clientY-oy>0?e.clientY-oy:0;
		    bodyx=window.screen.availWidth-$(".f_outer").width()-22;
		    bodyy=window.screen.availHeight-$(".f_outer").height()-120;
	        if(finalx>bodyx) finalx=bodyx;
	        if(finaly>bodyy) finaly=bodyy;
		    $(".f_outer").css({left:finalx,top:finaly});
	    }
    });
    $(".f_title").mousedown(function(e){
	    ox=e.clientX-$(".f_outer").offset().left;
	    oy=e.clientY-$(".f_outer").offset().top;
	    oy+=$(document).scrollTop();
	    flag=true;
    });

    $(".f_title").mouseup(function(){flag=false;});
});

function closepop(){
	$(".f_outer").hide();
	$(".f_outer h3").html("");
	$("#bgopacity").hide();
	$(".f_wider").removeClass("f_wider");
}

function openpop(title,wider){
    var w=wider||0;
    $(".f_outer h3").html(title);
    if(!wider) $(".f_outer").show().css({left:"30%",top:"10%"});
    else{
        $(".f_outer").show().css({left:"20%",top:"10%"});
        $(".f_content").add(".f_bgc").addClass("f_wider");
    }
    $("#bgopacity").show();
}