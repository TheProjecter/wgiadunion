using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using wgiAdUnionSystem.BLL;

public partial class syslogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
  
    protected void imgBtn_Click(object sender, EventArgs e)
    {
        if (Session["CheckCode"] == null)
        {
            return;
        }
        if (Session["CheckCode"].ToString().ToLower().Equals(txtCode.Value.ToLower()))
        {
            UserPrincipal principal = new UserPrincipal(txtUserName.Value, txtPass.Value);

            if (!principal.Identity.IsAuthenticated)
            {
                switch (principal.CheckStatus)
                {
                    case 1:

                        lblmsg.Text = "用户名不正确！";
                        break;
                    case 2:
                        lblmsg.Text = "用户名密码错误！";
                        break;
                    case 3:
                        lblmsg.Text = "你的用户状态已被锁定！";
                        break;
                }
            }

            else
            {

                // 如果用户通过验证,则将用户信息保存在缓存中,以备后用

                // 在实际中,朋友们可以尝试使用用户验证票的方式来保存用户信息,这也是.NET内置的用户处理机制

                Context.User = principal;

                FlowControl.SaveLoginInfo(principal.Identity.Name, "123,450");

                Response.Redirect("index.html");

            }
        }
        else
        {
            lblmsg.Text = "输入验证码错误！";
        }
    }
}
