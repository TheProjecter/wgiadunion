using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class cookie : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["siteid"] == null || Request["union"] == null || Request["url"] == null || Request["shopid"] == null || Request["userid"] == null) return;

        //step2:广告商处理逻辑，将贡献者网站和id保存
        string siteid = Request["siteid"];
        string union = Request["union"];
        string shopid = Request["shopid"];
        string userid = Request["userid"];

        //写入本站cookie
        //string userdata = "union=" + union + "|shopid=" + shopid + "|siteid=" + siteid;
        string userdata = union + "|" + shopid + "|" + siteid + "|" + userid;

        //加密保存
        //FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1,"siteuser",System.DateTime.Now,DateTime.Now.AddMonths(1),true,userdata);
        //string entrcyedTicket = FormsAuthentication.Encrypt(authTicket);

        //HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, entrcyedTicket);

        //普通保存
        HttpCookie authCookie = new HttpCookie("adunioncookie", userdata);
        authCookie.Expires = DateTime.Now.AddMonths(1);

        HttpContext.Current.Response.Cookies.Add(authCookie);

        //取出最终的广告页面地址
        string url = Request["url"];

        Response.Redirect(url);
        //Response.Redirect("/member/default.aspx");
    }
}
