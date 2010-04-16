window.addEvent("domready",function(){
$("btnLogin").addEvent("click",function(e){
                
           /**
	     * Prevent the submit event
	     */
	       new Event(e).stop();
	
              if($('acc').value=='')
                   {
                      $('msg').innerHTML="用戶名不能為空!";
                      $('acc').focus();
                      return false;
                   }
                    if($('psd').value=='')
                   {
                      $('msg').innerHTML="密碼不能為空!";
                      $('psd').focus();
                      return false;
                   }
                   
                   $('msg').innerHTML="系統正在驗證之中,請稍侯....!";
                   
                   var url='Controls/Ajax.aspx?action=sign&'+Object.toQueryString({acc:$('acc').value,passwd:$('psd').value});
                  
                   new Ajax(url,{method: 'post',
                   onComplete:function(){
                          var msg=this.response.text;
                          //var msg=xhr.transport.responseText ;
                          switch(msg)
                          {
                             case "0":
                               window.location.href="main.html";
                               break;
                             case "1":
                              $('msg').innerHTML="用戶名不存在!";
                              break;
                              case "2":
                               $('msg').innerHTML="用戶密碼錯誤!";
                              break;
                          }
                    }
                   }).request();

        });
});

window.addEvent("load",function(){
    if (top.location != location){
		top.location.href = "/login.html";
	}
});


