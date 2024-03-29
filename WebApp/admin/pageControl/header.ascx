﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="header.ascx.cs" Inherits="admin_pageControl_header" %>
	    <!--顶级菜单开始-->
      <div id="header">
        <div id="logpanel">
            您好，<asp:Label ID="lblusername" runat="server"></asp:Label>，欢迎登录&nbsp;
            [<asp:LinkButton ID="lbtnlogout" runat="server" Text="退出" OnClick="logout_click"></asp:LinkButton>]
        </div>
        	<h2>广告联盟管理后台</h2>
            <div id="topmenu">
            	<ul>
                	<li<asp:Literal ID="menu1" runat="server"></asp:Literal>><a href="Default.aspx">控制面板</a></li>
                    <li<asp:Literal ID="menu2" runat="server"></asp:Literal>><a href="Finace.aspx">财务管理</a></li>
                	<li<asp:Literal ID="menu3" runat="server"></asp:Literal>><a href="Users.aspx">用户管理</a></li>
                    <li<asp:Literal ID="menu4" runat="server"></asp:Literal>><a href="Notice.aspx">内容管理</a></li>
                    <li<asp:Literal ID="menu5" runat="server"></asp:Literal>><a href="logs.aspx">日志维护</a></li>
                    <li<asp:Literal ID="menu6" runat="server"></asp:Literal>><a href="beckup.aspx">数据备份</a></li>
                    <li<asp:Literal ID="menu7" runat="server"></asp:Literal>><a href="setup.aspx">系统设置</a></li>
              </ul>
          </div>
      </div>
	    <!--顶级菜单结束-->
        <!--子菜单开始-->
      <div id="top-panel">
            <div id="panel">
                <asp:PlaceHolder id="subMenu1" runat="server" Visible="false">
                    <ul class="submenu1">
                        <li><a href="#" class="report">Sales Report</a></li>
                        <li><a href="#" class="report_seo">SEO Report</a></li>
                        <li><a href="#" class="search">Search</a></li>
                        <li><a href="#" class="feed">RSS Feed</a></li>
                    </ul>
                </asp:PlaceHolder>
                <asp:PlaceHolder id="subMenu2" runat="server" Visible="false">
                    <ul class="submenu2">
                        <li><a href="Finace.aspx" class="report">提现申请</a></li>
                        <li><a href="#" class="report_seo">发放佣金</a></li>
                        <li><a href="#" class="search">佣金历史</a></li>
                        <li><a href="#" class="search">丢单申请</a></li>
                        <li><a href="#" class="feed">发放补偿</a></li>
                    </ul>
                </asp:PlaceHolder>
                <asp:PlaceHolder id="subMenu3" runat="server" Visible="false">
                    <ul class="submenu3">
                        <li><a href="Users.aspx" class="group">管理员管理</a></li>
                        <li><a href="siteUsers.aspx" class="group">网站主管理</a></li>
                        <li><a href="AdUser.aspx" class="group">广告主管理</a></li>
					    <li><a href="#adduser" class="useradd">Add user</a></li>
            		    <li><a href="#" class="search">Find user</a></li>
                        <li><a href="#" class="online">Users online</a></li>
                    </ul>
                </asp:PlaceHolder>
                <asp:PlaceHolder id="subMenu4" runat="server" Visible="false">
                    <ul class="submenu4">
                        <li><a href="Notice.aspx" class="report">公告管理</a></li>
                        <li><a href="Message.aspx" class="report_seo">站内信管理</a></li>
                        <li><a href="UnionInfo.aspx" class="report">联盟介绍管理</a></li>
                    </ul>
                </asp:PlaceHolder>
                <asp:PlaceHolder id="subMenu5" runat="server" Visible="false">
                    <ul class="submenu5">
                        <li><a href="#" class="report">广告主操作日志</a></li>
                        <li><a href="#" class="report_seo">网站主操作日志</a></li>
                        <li><a href="#" class="search">Search</a></li>
                        <li><a href="#" class="feed">RSS Feed</a></li>
                    </ul>
                </asp:PlaceHolder>
                <asp:PlaceHolder id="subMenu6" runat="server" Visible="false">
                    <ul class="submenu6">
                        <li><a href="#" class="report_seo">数据备份</a></li>
                    </ul>
                </asp:PlaceHolder>
                <asp:PlaceHolder id="subMenu7" runat="server" Visible="false">
                    <ul class="submenu7">
                        <li><a href="#" class="report">文章管理</a></li>
                        <li><a href="#" class="report_seo">文章类别管理</a></li>
                        <li><a href="#" class="search">广告类别管理</a></li>
                        <li><a href="#" class="feed">基础设置</a></li>
                        <li><a href="#" class="feed">更改密码</a></li>
                    </ul>
                </asp:PlaceHolder>
                
                
            </div>
      </div>
        <!--子菜单结束-->