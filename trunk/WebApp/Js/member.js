//coding=utf-8
$(function(){
	//菜单操作
	$("dt").click(function(){
		var thisdd=$(this).parent("dl").children("dd");
		$("dd").not(thisdd).slideUp();
		thisdd.slideToggle();
	});
});