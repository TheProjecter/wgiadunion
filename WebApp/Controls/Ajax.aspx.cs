using System;
using System.Data;

using wgiAdUnionSystem.BLL;
using Helper;

public partial class Controls_Ajax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request["action"];

        switch (action)
        {
            case "sign":
                DoLogin(Request["acc"], Request["passwd"]);//登錄
                break;        
            case "logout":
                DoLogout();
                break;
        }
    }

    private void DoLogin(string acc, string psd)
    {
        Response.ContentType = "text/html";
        Response.Clear();
        string msgcode = "-1";
        string userid = "-1";
        string usertype = "-1";
        //if (BUser.ProcessLogin(acc, psd, out msgcode, out userid, ref usertype))
        //{
        //    FlowControl.SaveLoginInfo(userid, usertype);
        //}
        Response.Write(msgcode);
        Response.End();
    }

    private void DoLogout()
    {
        Response.ContentType = "text/html";
        Response.Clear();
        int usertype = 0;// HelperSession.GetAuthenticatedUserType();
        string msg = "-1";
        if (usertype == 1 || usertype == 2)
        {
            msg = "0";
        }
        else if (usertype == 3)
        {
            msg = "1";
        }
        FlowControl.Logout();
        Response.Write(msg);
        Response.End();
    }
}
