using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Threading;

/// <summary>
/// BasePage 的摘要说明
/// </summary>
public class BasePage : System.Web.UI.Page
{
    /// <summary>
    /// 配置选择语言
    /// </summary>
    protected override void InitializeCulture()
    {

        CurrentLanguage s = (CurrentLanguage)Context.Profile.GetPropertyValue("CurrentLanguage");
        if (!String.IsNullOrEmpty(s.Currlanguage) && (s.Currlanguage != "Auto"))
        {
            //UICulture - 决定了采用哪一种本地化资源，也就是使用哪种语言
            //Culture - 决定各种数据类型是如何组织，如数字与日期
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(s.Currlanguage);
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(s.Currlanguage);
        }

    }

    protected override void OnPreInit(EventArgs e)
    {
        CurrentLanguage s = (CurrentLanguage)Context.Profile.GetPropertyValue("CurrentLanguage");
        if (!string.IsNullOrEmpty(s.Currlanguage) && s.Currlanguage != "Auto")
        {
            this.Theme = s.Currlanguage;
           // this.Title = "Demo程序测试";       
        }

        //this.MasterPageFile = @"~/LeftCommon.master";
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
}
