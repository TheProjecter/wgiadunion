using System;
using System.Web.UI;
using System.Collections;
using wgiAdUnionSystem.BLL;

/// <summary>
/// ValidatePage 的摘要说明
/// </summary>
public class ValidatePage : System.Web.UI.Page
{
    protected UserPrincipal principal;
    private string[] userdata = new string[1] { "" };//用户数据
    private wgiAdUnionSystem.Model.wgi_sysuser suser = new wgiAdUnionSystem.Model.wgi_sysuser();

    public wgiAdUnionSystem.Model.wgi_sysuser user
    {
        get { return suser; }
        set { suser = value; }
    }

    public ValidatePage()
    {
        if (Context.User.Identity.IsAuthenticated)
        {
            userdata = Helper.HelperSession.GetAuthenticatedUserData("|");

            if (!(Context.User is UserPrincipal))
            {
                principal = new UserPrincipal(User.Identity.Name);

                //用户数据
                try
                {
                    suser.id = int.Parse(userdata[1]);
                    suser.username = userdata[2];
                    suser.email = userdata[3];
                }
                catch (Exception)
                {
                    //throw:
                }

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
            Response.Redirect(@"~/admin/login.aspx?url=" + Request.CurrentExecutionFilePath);
            Response.End();
        }
        if (userdata[0] != "admin")
        {
            try
            {
                FlowControl.Logout();
            }
            catch (Exception)
            {
                //throw;
            }
            finally
            {
                Response.Redirect(@"~/admin/login.aspx?url=" + Request.CurrentExecutionFilePath);
                Response.End();
            }
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
