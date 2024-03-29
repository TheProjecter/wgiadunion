﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wgiAdUnionSystem.BLL;
using System.Web.UI;

/// <summary>
///广告主用户验证页
/// </summary>
public class advertiserPage:System.Web.UI.Page
{
    protected UserPrincipal principal;
    protected int companyid=1;//广告主用户ID

    public advertiserPage()
    {
        if (Context.User.Identity.IsAuthenticated)
        {
            if (!(Context.User is UserPrincipal))
            {
                principal = new UserPrincipal(User.Identity.Name);

                //用户数据
                string[] userdata = Helper.HelperSession.GetAuthenticatedUserData(",");

                Context.User = principal;
            
            }
        }
    }
 

    protected override void OnInit(EventArgs e)
    {

        base.OnInit(e);

        this.Load += new EventHandler(ValidatePage_Load);

    }

    //在页面加载的时候从缓存中提取用户信息

    private void ValidatePage_Load(object sender, System.EventArgs e)
    {
        if (!Context.User.Identity.IsAuthenticated)
        {
            //Response.Redirect(@"~/SysLogin.aspx?url="+Helper.HelperURL.GetCurrentUrl(this));
           // Response.Redirect(@"~/SysLogin.aspx?url="+Request.CurrentExecutionFilePath);
          //  Response.End();
        }

    }

    protected void SendMessage(string inputstr, UpdatePanel control)
    {
        System.Web.UI.ScriptManager.RegisterStartupScript(control, GetType(), DateTime.Now.ToString(), inputstr, true);
    }

    protected void SendMessage(string inputstr)
    {
        ClientScriptManager cm = Page.ClientScript;
        cm.RegisterStartupScript(GetType(), DateTime.Now.ToString(), inputstr);
    }

    [System.Web.Services.WebMethod]
    public static string DoSignOut(string usertype)
    {
        FlowControl.Logout();

        return "../SysLogin.aspx?type="+usertype;
        
    }
}
