using System;
using System.Web.UI;
using System.Collections;
using wgiAdUnionSystem.BLL;

/// <summary>
/// ValidatePage 的摘要说明
/// </summary>
//public class validateMember : System.Web.UI.Page
public class validateMember : System.Web.UI.UserControl
{
    protected UserPrincipal principal;
    private string[] userdata = new string[1] { "" };//用户数据
    private wgiAdUnionSystem.Model.wgi_sitehost _suser = new wgiAdUnionSystem.Model.wgi_sitehost();
    
    private bool _nocheck = false;//表示该页需不需要登录验证

    public bool nocheck {
        get { return _nocheck; }
        set { _nocheck=value;}
    }
    public wgiAdUnionSystem.Model.wgi_sitehost suser {
        get { return _suser; }
        set { _suser = value; }
    }

    public validateMember()
    {
        if (Context.User.Identity.IsAuthenticated)
        {
            if (!(Context.User is UserPrincipal))
            {
                principal = new UserPrincipal(Context.User.Identity.Name);

                //用户数据
                try
                {
                    userdata = Helper.HelperSession.GetAuthenticatedUserData("|");
                    suser.userid = int.Parse(userdata[1]);
                    suser.username = userdata[2];
                    suser.lastdate = Convert.ToDateTime(userdata[3]);//上次登录时间
                    suser.accountname = userdata[4];
                    suser.balance = decimal.Parse(userdata[5]);
                }
                catch (Exception)
                {
                    //_timeout = false;  //在这里标记用户已超时，刷新页面时通过这个参数获取登录状态
                    //OnInit(null);
                }
                finally { }

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
        //
        if (!Context.User.Identity.IsAuthenticated&&!nocheck)
        {
            //Response.Redirect(@"~/SysLogin.aspx?url="+Helper.HelperURL.GetCurrentUrl(this));
            Response.Redirect(@"~/member/Default.aspx?url=" + Request.CurrentExecutionFilePath);
            Response.End();
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
