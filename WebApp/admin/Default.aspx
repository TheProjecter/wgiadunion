<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_Default" %>

<%@ Register src="pageControl/dashboard.ascx" tagname="dashboard" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Dashboard - Admin Template</title>
<link rel="stylesheet" type="text/css" href="css/theme.css" />
<link rel="stylesheet" type="text/css" href="css/style.css" />
<script type="text/javascript">
   var StyleFile = "theme" + document.cookie.charAt(6) + ".css";
   document.writeln('<link rel="stylesheet" type="text/css" href="css/' + StyleFile + '">');
</script>
<!--[if IE]>
<link rel="stylesheet" type="text/css" href="css/ie-sucks.css" />
<![endif]-->
</head>
<body>
    <form id="form1" runat="server">
<!--内容区开始-->
	<div id="container">
	  <!--头部开始-->
	    <!--顶级菜单开始-->
      <div id="header">
        	<h2>广告联盟管理后台</h2>
            <div id="topmenu">
            	<ul>
                	<li class="current"><a href="index.html">控制面板</a></li>
                    <li><a href="#">财务管理</a></li>
                	<li><a href="users.html">用户管理</a></li>
                    <li><a href="#">丢单申请</a></li>
                    <li><a href="#">日志维护</a></li>
                    <li><a href="#">数据备份</a></li>
                    <li><a href="#">系统设置</a></li>
              </ul>
          </div>
      </div>
	    <!--顶级菜单结束-->
        <!--子菜单开始-->
      <div id="top-panel">
            <div id="panel">
                <ul>
                    <li><a href="#" class="report">Sales Report</a></li>
                    <li><a href="#" class="report_seo">SEO Report</a></li>
                    <li><a href="#" class="search">Search</a></li>
                    <li><a href="#" class="feed">RSS Feed</a></li>
                </ul>
            </div>
      </div>
        <!--子菜单结束-->
	  <!--头部结束-->
      <!--主内容区容器开始-->
        <div id="wrapper">
            <!--左内容区开始-->
            <asp:PlaceHolder runat="server" ID="holder"></asp:PlaceHolder>
            <!--左内容区结束-->
            <!--侧面板开始-->
            <div id="sidebar">
  				<ul>
                	<li><h3><a href="#" class="house">控制面板</a></h3>
                        <ul>
                        	<li><a href="#" class="report">Sales Report</a></li>
                    		<li><a href="#" class="report_seo">SEO Report</a></li>
                            <li><a href="#" class="search">Search</a></li>
                        </ul>
                    </li>
                    <li><h3><a href="#" class="folder_table">佣金管理</a></h3>
          				<ul>
                        	<li><a href="#" class="addorder">New order</a></li>
                          <li><a href="#" class="shipping">Shipments</a></li>
                            <li><a href="#" class="invoices">Invoices</a></li>
                        </ul>
                    </li>
                    <li><h3><a href="#" class="manage">系统设置</a></h3>
          				<ul>
                            <li><a href="#" class="manage_page">Pages</a></li>
                            <li><a href="#" class="cart">Products</a></li>
                            <li><a href="#" class="folder">Product categories</a></li>
            				<li><a href="#" class="promotions">Promotions</a></li>
                        </ul>
                    </li>
                  <li><h3><a href="#" class="user">用户管理</a></h3>
          				<ul>
                            <li><a href="#" class="useradd">Add user</a></li>
                            <li><a href="#" class="group">User groups</a></li>
            				<li><a href="#" class="search">Find user</a></li>
                            <li><a href="#" class="online">Users online</a></li>
                        </ul>
                    </li>
				</ul>       
          </div>
          
            <!--侧面板结束-->
      </div>
      <!--主内容区容器结束-->
      
      
        <!--脚部开始-->
        <div id="footer">
        
        <!--权版开始-->
        <div id="credits">
   		Template by <a href="http://www.bloganje.com">Bloganje</a>
        </div>
        <!--版权结束-->
        <!--主题切换区域开始-->
        <div id="styleswitcher">
            <ul>
                <li><a href="javascript: document.cookie='theme='; window.location.reload();" title="Default" id="mixswitch">m</a></li>
                <li><a href="javascript: document.cookie='theme=4'; window.location.reload();" title="Red" id="defswitch">d</a></li>
                <li><a href="javascript: document.cookie='theme=1'; window.location.reload();" title="Blue" id="blueswitch">b</a></li>
                <li><a href="javascript: document.cookie='theme=2'; window.location.reload();" title="Green" id="greenswitch">g</a></li>
                <li><a href="javascript: document.cookie='theme=3'; window.location.reload();" title="Brown" id="brownswitch">b</a></li>
                <li><a href="javascript: document.cookie='theme=5'; window.location.reload();" title="Mix" id="defswitch">m</a></li>
            </ul>
        </div>
        <!--主题切换区域结束-->
        <br />

        </div>
        
        <!--脚部结束-->
</div>
<!--内容区结束-->
    </form>
</body>
</html>
