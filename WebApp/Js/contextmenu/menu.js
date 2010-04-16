/**
 * author: yswang
 * version: 1.2
 * date: 2008-08-15
 * mail: [email]wangys0927@163.com[/email]
 */
 
// 获取对象
function $o(id){return document.getElementById(id);	}
// 获取目标元素
function getElement(evt){ evt = evt ||window.event; return (evt.srcElement || evt.target);}
// 鼠标X坐标
function positionX(evt){evt = evt || window.event; return (evt.x || evt.clientX || evt.pageX);}
// 鼠标Y坐标
function positionY(evt){evt = evt || window.event; return (evt.y || evt.clientY || evt.pageY);}
// 清除事件冒泡和传递影响
function clearEventBubble(evt){
   evt = evt || window.event;
   if(evt.stopPropagation) evt.stopPropagation(); else  evt.cancelBubble = true; 
   if(evt.preventDefault) evt.preventDefault(); else evt.returnValue = false;
} 
// 事件绑定
function addEvent(actionEvents,eventObj){
	 eventObj = eventObj || document;
	 if(window.attachEvent){
	 	  for(var actionType in actionEvents){
	 	    eventObj.attachEvent("on"+actionType,actionEvents[actionType]); 
	 	  }
	 	}
   if(window.addEventListener){
   	 for(var actionType in actionEvents){
   	   eventObj.addEventListener(actionType,actionEvents[actionType],false);	
   	 }
   }
}

document.oncontextmenu = function(){return false;	}

// 右键菜单
function contextMenu(initProps,bindingEvents){
	this._contextMenu = null;                            // 右键菜单体
	this._contextMenuId = initProps["contextMenuId"];    // 待加载右键菜单的对象
	this._targetElement = initProps["targetElement"];    // 右键菜单目标
	this._funcEvents = bindingEvents.bindings;          // 绑定的事件配置信息
	this._menuItems = null;                             // 菜单项
	// 浏览器类型判断
	this._isIE = function(){return navigator.userAgent.toLowerCase().indexOf("msie")!=-1 && document.all};
}

// 初始化右键菜单功能
contextMenu.prototype.buildContextMenu = function(){
	
	// 获取菜单对象
	this._contextMenu = $o(this._contextMenuId);
        this._contextMenu.style.top ="-1000px";
        this._contextMenu.style.left="-1000px";
	this._contextMenu.style.display = "none";
        // 阻止菜单的点击事件上传到document.onclick事件上
       this._contextMenu.onclick = function(evt){
             clearEventBubble(evt);
       }

	// 初始化样式菜单项
	this._menuItems = this._contextMenu.getElementsByTagName("ul")[0].getElementsByTagName("li");
	 for(var i in this._menuItems){
  		if(this._menuItems[i].className != "separator"){
  			 this._menuItems[i].className = "item";
	  		 this._menuItems[i].onmouseover = function(){this.className ="item itemOver";};
	  		 this._menuItems[i].onmouseout = function(){this.className = "item";}	
  	    }
	  }
	  
	var _self = this;
	
	addEvent({
		"contextmenu":function(){
			 var evt = window.event||arguments[0];
			 _self.showContextMenu(evt);
			 evt = null;
		},
		"click":function(){
				_self.hideContextMenu();
			}
	},document);

}

contextMenu.prototype.addFunc = function(funcId,funcEle){
		this._funcEvents[funcId](funcEle);
}

// 显示右键菜单
contextMenu.prototype.showContextMenu = function(evt){
	try{
		  var _cmenuObj = this._contextMenu;
		  var _focusEle = getElement(evt);
		  var _items = this._menuItems;
		  var _self = this;
      if(_focusEle.className == this._targetElement){
      	// 绑定菜单项点击事件
		  	 for(var j in _items){
		  		  if(_items[j].id && _items[j].className != "separator"){
			  		   _items[j].onclick = function(){_self.addFunc(this.id,_focusEle); _self.hideContextMenu(); };
		  	    }
		  	 }
      	
      	_cmenuObj.style.display = "block";
      	
      	var _px = positionX(evt);
      	var _py = positionY(evt);
      	var _bodyWidth = parseInt(document.body.offsetWidth ||document.body.clientWidth);
			  var _bodyHeight = parseInt(document.body.offsetHeight || document.body.clientHeight);
			  var _mWidth = parseInt( _cmenuObj.offsetWidth || _cmenuObj.style.width);
			  var _mHeight = parseInt(_cmenuObj.offsetHeight);
		  	
				_cmenuObj.style.left = ((_px + _mWidth) > _bodyWidth?(_px - _mWidth):_px) +"px";
				_cmenuObj.style.top  = ((_py + _mHeight) > _bodyHeight?(_py - _mHeight):_py) +"px";
      	
      	// ie 下创建背景遮盖层
      	if(this._isIE){
      		_self.createIframeBg({
      			  "left"   : _cmenuObj.style.left,
      			  "top"    : _cmenuObj.style.top,
      			  "width"  : _mWidth +"px",
      			  "height" : _mHeight+"px",
      			  "z-index": (parseInt(_cmenuObj.style.zIndex)-1)
      			});
      	}
      		
        _px = null,_py = null,_bodyWidth = null,_bodyHeight = null,_mWidth = null,_mHeight = null;
      }else{
      		this.hideContextMenu();
      }
		
	}catch(e){
   }finally{
   	_items = null;
   	_srcEle = null;
   	_cmenuObj = null;
	}
	
}

// 隐藏右键菜单
contextMenu.prototype.hideContextMenu = function(){
	// 移除在 ie 下创建 iframe背景层
	if(this._isIE && $o("maskIframe")){
		 document.body.removeChild($o("maskIframe"));	
	}
	// 隐藏菜单
	if(this._contextMenu && this._contextMenu.style.display != "none"){
	  this._contextMenu.style.display = "none";
	}
		
}

// ie 下为右键菜单添加 iframe背景层，用来遮住 select
contextMenu.prototype.createIframeBg = function(styleProp){
	var maskStyle = "position:absolute;left:"+styleProp["left"]+";top:"+styleProp["top"]+";width:"+styleProp["width"]+";height:"+styleProp["height"]+";z-index:"+styleProp["z-index"];

	if($o("maskIframe")){
		$o("maskIframe").style.cssText = maskStyle;
	}else{
		var _maskIframeBg = document.createElement("<iframe id=\"maskIframe\" src=\"\" frameborder='0' border='0' scrolling=\"no\"></iframe>");
		document.body.appendChild(_maskIframeBg);
    _maskIframeBg.style.cssText = maskStyle;
		_maskIframeBg = null;
  }
  maskStyle = null;
}

