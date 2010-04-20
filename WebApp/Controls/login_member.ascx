<%@ Control Language="C#" AutoEventWireup="true" CodeFile="login_member.ascx.cs" Inherits="Controls_login_member" %>
<asp:ScriptManager ID="ajaxscm" runat="server"></asp:ScriptManager>
			<div class="loginbox">
				<h3>联盟会员登录</h3>
				<div class="mbmbox">
				<asp:UpdatePanel ID="updarea" runat="server">
				    <ContentTemplate>
				        
					<!--登录开始--->
					<asp:Panel id="pnlnotlogin" runat="server" Visible="true">
						<table border="0">
							<tr><td>用户名：</td><td><asp:TextBox runat="server" type="text" name="username" id="txtUser" value="" maxlength="20" class="logtxt"></asp:TextBox></td></tr>
							<tr><td>密码：</td><td><asp:TextBox runat="server" TextMode="Password" ID="txtPass" MaxLength="20" class="logtxt"></asp:TextBox></td></tr>
							
							<tr><td>验证码：</td><td><asp:TextBox type="text" runat="server" name="vcode" id="txtCode" value="" maxlength="4" class="logvcode"></asp:TextBox><img src="/checkcode.aspx?t=1" alt="点此更换图片" class="vcodeimg" onclick="this.src+=1" /></td></tr>
						</table>
						<div class="logbtn"><asp:Button ID="btnsubmit" Text="登&nbsp;录" runat="server" OnClick="btn_login" /><a href="/register.aspx">注&nbsp;册</a></div>
					<div style="text-align:center; padding-top:8px;"><asp:Label runat="server" ID="lblLoginMessage" ForeColor="Red" Visible="false"></asp:Label></div>
					</asp:Panel>
					<!--登录结束-->
					<!--已登录box开始-->
					<asp:Panel id="pnllogin" runat="server" Visible="false">
						<p>尊敬的<asp:Label CssClass="lboxspan1" runat="server" ID="lbluname"></asp:Label>，欢迎您！</p>
						<p>您的姓名：<asp:Label CssClass="lboxspan1" runat="server" ID="lblname"></asp:Label></p>
						<p>您的账户余额：<asp:Label CssClass="lboxspan2" runat="server" ID="lblbank"></asp:Label></p>
						<p>上次登录：<asp:Label ID="lbllast" runat="server" CssClass="timespan"></asp:Label></p>
						<div class="logbtn"><asp:Button ID="btnlogout" Text="退&nbsp;出" runat="server" OnClick="btn_logout" /></div>
					</asp:Panel>
					<!--已登录box结束-->
				    </ContentTemplate>
				</asp:UpdatePanel>
				</div>
			</div>