<%@ Control Language="C#" AutoEventWireup="true" CodeFile="login_index.ascx.cs" Inherits="Controls_login_index" %>
					<!--登录开始-->
					<asp:Panel ID="pnlnotlogin" runat="server" CssClass="notlog">
						    <table border="0">
                                <tr><td>用户名：</td><td><asp:TextBox runat="server" type="text" name="username" id="txtUser" value="" maxlength="20" class="logtxt"></asp:TextBox></td></tr>
							    <tr><td>密码：</td><td><asp:TextBox runat="server" TextMode="Password" ID="txtPass" MaxLength="20" class="logtxt"></asp:TextBox></td></tr>
    							
							    <tr><td>验证码：</td><td><asp:TextBox runat="server" ID="txtCode" MaxLength="4" CssClass="logvcode"></asp:TextBox><img src="/checkcode.aspx?t=1" alt="点此更换图片" class="vcodeimg" onclick="this.src+=1" /></td></tr>
						    </table>
						   <div class="logbtn"><asp:Button ID="btnsubmit" Text="登&nbsp;录" runat="server" OnClick="btn_login" /><a href="/register.aspx">注&nbsp;册</a></div>
						   <div style="text-align:center; padding-top:8px;"><asp:Label runat="server" ID="lblLoginMessage" ForeColor="Red" Visible="false"></asp:Label></div>
					</asp:Panel>
					<!--登录结束-->
					<asp:Panel ID="pnllogin" CssClass="loged" runat="server">
						<p>尊敬的客户，欢迎您！</p>
						<p>您的姓名：<asp:Label CssClass="lboxspan1" runat="server" ID="lblname"></asp:Label></p>
						<p>您的账户余额：<asp:Label CssClass="lboxspan2" runat="server" ID="lblbank"></asp:Label></p>
						<p>上次登录：<asp:Label ID="lbllast" runat="server" CssClass="timespan"></asp:Label></p>
						<div class="logbtn">
						<a href="/member/default.aspx">个人中心</a>
						<asp:Button ID="btnlogout" Text="退&nbsp;出" runat="server" OnClick="btn_logout" /></div>
					</asp:Panel>
