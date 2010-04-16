using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using wgiAdUnionSystem.BLL;

public partial class Login : Page
{
    //protected void Page_Load(object sender, EventArgs e)
    //{
        
    //}
    //protected void Page_LoadComplete(object sender, EventArgs e)
    //{
    //    if (Session["CheckCode"] != null)
    //    {
    //        txtCode.Text = Session["CheckCode"].ToString();
    //    }
    //}
    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    if (Session["CheckCode"] == null)
    //    {
        //    return;
        //}
        //if (Session["CheckCode"].ToString().ToLower().Equals(txtCode.Text.ToLower()))
        //{
        //    UserPrincipal principal = new UserPrincipal(txtUser.Text, txtPass.Text);

        //    if (!principal.Identity.IsAuthenticated)
        //    {
        //        switch (principal.CheckStatus)
        //        {
        //            case 1:
        //                lblLoginMessage.Text = "用户名不正确！";
        //                break;
        //            case 2:
        //                lblLoginMessage.Text = "用户名密码错误！";
        //                break;
        //            case 3:
        //                lblLoginMessage.Text = "你的用户状态已被锁定！";
        //                break;
        //        }
        //    }

        //    else
        //    {

                // 如果用户通过验证,则将用户信息保存在缓存中,以备后用

                // 在实际中,朋友们可以尝试使用用户验证票的方式来保存用户信息,这也是.NET内置的用户处理机制

                //Context.User = principal;

                //FlowControl.SaveLoginInfo(principal.Identity.Name, "123,450");

                //Response.Redirect("Default.aspx");

        //    }
        //}
        //else
        //{
        //    lblLoginMessage.Text = "输入验证码错误！";
        //}
    //}
}
