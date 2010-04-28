//coding=utf-8;
$(function(){
    var ox;
    var oy;
    var flag=false;
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
}

function openpop(title){
    $(".f_outer h3").html(title);
    $(".f_outer").show().css({left:"30%",top:"10%"});
    $("#bgopacity").show();
}