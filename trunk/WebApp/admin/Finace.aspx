<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Finace.aspx.cs" Inherits="admin_Finace" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<asp:PlaceHolder ID="plhdTitle" runat="server"></asp:PlaceHolder>
</head>
<body>
    <form id="form" runat="server">

<!--内容区开始-->
	<div id="container">
	  <!--头部开始-->
      <asp:PlaceHolder ID="plhdHeader" runat="server"></asp:PlaceHolder>
	  <!--头部结束-->
      <!--主内容区容器开始-->
        <div id="wrapper">
            <!--左内容区开始-->
            <div id="content">
       			<div id="rightnow">
                    <h3 class="reallynow">
                        <span>操作区</span>
                        <a href="#" class="add">Add New Product</a>
                        <a href="#" class="app_add">Some Action</a>
                        <br />
                    </h3>
				    <p class="youhave">You have <a href="#">19 new orders</a>, <a href="#">12 new users</a> and <a href="#">5 new reviews</a>, today you made <a href="#">$1523.63 in sales</a> and a total of <strong>$328.24 profit </strong>
                    </p>
			  </div>
              <div id="box">
                内容区
              </div>
            </div>
            <!--左内容区结束-->
            <!--侧面板开始-->
            <asp:PlaceHolder ID="plhdSlide" runat="server"></asp:PlaceHolder>
            <!--侧面板结束-->
      </div>
      <!--主内容区容器结束-->
      
        <!--脚部开始-->
        <asp:PlaceHolder ID="plhdFooter" runat="server"></asp:PlaceHolder>
        <!--脚部结束-->
</div>
<!--内容区结束-->

    </form>
</body>
</html>
